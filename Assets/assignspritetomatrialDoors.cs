using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assignspritetomatrialDoors : MonoBehaviour
{
   public Material DefaultMat;
    public RequesStoresInHall requesStores;
private Material LocalMat;
 int StoreID;
    // Start is called before the first frame update
    void Start()
    {
try{
StoreID=int.Parse( gameObject.name);}
catch{
StoreID=0;
}
 GetComponent<MeshRenderer>().materials[0]=new Material(DefaultMat.shader);
LocalMat=GetComponent<MeshRenderer>().materials[0];

 try
        {
foreach(DataStore k in requesStores.Halls_info.data){
if(k.id==StoreID){
            StartCoroutine(DownloadRawImage(k.logo.ToString(), LocalMat));
            
}
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
