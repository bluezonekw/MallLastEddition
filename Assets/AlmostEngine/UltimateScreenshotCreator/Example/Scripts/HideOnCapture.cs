using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using AlmostEngine.Screenshot;

namespace AlmostEngine.Examples
{
		/// <summary>
		/// Add this component to all objects you want to hide during the capture process.
		/// Note that it works only in play mode.
		/// </summary>
		public class HideOnCapture : MonoBehaviour
		{
				void Start ()
				{
						ScreenshotManager.onCaptureBeginDelegate += Hide;
						ScreenshotManager.onCaptureEndDelegate += Show;
				}

				void OnDestroy ()
				{
						ScreenshotManager.onCaptureBeginDelegate -= Hide;
						ScreenshotManager.onCaptureEndDelegate -= Show;
				}

				void Hide ()
				{
						this.gameObject.SetActive (false);
				}

				void Show ()
				{
						this.gameObject.SetActive (true);
				}
		}
}