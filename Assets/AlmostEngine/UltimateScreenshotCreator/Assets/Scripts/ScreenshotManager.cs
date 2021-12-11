using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif



namespace AlmostEngine.Screenshot
{
		/// <summary>
		/// The ScreenshotManager allows to create multiple resolution screenshots in one click.
		/// </summary>
		/// 
		[ExecuteInEditMode]
		public class ScreenshotManager : MonoBehaviour
		{
				public ScreenshotConfig m_Config = new ScreenshotConfig ();
				protected ScreenshotTaker m_ScreenshotTaker;


				#region NAME PRESETS

				public class NamePreset
				{
						public string m_Path;
						public string m_Description;

						public NamePreset (string path = "", string description = "")
						{
								m_Path = path; 
								m_Description = description;
						}
				};

				public List<NamePreset> m_NamePresets = new List<NamePreset> ();

				protected void InitNamePresets ()
				{
						m_NamePresets.Clear ();
			
						m_NamePresets.Add (new NamePreset ("{width}x{height}-screenshot", "Default"));
						m_NamePresets.Add (new NamePreset ("{width}x{height}/screenshot", "Screenshots grouped by resolutions in separate folders"));
						m_NamePresets.Add (new NamePreset ("{ratio}/screenshot", "Screenshots grouped by ratio in separate folders"));
						m_NamePresets.Add (new NamePreset ("{category}/{name}", "Screenshots grouped by categories in separate folders"));
						m_NamePresets.Add (new NamePreset ("{name}", "Resolution name"));
						m_NamePresets.Add (new NamePreset ("{width}x{height}-{scale} {name} {orientation}", "Resolution infos"));
						if (typeof(ScreenshotManager).Assembly.GetType ("AlmostEngine.Preview.ResolutionGalleryWindow") != null) {
								m_NamePresets.Add (new NamePreset ("{width}x{height}-{scale}-{name} {orientation} {ppi}ppi {percent}%", "Resolution detailed infos"));
						}
						m_NamePresets.Add (new NamePreset ("{year}-{month}-{day}_{hour}h{minute}_{second}", "Current time"));
				}

				#endregion

		
				#region RESOLUTION PRESETS

				public static Dictionary<string, List<ScreenshotResolution>> m_Categories = new Dictionary<string, List<ScreenshotResolution>> ();
				public static List<ScreenshotResolution> m_ResolutionPresets = new List<ScreenshotResolution> ();

				public static void UpdateCategories ()
				{
						m_Categories.Clear ();
						foreach (ScreenshotResolution res in m_ResolutionPresets) {
				
								if (!m_Categories.ContainsKey (res.m_Category)) {
										m_Categories [res.m_Category] = new List<ScreenshotResolution> ();
								}
				
								m_Categories [res.m_Category].Add (res);
						}
				}

				public static void InitResolutionPresets ()
				{
						m_ResolutionPresets.Clear ();
			
						m_ResolutionPresets.Add (new ScreenshotResolution ("Default", 1920, 1080, "FHD(1080p)"));
						m_ResolutionPresets.Add (new ScreenshotResolution ("Default", 1680, 1050, "WSXGA+"));
						m_ResolutionPresets.Add (new ScreenshotResolution ("Default", 1600, 900, "HD+"));   
						m_ResolutionPresets.Add (new ScreenshotResolution ("Default", 1440, 900, "WXGA+")); 
						m_ResolutionPresets.Add (new ScreenshotResolution ("Default", 1366, 768, "HD"));  
						m_ResolutionPresets.Add (new ScreenshotResolution ("Default", 1280, 1024, "SXGA"));
						m_ResolutionPresets.Add (new ScreenshotResolution ("Default", 1280, 720, "WXGA(720p)")); 
						m_ResolutionPresets.Add (new ScreenshotResolution ("Default", 1024, 768, "XGA")); 
			
						UpdateCategories ();
			
						onPresetsInit ();
			
				}


				#endregion


				#region PREVIEW

				public ScreenshotResolution m_PreviewResolution;

				#endregion


				#region CAPTURE PROCESS

				public ScreenshotResolution m_GameViewResolution;
				public bool m_IsBurstActive = false;
				public bool m_IsCapturing = false;


				#endregion


				#region UI

				public bool m_ShowDestination = true;
				public bool m_ShowName = true;
				public bool m_ShowCaptureMode = true;
				public bool m_ShowResolutions = true;
				public bool m_ShowCameras = true;
				public bool m_ShowCanvas = true;
				public bool m_ShowPreview = true;
				public bool m_ShowCapture = true;
				public bool m_ShowUtils = false;
				public bool m_ShowHotkeys = true;
				public bool m_ShowGallery = true;

				#endregion


				#region DELEGATES

				public static UnityAction onPresetsInit = () => {
				};
				public static UnityAction onCaptureBeginDelegate = () => {
				};
				public static UnityAction onCaptureEndDelegate = () => {
				};

				#endregion


				#region BEHAVIOR METHODS

				public ScreenshotManager ()
				{
						InitGameViewResolution ();
						InitPreviewResolution ();			
						InitResolutionPresets ();
						InitNamePresets ();
				}

				protected void InitGameViewResolution ()
				{
						m_GameViewResolution = new ScreenshotResolution ();
						m_GameViewResolution.m_Active = true;
						m_GameViewResolution.m_ResolutionName = "GameView";
						m_GameViewResolution.m_Width = Screen.width;
						m_GameViewResolution.m_Height = Screen.height;
						m_GameViewResolution.m_Scale = 1;
				}

				protected void InitPreviewResolution ()
				{
						m_PreviewResolution = new ScreenshotResolution ();
						m_PreviewResolution.m_Width = 200;
						m_PreviewResolution.m_Height = 100;
						m_PreviewResolution.m_Scale = 1;
				}

				void Awake ()
				{	
						Reset ();
						ClearCache ();

						if (Application.isPlaying) {
								DontDestroyOnLoad (this.gameObject);
						}

						// Load settings in ingame preview mode
						if (Application.isPlaying && m_Config.m_PreviewInGameViewWhilePlaying == true) {
								InitIngamePreview ();
						}

				}

				void OnDestroy ()
				{
						#if UNITY_EDITOR
						SceneView.onSceneGUIDelegate -= HandleEventsDelegate;
						#endif
				}

				public void Reset ()
				{
						StopAllCoroutines ();

						m_IsCapturing = false;
						m_IsBurstActive = false;   
			
						InitScreenshotTaker ();

						m_ScreenshotTaker.Reset ();

				}

				public void ClearCache ()
				{
						foreach (ScreenshotResolution res in m_Config.m_Resolutions) {
								res.m_Texture = null;
						}
						if (m_ScreenshotTaker != null) {
								m_ScreenshotTaker.ClearCache ();
						}
				}

				void Update ()
				{	
						#if UNITY_EDITOR
						if (EditorApplication.isCompiling) {
								Reset ();
								ClearCache ();
								return;
						} 
						RegisterUpdate ();		


						#endif

						if (Application.isPlaying) {
								HandleHotkeys ();
						} 	
				}

				protected void InitScreenshotTaker ()
				{
						m_ScreenshotTaker = GameObject.FindObjectOfType<ScreenshotTaker> ();
						if (m_ScreenshotTaker == null) {
								m_ScreenshotTaker = gameObject.GetComponent<ScreenshotTaker> ();
						}
						if (m_ScreenshotTaker == null) {
								m_ScreenshotTaker = gameObject.AddComponent<ScreenshotTaker> ();
						}
				}

				protected void HandleHotkeys ()
				{
			
						if (m_Config.m_UpdatePreviewHotkey.IsPressed ()) {
								UpdatePreview ();
						}
						if (m_Config.m_CaptureHotkey.IsPressed ()) {
								if (m_IsBurstActive) {
										StopBurst ();			
								} else {
										Capture ();
								}
						}
						if (m_Config.m_PauseHotkey.IsPressed ()) {
								TogglePause ();
						}
			
						if (m_Config.m_AlignHotkey.IsPressed ()) {
								AlignToView ();
						}
			
				}
		
				#if UNITY_EDITOR
				protected void RegisterUpdate ()
				{
						SceneView.onSceneGUIDelegate -= HandleEventsDelegate;
						SceneView.onSceneGUIDelegate += HandleEventsDelegate;					
				}

				protected void HandleEventsDelegate (SceneView sceneview)
				{
						HandleEditorHotkeys ();
				}

				public void HandleEditorHotkeys ()
				{
						Event e = Event.current;
						if (m_Config.m_UpdatePreviewHotkey.IsPressed (e)) {
								UpdatePreview ();
								e.Use ();
						}
						if (m_Config.m_CaptureHotkey.IsPressed (e)) {
								if (m_IsBurstActive) {
										StopBurst ();			
								} else {
										Capture ();
								}
								e.Use ();
						}
						if (m_Config.m_PauseHotkey.IsPressed (e)) {
								TogglePause ();
								e.Use ();
						}
					
						if (m_Config.m_AlignHotkey.IsPressed (e)) {
								AlignToView ();
								e.Use ();
						}
				}
				
				#endif



				#endregion


				#region NAME METHODS

				protected string ParseNameSymbols (string name, ScreenshotResolution resolution)
				{
						// Add a 0 before numbers if < 10
						if (System.DateTime.Now.Month < 10) {
								name = name.Replace ("{month}", "0{month}");
						}
						if (System.DateTime.Now.Day < 10) {
								name = name.Replace ("{day}", "0{day}");
						}
						if (System.DateTime.Now.Hour < 10) {
								name = name.Replace ("{hour}", "0{hour}");
						}
						if (System.DateTime.Now.Minute < 10) {
								name = name.Replace ("{minute}", "0{minute}");
						}
						if (System.DateTime.Now.Second < 10) {
								name = name.Replace ("{second}", "0{second}");
						}

						// Date
						name = name.Replace ("{year}", System.DateTime.Now.Year.ToString ());
						name = name.Replace ("{month}", System.DateTime.Now.Month.ToString ());
						name = name.Replace ("{day}", System.DateTime.Now.Day.ToString ());
						name = name.Replace ("{hour}", System.DateTime.Now.Hour.ToString ());
						name = name.Replace ("{minute}", System.DateTime.Now.Minute.ToString ());
						name = name.Replace ("{second}", System.DateTime.Now.Second.ToString ());

						// Dimensions
						name = name.Replace ("{width}", resolution.m_Width.ToString ());
						name = name.Replace ("{height}", resolution.m_Height.ToString ());
						name = name.Replace ("{scale}", resolution.m_Scale.ToString ());
						name = name.Replace ("{ratio}", resolution.m_Ratio).Replace (":", "_");

						// Resolution
						name = name.Replace ("{orientation}", resolution.m_Orientation.ToString ());
						name = name.Replace ("{name}", resolution.m_ResolutionName);
						name = name.Replace ("{ppi}", resolution.m_PPI.ToString ());
						name = name.Replace ("{category}", resolution.m_Category);
						name = name.Replace ("{percent}", resolution.m_Stats.ToString ());


						return name;
				}

				protected string GetExtension ()
				{
						if (m_Config.m_Format == TextureExporter.ImageFormat.PNG) {
								return ".png";
						} else {
								return ".jpg";
						}
				}



				public string GetPath ()
				{
						string path = "";
						if (m_Config.m_DestinationFolder == ScreenshotConfig.DestinationFolder.CUSTOM_FOLDER) {
								path = m_Config.m_CustomRootedPath;
						} else if (m_Config.m_DestinationFolder == ScreenshotConfig.DestinationFolder.PERSISTENT_DATA_PATH) {
								#if UNITY_EDITOR || UNITY_STANDALONE
								path = Application.persistentDataPath + "/" + m_Config.m_CustomRelativePath;
								#elif UNITY_ANDROID
								path = AndroidUtils.GetFirstAvailableMediaStorage()  + "/" +  m_Config.m_CustomRelativePath;
								#else 
								path = Application.persistentDataPath + "/" + m_Config.m_CustomRelativePath;
								#endif
						} else if (m_Config.m_DestinationFolder == ScreenshotConfig.DestinationFolder.DATA_PATH) {
								path = Application.dataPath + "/" + m_Config.m_CustomRelativePath;
						} else if (m_Config.m_DestinationFolder == ScreenshotConfig.DestinationFolder.PICTURES_FOLDER) {
								#if UNITY_EDITOR || UNITY_STANDALONE
								path = System.Environment.GetFolderPath (System.Environment.SpecialFolder.MyPictures) + "/" + m_Config.m_CustomRelativePath;
								#elif UNITY_ANDROID
								path = AndroidUtils.GetExternalPictureDirectory()  + "/" +  m_Config.m_CustomRelativePath;
								#elif UNITY_IOS
								path = Application.persistentDataPath + "/" + m_Config.m_CustomRelativePath;
								#else 
								path = Application.persistentDataPath + "/" + m_Config.m_CustomRelativePath;
								#endif
						}
						// Add a slash if not already at the end of the folder name
						if (path.Length > 0) {
								path = path.Replace ("//", "/");
								if (path [path.Length - 1] != '/' && path [path.Length - 1] != '\\') {
										path += "/";
								}
						}

						return path;
				}

				public string UpdateFileName (ScreenshotResolution resolution)
				{
						string filename = "";

						#if UNITY_EDITOR || !UNITY_WEBGL
						// Destination Folder
						filename += GetPath ();
						#endif

						// File name
						filename += ParseNameSymbols (m_Config.m_FileName, resolution);

						// Get the file extension
						string extension = GetExtension ();

						// Increment the file number if a file already exist
						if (!m_Config.m_OverrideFiles && File.Exists (filename + extension)) {
								int i = 1;
								while (File.Exists (filename + " (" + i.ToString () + ")" + extension)) {
										i++;
								}
								return filename + " (" + i.ToString () + ")" + extension;
						} else {
								return filename + extension;
						}
				}

				public bool IsValidPath (string path)
				{
						#if UNITY_EDITOR_WIN
						// Check thar first 3 chars are a drive letter
						if (path.Length < 3)
								return false;
						if (!Char.IsLetter (path [0]))
								return false;
						if (path [1] != ':')
								return false;
						if (path [2] != '\\' && path [2] != '/')
								return false;
						#endif

						if (String.IsNullOrEmpty (path)) {
								return false;
						}

						char[] invalids = Path.GetInvalidPathChars ();
						foreach (char c in invalids) {
								if (path.Contains (c.ToString ()))
										return false;
						}

						try {
								Path.GetFullPath (path);
						} catch {
								return false;
						}


						return true;
				}

				#endregion


				#region RESOLUTIONS METHODS

				public ScreenshotResolution GetFirstActiveResolution ()
				{
						var resolutions = GetActiveResolutions ();
						if (resolutions.Count > 0) {
								return resolutions [0];
						} 
						return m_GameViewResolution;
				}

				public void UpdateRatios ()
				{
						foreach (ScreenshotResolution res in m_Config.m_Resolutions) {
								res.UpdateRatio ();
						}
				}

				public void SetAllPortait ()
				{
						foreach (ScreenshotResolution res in m_Config.m_Resolutions) {
								res.m_Orientation = ScreenshotResolution.Orientation.PORTRAIT;
						}
				}

				public void SetAllLandscape ()
				{
						foreach (ScreenshotResolution res in m_Config.m_Resolutions) {
								res.m_Orientation = ScreenshotResolution.Orientation.LANDSCAPE;
						}
				}

				public void SelectAllResolutions ()
				{
						foreach (ScreenshotResolution res in m_Config.m_Resolutions) {
								res.m_Active = true;
						}
				}

				public void ClearAllResolutions ()
				{
						foreach (ScreenshotResolution res in m_Config.m_Resolutions) {
								res.m_Active = false;
						}
				}

				public void RemoveAllResolutions ()
				{
						m_Config.m_Resolutions.Clear ();
				}

				public void UpdateGameviewResolution ()
				{
						// Update the gameview screenshot resolution
						Vector2 size = GameViewController.GetCurrentGameViewSize ();

						m_GameViewResolution.m_Scale = 1;
						m_GameViewResolution.m_Width = (int)size.x;
						m_GameViewResolution.m_Height = (int)size.y;
				}

				public void UpdateResolutionFilenames (List<ScreenshotResolution> resolutions)
				{
						// Update filenames
						foreach (ScreenshotResolution resolution in resolutions) {
								resolution.m_FileName = UpdateFileName (resolution);
						}
				}

				public List<ScreenshotResolution> GetActiveResolutions ()
				{
						List<ScreenshotResolution> resolutions = new List<ScreenshotResolution> ();


						if (m_Config.m_CaptureMode != ScreenshotTaker.CaptureMode.FIXED_GAMEVIEW &&
						    m_Config.m_ResolutionCaptureMode == ScreenshotConfig.ResolutionMode.CUSTOM_RESOLUTIONS) {
								foreach (ScreenshotResolution resolution in m_Config.m_Resolutions) {

										// Ignore inactive ones
										if (resolution.m_Active == false)
												continue;

										// Ignore invalid ones
										if (!resolution.IsValid ())
												continue;

										resolutions.Add (resolution);
								}
						}

						if (m_Config.m_ResolutionCaptureMode == ScreenshotConfig.ResolutionMode.GAME_VIEW
						      || m_Config.m_CaptureMode == ScreenshotTaker.CaptureMode.FIXED_GAMEVIEW) {
								resolutions.Add (m_GameViewResolution);
						} 

						return resolutions;
				}

				#endregion

				#region EXPORT METHODS

				public void ExportAllToFiles ()
				{
						ExportToFiles (GetActiveResolutions ());
				}

				public void ExportToFiles (List<ScreenshotResolution> resolutions)
				{
						UpdateResolutionFilenames (resolutions);
						foreach (ScreenshotResolution resolution in resolutions) {
								if (TextureExporter.ExportToFile (resolution.m_Texture, resolution.m_FileName, m_Config.m_Format, (int)m_Config.m_JPGQuality)) {
										Debug.Log ("Image exported : " + resolution.m_FileName);
								}
						}
				}

				#endregion

				#region CAMERAS

				public List<ScreenshotCamera> GetActiveCameras ()
				{
						List<ScreenshotCamera> cameras = new List<ScreenshotCamera> ();


						if (m_Config.m_CameraMode == ScreenshotConfig.CamerasMode.CUSTOM_CAMERAS) {
								foreach (ScreenshotCamera camera in m_Config.m_Cameras) {

										// Ignore inactive ones
										if (camera.m_Active == false)
												continue;

										// Ignore invalid ones
										if (camera.m_Camera == null)
												continue;

										cameras.Add (camera);
								}
						}

						return cameras;
				}

				#endregion

				#region CAPTURE

				/// <summary>
				/// Captures the active resolutions.
				/// </summary>
				public void Capture ()
				{
						// Get resolutions to capture
						List<ScreenshotResolution> resolutions = GetActiveResolutions ();
						UpdateGameviewResolution ();

						// Capture the resolutions
						StartCoroutine (CaptureCoroutine (resolutions));

				}

				/// <summary>
				/// Updates all active resolutions.
				/// </summary>
				public void UpdateAll ()
				{
						// Get resolutions to capture
						List<ScreenshotResolution> resolutions = GetActiveResolutions ();
						UpdateGameviewResolution ();

						// Capture the resolutions
						Update (resolutions);
				}

				/// <summary>
				/// Updates the resolutions.
				/// </summary>
				public void Update (List<ScreenshotResolution> resolutions)
				{
						StartCoroutine (CaptureCoroutine (resolutions, false, false));
				}


				protected IEnumerator CaptureCoroutine (List<ScreenshotResolution> resolutions, bool exportMask = true, bool playSoundMask = true)
				{
						// Burst
						if (m_Config.m_ShotMode == ScreenshotConfig.ShotMode.BURST && !Application.isPlaying) {
								Debug.LogError ("In burst mode the application needs to be playing.");
								yield break;	
						}

						// Prevent multiple capture process		
						if (m_IsCapturing == true) {
								Debug.LogError ("A capture process is already running.");
								yield break;	
						}

						// We set capturing to true to prevent conflicts
						m_IsCapturing = true;
			
						// Hide guides if in-game preview
						if (Application.isPlaying && m_Config.m_PreviewInGameViewWhilePlaying && m_Config.m_ShowGuidesInPreview) {
								HideGuides ();
						}

						// Notify capture start
						onCaptureBeginDelegate ();

						// Capture
						if (m_Config.m_ShotMode == ScreenshotConfig.ShotMode.ONE_SHOT) {
								yield return StartCoroutine (UpdateCoroutine (resolutions, GetActiveCameras (), m_Config.m_Overlays, exportMask, playSoundMask));
						} else if (m_Config.m_ShotMode == ScreenshotConfig.ShotMode.BURST) {
								m_IsBurstActive = true;

								// Capture sequence
								for (int i = 0; i < m_Config.m_MaxBurstShotsNumber && m_IsBurstActive; ++i) {

										yield return StartCoroutine (UpdateCoroutine (resolutions, GetActiveCameras (), m_Config.m_Overlays, exportMask, playSoundMask));

										yield return new WaitForSeconds (m_Config.m_ShotTimeStep);
								}

								m_IsBurstActive = false;
						} 

						// Notify capture end
						onCaptureEndDelegate ();

						//Restore guides if in-game preview
						if (Application.isPlaying && m_Config.m_PreviewInGameViewWhilePlaying && m_Config.m_ShowGuidesInPreview) {
								ShowGuides ();
						} else {
								HideGuides ();
						}
			
						#if UNITY_EDITOR	
						// Refresh the gameview to trigger a paint event
						SceneView.RepaintAll ();
						#endif

						// Liberate the token
						m_IsCapturing = false;

				}

				public void StopBurst ()
				{
						// Set m_IsBurstActive to false so its coroutine loop will end
						m_IsBurstActive = false;
				}

				protected IEnumerator UpdateCoroutine (List<ScreenshotResolution> resolutions, List<ScreenshotCamera> cameras, List<ScreenshotOverlay> overlays, bool exportMask = true, bool playSoundMask = true)
				{
						// Update the filenames
						UpdateResolutionFilenames (resolutions);

						yield return StartCoroutine (m_ScreenshotTaker.CaptureScreenshotsCoroutine (resolutions, 
								cameras,
								overlays,
								(m_Config.m_CaptureMode == ScreenshotTaker.CaptureMode.GAMEVIEW_RESIZING && m_Config.m_ResolutionCaptureMode == ScreenshotConfig.ResolutionMode.GAME_VIEW) ? ScreenshotTaker.CaptureMode.FIXED_GAMEVIEW : m_Config.m_CaptureMode,
								(int)m_Config.m_MultisamplingAntiAliasing,
								exportMask,
								m_Config.m_Format,
								(int)m_Config.m_JPGQuality,
								m_Config.m_CaptureActiveUICanvas,
								m_Config.m_PlaySoundOnCapture && playSoundMask,
								m_Config.m_ColorFormat,			                                                                          
								m_Config.m_RecomputeAlphaLayer));
				}

				#endregion


				#region PREVIEW METHODS


				List<ScreenshotResolution> m_PreviewList = new List<ScreenshotResolution> ();

				public virtual void UpdatePreview ()
				{
						StartCoroutine (UpdatePreviewCoroutine ());
				}


				protected IEnumerator UpdatePreviewCoroutine ()
				{
						if (m_IsCapturing)
								yield break;

						m_IsCapturing = true;

						// Delegate call
						onCaptureBeginDelegate ();

						// Update resolutions
						m_PreviewList.Clear ();
						m_PreviewList.Add (GetFirstActiveResolution ());
						UpdateGameviewResolution ();
						UpdateResolutionFilenames (m_PreviewList);

						// Update overlays & guides
						m_PreviewOverlayList.Clear ();
						m_PreviewOverlayList.AddRange (m_Config.m_Overlays);
						if (m_Config.m_ShowGuidesInPreview) {
								m_GuidesOverlay = new ScreenshotOverlay (true, m_Config.m_GuideCanvas);
								m_PreviewOverlayList.Add (m_GuidesOverlay);
								ShowGuides ();
						}

						// Capture preview
						yield return StartCoroutine (m_ScreenshotTaker.CaptureScreenshotsCoroutine (m_PreviewList, 
								GetActiveCameras (),
								m_PreviewOverlayList,
								(m_Config.m_CaptureMode == ScreenshotTaker.CaptureMode.GAMEVIEW_RESIZING && m_Config.m_ResolutionCaptureMode == ScreenshotConfig.ResolutionMode.GAME_VIEW) ? ScreenshotTaker.CaptureMode.FIXED_GAMEVIEW : m_Config.m_CaptureMode,
								(int)m_Config.m_MultisamplingAntiAliasing,
								false,
								m_Config.m_Format,
								(int)m_Config.m_JPGQuality,
								m_Config.m_CaptureActiveUICanvas,
								false,
								m_Config.m_ColorFormat,			                                                                          
								m_Config.m_RecomputeAlphaLayer));

						// Restore guides
						if (Application.isPlaying && m_Config.m_PreviewInGameViewWhilePlaying && m_Config.m_ShowGuidesInPreview) {
								ShowGuides ();
						} else {
								HideGuides ();
						}

						// Delegate call
						onCaptureEndDelegate ();

						m_IsCapturing = false;

				}

				List<ScreenshotOverlay> m_PreviewOverlayList = new List<ScreenshotOverlay> ();
				ScreenshotOverlay m_GuidesOverlay;



				protected void InitIngamePreview ()
				{
						m_PreviewOverlayList.Clear ();			
						m_PreviewOverlayList.AddRange (m_Config.m_Overlays);
						if (m_Config.m_ShowGuidesInPreview) {
								m_GuidesOverlay = new ScreenshotOverlay (true, m_Config.m_GuideCanvas);
								m_PreviewOverlayList.Add (m_GuidesOverlay);
						}
						m_ScreenshotTaker.ApplySettings (GetActiveCameras (), m_PreviewOverlayList, m_Config.m_CaptureMode, m_Config.m_CaptureActiveUICanvas);
				}

				protected void ShowGuides ()
				{
						if (m_Config.m_ShowGuidesInPreview && m_Config.m_GuideCanvas != null) {
								m_Config.m_GuideCanvas.gameObject.SetActive (true);
								m_Config.m_GuideCanvas.enabled = true;
								Image[] images = m_Config.m_GuideCanvas.GetComponentsInChildren<Image> ();
								foreach (Image image in images) {
										image.color = m_Config.m_GuidesColor;
								}
						}
				}

				protected void HideGuides ()
				{
						if (m_Config.m_PreviewInGameViewWhilePlaying == true && Application.isPlaying && m_Config.m_ShowGuidesInPreview && !m_IsCapturing)
								return;

						if (m_Config.m_GuideCanvas != null) {
								m_Config.m_GuideCanvas.gameObject.SetActive (false);
						}
				}

				#endregion


				#region UTILS

				public void AlignToView ()
				{
						#if UNITY_EDITOR
						if (SceneView.lastActiveSceneView != null) {
								foreach (ScreenshotCamera camera in GetActiveCameras()) {
										Undo.RecordObject (camera.m_Camera.transform, "Changed Camera position");
										camera.m_Camera.transform.position = SceneView.lastActiveSceneView.camera.transform.position;
										camera.m_Camera.transform.rotation = SceneView.lastActiveSceneView.camera.transform.rotation;
								}
						}
						#endif
				}

				public void SetTime (float time)
				{
						if (time != m_Config.m_Time) {
								m_Config.m_Time = time;
								Time.timeScale = time;
						}
				}

				public void TogglePause ()
				{
						if (m_Config.m_Time == 0f) {
								SetTime (1f);
						} else {
								SetTime (0f);
						}
				}

				public bool CanCapture ()
				{
						if (m_Config.m_ShotMode == ScreenshotConfig.ShotMode.BURST && !Application.isPlaying) {
								return false;	
						}
						return true;
				}

				public int GetActiveCamerasCount ()
				{
						if (m_Config.m_CameraMode == ScreenshotConfig.CamerasMode.GAME_VIEW) {
								return 1;
						} 
						int i = 0;
						foreach (ScreenshotCamera camera in m_Config.m_Cameras) {
								if (camera.m_Active) {
										i++;
								}
						}
						return i;
				}

				#endregion

		}

}