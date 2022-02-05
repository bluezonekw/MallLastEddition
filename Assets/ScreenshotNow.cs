using UnityEngine;
using UnityEngine.UI;
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
public Text TName, TPhone, TOrderNumber, TDateorder, TDateArrival, TPrice;

public Text HTName, HTPhone, HTOrderNumber, HTDateorder, HTDateArrival, HTPrice;
public ArabicText Title,HName, HPhone, HOrderNumber, HDateorder, HDateArrival, HPrice;
    // Use this for initialization
    void Start()
    {


if (UPDownMenu.LanguageValue == 1)
        {
HTName.alignment= TextAnchor.MiddleLeft;
HTPhone.alignment= TextAnchor.MiddleLeft;
HTOrderNumber.alignment= TextAnchor.MiddleLeft;
HTDateorder.alignment= TextAnchor.MiddleLeft;
HTDateArrival.alignment= TextAnchor.MiddleLeft;
HTPrice.alignment= TextAnchor.MiddleLeft;
Title.Text="Recipt";
HName.Text="Name:";
HPhone.Text="Phone:";
HOrderNumber.Text="Order NO:";
HDateorder.Text="Order Date:";
HDateArrival.Text="Order Arrive:";
HPrice.Text="Price:";



TName.alignment= TextAnchor.MiddleRight;
TPhone.alignment= TextAnchor.MiddleRight;
TOrderNumber.alignment= TextAnchor.MiddleRight;
TDateorder.alignment= TextAnchor.MiddleRight;
TDateArrival.alignment= TextAnchor.MiddleRight;
TPrice.alignment= TextAnchor.MiddleRight;



  }
        else
        {
HTName.alignment= TextAnchor.MiddleRight;
HTPhone.alignment= TextAnchor.MiddleRight;
HTOrderNumber.alignment= TextAnchor.MiddleRight;
HTDateorder.alignment= TextAnchor.MiddleRight;
HTDateArrival.alignment= TextAnchor.MiddleRight;
HTPrice.alignment= TextAnchor.MiddleRight;
Title.Text="فاتــــــــورة";
HName.Text="الاسم:";
HPhone.Text="الهاتف:";
HOrderNumber.Text="رقم الطلب:";
HDateorder.Text="تاريخ الطلب:";
HDateArrival.Text="تاريخ التوصيل:";
HPrice.Text="السعـــر:";




TName.alignment= TextAnchor.MiddleLeft;
TPhone.alignment= TextAnchor.MiddleLeft;
TOrderNumber.alignment= TextAnchor.MiddleLeft;
TDateorder.alignment= TextAnchor.MiddleLeft;
TDateArrival.alignment= TextAnchor.MiddleLeft;
TPrice.alignment= TextAnchor.MiddleLeft;




}




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