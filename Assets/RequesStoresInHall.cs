using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RestSharp;
using Newtonsoft.Json;
using System.Linq;

public class RequesStoresInHall : MonoBehaviour
{
    public int StoreidFrom,StoreidTo;
    

public GameObject WelcomMessage;
    public List<GameObject> ShopLocker;
public GameObject Parent;

    public GameObject banner,Door;
    IEnumerator loadDoorAndBanner()
    {


        yield return new WaitUntil(() => loadAllshops.ImageLoad=true);
        try
        {
            


                StartCoroutine(Door.GetComponent<assignspritetomatrialDoors>().DownloadMatrial());
                StartCoroutine(banner.GetComponent<assignBannerFromApi>().DownloadRawImage());


            
        }
        catch
        {
            print("test");
        }
    }


    private void OnEnable()
    {
          StartCoroutine(loadDoorAndBanner());
    
    }
    private void OnDisable()
    {
       
        banner.GetComponent<assignBannerFromApi>().deleteallbanners();
        Door.GetComponent<assignspritetomatrialDoors>().restalldoor();
    }
    void Start()
    {
      

        foreach (Transform child in Parent.transform)
        {

            ShopLocker.Add(child.gameObject);

        }
       
try{	
	 foreach (var g in ShopLocker)
    		    {
			
if(loadAllshops.d[int.Parse(g.name)-1]!=null){
 					if (loadAllshops.d[int.Parse(g.name)-1].is_active == 1) 
					{
            					 g.SetActive(false);
               
                   						 }

					 else
       					     {
         				       g.SetActive(true);


         		   			  }
}else{


  g.SetActive(true);

}
				



			}
                      
        


}

catch{}



    }



 

   

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
