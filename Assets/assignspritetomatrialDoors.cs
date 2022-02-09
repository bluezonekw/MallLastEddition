using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class assignspritetomatrialDoors : MonoBehaviour
{
   public Material DefaultMat;
    public RequesStoresInHall requesStores;
private Material LocalMat;
bool x,loaded;
 int StoreID;
GameObject Player;
    // Start is called before the first frame update




    void Awake()
    {
Player = GameObject.FindWithTag("Player");
try{
StoreID=int.Parse( gameObject.name);}
catch{
StoreID=0;
}




 
 try
        {

GetComponent<MeshRenderer>().materials[0]=new Material(DefaultMat.shader);
LocalMat=GetComponent<MeshRenderer>().materials[0];
            StartCoroutine(DownloadRawImage(loadAllshops.d[StoreID-1].logo.ToString(), LocalMat));
            


        }
        catch
        {

        }



















       
    }



    IEnumerator DownloadRawImage(string url, Material I)
    {
loaded=true;  

    

 WWW www = new WWW(url);
        yield return www;

       I.SetTexture("_MainTex",  www.texture);
 

 
 
    }
    // Update is called once per frame
    void Update()
    {/*
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


 GetComponent<MeshRenderer>().materials[0]=new Material(DefaultMat.shader);
LocalMat=GetComponent<MeshRenderer>().materials[0];

 try
        {


            StartCoroutine(DownloadRawImage(loadAllshops.d[StoreID-1].logo.ToString(), LocalMat));
            


        }
        catch
        {

        }






}
*/
    }






}
