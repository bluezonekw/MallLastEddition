
#if UNITY_IOS

using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

namespace AlmostEngine.Screenshot
{
		public class iOsUtils
		{
		
				[DllImport ("__Internal")]
				private static extern void _AddImageToGallery (string file);

				[DllImport ("__Internal")]
				private static extern bool _HasGalleryAuthorization ();

				[DllImport ("__Internal")]
				private static extern void _RequestGalleryAuthorization ();


				/// <summary>
				/// Call the native iOs code to add the image at the given path to the phone gallery.
				/// </summary>
				/// <param name="file">The file path.</param>
				public static void AddImageToGallery (string file)
				{
						_AddImageToGallery (file);
				}

				/// <summary>
				/// Determines if the app has gallery authorization.
				/// Note that for this method to work the native plugin "Plugins/iOS/iOSUtils.m" must have "Platform Settings/Rarely Used Frameworks/Photos" dependency checked.
				/// </summary>
				/// <returns><c>true</c> if has gallery authorization; otherwise, <c>false</c>.</returns>
				public static bool HasGalleryAuthorization()
				{
					return _HasGalleryAuthorization();
				}

				/// <summary>
				/// Requests the gallery authorization. 
				/// Note that for this method to work the native plugin "Plugins/iOS/iOSUtils.m" must have "Platform Settings/Rarely Used Frameworks/Photos" dependency checked.
				/// </summary>
				public static void RequestGalleryAuthorization()
				{
					_RequestGalleryAuthorization();
				}

		}
}

#endif