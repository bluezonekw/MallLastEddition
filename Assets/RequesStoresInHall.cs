using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RestSharp;
using Newtonsoft.Json;

public class RequesStoresInHall : MonoBehaviour
{
    public int StoreidFrom,StoreidTo;
    
    public List<GameObject> Category;
public GameObject WelcomMessage;
    public List<GameObject> ShopLocker;
public GameObject Parent;



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
