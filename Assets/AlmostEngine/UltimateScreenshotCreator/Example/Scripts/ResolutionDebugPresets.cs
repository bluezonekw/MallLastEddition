#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

using AlmostEngine.Screenshot;

namespace AlmostEngine.Examples
{
		[InitializeOnLoad]
		public class ResolutionDebugPresets
		{

				static ResolutionDebugPresets ()
				{
						ScreenshotManager.onPresetsInit -= InitPresets;
						ScreenshotManager.onPresetsInit += InitPresets;

						ScreenshotManager.InitResolutionPresets ();
				}

				public static void InitPresets ()
				{

			
						ScreenshotManager.m_ResolutionPresets.Add (new ScreenshotResolution ("Debug", 800, 600, "")); 
						ScreenshotManager.m_ResolutionPresets.Add (new ScreenshotResolution ("Debug", 300, 400, "")); 
						ScreenshotManager.m_ResolutionPresets.Add (new ScreenshotResolution ("Debug", 3000, 8000, "")); 
						ScreenshotManager.m_ResolutionPresets.Add (new ScreenshotResolution ("Debug", 800, 300, "")); 
						ScreenshotManager.m_ResolutionPresets.Add (new ScreenshotResolution ("Debug", 3000, 2000, "")); 
						ScreenshotManager.m_ResolutionPresets.Add (new ScreenshotResolution ("Debug", 200, 300, ""));  
						ScreenshotManager.m_ResolutionPresets.Add (new ScreenshotResolution ("Debug", 4000, 1000, "")); 





						ScreenshotManager.UpdateCategories ();
				}
		}
}


#endif