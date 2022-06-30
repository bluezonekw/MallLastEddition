using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class imageUrl : MonoBehaviour
{
    private RawImage _image;
    private static RawImage i;
    public string URLImage;
 private static  bool loadimage;
 private static string UImage;
    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<RawImage>();
        StartCoroutine(DownloadImage(URLImage, _image));
    }
    public static RawImage LoadRawImage(String RawImageurl)
    {
        UImage = RawImageurl;
        loadimage = true;

       Debug.Log("ddddddddddddddddd");
        return i;


    }
    // Update is called once per frame
    void Update()
    {
        if (loadimage)
        {

            StartCoroutine(DownloadRawImage(UImage, i));

            loadimage = false;
           Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaa");
        }
        
    }
    IEnumerator DownloadRawImage(string url, RawImage I)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();


        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
           Debug.Log(url);
            I.texture = ((DownloadHandlerTexture)www.downloadHandler).texture;

        }

       

    }

    IEnumerator DownloadImage(string url, RawImage I)
    {

        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();


        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
           Debug.Log(url);
            I.texture = ((DownloadHandlerTexture)www.downloadHandler).texture;

        }






       

    }
}
