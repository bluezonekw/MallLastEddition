using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using RestSharp;
using System;
using UnityEngine.UI;
public class ClosedOpendOrders : MonoBehaviour
{
public Transform Open,Close;
public GameObject Item;
GameObject CurrentItem;
public ArabicText Title,Closed,Opened;
    // Start is called before the first frame update
public PastOrder Request;

 public static string UnixTimeStampToDateTime(double unixTimeStamp)
    {
        // Unix timestamp is seconds past epoch
        System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
        dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
        return dtDateTime.ToString("dd/MM/yyyy");
    }


public void LoadOrderopen (){
try{
foreach (Transform child in Open.transform) {
     GameObject.Destroy(child.gameObject);
 }

 }
catch{}



try{

var client = new RestClient("http://mymall-kw.com/api/V1/orders?type=open&limit=100");
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
request.AddHeader("auth-token",AuthToken() );
request.AlwaysMultipartFormData = true;
IRestResponse response = client.Execute(request);
Request=JsonConvert.DeserializeObject<PastOrder>(response.Content);
print(response.Content);
if(Request.statsu == 1){
 foreach (PastOrderData I in Request.data.data){

CurrentItem = GameObject.Instantiate(Item, Open);

if (UPDownMenu.LanguageValue == 1)
        {
CurrentItem.GetComponent<orderItem>().Id.enabled = false;
CurrentItem.GetComponent<orderItem>().Price.enabled = false;
CurrentItem.GetComponent<orderItem>().DateArrive.enabled = false;

CurrentItem.GetComponent<orderItem>().Id.GetComponent<Text>().text="NO.  "+I.id.ToString();
CurrentItem.GetComponent<orderItem>().Price.GetComponent<Text>().text="Total Price : "+I.final_price.ToString();
CurrentItem.GetComponent<orderItem>().DateArrive.GetComponent<Text>().text= "Arrive at: "+UnixTimeStampToDateTime(I.delivery_time).ToString();
            //request.AddHeader("lang-api", "en");
        }
        else
        {
CurrentItem.GetComponent<orderItem>().Id.Text="رقم الفاتورة"+" : "+I.id.ToString();
CurrentItem.GetComponent<orderItem>().Price.Text="إجمالي السعر"+" : "+I.final_price.ToString();
CurrentItem.GetComponent<orderItem>().DateArrive.Text="سيصل فى "+" : "+UnixTimeStampToDateTime(I.delivery_time).ToString();
          //  request.AddHeader("lang-api", "ar");

        }
StartCoroutine(CurrentItem.GetComponent<orderItem>().DownLoadSprite(I.image));
CurrentItem.GetComponent<orderItem>().idnumber=I.id;


}


}

}
catch{}
}









public void LoadOrderclose (){

try{
foreach (Transform child in Close.transform) {
     GameObject.Destroy(child.gameObject);
 }

 }
catch{}

try{

var client = new RestClient("http://mymall-kw.com/api/V1/orders?type=closed&limit=100");
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
request.AddHeader("auth-token",AuthToken() );
request.AlwaysMultipartFormData = true;
IRestResponse response = client.Execute(request);
Request=JsonConvert.DeserializeObject<PastOrder>(response.Content);
print(response.Content);
if(Request.statsu == 1){
 foreach (PastOrderData I in Request.data.data){

CurrentItem = GameObject.Instantiate(Item, Close);

if (UPDownMenu.LanguageValue == 1)
        {
CurrentItem.GetComponent<orderItem>().Id.Text="NO.  "+I.id.ToString();
CurrentItem.GetComponent<orderItem>().Price.Text="Total Price : "+I.final_price.ToString();
            //request.AddHeader("lang-api", "en");
        }
        else
        {
CurrentItem.GetComponent<orderItem>().Id.Text="رقم الفاتورة :"+I.id.ToString();
CurrentItem.GetComponent<orderItem>().Price.Text="إجمالي السعر : "+I.final_price.ToString();
          //  request.AddHeader("lang-api", "ar");

        }
StartCoroutine(CurrentItem.GetComponent<orderItem>().DownLoadSprite(I.image));



}


}

}
catch{}
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

    void Start()
    {
 


        LoadOrderopen ();
    }

    // Update is called once per frame
    void Update()
    {
        if (UPDownMenu.LanguageValue == 1)
        {

Title.Text="My Order";
Closed.Text="Closed";
 Opened.Text="Open";
      
        }
        else
        {
Title.Text=" طلباتى";
       Closed.Text="المغلقة";
 Opened.Text="المفتوحة";   
        }
    }
}


// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class PastOrderData
    {
        public int id { get; set; }
        public int products_count { get; set; }
        public int order_price { get; set; }
        public int shipping_price { get; set; }
        public int final_price { get; set; }
        public object coupon_code { get; set; }
        public string discount_type { get; set; }
        public object note { get; set; }
        public string status { get; set; }
        public string payment_method { get; set; }
        public int delivery_time { get; set; }
        public int created_at { get; set; }
        public int discount { get; set; }
        public int coins { get; set; }
        public string type { get; set; }
        public string image { get; set; }
        public int current_page { get; set; }
        public List<PastOrderData> data { get; set; }
        public string first_page_url { get; set; }
        public int from { get; set; }
        public object next_page_url { get; set; }
        public string path { get; set; }
        public string per_page { get; set; }
        public object prev_page_url { get; set; }
        public int to { get; set; }
    }

    public class PastOrder
    {
        public int statsu { get; set; }
        public string message { get; set; }
        public PastOrderData data { get; set; }
    }


