using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;

#if UNITY_EDITOR
using UnityEditor;
#endif


namespace AlmostEngine.Screenshot
{
	/// <summary>
	/// The Screenshot Taker is a component used to take screenshots, with various capture modes and custom settings.
	/// </summary>
	[ExecuteInEditMode]
	[RequireComponent(typeof(AudioSource))]
	public class ScreenshotTaker : MonoBehaviour
	{
		public enum ColorFormat
		{
			RGB,
			RGBA}
		;

		public enum CaptureMode
		{
			GAMEVIEW_RESIZING,
			RENDER_TO_TEXTURE,
			FIXED_GAMEVIEW}
		;

		public AudioClip m_ShotSound;

		/// <summary>
		/// The texture containing the last screenshot taken.
		/// </summary>
		public Texture2D m_ScreenshotTexture;

		[Tooltip("In gameview resizing mode, the number of frames the screenshot taker waits before to take the screenshot after the gameview has been resized. " +
		"The default value of 2 should be enough for most settings. " +
		"Increase this number when some elements are not well updated, like GUI, or when you see some post effects artefacts. " +
		"Post effects like temporal anti aliasing requier a value of at least 10.")]
		public int m_GameViewResizingWaitingFrames = 2;


		ScreenshotResolution m_CaptureResolution = new ScreenshotResolution();
		Dictionary<ScreenshotResolution, RenderTexture> m_RenderTextureCache = new Dictionary<ScreenshotResolution, RenderTexture>();

		
		#if (UNITY_EDITOR) && (! UNITY_5_4_OR_NEWER)
				[HideInInspector]
				public bool m_NeedRestoreLayout;

				[Tooltip ("If true, the editor layout is saved and restored before and after each capture process.")]
				public bool m_ForceLayoutPreservation = true;
				#endif

		[HideInInspector]
		public bool m_IsRunning = false;
		List<ScreenshotCamera> m_Cameras = new List<ScreenshotCamera>();
		List<ScreenshotCamera> m_SceneCameras = new List<ScreenshotCamera>();
		List<ScreenshotOverlay> m_Overlays = new List<ScreenshotOverlay>();
		List<ScreenshotOverlay> m_SceneOverlays = new List<ScreenshotOverlay>();




		void Update()
		{		
			#if UNITY_EDITOR
			if (EditorApplication.isCompiling) {
				Reset();
				return;
			} 
			#endif

			#if (UNITY_EDITOR) && (! UNITY_5_4_OR_NEWER)		
						RestoreLayoutIfNeeded ();							
			#endif
		}

		public void Reset()
		{
			StopAllCoroutines();
			
			
			#if (UNITY_EDITOR) && (! UNITY_5_4_OR_NEWER)
						RestoreLayoutIfNeeded ();				
			#endif

			
			RestoreTime();			
			RestoreSettings();

			m_IsRunning = false;
		}

		/// <summary>
		/// Clears the cache of RenderTexture used to capture the screenshots.
		/// </summary>
		public void ClearCache()
		{
			m_RenderTextureCache.Clear();
			m_CaptureResolution.m_Texture = null;
		}

		#region API

		public delegate void UpdateDelegate(ScreenshotResolution res);

		/// <summary>
		/// Delegate called when the capture starts.
		/// </summary>
		public static UpdateDelegate onResolutionUpdateStartDelegate = (ScreenshotResolution res) => {
		};
		/// <summary>
		/// Delegate called when the capture ends.
		/// </summary>
		public static UpdateDelegate onResolutionUpdateEndDelegate = (ScreenshotResolution res) => {
		};
		/// <summary>
		/// Delegate called when the screen is resized.
		/// </summary>
		public static UpdateDelegate onResolutionScreenResizedDelegate = (ScreenshotResolution res) => {
		};
		/// <summary>
		/// Delegate called when the capture is a success.
		/// </summary>
		public static UpdateDelegate onResolutionExportSuccessDelegate = (ScreenshotResolution res) => {
		};
		/// <summary>
		/// Delegate called when the capture is a failure.
		/// </summary>
		public static UpdateDelegate onResolutionExportFailureDelegate = (ScreenshotResolution res) => {
		};


		/// <summary>
		/// Captures the current screen at its current resolution, including UI.
		/// </summary>
		public void CaptureScreen(string fileName, 
		                          TextureExporter.ImageFormat imageFormat = TextureExporter.ImageFormat.PNG,
		                          int JPGQuality = 100,
		                          bool renderUI = true,
		                          bool playSound = false,
		                          ColorFormat colorFormat = ColorFormat.RGB,
		                          bool recomputeAlphaMask = false)
		{
			Vector2 size = GameViewController.GetCurrentGameViewSize();
			Capture((int)size.x, (int)size.y, 1, fileName, null, null, CaptureMode.FIXED_GAMEVIEW, 8, imageFormat, JPGQuality, renderUI, playSound, colorFormat, recomputeAlphaMask);
		}

		/// <summary>
		/// Captures the scene with the specified width, height, resolution upscale, and export it to the file fileName,
		/// using the mode RENDER_TO_TEXTURE.
		/// No UI is captured with this mode.
		/// </summary>
		public void CaptureScene(int width, int height, int upscale, string fileName, 
		                         List<Camera> cameras, 
		                         int antiAliasing = 8,
		                         TextureExporter.ImageFormat imageFormat = TextureExporter.ImageFormat.PNG,
		                         int JPGQuality = 100,
		                         bool playSound = false,
		                         ColorFormat colorFormat = ColorFormat.RGB,
		                         bool recomputeAlphaMask = false)
		{
			Capture(width, height, upscale, fileName, cameras, null, CaptureMode.RENDER_TO_TEXTURE, antiAliasing, imageFormat, JPGQuality, false, playSound, colorFormat, recomputeAlphaMask);
		}



		/// <summary>
		/// Captures the game with the specified width, height, resolution upscale, and export it to the file fileName.
		/// </summary>
		public void Capture(int width, int height, int upscale, string fileName, 
		                    List<Camera> cameras = null, 
		                    List<Canvas> canvas = null, 
		                    CaptureMode captureMode = CaptureMode.RENDER_TO_TEXTURE,
		                    int antiAliasing = 8,
		                    TextureExporter.ImageFormat imageFormat = TextureExporter.ImageFormat.PNG,
		                    int JPGQuality = 100,
		                    bool renderUI = true,
		                    bool playSound = false,
		                    ColorFormat colorFormat = ColorFormat.RGB,
		                    bool recomputeAlphaMask = false)
		{
			// Update resolution item
			m_CaptureResolution.m_Width = width;
			m_CaptureResolution.m_Height = height;
			m_CaptureResolution.m_Scale = upscale;
			m_CaptureResolution.m_FileName = fileName;

			// Create camera items
			List <ScreenshotCamera> screenshotCameras = new List<ScreenshotCamera>();
			if (cameras != null) {
				foreach (Camera camera in cameras) {
					ScreenshotCamera scamera = new ScreenshotCamera(camera);
					screenshotCameras.Add(scamera);
				}
			}

			// Create the overlays items
			List <ScreenshotOverlay> screenshotCanvas = new List<ScreenshotOverlay>();
			if (canvas != null) {
				foreach (Canvas c in canvas) {
					ScreenshotOverlay scanvas = new ScreenshotOverlay(true, c);
					screenshotCanvas.Add(scanvas);
				}
			}

			Capture(new List<ScreenshotResolution>{ m_CaptureResolution }, 
				screenshotCameras, 
				screenshotCanvas, 
				captureMode, 
				antiAliasing, 
				true, 
				imageFormat, 
				JPGQuality, 
				renderUI, 
				playSound, 
				colorFormat, 
				recomputeAlphaMask);
		}

		/// <summary>
		/// Captures the specified resolutions with custom parameters.
		/// </summary>
		public void Capture(List<ScreenshotResolution> resolutions, 
		                    List<ScreenshotCamera> cameras, 
		                    List<ScreenshotOverlay> overlays, 
		                    CaptureMode captureMode,
		                    int antiAliasing = 8,
		                    bool export = true,
		                    TextureExporter.ImageFormat imageFormat = TextureExporter.ImageFormat.PNG,
		                    int JPGQuality = 100,
		                    bool renderUI = true,
		                    bool playSound = false,
		                    ColorFormat colorFormat = ColorFormat.RGB,
		                    bool recomputeAlphaMask = false)
		{
			StartCoroutine(CaptureScreenshotsCoroutine(resolutions, 
				cameras, 
				overlays, 
				captureMode, 
				antiAliasing,
				export,
				imageFormat, 
				JPGQuality, 
				renderUI, 
				playSound, 
				colorFormat, 
				recomputeAlphaMask));
		}

		#endregion


		#region Capture

		public IEnumerator CaptureScreenshotsCoroutine(List<ScreenshotResolution> resolutions, 
		                                               List<ScreenshotCamera> cameras, 
		                                               List<ScreenshotOverlay> overlays, 
		                                               CaptureMode captureMode,
		                                               int antiAliasing = 8,
		                                               bool export = false,
		                                               TextureExporter.ImageFormat imageFormat = TextureExporter.ImageFormat.PNG,
		                                               int JPGQuality = 100,
		                                               bool renderUI = true,
		                                               bool playSound = false,
		                                               ColorFormat colorFormat = ColorFormat.RGB,
		                                               bool recomputeAlphaMask = false,
		                                               bool stopTime = true,
		                                               bool restore = true)
		{

			if (resolutions == null) {
				Debug.LogError("Resolution list is null.");
				yield break;
			}
			if (cameras == null) {
				Debug.LogError("Cameras list is null.");
				yield break;
			}
			if (overlays == null) {
				Debug.LogError("Overlays list is null.");
				yield break;
			}
			if (m_IsRunning == true) {
				Debug.LogError("A capture process is already running.");
				yield break;
			}

			if (captureMode == CaptureMode.RENDER_TO_TEXTURE && !UnityVersion.HasPro()) {
				Debug.LogError("RENDER_TO_TEXTURE requires Unity Pro or Unity 5.0 and later.");
				yield break;
			}

			#if (!UNITY_EDITOR && !UNITY_STANDALONE_WIN)
			if (captureMode == CaptureMode.GAMEVIEW_RESIZING)
			{
					Debug.LogError ("GAMEVIEW_RESIZING capture mode is only available for Editor and Windows Standalone.");
					yield break;
			}
			#endif

			// Init
			m_IsRunning = true;
			
			// Stop the time so all screenshots are exactly the same
			if (Application.isPlaying && stopTime) {
				StopTime();
			}


			// Apply settings: enable and disable the cameras and canvas
			ApplySettings(cameras, overlays, captureMode, renderUI);

			// Save the screen config to be restored after the capture process
			if (captureMode == CaptureMode.GAMEVIEW_RESIZING) {
				GameViewController.SaveCurrentGameViewSize();
				
				#if !UNITY_EDITOR && UNITY_STANDALONE_WIN
				yield return null;
				yield return new WaitForEndOfFrame();
				#endif
			}
			
			// Capture all resolutions
			foreach (ScreenshotResolution resolution in resolutions) {
				
				// Play the shot sound
				if (playSound) {
					PlaySound();
				}

				// Update the texture
				yield return StartCoroutine(CaptureResolutionTextureCoroutine(resolution, captureMode, antiAliasing, colorFormat, recomputeAlphaMask));

				// Export to file
				if (export) {
					if (TextureExporter.ExportToFile(resolution.m_Texture, resolution.m_FileName, imageFormat, JPGQuality)) {
						Debug.Log("Screenshot created : " + resolution.m_FileName);
						onResolutionExportSuccessDelegate(resolution);
					} else {
						Debug.LogError("Failed to create : " + resolution.m_FileName);
						onResolutionExportFailureDelegate(resolution);
					}
				}
				
			}

			// Restore screen config
			if (restore && captureMode == CaptureMode.GAMEVIEW_RESIZING) {
				GameViewController.RestoreGameViewSize();		
			}

			#if ( UNITY_EDITOR && !UNITY_5_4_OR_NEWER)
			// Call restore layout for old unity versions
			if (restore && captureMode == CaptureMode.GAMEVIEW_RESIZING) {		
				m_NeedRestoreLayout = true;
			} 
			#endif

			#if UNITY_EDITOR
			// Dirty hack, try to force an editor Update() to get the gameview back to normal
			if (captureMode == CaptureMode.FIXED_GAMEVIEW || captureMode == CaptureMode.GAMEVIEW_RESIZING) {
				if (!Application.isPlaying) {	
					GameViewUtils.GetGameView().Repaint();
				}							
			}
			#endif
			
			// Restore everything
			if (Application.isPlaying && stopTime) {
				RestoreTime();
			}
			if (Application.isEditor || restore) {
				RestoreSettings();
			}

			// End
			m_IsRunning = false;
		}



		/// <summary>
		/// Captures the resolution texture.
		/// </summary>
		IEnumerator CaptureResolutionTextureCoroutine(ScreenshotResolution resolution, CaptureMode captureMode, int antiAliasing, ColorFormat colorFormat, bool recomputeAlphaMask)
		{
			
			if (!resolution.IsValid())
				yield break;

			// Delegate call
			onResolutionUpdateStartDelegate(resolution);

			// Init texture
			m_ScreenshotTexture = GetOrCreateTexture(resolution, colorFormat, captureMode == CaptureMode.FIXED_GAMEVIEW ? true : false);

			if (captureMode == CaptureMode.GAMEVIEW_RESIZING) {

				// Force screen size change
				GameViewController.SetGameViewSize(m_ScreenshotTexture.width, m_ScreenshotTexture.height);
				yield return new WaitForEndOfFrame();

				// Force wait
				if (!Application.isPlaying) {
					// Useless texture update in editor mode when game is not running,
					// that takes some computational times to be sure that the UI is updated at least one time before the capture
					if (MultiDisplayUtils.IsMultiDisplay()) {
						yield return MultiDisplayCopyRenderBufferToTextureCoroutine(m_ScreenshotTexture);
					} else {
						CopyScreenToTexture(m_ScreenshotTexture);
					}
				}

				// Force screen size change, again
				// Particularly needed for special effects using several frame to compute their effects, like temporal anti aliasing
				for (int i = 0; i < m_GameViewResizingWaitingFrames; ++i) {
					GameViewController.SetGameViewSize(m_ScreenshotTexture.width, m_ScreenshotTexture.height);
					yield return new WaitForEndOfFrame();		
				}			

				// Delegate call to notify screen is resized
				onResolutionScreenResizedDelegate(resolution);

				// Capture the screen content
				if (MultiDisplayUtils.IsMultiDisplay()) {
					yield return MultiDisplayCopyRenderBufferToTextureCoroutine(m_ScreenshotTexture);
				} else {
					CopyScreenToTexture(m_ScreenshotTexture);
				}

			} else if (captureMode == CaptureMode.RENDER_TO_TEXTURE) {	

				// Do not need to wait anything, just capture the cameras
				RenderTexture renderTexture = GetOrCreateRenderTexture(resolution, antiAliasing);
				RenderCamerasToTexture(m_Cameras, m_ScreenshotTexture, renderTexture);

			} else if (captureMode == CaptureMode.FIXED_GAMEVIEW) {

				// Wait for the end of rendering
				yield return new WaitForEndOfFrame();

				// Capture the screen content
				if (MultiDisplayUtils.IsMultiDisplay()) {
					yield return MultiDisplayCopyRenderBufferToTextureCoroutine(m_ScreenshotTexture);
				} else {
					CopyScreenToTexture(m_ScreenshotTexture);
				}
			}

			// Alpha mask
			if (colorFormat == ColorFormat.RGBA && recomputeAlphaMask) {
				// Capture the screen content
				yield return StartCoroutine(RecomputeAlphaMask(resolution, m_Cameras, captureMode));
			}

			// Delegate call
			onResolutionUpdateEndDelegate(resolution);
		}

		public void CopyScreenToTexture(Texture2D targetTexture)
		{
			targetTexture.ReadPixels(new Rect(0, 0, targetTexture.width, targetTexture.height), 0, 0);
			targetTexture.Apply(false);
		}

		public void RenderCamerasToTexture(List<ScreenshotCamera> cameras, Texture2D targetTexture, RenderTexture renderTexture)
		{		

			RenderTexture tmp = RenderTexture.active;
			RenderTexture.active = renderTexture;

			// Render all cameras in custom render texture
			foreach (ScreenshotCamera camera in cameras) {

				if (camera.m_Active == false)
					continue;
				if (camera.m_Camera == null)
					continue;
				if (camera.m_Camera.enabled == false)
					continue;

				RenderTexture previous = camera.m_Camera.targetTexture;
				camera.m_Camera.targetTexture = renderTexture;
				camera.m_Camera.Render();
				camera.m_Camera.targetTexture = previous;

			}

			// Copy render buffer to texture
			targetTexture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
			targetTexture.Apply(false);
			RenderTexture.active = tmp;
		}

		#endregion


		#region Multi Display


		Camera GetLastActiveCamera()
		{
			// Get last camera on the list
			for (int i = m_Cameras.Count - 1; i >= 0; i--) {
				if (m_Cameras[i].m_Active && m_Cameras[i].m_Camera != null && m_Cameras[i].m_Camera.enabled == true) {
					return m_Cameras[i].m_Camera;
				}
			}
			// If not cameras on the list, get the active camera for display 1 with the higher depth
			Camera[] cameras = GameObject.FindObjectsOfType<Camera>();
			Camera best = null;
			foreach (Camera cam in cameras) {

				#if (UNITY_5_4_OR_NEWER)
				if (cam.enabled == true && cam.targetDisplay == 0) {
					#else
								if (cam.enabled == true) {
					#endif
					if (best != null && cam.depth > best.depth) {
						best = cam;
					} else {
						best = cam;
					}
				}
			}
			if (best != null)
				return best;
			// Return camera tagged as MainCamera
			return Camera.main;
		}

		IEnumerator MultiDisplayCopyRenderBufferToTextureCoroutine(Texture2D targetTexture)
		{
			Camera lastCamera = GetLastActiveCamera();

			// On multi display we need to wait for the last camera to capture to be rendered
			if (lastCamera != null) {
				// Add a capture camera component and start the capture process
				if (lastCamera.GetComponent<MultiDisplayCameraCapture>() == null) {
					lastCamera.gameObject.AddComponent<MultiDisplayCameraCapture>();
				}
				MultiDisplayCameraCapture capture = lastCamera.GetComponent<MultiDisplayCameraCapture>();			
				capture.CaptureCamera(targetTexture);
				// Wait for capture
				while (!capture.CopyIsOver()) {
					yield return null;
				}
				// Clean
				GameObject.DestroyImmediate(capture);

			} else {
				// Just read the actual render buffer
				CopyScreenToTexture(targetTexture);
			}
		}

		#endregion

		#region TEXTURE

		Texture2D GetOrCreateTexture(ScreenshotResolution resolution, ColorFormat colorFormat, bool noScale = false)
		{

			// Compute real dimensions
			int width = noScale ? resolution.m_Width : resolution.ComputeTargetWidth();
			int height = noScale ? resolution.m_Height : resolution.ComputeTargetHeight();

			// Create texture if needed
			if (resolution.m_Texture == null || resolution.m_Texture.width != width || resolution.m_Texture.height != height ||
			    (resolution.m_Texture.format == TextureFormat.ARGB32 && colorFormat != ColorFormat.RGBA) ||
			    (resolution.m_Texture.format == TextureFormat.RGB24 && colorFormat != ColorFormat.RGB)) {

				if (colorFormat == ColorFormat.RGBA) {
					resolution.m_Texture = new Texture2D(width, height, TextureFormat.ARGB32, false);
				} else {
					resolution.m_Texture = new Texture2D(width, height, TextureFormat.RGB24, false);
				}
			}

			return resolution.m_Texture;
		}

		RenderTexture GetOrCreateRenderTexture(ScreenshotResolution resolution, int antiAliasing = 0)
		{
			// Compute real resolutions
			int width = resolution.ComputeTargetWidth();
			int height = resolution.ComputeTargetHeight();

			// Create render texture if needed
			if (!m_RenderTextureCache.ContainsKey(resolution) || m_RenderTextureCache[resolution] == null
			    || m_RenderTextureCache[resolution].width != width || m_RenderTextureCache[resolution].height != height
			    || m_RenderTextureCache[resolution].antiAliasing != antiAliasing) {
				m_RenderTextureCache[resolution] = new RenderTexture(width, height, 32, RenderTextureFormat.ARGB32);
				if (antiAliasing != 0) {
					m_RenderTextureCache[resolution].antiAliasing = antiAliasing;			
				}
			}

			return m_RenderTextureCache[resolution];
		}

		#endregion



		#region GENERAL SETTINGS

		public void ApplySettings(List<ScreenshotCamera> cameras, List<ScreenshotOverlay> overlays, CaptureMode captureMode, bool renderUI)
		{

			// SET CAMERAS		
			m_Cameras = cameras;
			m_SceneCameras = FindAllOtherSceneCameras(cameras);
			if (cameras.Count > 0 && captureMode == CaptureMode.GAMEVIEW_RESIZING) {		
				DisableCameras(m_SceneCameras);
			}
			ApplyCameraSettings(cameras);
			
			// SET OVERLAYS
			m_Overlays = overlays;
			m_SceneOverlays = FindAllOtherSceneCanvas(overlays);
			if (renderUI == false) {
				DisableCanvas(m_SceneOverlays);
			}
			ApplyOverlaySettings(overlays);
		}

		void RestoreSettings()
		{
			
			// Restore cameras
			RestoreCameraSettings(m_Cameras);
			RestoreCameraSettings(m_SceneCameras);
			
			// Restore overlays
			RestoreOverlaySettings(m_Overlays);		
			RestoreOverlaySettings(m_SceneOverlays);
		}

		float m_PreviousTimeScale = 1f;

		void StopTime()
		{
			m_PreviousTimeScale = Time.timeScale;
			Time.timeScale = 0f;
		}

		void RestoreTime()
		{
			Time.timeScale = m_PreviousTimeScale;
		}

		#if (UNITY_EDITOR) && (! UNITY_5_4_OR_NEWER)
				void RestoreLayoutIfNeeded ()
				{
						if (m_NeedRestoreLayout) {
								m_NeedRestoreLayout = false;
								if (m_ForceLayoutPreservation) {
										GameViewController.RestoreLayout ();
								}
						}
				}
				#endif

		#endregion

				
		#region CANVAS SETTINGS

		List<ScreenshotOverlay> FindAllOtherSceneCanvas(List<ScreenshotOverlay> overlays)
		{
			List<ScreenshotOverlay> sceneUIOverlaysCanvas = new List<ScreenshotOverlay>();
			
			// Find all canvas using screenspaceoverlay on the scene
			Canvas[] canvas = GameObject.FindObjectsOfType<Canvas>();
			foreach (Canvas canva in canvas) {
				if (canva.gameObject.activeInHierarchy == true
				    && canva.enabled == true) { 
					
					// Ignore overlays canvas
					bool contains = false;
					foreach (ScreenshotOverlay overlay in overlays) {
						if (overlay.m_Canvas == canva && overlay.m_Active)
							contains = true;
					}
					if (contains)
						continue;
					
					// Add canvas to list
					sceneUIOverlaysCanvas.Add(new ScreenshotOverlay(true, canva));
				}
			}
			return sceneUIOverlaysCanvas;
		}

		void DisableCanvas(List<ScreenshotOverlay> overlays)
		{
			if (overlays == null)
				return;
			foreach (ScreenshotOverlay overlay in overlays) {
				if (overlay == null)
					continue;
				overlay.Disable();
			}
		}

		void ApplyOverlaySettings(List<ScreenshotOverlay> overlays)
		{
			if (overlays == null)
				return;
			foreach (ScreenshotOverlay overlay in overlays) {
				if (overlay == null)
					continue;
				if (overlay.m_Active && overlay.m_Canvas != null) {
					overlay.ApplySettings();
				}
			}
		}

		public void RestoreOverlaySettings(List<ScreenshotOverlay> overlays)
		{
			if (overlays == null)
				return;
			foreach (ScreenshotOverlay overlay in overlays) {
				if (overlay == null)
					continue;
				if (overlay.m_Active && overlay.m_Canvas != null) {
					overlay.RestoreSettings();
				}
			}
		}

		#endregion

		#region CAMERAS SETTINGS

		
		List<ScreenshotCamera> FindAllOtherSceneCameras(List<ScreenshotCamera> cameras)
		{
			List<ScreenshotCamera> cams = new List<ScreenshotCamera>();
			Camera[] sceneCameras = GameObject.FindObjectsOfType<Camera>();
			foreach (Camera camera in sceneCameras) {
				bool contains = false;
				foreach (ScreenshotCamera cam in cameras) {
					if (cam.m_Camera == camera && cam.m_Active == true) {
						contains = true;
					}
				}
				if (!contains) {
					cams.Add(new ScreenshotCamera(camera));
				}
			}
			return cams;
		}

		void DisableCameras(List<ScreenshotCamera> cameras)
		{
			if (cameras == null)
				return;

			foreach (ScreenshotCamera camera in cameras) {
				if (camera == null)
					continue;
				camera.Disable();
			}
		}

		public void RestoreCameraSettings(List<ScreenshotCamera> cameras)
		{
			if (cameras == null)
				return;

			foreach (ScreenshotCamera camera in cameras) {
				if (camera == null)
					continue;
				if (camera.m_Active == false)
					continue;
				if (camera.m_Camera == null)
					continue;
				camera.RestoreSettings();
			}
		}

		void ApplyCameraSettings(List<ScreenshotCamera> cameras)
		{
			if (cameras == null)
				return;

			foreach (ScreenshotCamera camera in cameras) {
				if (camera == null)
					continue;
				if (camera.m_Active == false)
					continue;
				if (camera.m_Camera == null)
					continue;
				
				camera.ApplySettings();
			}
		}

		#endregion

				
		#region Transparency

		Dictionary<ScreenshotCamera, Camera> m_CameraClones = new Dictionary<ScreenshotCamera, Camera>();

		Camera CreateOrGetCameraClone(ScreenshotCamera camera)
		{
			if (!m_CameraClones.ContainsKey(camera) || m_CameraClones[camera] == null) {
				GameObject obj = new GameObject();
				obj.transform.position = camera.m_Camera.transform.position;
				obj.transform.rotation = camera.m_Camera.transform.rotation;
				obj.transform.localScale = camera.m_Camera.transform.localScale;
				
				Camera cam = obj.AddComponent<Camera>();
				cam.CopyFrom(camera.m_Camera);
				
				m_CameraClones[camera] = cam;
			}
			
			return m_CameraClones[camera];
		}

		IEnumerator RecomputeAlphaMask(ScreenshotResolution resolution, List<ScreenshotCamera> cameras, CaptureMode captureMode)
		{
			Texture2D texture = resolution.m_Texture;
			Texture2D mask = new Texture2D(texture.width, texture.height, TextureFormat.ARGB32, false);

			
			// Clone existing cameras
			List<Camera> cameraClones = new List<Camera>();
			List<ScreenshotCamera> toClone = cameras;
			if (cameras.Count == 0) {
				toClone = m_SceneCameras;
			}
			foreach (ScreenshotCamera camera in toClone) {
				if (camera.m_Camera == null)
					continue;
				if (camera.m_Active == false)
					continue;
				Camera clone = CreateOrGetCameraClone(camera);
				clone.ResetAspect();
				cameraClones.Add(clone);
			}


			if (captureMode == CaptureMode.RENDER_TO_TEXTURE) {

					
				// Render mask
				RenderTexture renderTexture = GetOrCreateRenderTexture(resolution);
				foreach (Camera camera in cameraClones) {
					camera.targetTexture = renderTexture;
					camera.Render();
					camera.targetTexture = null;
				}
				
				// Copy
				RenderTexture tmp = RenderTexture.active;
				RenderTexture.active = renderTexture;
				mask.ReadPixels(new Rect(0, 0, mask.width, mask.height), 0, 0);
				mask.Apply(false);
				RenderTexture.active = tmp;

			} else {

				if (cameras.Count == 0) {
					DisableCameras(m_SceneCameras);
				} else {
					DisableCameras(cameras);
				}

				#if UNITY_EDITOR
				if (Application.isPlaying) {
					yield return new WaitForEndOfFrame();
				} else {
					// We need to force a gameview repaint
					Vector2 current = GameViewController.GetCurrentGameViewSize();
					GameViewController.SetGameViewSize((int)current.x, (int)current.y);
					yield return new WaitForEndOfFrame();
				}
				#else
								yield return new WaitForEndOfFrame ();
				#endif

				
				mask.ReadPixels(new Rect(0, 0, mask.width, mask.height), 0, 0);
				mask.Apply(false);

				if (cameras.Count == 0) {
					RestoreCameraSettings(m_SceneCameras);
				} else {
					RestoreCameraSettings(cameras);
				}

			}

			// Remove cameras
			foreach (Camera camera in cameraClones) {
				DestroyImmediate(camera.gameObject);
			}


			
			// Combine
			Color col;
			for (int i = 0; i < mask.width; i++) {
				for (int j = 0; j < mask.height; j++) {
					col = texture.GetPixel(i, j);
					col.a = mask.GetPixel(i, j).a;
					texture.SetPixel(i, j, col);
				}
			}
		}

		#endregion

		#region SOUND

		void PlaySound()
		{	
			
			if (GetComponent<AudioSource>() == null)
				return;
			
			GetComponent<AudioSource>().PlayOneShot(m_ShotSound);
		}

		#endregion




	}
}
