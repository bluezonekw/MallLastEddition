using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assignspritetomatrialDoors : MonoBehaviour
{
    public Material[] mat;
    public RequesStoresInHall requesStores;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            for (int x = 0; x < mat.Length - 1; x++)
            {
                StartCoroutine(DownloadRawImage(requesStores.Halls_info.data.data.ToArray()[x].banner.ToString(), mat[x]));

            }

        }
        catch
        {

        }
    }
    IEnumerator DownloadRawImage(string url, Material I)
    {


        WWW www = new WWW(url);
        yield return www;
        try
        {

            I.SetTexture("_MainTex",www.texture);

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
