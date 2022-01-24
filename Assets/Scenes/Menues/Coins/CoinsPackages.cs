using Newtonsoft.Json;
using RestSharp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsPackages : MonoBehaviour
{
public ArabicText Header;
public GameObject ItemPackage;
    CoinPackageRequest Request;
public Transform ScrollLocation;
PackgeInfo  singlePackage;
GameObject g;
    // Start is called before the first frame update
    void Start()
    {
var client = new RestClient("http://mymall-kw.com/api/V1/coin-packages");
client.Timeout = -1;
var request = new RestRequest(Method.GET);
request.AddHeader("password-api", "mall_2021_m3m");
		if (UPDownMenu.LanguageValue == 1)
           		 {
             		   request.AddHeader("lang-api", "en");
					Header.Text="Coins";
       			     }
          	  else
            		{

             			   request.AddHeader("lang-api", "ar");

					Header.Text="الذهبيات";
        		    }

request.AddHeader("auth-token", AuthToken());
request.AlwaysMultipartFormData = true;
IRestResponse response = client.Execute(request);
Request = JsonConvert.DeserializeObject<CoinPackageRequest>(response.Content);
print(response.Content);
foreach(var i in Request.data){
g=GameObject.Instantiate(ItemPackage, ScrollLocation);
singlePackage=g.GetComponent<PackgeInfo>();
singlePackage.id=i.id;
 singlePackage.Coins.Text=i.coins.ToString();
singlePackage.Price.Text=i.price.ToString();
}
        
    }

public void ClosMenu(){
Destroy(gameObject);

}



        public string AuthToken()
        {

            try
            {
                return ApiClasses.Register.data.token;
            }
            catch

            {

                return ApiClasses.Login.data.original.access_token;

            }


        }

    // Update is called once per frame
    void Update()
    {
        
    }
}


  public class DataCoinRequestPackage
    {
        public int id { get; set; }
        public int price { get; set; }
        public int coins { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class CoinPackageRequest
    {
        public int statsu { get; set; }
        public string message { get; set; }
        public List<DataCoinRequestPackage> data { get; set; }
    }