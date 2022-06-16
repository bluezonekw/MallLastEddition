using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using RTLTMPro;
using RestSharp;
using Newtonsoft;
using Newtonsoft.Json;

public class LoadBoothProduct : MonoBehaviour
{
public RawImage Icon;
public RTLTextMeshPro Name,Price;
public GameObject ProductPanel;
public GameObject loginGameobject;
    // Start is called before the first frame update
    void Start()
    {
        
    }


     public string AuthToken()
    {

       if(!UPDownMenu.Login)
        {
            return ApiClasses.Register.data.token;
        }
        else

        {

            return ApiClasses.Login.data.original.access_token;

        }


    }


public void LoadDetailsProduct(){

if(ApiClasses.Vistor){
    GameObject.Instantiate(loginGameobject, GameObject.FindGameObjectWithTag("MainCanvas").transform);
 }else
 {
	
			var client = new RestClient("http://mymall-kw.com/api/V1/get-single-product/"+gameObject.name);
			client.Timeout = -1;
			var request = new RestRequest(Method.GET);
			request.AddHeader("password-api", "mall_2021_m3m");
			 if (UPDownMenu.LanguageValue == 1)
       							     {
      							          request.AddHeader("lang-api", "en");
      							      }
   							         else
         								   {
		
          								      request.AddHeader("lang-api", "ar");

         													   }
			request.AddHeader("auth-token",AuthToken());
			request.AlwaysMultipartFormData = true;
			IRestResponse response = client.Execute(request);

			print(response.Content);
            

    GetDetailsProduct.ProductRequst=JsonConvert.DeserializeObject<StoreProduct>(response.Content);
            loadimageFromApi.ProductRequst = GetDetailsProduct.ProductRequst;
GameObject g= GameObject.Instantiate(ProductPanel,GameObject.FindGameObjectWithTag("MainCanvas").transform);
	
            }
		

 
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
