using UnityEngine;
using System.Collections;

namespace AlmostEngine.Screenshot
{
		public class TextureExporter
		{
		
				public enum ImageFormat
				{
						PNG,
						JPG}
				;

				public static bool CreateExportDirectory (string filename)
				{
					
						// Create the folder if needed
						string fullpath = filename;
						if (string.IsNullOrEmpty (fullpath)) {
								Debug.LogError ("Filename is null or empty.");
								return false;
						}
					
						fullpath = fullpath.Replace ("\\", "/");
					
						if (!fullpath.Contains ("/")) {
								Debug.LogError ("Filename incorrect : " + filename);
								return false;
						}
					
						fullpath = fullpath.Substring (0, fullpath.LastIndexOf ('/'));
					
					
						if (!System.IO.Directory.Exists (fullpath)) {
								Debug.Log ("Creating directory " + fullpath);
								try {
										System.IO.Directory.CreateDirectory (fullpath);
								} catch {
										Debug.LogError ("Failed to create directory : " + fullpath);
										return false;
								}
						}

						return true;
				}

				public static bool ExportToFile (Texture2D texture, string filename, ImageFormat imageFormat, int JPGQuality = 70)
				{
						if (texture == null) {
								Debug.LogError ("Texture is null.");
								return false;
						}

						#if UNITY_WEBPLAYER

						Debug.Log("WebPlayer is not supported.");
						return false;

						#else

						// Convert texture to bytes
						byte[] bytes = null;
						if (imageFormat == ImageFormat.JPG) {
								bytes = texture.EncodeToJPG (JPGQuality);
						} else {
								bytes = texture.EncodeToPNG ();
						}

						#endif


						#if UNITY_WEBGL && !UNITY_EDITOR

						// Create a downloadable image for the web browser
						try {
							string shortFileName = filename;
							int index = filename.LastIndexOf('/');
							if (index >= 0) {
								shortFileName = filename.Substring(index+1);
							}
							string format = (imageFormat == ImageFormat.JPG) ? "jpeg" : "png";
							WebGLUtils.ExportImage(bytes, shortFileName, format);
						} catch {
							Debug.LogError ("Failed to create downloadable image.");
							return false;
						}

						#elif !UNITY_WEBPLAYER

						// Create the directory
						if (!CreateExportDirectory (filename))
								return false;

						// Export the image
						try {
								System.IO.File.WriteAllBytes (filename, bytes);
						} catch {
								Debug.LogError ("Failed to create the file : " + filename);
								return false;
						}

						#endif

						#if UNITY_ANDROID && !UNITY_EDITOR

						// Update android gallery
						try {
							AndroidUtils.AddImageToGallery(filename);
						} catch {
							Debug.LogError ("Failed to update Android Gallery");
							return false;
						}

						#elif UNITY_IOS && !UNITY_EDITOR

						// Update ios gallery
						try {
							iOsUtils.AddImageToGallery(filename);
						} catch {
							Debug.LogError ("Failed to update iOS Gallery");
							return false;
						}


						#endif

						#if !UNITY_WEBPLAYER
						return true;
						#endif
		
		
				}
	
		}
}
