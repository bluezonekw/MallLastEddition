using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System;
using RestSharp;
public class SendPayment : MonoBehaviour
{
      string token = "rLtt6JWvbUHDDhsZnfpAhpYk4dxYDQkbcPTyGaKp2TYqQgG7FGZ5Th_WD53Oq8Ebz6A53njUoo1w3pjU1D4vs_ZMqFiz_j0urb_BH9Oq9VZoKFoJEDAbRZepGcQanImyYrry7Kt6MnMdgfG5jn4HngWoRdKduNNyP4kzcp3mRv7x00ahkm9LAK7ZRieg7k1PDAnBIOG3EyVSJ5kK4WLMvYr7sCwHbHcu4A5WwelxYK0GMJy37bNAarSJDFQsJ2ZvJjvMDmfWwDVFEVe_5tOomfVNt6bOg9mexbGjMrnHBnKnZR1vQbBtQieDlQepzTZMuQrSuKn-t5XZM7V6fCW7oP-uXGX-sMOajeX65JOf6XVpk29DP6ro8WTAflCDANC193yof8-f5_EYY-3hXhJj7RBXmizDpneEQDSaSz5sFk0sV5qPcARJ9zGG73vuGFyenjPPmtDtXtpx35A-BVcOSBYVIWe9kndG3nclfefjKEuZ3m4jL9Gg1h2JBvmXSMYiZtp9MR5I6pvbvylU_PP5xJFSjVTIz7IQSjcVGO41npnwIxRXNRxFOdIUHn0tjQ-7LwvEcTXyPsHXcMD8WtgBh-wxR8aKX7WPSsT1O8d8reb2aR7K3rkV3K82K_0OgawImEpwSvp9MNKynEAJQS6ZHe_J_l77652xwPNxMRTMASk1ZsJL";
       public Text k; 
public bool loadurl;
string url;
public BrowserOpener s;


public  async  void Play(){

var client = new RestClient("https://apitest.myfatoorah.com/v2/SendPayment");
client.Timeout = -1;
var request = new RestRequest(Method.POST);
request.AddHeader("Authorization", "Bearer rLtt6JWvbUHDDhsZnfpAhpYk4dxYDQkbcPTyGaKp2TYqQgG7FGZ5Th_WD53Oq8Ebz6A53njUoo1w3pjU1D4vs_ZMqFiz_j0urb_BH9Oq9VZoKFoJEDAbRZepGcQanImyYrry7Kt6MnMdgfG5jn4HngWoRdKduNNyP4kzcp3mRv7x00ahkm9LAK7ZRieg7k1PDAnBIOG3EyVSJ5kK4WLMvYr7sCwHbHcu4A5WwelxYK0GMJy37bNAarSJDFQsJ2ZvJjvMDmfWwDVFEVe_5tOomfVNt6bOg9mexbGjMrnHBnKnZR1vQbBtQieDlQepzTZMuQrSuKn-t5XZM7V6fCW7oP-uXGX-sMOajeX65JOf6XVpk29DP6ro8WTAflCDANC193yof8-f5_EYY-3hXhJj7RBXmizDpneEQDSaSz5sFk0sV5qPcARJ9zGG73vuGFyenjPPmtDtXtpx35A-BVcOSBYVIWe9kndG3nclfefjKEuZ3m4jL9Gg1h2JBvmXSMYiZtp9MR5I6pvbvylU_PP5xJFSjVTIz7IQSjcVGO41npnwIxRXNRxFOdIUHn0tjQ-7LwvEcTXyPsHXcMD8WtgBh-wxR8aKX7WPSsT1O8d8reb2aR7K3rkV3K82K_0OgawImEpwSvp9MNKynEAJQS6ZHe_J_l77652xwPNxMRTMASk1ZsJL");
request.AddHeader("Content-Type", "application/json");
request.AddHeader("Cookie", "ApplicationGatewayAffinity=3ef0c0508ad415fb05a4ff3f87fb97da; ApplicationGatewayAffinityCORS=3ef0c0508ad415fb05a4ff3f87fb97da");
var body = @"{
" + "\n" +
@"  ""CustomerName"": ""MostafaMahmoud"",
" + "\n" +
@"  ""NotificationOption"": ""lnk"",
" + "\n" +
@"  ""MobileCountryCode"": ""965"",
" + "\n" +
@"  ""CustomerMobile"": ""01017800204"",
" + "\n" +
@"  ""CustomerEmail"": ""drshdrsh26@yahoo.com"",
" + "\n" +
@"  ""InvoiceValue"": 1,
" + "\n" +
@"  ""DisplayCurrencyIso"": ""kwd"",
" + "\n" +
@"  ""CallBackUrl"": ""https://mymall-kw.com"",
" + "\n" +
@"  ""ErrorUrl"": ""https://mymall-kw.com"",
" + "\n" +
@"  ""Language"": ""Ar""
" + "\n" +
@"}";
request.AddParameter("application/json", body,  ParameterType.RequestBody);
IRestResponse response = client.Execute(request);


REsponseMyfatoraah myDeserializedClass = JsonConvert.DeserializeObject<REsponseMyfatoraah>(response.Content);
url=myDeserializedClass.Data.InvoiceURL;

print(response.Content);
loadurl=true;


}










public void size(string x){
k.text=x;


}
public void closebrwoser(){
k.text="Closed";


}
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {





        if(loadurl){

//Application.OpenURL(url);
 s.pageToOpen=url;
 s.OnButtonClicked();
 

loadurl=false;
}
    }









}



  public class DataMyfatoraah
    {
        public int InvoiceId { get; set; }
        public string InvoiceURL { get; set; }
        public string CustomerReference { get; set; }
        public string UserDefinedField { get; set; }
    }

    public class REsponseMyfatoraah
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object ValidationErrors { get; set; }
        public DataMyfatoraah Data { get; set; }
    }






