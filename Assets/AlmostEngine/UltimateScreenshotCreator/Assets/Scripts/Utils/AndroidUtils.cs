#if UNITY_ANDROID

using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



using AlmostEngine.Examples;

namespace AlmostEngine.Screenshot
{
	public class AndroidUtils
	{

		public static string GetExternalPictureDirectory()
		{
			if (IsPrimaryStorageAvailable()) {
				return GetPrimaryStorage() + "/" + AndroidUtils.GetPictureFolder();
			} else {
				return GetFirstAvailableMediaStorage();
			}
		}

		public static bool IsPrimaryStorageAvailable()
		{
			try {
				AndroidJavaClass environment = new AndroidJavaClass("android.os.Environment");
				IntPtr getExternalStorageStateMethod = AndroidJNI.GetStaticMethodID(environment.GetRawClass(), "getExternalStorageState", "()Ljava/lang/String;");
				IntPtr statePtr = AndroidJNI.CallStaticObjectMethod(environment.GetRawClass(), getExternalStorageStateMethod, new jvalue[] { });
				string state = AndroidJNI.GetStringUTFChars(statePtr);
				AndroidJNI.DeleteLocalRef(statePtr);

				if (state == "mounted")
					return true;
								
			} catch (System.Exception e) {
				Debug.LogError("AndroidUtils: Error getting external storage state: " + e.Message);
			}
			return false;
		}

		public static string GetPrimaryStorage()
		{
			try {
				AndroidJavaClass environment = new AndroidJavaClass("android.os.Environment");
				IntPtr getExternalStorageDirectoryMethod = AndroidJNI.GetStaticMethodID(environment.GetRawClass(), "getExternalStorageDirectory", "()Ljava/io/File;");
				IntPtr filePtr = AndroidJNI.CallStaticObjectMethod(environment.GetRawClass(), getExternalStorageDirectoryMethod, new jvalue[] { });
				IntPtr getPathMethod = AndroidJNI.GetMethodID(AndroidJNI.GetObjectClass(filePtr), "getPath", "()Ljava/lang/String;");
				IntPtr pathPtr = AndroidJNI.CallObjectMethod(filePtr, getPathMethod, new jvalue[] { });
				string path = AndroidJNI.GetStringUTFChars(pathPtr);
				AndroidJNI.DeleteLocalRef(filePtr);
				AndroidJNI.DeleteLocalRef(pathPtr);

				return path;

			} catch (System.Exception e) {
				Debug.LogError("AndroidUtils: Error getting primary external storage directory: " + e.Message);
			}
			return "";
		}


		public static string GetFirstAvailableMediaStorage()
		{
			List<string> secondaryStorages = GetAvailableSecondaryStorages();
			if (secondaryStorages.Count > 0)
				return secondaryStorages[0];

			// Fallback
			Debug.LogWarning("No media storage available, using persistentDataPath as fallback");
			return Application.persistentDataPath;

		}

		/// <summary>
		/// Gets all secondary storages and return only available ones.
		/// </summary>
		public static List<string> GetAvailableSecondaryStorages()
		{

			List<string> storages = new List<string>();


			try {
				// Get methods
				AndroidJavaClass classPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
				AndroidJavaObject objActivity = classPlayer.GetStatic<AndroidJavaObject>("currentActivity");
				IntPtr obj_context = AndroidJNI.FindClass("android/content/ContextWrapper");
				IntPtr getExternalMediaDirsMethod = AndroidJNIHelper.GetMethodID(obj_context, "getExternalMediaDirs", "()[Ljava/io/File;");

				// Get files array
				IntPtr filesPtr = AndroidJNI.CallObjectMethod(objActivity.GetRawObject(), getExternalMediaDirsMethod, new jvalue[0]);

				// Get files from array
				IntPtr[] files = AndroidJNI.FromObjectArray(filesPtr);

				// Parse files
				for (int i = 0; i < files.Length; ++i) {
					
					// Get file path
					IntPtr getPathMethod = AndroidJNI.GetMethodID(AndroidJNI.GetObjectClass(files[i]), "getPath", "()Ljava/lang/String;");
					IntPtr pathPtr = AndroidJNI.CallObjectMethod(files[i], getPathMethod, new jvalue[] { });

					string path = AndroidJNI.GetStringUTFChars(pathPtr);
					/// NOTE: Since kitkat 4.4 is it not allowed to write on secondary storage outside app directory.
//					path = path.Substring(0, path.IndexOf("/Android"));

					// Check path is available
					AndroidJavaClass environment = new AndroidJavaClass("android.os.Environment");
					IntPtr getExternalStorageStateMethod = AndroidJNI.GetStaticMethodID(environment.GetRawClass(), "getExternalStorageState", "(Ljava/io/File;)Ljava/lang/String;");

					jvalue[] args = new jvalue[1];
					args[0].l = files[i];
					IntPtr statePtr = AndroidJNI.CallStaticObjectMethod(environment.GetRawClass(), getExternalStorageStateMethod, args);
					string state = AndroidJNI.GetStringUTFChars(statePtr);
					if (state == "mounted") {
						storages.Add(path);
					}
				}


			} catch (System.Exception e) {
				Debug.LogError("AndroidUtils: Error getting secondary external storage directory: " + e.Message);
			}

			return storages;

		}

		public static string GetPictureFolder()
		{
			return GetDirectoryName("DIRECTORY_PICTURES");
		}

		public static string GetDirectoryName(string directoryType = "DIRECTORY_PICTURES")
		{
			AndroidJavaClass environment = new AndroidJavaClass("android.os.Environment");
			IntPtr fieldID = AndroidJNI.GetStaticFieldID(environment.GetRawClass(), directoryType, "Ljava/lang/String;");
			return AndroidJNI.GetStaticStringField(environment.GetRawClass(), fieldID);
		}


		/// <summary>
		/// Call the Media Scanner to add the media to the gallery
		/// </summary>
		public static void AddImageToGallery(string file)
		{

			try {
				AndroidJavaClass classPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
				AndroidJavaObject objActivity = classPlayer.GetStatic<AndroidJavaObject>("currentActivity");
				AndroidJavaClass classMedia = new AndroidJavaClass("android.media.MediaScannerConnection");
				classMedia.CallStatic("scanFile", new object[4] { objActivity,
					new string[] { file },
					null,
					null
				});

			} catch (System.Exception e) {
				Debug.LogError("AndroidUtils: Error refreshing gallery: " + e.Message);
			}
		}

	}
}

#endif