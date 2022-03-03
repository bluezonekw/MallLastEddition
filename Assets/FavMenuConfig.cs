using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using RestSharp;
using Newtonsoft.Json;
public class FavMenuConfig : MonoBehaviour
{

public  FavRequest Response;
public GameObject FavItemExample;
public Transform locationOfFavItems;
 public ArabicText Counts;
GameObject Created;
FavItem itemscript;
public ArabicText FavTitle;
    // Start is called before the first frame update
    void Start()
    {
if (UPDownMenu.LanguageValue == 1)
        {


FavTitle.Text="Favourite";

}



else


{

FavTitle.Text="المفضلة";




}



        StartCoroutine(GetFavItem()); 
try{
Counts.Text=Response.data.data.Count.ToString();
foreach(FavData f in Response.data.data)

{
Created=GameObject.Instantiate(FavItemExample, locationOfFavItems);
itemscript=Created.GetComponent<FavItem>();
itemscript.PeoductId=f.id;
itemscript.Name.Text=f.name;
if(f.sale_price!=null){
itemscript.Price.Text=f.sale_price.ToString();
}
else{
itemscript.Price.Text=f.regular_price.ToString();
}

StartCoroutine(DownLoadImagetexture(f.img,itemscript.FavImage));


}

}
catch{


}
    }

  IEnumerator DownLoadImagetexture(string URL, RawImage s)
    {
        WWW www = new WWW(URL);
        yield return www;
        s.texture = www.texture;
       
    }



    // Update is called once per frame
    void Update()
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

IEnumerator GetFavItem()
 	   {
            try{
	var client = new RestClient("http://mymall-kw.com/api/V1/favorite?limit=1000");
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
	request.AddHeader("auth-token", AuthToken());
	request.AlwaysMultipartFormData = true;
	IRestResponse response = client.Execute(request);
 
       Response = JsonConvert.DeserializeObject<FavRequest>(response.Content);


            }
            catch{
                
            }
           yield return null;
	   }


public void  DestroyFav()
    {


        GameObject.Destroy(gameObject);
    }

}
