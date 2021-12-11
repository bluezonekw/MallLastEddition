
//#define ULTIMATE_SCREENSHOT_DEBUG
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using System.IO;

namespace AlmostEngine.Screenshot
{
		[CustomEditor (typeof(ScreenshotManager))]
		public class ScreenshotManagerInspector : Editor
		{
				protected ScreenshotManager m_ScreenshotManager;
				public ReorderableList m_ResolutionReorderableList;
				public ReorderableList m_OverlayReorderableList;
				public ReorderableList m_CameraReorderableList;
				float m_PreviewWidth;
				float m_PreviewHeight;
				protected GUIStyle m_BoxStyle;

				#region CONSTRUCTORS

				//				SerializedProperty m_DontDestroyOnLoad;
				SerializedProperty m_DestinationFolder;
				SerializedProperty m_Format;
				SerializedProperty m_ColorFormat;
				SerializedProperty m_RecomputeAlphaLayer;
				SerializedProperty m_JPGQuality;
				SerializedProperty m_CaptureMode;
				SerializedProperty m_AntiAliasing;
				SerializedProperty m_Cameras;
				SerializedProperty m_CameraMode;
				SerializedProperty m_Resolutions;
				SerializedProperty m_ResolutionCaptureMode;
				SerializedProperty m_Overlays;
				SerializedProperty m_CaptureActiveUICanvas;
				SerializedProperty m_PreviewInGameViewWhilePlaying;
				SerializedProperty m_ShowGuidesInPreview;
				SerializedProperty m_GuideCanvas;
				SerializedProperty m_GuidesColor;
				SerializedProperty m_ShowPreview;
				SerializedProperty m_PreviewSize;
				SerializedProperty m_ShotMode;
				SerializedProperty m_MaxBurstShotsNumber;
				SerializedProperty m_ShotTimeStep;
				SerializedProperty m_PlaySoundOnCapture;
				SerializedProperty m_OverrideFiles;

				public virtual void OnEnable ()
				{
						m_ScreenshotManager = (ScreenshotManager)target;


//						m_DontDestroyOnLoad = serializedObject.FindProperty ("m_Config.m_DontDestroyOnLoad");
						m_DestinationFolder = serializedObject.FindProperty ("m_Config.m_DestinationFolder");
						m_Format = serializedObject.FindProperty ("m_Config.m_Format");
						m_ColorFormat = serializedObject.FindProperty ("m_Config.m_ColorFormat");
						m_RecomputeAlphaLayer = serializedObject.FindProperty ("m_Config.m_RecomputeAlphaLayer");
						m_JPGQuality = serializedObject.FindProperty ("m_Config.m_JPGQuality");
						m_CaptureMode = serializedObject.FindProperty ("m_Config.m_CaptureMode");
						m_AntiAliasing = serializedObject.FindProperty ("m_Config.m_MultisamplingAntiAliasing");
						m_Cameras = serializedObject.FindProperty ("m_Config.m_Cameras");
						m_CameraMode = serializedObject.FindProperty ("m_Config.m_CameraMode");
						m_Resolutions = serializedObject.FindProperty ("m_Config.m_Resolutions");
						m_ResolutionCaptureMode = serializedObject.FindProperty ("m_Config.m_ResolutionCaptureMode");
						m_Overlays = serializedObject.FindProperty ("m_Config.m_Overlays");
						m_CaptureActiveUICanvas = serializedObject.FindProperty ("m_Config.m_CaptureActiveUICanvas");
						m_PreviewInGameViewWhilePlaying = serializedObject.FindProperty ("m_Config.m_PreviewInGameViewWhilePlaying");
						m_ShowGuidesInPreview = serializedObject.FindProperty ("m_Config.m_ShowGuidesInPreview");
						m_GuideCanvas = serializedObject.FindProperty ("m_Config.m_GuideCanvas");
						m_GuidesColor = serializedObject.FindProperty ("m_Config.m_GuidesColor");
						m_ShowPreview = serializedObject.FindProperty ("m_Config.m_ShowPreview");
						m_PreviewSize = serializedObject.FindProperty ("m_Config.m_PreviewSize");
						m_ShotMode = serializedObject.FindProperty ("m_Config.m_ShotMode");
						m_MaxBurstShotsNumber = serializedObject.FindProperty ("m_Config.m_MaxBurstShotsNumber");
						m_ShotTimeStep = serializedObject.FindProperty ("m_Config.m_ShotTimeStep");
						m_PlaySoundOnCapture = serializedObject.FindProperty ("m_Config.m_PlaySoundOnCapture");
						m_OverrideFiles = serializedObject.FindProperty ("m_Config.m_OverrideFiles");



						CreateResolutionReorderableList ();
						CreateOverlayList ();
						CreateCameraReorderableList ();
				}

				protected GUIStyle m_CenteredGreyTextStyle;

				protected void InitBackgroundBoxStyle ()
				{
						m_BoxStyle = new GUIStyle (GUI.skin.box);
			
						if (m_CenteredGreyTextStyle == null) {
								m_CenteredGreyTextStyle = new GUIStyle ();
								m_CenteredGreyTextStyle.wordWrap = true;
								m_CenteredGreyTextStyle.alignment = TextAnchor.MiddleCenter;
								m_CenteredGreyTextStyle.fontSize = 10;
								m_CenteredGreyTextStyle.normal.textColor = Color.gray;
						}
				}

				#endregion

				public override void OnInspectorGUI ()
				{

						// catch events
						m_ScreenshotManager.HandleEditorHotkeys ();


						serializedObject.Update ();

						InitBackgroundBoxStyle ();


						EditorGUILayout.Separator ();




			
			
			
						EditorGUILayout.BeginVertical (m_BoxStyle);
						DrawCaptureModeUI ();
						EditorGUILayout.EndVertical ();
			
						EditorGUILayout.Separator ();
						EditorGUILayout.Separator ();



						EditorGUILayout.BeginVertical (m_BoxStyle);
						DrawFolderGUI ();
						EditorGUILayout.EndVertical ();
			


						EditorGUILayout.Separator ();
						EditorGUILayout.Separator ();

						EditorGUILayout.BeginVertical (m_BoxStyle);
						DrawNameGUI ();
						EditorGUILayout.EndVertical ();

						EditorGUILayout.Separator ();
						EditorGUILayout.Separator ();

						if (m_ScreenshotManager.m_Config.m_CaptureMode != ScreenshotTaker.CaptureMode.FIXED_GAMEVIEW) {
								EditorGUILayout.BeginVertical (m_BoxStyle);
								DrawResolutionGUI ();
								EditorGUILayout.EndVertical ();
						}

						EditorGUILayout.Separator ();
						EditorGUILayout.Separator ();


				
						EditorGUILayout.BeginVertical (m_BoxStyle);
						DrawCamerasGUI ();
						EditorGUILayout.EndVertical ();

						EditorGUILayout.Separator ();
						EditorGUILayout.Separator ();

						EditorGUILayout.BeginVertical (m_BoxStyle);
						DrawOverlaysGUI ();
						EditorGUILayout.EndVertical ();


						EditorGUILayout.Separator ();
						EditorGUILayout.Separator ();

						EditorGUILayout.BeginVertical (m_BoxStyle);
						DrawPreviewGUI ();
						EditorGUILayout.EndVertical ();

						EditorGUILayout.Separator ();
						EditorGUILayout.Separator ();

						EditorGUILayout.BeginVertical (m_BoxStyle);
						DrawCaptureGUI ();
						EditorGUILayout.EndVertical ();

						EditorGUILayout.Separator ();
						EditorGUILayout.Separator ();

						EditorGUILayout.BeginVertical (m_BoxStyle);
						DrawUtilsGUI ();
						EditorGUILayout.EndVertical ();

						EditorGUILayout.Separator ();
						EditorGUILayout.Separator ();


						EditorGUILayout.BeginVertical (m_BoxStyle);
						DrawConfigGUI ();
						EditorGUILayout.EndVertical ();

						EditorGUILayout.Separator ();
						EditorGUILayout.Separator ();
						DrawContactGUI ();




						#if ULTIMATE_SCREENSHOT_DEBUG

						EditorGUILayout.Separator();
						EditorGUILayout.Separator();
						DrawDebugGUI();

						#endif


						serializedObject.ApplyModifiedProperties ();

				}


				#region FOLDERS

				string newPath = "";

				protected void DrawFolderGUI ()
				{
						// Title
						m_ScreenshotManager.m_ShowDestination = EditorGUILayout.Foldout (m_ScreenshotManager.m_ShowDestination, "Destination".ToUpper ());
						if (m_ScreenshotManager.m_ShowDestination == false)
								return;
						EditorGUILayout.Separator ();

						// Select destination type
						EditorGUILayout.PropertyField (m_DestinationFolder);

						// Path
						if (m_ScreenshotManager.m_Config.m_DestinationFolder == ScreenshotConfig.DestinationFolder.CUSTOM_FOLDER) {

								EditorGUILayout.BeginHorizontal ();

								// Path
								newPath = EditorGUILayout.TextField (m_ScreenshotManager.m_Config.m_CustomRootedPath);
								if (newPath != m_ScreenshotManager.m_Config.m_CustomRootedPath) {
										m_ScreenshotManager.m_Config.m_CustomRootedPath = newPath;
										EditorUtility.SetDirty (m_ScreenshotManager);
								}

								// Browse button
								if (GUILayout.Button ("Browse", GUILayout.MaxWidth (70))) {
										newPath = EditorUtility.OpenFolderPanel ("Select destionation folder", m_ScreenshotManager.m_Config.m_CustomRootedPath, m_ScreenshotManager.m_Config.m_CustomRootedPath);
										if (newPath != m_ScreenshotManager.m_Config.m_CustomRootedPath) {
												m_ScreenshotManager.m_Config.m_CustomRootedPath = newPath;
												EditorUtility.SetDirty (m_ScreenshotManager);

												// Dirty hack
												// The TextField is conflicting with the browse field:
												// if the textfield is selected then it will not be updated after the folder selection.
												GUI.FocusControl ("");
										}
								}
								EditorGUILayout.EndHorizontal ();

						} else {
								EditorGUILayout.BeginHorizontal ();

								// Path
								newPath = EditorGUILayout.TextField (m_ScreenshotManager.m_Config.m_CustomRelativePath);
								if (newPath != m_ScreenshotManager.m_Config.m_CustomRelativePath) {
										m_ScreenshotManager.m_Config.m_CustomRelativePath = newPath;
										EditorUtility.SetDirty (m_ScreenshotManager);
								}

								EditorGUILayout.EndHorizontal ();
						}

						// Warning message
						if (!m_ScreenshotManager.IsValidPath (m_ScreenshotManager.GetPath ())) {
								EditorGUILayout.HelpBox ("Path \"" + m_ScreenshotManager.GetPath () + "\" is invalid.", MessageType.Warning);
						}

				}

				#endregion

				#region NAMES

				void OnNameSelectCallback (object target)
				{
						m_ScreenshotManager.m_Config.m_FileName = (string)target;

						// Dirty hack
						// The TextField is conflicting with the browse field:
						// if the textfield is selected then it will not be updated after the folder selection.
						GUI.FocusControl ("");
				}

				string fullName = "";

				protected void DrawNameGUI ()
				{
						//Title
						m_ScreenshotManager.m_ShowName = EditorGUILayout.Foldout (m_ScreenshotManager.m_ShowName, "File Name".ToUpper ());
						if (m_ScreenshotManager.m_ShowName == false)
								return;
						EditorGUILayout.Separator ();


						// Name
						EditorGUILayout.BeginHorizontal ();

						newPath = EditorGUILayout.TextField (m_ScreenshotManager.m_Config.m_FileName);
						if (newPath != m_ScreenshotManager.m_Config.m_FileName) {
								m_ScreenshotManager.m_Config.m_FileName = newPath;
								EditorUtility.SetDirty (m_ScreenshotManager);
						}

						// Create Name Examples Menu
						if (GUILayout.Button ("Examples", GUILayout.MaxWidth (70))) {
								var menu = new GenericMenu ();
								foreach (ScreenshotManager.NamePreset path in m_ScreenshotManager.m_NamePresets) {
					
										menu.AddItem (new GUIContent (path.m_Description), false, OnNameSelectCallback, path.m_Path);
								}
								menu.ShowAsContext ();
						}

						EditorGUILayout.EndHorizontal ();


						// Warning message
						if (m_ScreenshotManager.m_Config.m_Resolutions.Count > 0) {
								fullName = m_ScreenshotManager.UpdateFileName (m_ScreenshotManager.m_Config.m_Resolutions [0]);
						} else {
								fullName = m_ScreenshotManager.UpdateFileName (m_ScreenshotManager.m_GameViewResolution);
						}
						if (m_ScreenshotManager.m_Config.m_FileName == "" || m_ScreenshotManager.IsValidPath (m_ScreenshotManager.GetPath ()) && !m_ScreenshotManager.IsValidPath (fullName)) {
								EditorGUILayout.HelpBox ("Name is invalid.", MessageType.Warning);
						}
			
						// Override

			
						EditorGUILayout.PropertyField (m_OverrideFiles);


						// Format			
						if (m_ScreenshotManager.m_Config.m_CaptureMode != ScreenshotTaker.CaptureMode.FIXED_GAMEVIEW) {
								EditorGUILayout.PropertyField (m_Format);
								if (m_ScreenshotManager.m_Config.m_Format == TextureExporter.ImageFormat.JPG) {
										EditorGUI.indentLevel++;
										EditorGUILayout.Slider (m_JPGQuality, 1f, 100f);
										EditorGUI.indentLevel--;
								} else {
										EditorGUI.indentLevel++;
										EditorGUILayout.PropertyField (m_ColorFormat);
				
										if (m_ScreenshotManager.m_Config.m_ColorFormat == ScreenshotTaker.ColorFormat.RGBA) {
												EditorGUILayout.PropertyField (m_RecomputeAlphaLayer);
										}

										EditorGUI.indentLevel--;
								}
						}


						EditorGUILayout.Separator ();
						EditorGUILayout.Separator ();

						// Display full name
						EditorGUILayout.LabelField ("Full name: " + fullName, EditorStyles.miniLabel);

				}

				#endregion


				#region CAMERA

				void DrawCaptureModeUI ()
				{
						EditorGUILayout.PropertyField (m_CaptureMode);


						if (m_ScreenshotManager.m_Config.m_CaptureMode == ScreenshotTaker.CaptureMode.GAMEVIEW_RESIZING) {
								EditorGUILayout.HelpBox ("GAMEVIEW_RESIZING is for Editor and Windows Standalone only, can capture the UI, with custom resolutions.", MessageType.Info);
						} else if (m_ScreenshotManager.m_Config.m_CaptureMode == ScreenshotTaker.CaptureMode.RENDER_TO_TEXTURE) {
								EditorGUILayout.HelpBox ("RENDER_TO_TEXTURE is for Editor and all platforms, can not capture the UI, with custom resolutions.", MessageType.Info);
						} else if (m_ScreenshotManager.m_Config.m_CaptureMode == ScreenshotTaker.CaptureMode.FIXED_GAMEVIEW) {
								EditorGUILayout.HelpBox ("FIXED_GAMEVIEW is for Editor and all platforms, can capture the UI, only at the screen resolution.", MessageType.Info);
						}
			
						if (m_ScreenshotManager.m_Config.m_CaptureMode == ScreenshotTaker.CaptureMode.RENDER_TO_TEXTURE) {
								EditorGUI.indentLevel++;
								EditorGUILayout.PropertyField (m_AntiAliasing);
								EditorGUI.indentLevel--;

								if (m_ScreenshotManager.m_Config.m_MultisamplingAntiAliasing != ScreenshotConfig.AntiAliasing.NONE) {
										bool incompatibility = false;
										foreach (ScreenshotCamera camera in m_ScreenshotManager.m_Config.m_Cameras) {
												if (camera.m_Camera == null)
														continue;
												#if UNITY_5_6_OR_NEWER
						if (camera.m_Camera.allowHDR) {
												#else 
												if (camera.m_Camera.hdr) {
														#endif
														incompatibility = true;														
												}
										}
										if (incompatibility) {
												EditorGUILayout.HelpBox ("It is impossible to use MultiSampling Antialiasing when one or more camera is using HDR.", MessageType.Warning);
										}
								}

								if (!UnityVersion.HasPro ()) {
										EditorGUILayout.HelpBox ("RENDER_TO_TEXTURE requires Unity Pro or Unity 5.0 and later.", MessageType.Error);
								}
						}

				}

				void CreateCameraReorderableList ()
				{
						m_CameraReorderableList = new ReorderableList (serializedObject, m_Cameras, true, true, true, true);
						m_CameraReorderableList.drawElementCallback = (Rect position, int index, bool active, bool focused) => {
								SerializedProperty element = m_CameraReorderableList.serializedProperty.GetArrayElementAtIndex (index);
								EditorGUI.PropertyField (position, element);
						};
						m_CameraReorderableList.drawHeaderCallback = (Rect position) => {
								EditorGUI.LabelField (position, "Active             Camera                                                  Settings");
						};
						m_CameraReorderableList.onAddCallback = (ReorderableList list) => {
								m_ScreenshotManager.m_Config.m_Cameras.Add (new ScreenshotCamera ());
								EditorUtility.SetDirty (m_ScreenshotManager);
						};
						m_CameraReorderableList.elementHeight = 8 * 20;
				}

				void DrawCamerasGUI ()
				{
						// Title
						m_ScreenshotManager.m_ShowCameras = EditorGUILayout.Foldout (m_ScreenshotManager.m_ShowCameras, "Cameras".ToUpper ());
						if (m_ScreenshotManager.m_ShowCameras == false)
								return;


						EditorGUILayout.PropertyField (m_CameraMode);

						if (m_ScreenshotManager.m_Config.m_CameraMode == ScreenshotConfig.CamerasMode.CUSTOM_CAMERAS) {

								EditorGUILayout.Separator ();

				
								// List
								m_CameraReorderableList.DoLayoutList ();

						} else if (m_ScreenshotManager.m_Config.m_CaptureMode == ScreenshotTaker.CaptureMode.RENDER_TO_TEXTURE) {
								EditorGUILayout.HelpBox ("RENDER_TO_TEXTURE requires the use the CUSTOM_CAMERAS mode.", MessageType.Warning);
						}
				}


				#endregion

				#region RESOLUTIONS

				void CreateResolutionReorderableList ()
				{
						m_ResolutionReorderableList = new ReorderableList (serializedObject, m_Resolutions, true, true, true, true);
						m_ResolutionReorderableList.drawElementCallback = (Rect position, int index, bool active, bool focused) => {
								SerializedProperty element = m_ResolutionReorderableList.serializedProperty.GetArrayElementAtIndex (index);
								EditorGUI.PropertyField (position, element);
						};

						m_ResolutionReorderableList.onChangedCallback = (ReorderableList list) => {
								m_ScreenshotManager.UpdateRatios ();
								EditorUtility.SetDirty (m_ScreenshotManager);
						};

						m_ResolutionReorderableList.onSelectCallback = (ReorderableList list) => {
								m_ScreenshotManager.UpdateRatios ();
								EditorUtility.SetDirty (m_ScreenshotManager);
						};

						m_ResolutionReorderableList.drawHeaderCallback = (Rect position) => {
				
								if (typeof(ScreenshotManager).Assembly.GetType ("AlmostEngine.Preview.ResolutionGalleryWindow") != null) {
										EditorGUI.LabelField (position, "Active  Width     Height  Scale Ratio   Orientation        PPI/Forced       %             Name                 Category");
								} else {
										EditorGUI.LabelField (position, "Active  Width     Height  Scale Ratio   Orientation        Name                 Category");
								}
						};



						m_ResolutionReorderableList.onAddDropdownCallback = (Rect position, ReorderableList list) => {
								var menu = new GenericMenu ();

								ConstructResolutionPresetsMenu (menu);

								menu.AddItem (new GUIContent ("custom"), false, OnResolutionSelectCallback, new ScreenshotResolution ());

								menu.ShowAsContext ();
						};
			
				}

				void ConstructResolutionPresetsMenu (GenericMenu menu)
				{
						foreach (string key in ScreenshotManager.m_Categories.Keys) {
								menu.AddItem (new GUIContent (key + "/(add all)"), false, OnResolutionSelectAllCallback, ScreenshotManager.m_Categories [key]);
						}

						foreach (ScreenshotResolution res in ScreenshotManager.m_ResolutionPresets) {
								string name = res.m_Category + "/" + res.ToString ();
								menu.AddItem (new GUIContent (name), false, OnResolutionSelectCallback, res);
						}
						EditorUtility.SetDirty (m_ScreenshotManager);
				}

				void OnResolutionSelectAllCallback (object target)
				{
						List<ScreenshotResolution> selection = (List<ScreenshotResolution>)target;
						foreach (ScreenshotResolution res in selection) {
								m_ScreenshotManager.m_Config.m_Resolutions.Add (new ScreenshotResolution (res));
						}
						m_ScreenshotManager.UpdateRatios ();
						EditorUtility.SetDirty (m_ScreenshotManager);
				}

				void OnResolutionSelectCallback (object target)
				{
						ScreenshotResolution selection = (ScreenshotResolution)target;
						m_ScreenshotManager.m_Config.m_Resolutions.Add (new ScreenshotResolution (selection));
						m_ScreenshotManager.UpdateRatios ();
						EditorUtility.SetDirty (m_ScreenshotManager);
				}

				protected virtual void DrawResolutionGUI ()
				{
						// Title
						m_ScreenshotManager.m_ShowResolutions = EditorGUILayout.Foldout (m_ScreenshotManager.m_ShowResolutions, "Resolutions".ToUpper ());
						if (m_ScreenshotManager.m_ShowResolutions == false)
								return;
			
						EditorGUILayout.PropertyField (m_ResolutionCaptureMode);
						EditorGUILayout.Separator ();


						if (m_ScreenshotManager.m_Config.m_ResolutionCaptureMode == ScreenshotConfig.ResolutionMode.CUSTOM_RESOLUTIONS) {


								// Buttons
								EditorGUILayout.BeginHorizontal ();
								if (GUILayout.Button ("Select all")) {
										m_ScreenshotManager.SelectAllResolutions ();
										EditorUtility.SetDirty (m_ScreenshotManager);
								}
								if (GUILayout.Button ("Deselect all")) {
										m_ScreenshotManager.ClearAllResolutions ();
										EditorUtility.SetDirty (m_ScreenshotManager);
								}
								if (GUILayout.Button ("Remove all")) {
										m_ScreenshotManager.RemoveAllResolutions ();
										EditorUtility.SetDirty (m_ScreenshotManager);
								}
								EditorGUILayout.EndHorizontal ();
				
								EditorGUILayout.BeginHorizontal ();
								if (GUILayout.Button ("Set all Portait")) {
										m_ScreenshotManager.SetAllPortait ();
										EditorUtility.SetDirty (m_ScreenshotManager);
								}
								if (GUILayout.Button ("Set all Landscape")) {
										m_ScreenshotManager.SetAllLandscape ();
										EditorUtility.SetDirty (m_ScreenshotManager);
								}
								EditorGUILayout.EndHorizontal ();

								EditorGUILayout.Space ();

								// List
								m_ResolutionReorderableList.DoLayoutList ();
						}

				}

				#endregion

				#region OVERLAYS

				void CreateOverlayList ()
				{
						m_OverlayReorderableList = new ReorderableList (serializedObject, m_Overlays, true, true, true, true);
						m_OverlayReorderableList.drawElementCallback = (Rect position, int index, bool active, bool focused) => {
								SerializedProperty element = m_OverlayReorderableList.serializedProperty.GetArrayElementAtIndex (index);
								EditorGUI.PropertyField (position, element);
						};
						m_OverlayReorderableList.drawHeaderCallback = (Rect position) => {
								EditorGUI.LabelField (position, "Active     Canvas");
						};
				}

				void DrawOverlaysGUI ()
				{
						// Title
						m_ScreenshotManager.m_ShowCanvas = EditorGUILayout.Foldout (m_ScreenshotManager.m_ShowCanvas, "Overlays".ToUpper ());
						if (m_ScreenshotManager.m_ShowCanvas == false)
								return;
						EditorGUILayout.Separator ();
			
			
						// Auto add

			
						EditorGUILayout.PropertyField (m_CaptureActiveUICanvas);

						if (m_ScreenshotManager.m_Config.m_CaptureActiveUICanvas && m_ScreenshotManager.m_Config.m_CaptureMode == ScreenshotTaker.CaptureMode.RENDER_TO_TEXTURE) {
								EditorGUILayout.HelpBox ("Note that Screenspace Overlay Canvas and Overlays can not be rendered in RENDER_TO_TEXTURE mode.", MessageType.Info);
						} else if (m_ScreenshotManager.m_Config.m_CaptureActiveUICanvas && m_ScreenshotManager.m_Config.m_CameraMode == ScreenshotConfig.CamerasMode.CUSTOM_CAMERAS) {
								EditorGUILayout.HelpBox ("Note that some of your UI will not be rendered if its layer isn't in any active camera culling mask.", MessageType.Info);
						}
			
						EditorGUILayout.Separator ();



						// List
						m_OverlayReorderableList.DoLayoutList ();

				}

				#endregion

				#region PREVIEW



				void DrawPreviewGUI ()
				{

						// Title
						m_ScreenshotManager.m_ShowPreview = EditorGUILayout.Foldout (m_ScreenshotManager.m_ShowPreview, "Preview".ToUpper ());
						if (m_ScreenshotManager.m_ShowPreview == false)
								return;
						EditorGUILayout.Separator ();


						EditorGUILayout.PropertyField (m_PreviewInGameViewWhilePlaying);
						EditorGUILayout.Separator ();
						EditorGUILayout.Separator ();


						EditorGUILayout.PropertyField (m_ShowGuidesInPreview);
						EditorGUILayout.PropertyField (m_GuideCanvas);
						EditorGUILayout.PropertyField (m_GuidesColor);


						EditorGUILayout.Separator ();
						EditorGUILayout.PropertyField (m_ShowPreview);


						if (m_ScreenshotManager.m_Config.m_ShowPreview) {
				
								EditorGUILayout.Slider (m_PreviewSize, 0.05f, 1f);



								// Draw preview texture if any
								if (m_ScreenshotManager.GetFirstActiveResolution ().m_Texture != null) {



										// On repaint event, compute the preview dimensions and update the texture if needed
										#if UNITY_2017_3_OR_NEWER
										if (Event.current.type == EventType.Repaint) {
										#else
										if (Event.current.type == EventType.repaint) {
										#endif

												if (m_ScreenshotManager.GetFirstActiveResolution ().IsValid ()) {

														m_PreviewWidth = m_ScreenshotManager.m_Config.m_PreviewSize * GUILayoutUtility.GetLastRect ().width;
														m_PreviewHeight = m_PreviewWidth * m_ScreenshotManager.GetFirstActiveResolution ().m_Texture.height / m_ScreenshotManager.GetFirstActiveResolution ().m_Texture.width;

												}
										}


										// Draw an empty label to make some place to display the preview texture
										EditorGUILayout.LabelField ("", GUILayout.Height (m_PreviewHeight));

										Rect previewRect = GUILayoutUtility.GetLastRect ();
										previewRect.x = previewRect.x + previewRect.width / 2 - m_PreviewWidth / 2;
										previewRect.width = m_PreviewWidth;
										previewRect.height = m_PreviewHeight;
										EditorGUI.DrawPreviewTexture (previewRect, m_ScreenshotManager.GetFirstActiveResolution ().m_Texture);
								} else {
										EditorGUILayout.Separator ();
										EditorGUILayout.Separator ();
										EditorGUILayout.LabelField ("Press update to create the preview image.", m_CenteredGreyTextStyle);
										EditorGUILayout.Separator ();
								}

								// Button
								if (GUILayout.Button ("Update")) {
										m_ScreenshotManager.UpdatePreview ();
								}

						}


				}

				#endregion

				#region CAPTURE



				protected virtual void DrawCaptureGUI ()
				{
						// Title
						m_ScreenshotManager.m_ShowCapture = EditorGUILayout.Foldout (m_ScreenshotManager.m_ShowCapture, "Capture".ToUpper ());
						if (m_ScreenshotManager.m_ShowCapture == false)
								return;
						EditorGUILayout.Separator ();

						// Mode selection
						EditorGUILayout.PropertyField (m_ShotMode);
						if (m_ScreenshotManager.m_Config.m_ShotMode == ScreenshotConfig.ShotMode.BURST) {
								EditorGUI.indentLevel++;
								EditorGUILayout.PropertyField (m_MaxBurstShotsNumber);
								EditorGUILayout.PropertyField (m_ShotTimeStep);
								EditorGUI.indentLevel--;
						}

						EditorGUILayout.Space ();
						EditorGUILayout.Space ();


						// Buttons
						EditorGUILayout.BeginHorizontal ();

						// If can not capture, set button to disabled
						// else set a green background
						if (m_ScreenshotManager.CanCapture ()) {
								GUI.color = new Color (0.6f, 1f, 0.6f, 1.0f);
						} else {
								GUI.enabled = false;
						}


						if (m_ScreenshotManager.m_Config.m_ShotMode == ScreenshotConfig.ShotMode.ONE_SHOT) {
								if (GUILayout.Button ("Take screenshot(s)", GUILayout.Height (50))) {
										m_ScreenshotManager.Capture ();
								}
						} else if (m_ScreenshotManager.m_Config.m_ShotMode == ScreenshotConfig.ShotMode.BURST) {
				
								if (m_ScreenshotManager.m_IsBurstActive) {
										if (GUILayout.Button ("Stop", GUILayout.Height (50))) {
												m_ScreenshotManager.StopBurst ();
										}
								} else {
										if (GUILayout.Button ("Start Burst Shot", GUILayout.Height (50))) {
												m_ScreenshotManager.Capture ();
										}
								}

						}

						// Restaure GUI
						GUI.enabled = true;
						GUI.color = Color.white;

						// Show button
						if (GUILayout.Button ("Show", GUILayout.MaxWidth (70), GUILayout.Height (50))) {
								EditorUtility.RevealInFinder (m_ScreenshotManager.GetPath ());
						}

						EditorGUILayout.EndHorizontal ();

						// Info message
						if (!m_ScreenshotManager.CanCapture ()) {
								EditorGUILayout.HelpBox ("The application needs to be playing to take the screenshots.", MessageType.Info);
						}
			
						if (m_ScreenshotManager.m_Config.m_ShotMode == ScreenshotConfig.ShotMode.BURST
						    && m_ScreenshotManager.m_Config.m_PreviewInGameViewWhilePlaying && m_ScreenshotManager.GetActiveResolutions ().Count > 1) {
								EditorGUILayout.HelpBox ("In burst mode and PreviewInGameViewWhilePlaying mode, it is recommanded to only capture one resolution at a time to prevent GameView deformationss while capturing.", MessageType.Warning);
						}

						// Warning message
						if (m_ScreenshotManager.m_Config.m_ShotMode == ScreenshotConfig.ShotMode.BURST
						    && m_ScreenshotManager.m_Config.m_OverrideFiles) {
								EditorGUILayout.HelpBox ("The file override mode is enabled: burst screenshots are probably going to be overrided. Set override to false to automatically increment screenshot names.", MessageType.Warning);

						}


						EditorGUILayout.Space ();
				}

				#endregion


				#region UTILS


				protected virtual void DrawUtilsGUI ()
				{
						// Title
						m_ScreenshotManager.m_ShowUtils = EditorGUILayout.Foldout (m_ScreenshotManager.m_ShowUtils, "Utils".ToUpper ());
						if (m_ScreenshotManager.m_ShowUtils == false)
								return;
						EditorGUILayout.Separator ();





						// Time
						EditorGUILayout.BeginHorizontal ();
						EditorGUILayout.LabelField ("Time scale");
						float timeScale = m_ScreenshotManager.m_Config.m_Time;
						float time = EditorGUILayout.Slider (timeScale, 0f, 1f);
						if (time != timeScale) {
								m_ScreenshotManager.SetTime (time);
						}
						EditorGUILayout.EndHorizontal ();

						// Pause button
						if (Time.timeScale == 0f) {
								if (GUILayout.Button ("Resume game (set time scale to 1)")) {
										m_ScreenshotManager.TogglePause ();
								} 
						} else {
								if (GUILayout.Button ("Pause game (set time scale to 0)")) {
										m_ScreenshotManager.TogglePause ();
								} 
						}

						// Align
						if (GUILayout.Button ("Align cameras to view")) {
								m_ScreenshotManager.AlignToView ();
						}



				}

				protected virtual void DrawConfigGUI ()
				{
						// Title
						m_ScreenshotManager.m_ShowHotkeys = EditorGUILayout.Foldout (m_ScreenshotManager.m_ShowHotkeys, "Misc.".ToUpper ());
						if (m_ScreenshotManager.m_ShowHotkeys == false)
								return;
						EditorGUILayout.Separator ();


						// Hotkeys
						DrawHotkey ("Capture Key", m_ScreenshotManager.m_Config.m_CaptureHotkey);
						DrawHotkey ("Align To View Key", m_ScreenshotManager.m_Config.m_AlignHotkey);
						DrawHotkey ("Update Preview Key", m_ScreenshotManager.m_Config.m_UpdatePreviewHotkey);
						DrawHotkey ("Pause Key (ingame only)", m_ScreenshotManager.m_Config.m_PauseHotkey);

			
						EditorGUILayout.HelpBox ("Note that the hotkeys only work when focused on the SceneView, on the inspector, or in Playing mode.", MessageType.Info);

						EditorGUILayout.Separator ();
						EditorGUILayout.Separator ();

						// Sounds
						EditorGUILayout.PropertyField (m_PlaySoundOnCapture);
//						EditorGUILayout.PropertyField (m_DontDestroyOnLoad);

						EditorGUILayout.Separator ();
						EditorGUILayout.Separator ();



						if (GUILayout.Button ("Reset state")) {
								m_ScreenshotManager.Reset ();
						}
						if (GUILayout.Button ("Clear cache")) {
								m_ScreenshotManager.ClearCache ();
						}



				}

				protected void DrawHotkey (string name, HotKey key)
				{
						EditorGUILayout.BeginHorizontal ();

						EditorGUILayout.LabelField (name);

						bool shift = EditorGUILayout.ToggleLeft ("Shift", key.m_Shift, GUILayout.MaxWidth (45));
						if (shift != key.m_Shift) {
								EditorUtility.SetDirty (m_ScreenshotManager);
								key.m_Shift = shift;
						}

						bool control = EditorGUILayout.ToggleLeft ("Control", key.m_Control, GUILayout.MaxWidth (60));
						if (control != key.m_Control) {
								EditorUtility.SetDirty (m_ScreenshotManager);
								key.m_Control = control;
						}

						bool alt = EditorGUILayout.ToggleLeft ("Alt", key.m_Alt, GUILayout.MaxWidth (40));
						if (alt != key.m_Alt) {
								EditorUtility.SetDirty (m_ScreenshotManager);
								key.m_Alt = alt;
						}

						KeyCode k = (KeyCode)EditorGUILayout.EnumPopup (key.m_Key);
						if (k != key.m_Key) {
								EditorUtility.SetDirty (m_ScreenshotManager);
								key.m_Key = k;
						}
			                  
						EditorGUILayout.EndHorizontal ();




				}

				protected virtual void DrawContactGUI ()
				{
						EditorGUILayout.LabelField (UltimateScreenshotCreator.VERSION, m_CenteredGreyTextStyle);
						EditorGUILayout.LabelField (UltimateScreenshotCreator.AUTHOR, m_CenteredGreyTextStyle);
				}


				#endregion





				#region DEBUG

				void DrawDebugGUI ()
				{

						EditorGUILayout.PropertyField (serializedObject.FindProperty ("m_IsBurstActive"));
						EditorGUILayout.PropertyField (serializedObject.FindProperty ("m_IsCapturing"));
						EditorGUILayout.PropertyField (serializedObject.FindProperty ("m_IsCapturingPreview"));
						
						EditorGUILayout.LabelField ("Overlays");
						foreach (ScreenshotOverlay k in m_ScreenshotManager.m_Config.m_Overlays) {
								EditorGUILayout.LabelField ("[" + k.m_Canvas.ToString () + "] " + k.m_SettingStack.Count);
						}
			
						EditorGUILayout.LabelField ("Cameras");
						foreach (ScreenshotCamera k in m_ScreenshotManager.m_Config.m_Cameras) {
								EditorGUILayout.LabelField ("[" + k.m_Camera.ToString () + "] " + k.m_SettingStack.Count);
						}
			
				}

				#endregion


		}
}