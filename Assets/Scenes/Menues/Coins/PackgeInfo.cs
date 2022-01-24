using Newtonsoft.Json;
using RestSharp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackgeInfo : MonoBehaviour
{
BuyingCoins Request;
public ArabicText Coins,Price;
public int id;
    // Start is called before the first frame update
    void Start()
    {
        
    }
public void buyPackage(){
var client = new RestClient("http://mymall-kw.com/api/V1/coin-packages/1");
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
print(response.Content);
Request = JsonConvert.DeserializeObject<BuyingCoins>(response.Content);
           UPDownMenu.coinsnumber+=int.Parse(Coins.Text);


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



 public class DataCoinPayment
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public object email_verified_at { get; set; }
        public int gander { get; set; }
        public int coins { get; set; }
        public int total_orders_cost { get; set; }
        public int total_coins_spend { get; set; }
    }

    public class BuyingCoins
    {
        public int statsu { get; set; }
        public string message { get; set; }
        public DataCoinPayment data { get; set; }
    }