using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

        print("ddddddddddddddddd");
        return i;


    }
    // Update is called once per frame
    void Update()
    {
        if (loadimage)
        {

            StartCoroutine(DownloadRawImage(UImage, i));

            loadimage = false;
            print("aaaaaaaaaaaaaaaaaaaaaaaaaa");
        }
        
    }
    IEnumerator DownloadRawImage(string url, RawImage I)
    {


        WWW www = new WWW(url);
        yield return www;
        try
        {

            I.texture = www.texture;
            print(" Error is          :  " + www.error);

        }
        catch (Exception ex)
        {

            print("eeeeeeeeeeeeeeeeee             " + ex.Message);

        }

    }

    IEnumerator DownloadImage(string url, RawImage I)
    {
        WWW www = new WWW(url);
        yield return www;
        try
        {

            I.texture = www.texture;
            print(" Error is          :  " + www.error);

        }
        catch(Exception ex)
        {

            print("eeeeeeeeeeeeeeeeee             " + ex.Message);

        }

    }
}
