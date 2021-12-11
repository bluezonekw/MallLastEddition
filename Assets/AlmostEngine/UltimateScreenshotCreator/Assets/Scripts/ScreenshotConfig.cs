using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlmostEngine.Screenshot
{
		[System.Serializable]
		public class ScreenshotConfig
		{

//				public bool m_DontDestroyOnLoad = false;

				#region DESTINATION

				public enum DestinationFolder
				{
						CUSTOM_FOLDER,
						DATA_PATH,
						PERSISTENT_DATA_PATH,
						PICTURES_FOLDER}
				;

				public DestinationFolder m_DestinationFolder = DestinationFolder.PICTURES_FOLDER;
				public string m_CustomRootedPath = "";
				public string m_CustomRelativePath = "Screenshots/";

				#endregion

				#region NAME

				public string m_FileName = "{width}x{height}-screenshot";

				[Tooltip ("Override files or increment automatically the filenames.")]
				public bool m_OverrideFiles = false;

				[Tooltip ("Use PNG to create screenshots with a transparent background.")]
				public TextureExporter.ImageFormat m_Format;

				[Tooltip ("RGB is the default color format.\n" +
				"Use RGBA to create screenshots with an alpha layer, enabling transparent backgrounds.")]
				public ScreenshotTaker.ColorFormat m_ColorFormat;

				public float m_JPGQuality = 75f;

				#endregion

				#region CAPTURE MODES

		
				public ScreenshotTaker.CaptureMode m_CaptureMode = ScreenshotTaker.CaptureMode.FIXED_GAMEVIEW;

				public enum AntiAliasing
				{
						NONE = 0,
						TWO = 2,
						FOUR = 4,
						EIGHT = 8}

				;

				public AntiAliasing m_MultisamplingAntiAliasing = AntiAliasing.EIGHT;

				[Tooltip ("Force alpha layer to be recomputed. This is a costly process. " +
				"Use only if you have alpha problems in RGBA mode.")]
				public bool m_RecomputeAlphaLayer = false;

				public enum ShotMode
				{
						ONE_SHOT,
						BURST}
				;

				public ShotMode m_ShotMode;
				public int m_MaxBurstShotsNumber = 20;
				public float m_ShotTimeStep = 0.25f;

				#endregion

				#region CAMERAS

				public enum CamerasMode
				{
						GAME_VIEW,
						CUSTOM_CAMERAS}
				;

				[Tooltip ("GAME_VIEW will capture what you see on the screen.\n" +
				"CUSTOM_CAMERAS allows you to customize the cameras to be used, and their rendering properties.")]
				public CamerasMode m_CameraMode;
				public List<ScreenshotCamera> m_Cameras = new List<ScreenshotCamera> ();

				#endregion

				#region RESOLUTIONS

				public enum ResolutionMode
				{
						GAME_VIEW,
						CUSTOM_RESOLUTIONS}
				;

				[Tooltip ("GAME_VIEW will capture what you see on the screen.\n" +
				"CUSTOM_RESOLUTIONS allows you to customize the resolutions to be used.")]
				public ResolutionMode m_ResolutionCaptureMode = ResolutionMode.CUSTOM_RESOLUTIONS;
				public List<ScreenshotResolution> m_Resolutions = new List<ScreenshotResolution> ();

				#endregion

				#region OVERLAYS

				[Tooltip ("Capture or not the active UI Canvas.")]
				public bool m_CaptureActiveUICanvas = true;
				public List<ScreenshotOverlay> m_Overlays = new List<ScreenshotOverlay> ();

				#endregion

				#region PREVIEW

				public bool m_ShowGuidesInPreview = false;
				public Canvas m_GuideCanvas;
				public Color m_GuidesColor = Color.white;
				public bool m_ShowPreview = true;
				public float m_PreviewSize = 1f;
		
				[Tooltip ("If set to true, the camera and overlay settings will be applied when the application starts playing.")]
				public bool m_PreviewInGameViewWhilePlaying = false;

				#endregion

				#region UTILS

				public bool m_PlaySoundOnCapture = true;
				public float m_Time = 1f;

				#endregion

				#region HOTKEYS

				public HotKey m_CaptureHotkey = new HotKey (false, false, false, KeyCode.None);
				public HotKey m_UpdatePreviewHotkey = new HotKey (false, false, false, KeyCode.None);
				public HotKey m_AlignHotkey = new HotKey (false, false, false, KeyCode.None);
				public HotKey m_PauseHotkey = new HotKey (false, false, false, KeyCode.None);

				#endregion

		}
}