using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class assignBannerFromApi : MonoBehaviour
{
    public RequesStoresInHall requesStores;
    private RawImage rawImage;
    int StoreID;
bool x,loaded;
GameObject Player;
    // Start is called before the first frame update
  

  void Awake()
    {
	Player = GameObject.FindWithTag("Player");
	try{
StoreID=int.Parse( gameObject.name);
        rawImage = GetComponent<RawImage>();



}
catch{
StoreID=0;
}



try{

            StartCoroutine(DownloadRawImage(loadAllshops.d[StoreID-1].banner.ToString(), rawImage));


        }
        catch
        {

        }












    }
    IEnumerator DownloadRawImage(string url, RawImage I)
    {
 loaded=true; 

       WWW www = new WWW(url);
        yield return www;

       I.texture = www.texture;
   
    }
    // Update is called once per frame
    void Update()
    {
        
/*
if(StoreID>=1 && StoreID<=110){
if(Player.transform.localPosition.y<3){
           x=true;
}
	}else
		if(StoreID>=221){

		if(Player.transform.localPosition.y>10){


			x=true;

			}

				}
				else
					if(StoreID>=111 && StoreID<=220){

					if(Player.transform.localPosition.y>3&&Player.transform.localPosition.y<10){


						x=true;

}

}

if(x&&!loaded){



        try
        {

            StartCoroutine(DownloadRawImage(loadAllshops.d[StoreID-1].banner.ToString(), rawImage));


        }
        catch
        {

        }



}





*/


    }




}
