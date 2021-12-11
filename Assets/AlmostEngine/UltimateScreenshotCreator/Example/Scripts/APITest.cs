using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using AlmostEngine.Screenshot;

namespace AlmostEngine.Examples
{
	public class APITest : MonoBehaviour
	{
		public int m_Width = 800;
		public int m_Height = 600;
		public int m_Scale = 1;
		public string m_FullpathA = "";
		public string m_FullpathB = "";
		public KeyCode m_ShortcutA = KeyCode.F6;
		public KeyCode m_ShortcutB = KeyCode.F7;

		void Update()
		{
			if (Input.GetKeyDown(m_ShortcutA)) {
				ScreenshotTaker taker = GameObject.FindObjectOfType<ScreenshotTaker>();
				// Capture the current screen at its current resolution, including UI
				taker.CaptureScreen(m_FullpathA);
			}
			if (Input.GetKeyDown(m_ShortcutB)) {
				ScreenshotTaker taker = GameObject.FindObjectOfType<ScreenshotTaker>();
				// Capture the screen at a custom resolution using render to texture.
				// You must specify the list of cameras to be used in that mode.
				// Here we use Camera.main, the first scene camera tagged as "MainCamera"
				List<Camera> cameras = new List<Camera>{ Camera.main };
				taker.CaptureScene(m_Width, m_Height, m_Scale, m_FullpathB, cameras, 8, TextureExporter.ImageFormat.JPG, 70);
			}
		}
	}
}

