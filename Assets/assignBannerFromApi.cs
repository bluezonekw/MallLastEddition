using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class assignBannerFromApi : MonoBehaviour
{
    public RequesStoresInHall requesStores;
    private RawImage rawImage;
    public int NumberBanner;
    // Start is called before the first frame update
    void Start()
    {
        rawImage = GetComponent<RawImage>();
        try
        {
            StartCoroutine(DownloadRawImage(requesStores.Halls_info.data.data.ToArray()[NumberBanner - 1].banner.ToString(), rawImage));
        }
        catch
        {

        }
    }
    IEnumerator DownloadRawImage(string url, RawImage I)
    {


        WWW www = new WWW(url);
        yield return www;
        try
        {

            I.texture = www.texture;

        }
        catch (Exception ex)
        {


        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
