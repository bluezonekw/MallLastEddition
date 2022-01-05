using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class assignBannerFromApi : MonoBehaviour
{
    public RequesStoresInHall requesStores;
    private RawImage rawImage;
    int StoreID;
    // Start is called before the first frame update
    void Start()
    {
try{
StoreID=int.Parse( gameObject.name);
        rawImage = GetComponent<RawImage>();
}
catch{
StoreID=0;
}
        try
        {
foreach(DataStore k in requesStores.Halls_info.data){
if(k.id==StoreID){
            StartCoroutine(DownloadRawImage(k.banner.ToString(), rawImage));
}
}
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
