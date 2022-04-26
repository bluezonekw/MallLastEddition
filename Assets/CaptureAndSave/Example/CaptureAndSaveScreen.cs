using UnityEngine;
using System.Collections;

public class CaptureAndSaveScreen : MonoBehaviour {
	
	string x = "0";
	string y = "0";
	string width = "0";
	string height = "0";

	public Texture2D tex, watermark;

	CaptureAndSave snapShot ;

	string log="Log";
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
		if(GUI.Button(new Rect(20,20,150,50),"Save Full Screen"))
		{
			snapShot.CaptureAndSaveToAlbum(ImageType.JPG);
			//snapShot.CaptureAndSaveAtPath(System.IO.Path.Combine(Application.persistentDataPath,"Image.jpg"),ImageType.JPG);
		}

		if(GUI.Button(new Rect(200,20,170,50),"Save in double resolution"))
		{
			snapShot.CaptureAndSaveToAlbum(Screen.width * 2, Screen.height * 2, Camera.main,ImageType.JPG);
		}

		if(GUI.Button(new Rect(380,20,170,50),"Save with watermark"))
		{
			snapShot.CaptureAndSaveToAlbum(Screen.width, Screen.height, Camera.main,ImageType.JPG, watermark, WatermarkAlignment.TOP_LEFT);
		}

		GUI.Label(new Rect(20,70,500,20),"------------------------------------------------------------------------------------------------------------------------------");

		GUI.Label(new Rect(20,100,50,20),"X : ");
		x = GUI.TextField(new Rect(80,100,50,20),x);

		GUI.Label(new Rect(160,100,50,20),"Y : ");
		y = GUI.TextField(new Rect(200,100,50,20),y);

		GUI.Label(new Rect(20,130,50,20),"Width : ");
		width = GUI.TextField(new Rect(80,130,50,20),width);

		GUI.Label(new Rect(150,130,50,20),"Height : ");
		height = GUI.TextField(new Rect(200,130,50,20),height);

		if(GUI.Button(new Rect(20,160,150,50),"Save Selected Screen") && int.Parse(width) > 0 && int.Parse(height) > 0)
		{
			snapShot.CaptureAndSaveToAlbum(int.Parse(x),int.Parse(y),int.Parse(width),int.Parse(height),ImageType.JPG);
		}
		if(GUI.Button(new Rect(200,160,250,50),"Save Selected Screen with watermark") && int.Parse(width) > 0 && int.Parse(height) > 0)
		{
			snapShot.CaptureAndSaveToAlbum(int.Parse(x),int.Parse(y),int.Parse(width),int.Parse(height),ImageType.JPG,watermark,WatermarkAlignment.CENTER);
		}

	
		GUI.Label(new Rect(20,230,500,20),"------------------------------------------------------------------------------------------------------------------------------");
		GUI.Label(new Rect(70,250,200,50),"Click This Texture to Save");
		if(GUI.Button(new Rect(50,270,200,200),tex) && tex != null)
		{
			snapShot.SaveTextureToGallery(tex,ImageType.JPG);
		}


		if (GUI.Button (new Rect (Screen.width - 120, 10, 100, 40), "Next")) {
			UnityEngine.SceneManagement.SceneManager.LoadScene (2);
		}
	}
}
