using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RestSharp;
using Newtonsoft.Json;

public class RequesStoresInHall : MonoBehaviour
{
    public int StoreidFrom,StoreidTo;
    public Hall Halls_info;
    public List<GameObject> Category;
public GameObject WelcomMessage;
    public List<GameObject> ShopLocker;
    private void Awake()
    {
    

try{
        var client = new RestClient(@"https://mymall-kw.com/api/V1/get-stores-pagination?from="+StoreidFrom+"&to=" + StoreidTo);
        client.Timeout = -1;
        var request = new RestRequest(Method.GET);
        request.AddHeader("password_api", "mall_2021_m3m");
        request.AddHeader("lang_api", "en");
        request.AlwaysMultipartFormData = true;
        IRestResponse response = client.Execute(request);
        Halls_info = JsonConvert.DeserializeObject<Hall>(response.Content);

        GameObject Parent = null;
        foreach (Transform child in transform)

        {
            if (child.tag == "ShopLocker")
            {
                Parent = child.gameObject;

            }



        }

        foreach (Transform child in Parent.transform)
        {

            ShopLocker.Add(child.gameObject);
        }

       
   	  foreach (var v in Halls_info.data)
      	  {
		 foreach (var g in ShopLocker)
    		    {
			if(v.id.ToString()==g.name)
				{

 					if (v.is_active == 1) 
					{
            					 g.SetActive(false);
                
                   						 }

					 else
       					     {
         				       g.SetActive(true);

         		   			  }

				}



			}
                      
        }


}

catch{}

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
