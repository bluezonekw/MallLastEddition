using UnityEngine;
using System.Collections;

public class CaptureAndSaveCamera : MonoBehaviour {
	
#if UNITY_5

	public Texture2D watermark;

	CaptureAndSave snapShot ;

	string log="Log:\n";

	void Start()
	{
		snapShot = GameObject.FindObjectOfType<CaptureAndSave>();
	}

	void OnEnable()
	{
		CaptureAndSaveEventListener.onError += OnError;
		CaptureAndSaveEventListener.onSuccess += OnSuccess;
	}

	void OnDisable()
	{
		CaptureAndSaveEventListener.onError += OnError;
		CaptureAndSaveEventListener.onSuccess += OnSuccess;
	}

	void OnError(string error)
	{
		log += "\n"+error;
		Debug.Log ("Error : "+error);
	}

	void OnSuccess(string msg)
	{
		log += "\n"+msg;
		Debug.Log ("Success : "+msg);
	}

	void OnGUI()
	{
		GUILayout.Label (log);

		if(GUI.Button(new Rect(Screen.width/2 - 210, Screen.height-120,200,120),"Save in double resolution"))
		{
			snapShot.CaptureAndSaveToAlbum(Screen.width * 2, Screen.height * 2, Camera.main,ImageType.JPG);
		}

		if(GUI.Button(new Rect(Screen.width/2 + 30, Screen.height-120,200,120),"Save with watermark"))
		{
			snapShot.CaptureAndSaveToAlbum(Screen.width, Screen.height, Camera.main,ImageType.JPG,watermark,WatermarkAlignment.BOTTOM_RIGHT);
		}


		if (GUI.Button (new Rect (Screen.width - 120, 10, 100, 40), "Next")) {
			UnityEngine.SceneManagement.SceneManager.LoadScene (1);
		}
	}
#endif
}
