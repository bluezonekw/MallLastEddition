using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using AlmostEngine.Screenshot;

namespace AlmostEngine.Examples
{
		public class ValidationCanvas : MonoBehaviour
		{

				ScreenshotManager m_ScreenshotManager;
				public Canvas m_Canvas;
				public RectTransform m_ImageContainer;
				public RawImage m_Texture;

				void Start ()
				{
						m_ScreenshotManager = GameObject.FindObjectOfType<ScreenshotManager> ();
				}

				/// <summary>
				/// Call this method to start a screenshot capture process and display the validation canvas when the capture is completed.
				/// </summary>
				public void Capture ()
				{
						// Start listening to end capture event
						ScreenshotManager.onCaptureEndDelegate += OnCaptureEndDelegate;

						// Call update to only capture the texture without exporting
						m_ScreenshotManager.UpdateAll ();
				}

				#region Event callbacks

				public void OnCaptureEndDelegate ()
				{
						// Stop listening the callback
						ScreenshotManager.onCaptureEndDelegate -= OnCaptureEndDelegate;

						// Update the texture image
						m_Texture.texture = m_ScreenshotManager.GetFirstActiveResolution ().m_Texture;

						// Scale the texture to fit its parent size
						m_Texture.SetNativeSize ();
						float scaleCoeff = m_ImageContainer.rect.height / m_Texture.texture.height;
						m_Texture.transform.localScale = new Vector3 (scaleCoeff, scaleCoeff, scaleCoeff);

						// Show canvas
						m_Canvas.enabled = true;
				}

				#endregion

				#region UI callbacks

				public void OnDiscardCallback ()
				{
						// Hide canvas
						m_Canvas.enabled = false;
				}

				public void OnSaveCallback ()
				{
						// Export the screenshots to files
						m_ScreenshotManager.ExportAllToFiles ();

						// Hide canvas
						m_Canvas.enabled = false;
				}

				#endregion
		}
}
