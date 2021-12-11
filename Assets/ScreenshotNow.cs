using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;
public class ScreenshotNow : MonoBehaviour
{
    string toastString;
    string input;
    AndroidJavaObject currentActivity;
    AndroidJavaClass UnityPlayer;
    AndroidJavaObject context;


    public ArabicText Name, Phone, OrderNumber, Dateorder, DateArrival, Price;
    // Use this for initialization
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");
        }
    }
    public void showToastOnUiThread(string toastString)
    {
        this.toastString = toastString;
        currentActivity.Call("runOnUiThread", new AndroidJavaRunnable(showToast));
    }

    void showToast()
    {
        Debug.Log(this + ": Running on UI thread");

        AndroidJavaClass Toast = new AndroidJavaClass("android.widget.Toast");
        AndroidJavaObject javaString = new AndroidJavaObject("java.lang.String", toastString);
        AndroidJavaObject toast = Toast.CallStatic<AndroidJavaObject>("makeText", context, javaString, Toast.GetStatic<int>("LENGTH_SHORT"));
        toast.Call("show");
    }
    // Update is called once per frame
    void Update()
    {
      

    }
    public void Closescreen()
    {
       
        Destroy(gameObject);

    }
    public void SaveRecipt()
    {


        StartCoroutine(TakeScreenshotAndShare());





    }

    private IEnumerator TakeScreenshotAndShare()
    {
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        string filePath = Path.Combine(Application.temporaryCachePath,DateTime.Now.ToString("yyyy_MM_dd.HH_mm_ss") + "shared img.png");
        File.WriteAllBytes(filePath, ss.EncodeToPNG());

        // To avoid memory leaks
        Destroy(ss);

        //new NativeShare().AddFile(filePath).SetSubject("My Mall").SetText("My Recipt").Share();

        showToastOnUiThread("Saved in     "+filePath);
    }
}