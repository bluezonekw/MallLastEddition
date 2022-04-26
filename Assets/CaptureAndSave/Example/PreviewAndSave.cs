using UnityEngine;
using System.Collections;

public class PreviewAndSave : MonoBehaviour {

	public Texture2D watermark;

	Texture2D tex;

	CaptureAndSave snapShot ;

	void Start()
	{
		snapShot = GameObject.FindObjectOfType<CaptureAndSave>();
	}

	void OnEnable()
	{
		CaptureAndSaveEventListener.onError += OnError;
		CaptureAndSaveEventListener.onSuccess += OnSuccess;
		CaptureAndSaveEventListener.onScreenShotInvoker += OnScreenShot;
	}

	void OnDisable()
	{
		CaptureAndSaveEventListener.onError -= OnError;
		CaptureAndSaveEventListener.onSuccess -= OnSuccess;
		CaptureAndSaveEventListener.onScreenShotInvoker -= OnScreenShot;
	}

	void OnError(string error)
	{
		Debug.Log ("Error : "+error);
	}

	void OnSuccess(string msg)
	{
		Debug.Log ("Success : "+msg);
	}

	void OnScreenShot(Texture2D tex2D)
	{
		// assign screenshot
		tex = tex2D;
	}


	void OnGUI()
	{
		if(GUI.Button(new Rect(0,5,150,50),"Get Screenshot"))
		{
			snapShot.GetFullScreenShot(ImageType.JPG);
			//snapShot.GetFullScreenShot(ImageType.JPG, watermark, WatermarkAlignment.TOP_RIGHT);// save with watermark
		}

		if(tex != null && GUI.Button(new Rect(160,5,150,50),"Save"))
		{
			// save screenshot
			snapShot.SaveTextureToGallery(tex,ImageType.JPG);
		}

		// preview
		if(tex != null)
			GUI.Label (new Rect (0, 60, Screen.width,Screen.height),tex);


		if (GUI.Button (new Rect (Screen.width - 120, 10, 100, 40), "Next")) {
			UnityEngine.SceneManagement.SceneManager.LoadScene (0);
		}
	}
}
