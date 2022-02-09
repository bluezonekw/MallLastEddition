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
public REsponseMyfatoraah GetInvoicId;
public BrowserOpener  BrowserOpenr1;
public GameObject MessageObject;
public ArabicText BuyBtn;
    // Start is called before the first frame update
    void Start()
    {
        
if (UPDownMenu.LanguageValue == 1)
        {


BuyBtn.Text="Buy";

}



else


{

BuyBtn.Text="شراء";




}



    }
 public string Email()
    {

        if(!UPDownMenu.Login)
        {
            return ApiClasses.Register.data.user.email;
        }
       else
        {

            return ApiClasses.Login.data.original.user.email;

        }


    }


    public string Name()
    {

        if(!UPDownMenu.Login)
        {
            return ApiClasses.Register.data.user.name;
        }
        else

        {

            return ApiClasses.Login.data.original.user.name;

        }


    }


    public string Phone()
    {

        if(!UPDownMenu.Login)
        {
            return ApiClasses.Register.data.user.phone;
        }
        else

        {

            return ApiClasses.Login.data.original.user.phone;

        }


    }





public void openPayment()
{try{
var client = new RestClient("https://api.myfatoorah.com/v2/SendPayment");
client.Timeout = -1;
var request = new RestRequest(Method.POST);

request.AddHeader("Authorization", "Bearer Fadv8OV_71a-BP6RJMl8uH9NnrwO-2eWMwEiwqHJlcQWdJxg1AU2r3nz39b8diV140RdF7PKq6RdhcnBdToV6TByHy1OM8B8Hr1qcF97nmW5EUgDBNfo49pNELogtQEbzSV1m5OwwlGfZD-u_1D62LH2NidNfpB1y3Mq2klkGCB6wydGSbmud9-iBnXJb1ef-KxXC20-ILlOB7rYkXKsCo4E2T4Ci7djt3HHLTnhE08NBlL1hk8DHpj0PSKtoC1Kv33KCAHmPDyiEbnpaDDN26CPKFC_CTZQs-pkIUwCIWFNIezP7r-Djw7C-PQoANQk6AmDGW5NVM2Bd_G8fnRqoLpFIrAubqWnW9TSsWghU38d6Jd2SORm9jCbzRqE2UYhduPxUIqo8kehZ1abKRA9scoSr5lyGcFR6sWyptmCSMWa9LBSVHsnP-Gz4-4s5pooHK7xV49PIbB2cAoHRzI15aBjMIcImyU2-095xzQPjC0g7Ctvu_-hygb2sLmJBVkS87iYWoF-arr-h803-5IcF91teigQVjKp7RWZu4mbcy6GLIsOzt4WpTumc82y7TEoLbLWY6FowaCzxEPeMHV2Yx-CjbR4EqD4no_GtaLDN8rB55B1fkgHO_alFFSfZvGh_QT7RFyIKDOnct9iZWhMILR2bDj7KZMhEZPHjPJUvGT2lCJep_JHioKJPdC_urpQJ7Ie5w");
request.AddHeader("Content-Type", "application/json");
request.AddHeader("Cookie", "ApplicationGatewayAffinity=3ef0c0508ad415fb05a4ff3f87fb97da; ApplicationGatewayAffinityCORS=3ef0c0508ad415fb05a4ff3f87fb97da");
string MainBody="";

if (UPDownMenu.LanguageValue == 1)
        {
MainBody=@"{" + "\n" +@"    ""CustomerName"": """+Name()+@"""," + "\n" +@"    ""NotificationOption"": ""LNK""," + "\n" +@"    ""MobileCountryCode"": ""+965""," + "\n" +@"    ""CustomerMobile"": """+Phone()+@"""," + "\n" +@"    ""CustomerEmail"": """+ Email()+@"""," + "\n" +@"    ""InvoiceValue"": "+Price.Text+@"," + "\n" +@"    ""DisplayCurrencyIso"": ""kwd""," + "\n" +@"    ""CallBackUrl"": ""https://mymall-kw.com/""," + "\n" +@"    ""ErrorUrl"": ""https://mymall-kw.com/""," + "\n" +@"    ""Language"": ""En"",""InvoiceItems"": [";
            
        }
        else
        {


MainBody=@"{" + "\n" +@"    ""CustomerName"": """+Name()+@"""," + "\n" +@"    ""NotificationOption"": ""LNK""," + "\n" +@"    ""MobileCountryCode"": ""+965""," + "\n" +@"    ""CustomerMobile"": """+Phone()+@"""," + "\n" +@"    ""CustomerEmail"": """+ Email()+@"""," + "\n" +@"    ""InvoiceValue"": "+Price.Text+@"," + "\n" +@"    ""DisplayCurrencyIso"": ""kwd""," + "\n" +@"    ""CallBackUrl"": ""https://mymall-kw.com/""," + "\n" +@"    ""ErrorUrl"": ""https://mymall-kw.com/""," + "\n" +@"    ""Language"": ""AR"",""InvoiceItems"": [";          

        }



string Items51=@"{""ItemName"": """+Coins.Text+@""",""Quantity"": 1,""UnitPrice"": "+Price.Text+"}";


var body = MainBody+Items51+@"] }";


print(body);
request.AddParameter("application/json", body,  ParameterType.RequestBody);
IRestResponse response = client.Execute(request);
GetInvoicId = JsonConvert.DeserializeObject<REsponseMyfatoraah>(response.Content);
print(response.Content);
BrowserOpenr1.pageToOpen=GetInvoicId.Data.InvoiceURL;
BrowserOpenr1.OnButtonClicked();
}
catch{
if (UPDownMenu.LanguageValue == 1)
        {
	  GameObject g= GameObject.Instantiate(MessageObject, GameObject.FindGameObjectWithTag("MainCanvas").transform);
            MessageObject.SetActive(true);
           g.GetComponent<optionPopUp>().Message.Text = "Please Try Again";
         
            
        }
        else
        {
 GameObject g= GameObject.Instantiate(MessageObject, GameObject.FindGameObjectWithTag("MainCanvas").transform);
            MessageObject.SetActive(true);
           g.GetComponent<optionPopUp>().Message.Text = "حدث خطأ فى الدفع";
	   
         
           

        }


}

}

public void BackFromWeb()




{
try{
var client = new RestClient("https://api.myfatoorah.com/v2/GetPaymentStatus");
client.Timeout = -1;
var request = new RestRequest(Method.POST);


request.AddHeader("Authorization", "Bearer Fadv8OV_71a-BP6RJMl8uH9NnrwO-2eWMwEiwqHJlcQWdJxg1AU2r3nz39b8diV140RdF7PKq6RdhcnBdToV6TByHy1OM8B8Hr1qcF97nmW5EUgDBNfo49pNELogtQEbzSV1m5OwwlGfZD-u_1D62LH2NidNfpB1y3Mq2klkGCB6wydGSbmud9-iBnXJb1ef-KxXC20-ILlOB7rYkXKsCo4E2T4Ci7djt3HHLTnhE08NBlL1hk8DHpj0PSKtoC1Kv33KCAHmPDyiEbnpaDDN26CPKFC_CTZQs-pkIUwCIWFNIezP7r-Djw7C-PQoANQk6AmDGW5NVM2Bd_G8fnRqoLpFIrAubqWnW9TSsWghU38d6Jd2SORm9jCbzRqE2UYhduPxUIqo8kehZ1abKRA9scoSr5lyGcFR6sWyptmCSMWa9LBSVHsnP-Gz4-4s5pooHK7xV49PIbB2cAoHRzI15aBjMIcImyU2-095xzQPjC0g7Ctvu_-hygb2sLmJBVkS87iYWoF-arr-h803-5IcF91teigQVjKp7RWZu4mbcy6GLIsOzt4WpTumc82y7TEoLbLWY6FowaCzxEPeMHV2Yx-CjbR4EqD4no_GtaLDN8rB55B1fkgHO_alFFSfZvGh_QT7RFyIKDOnct9iZWhMILR2bDj7KZMhEZPHjPJUvGT2lCJep_JHioKJPdC_urpQJ7Ie5w");
request.AddHeader("Content-Type", "application/json");
request.AddHeader("Cookie", "ApplicationGatewayAffinity=3ef0c0508ad415fb05a4ff3f87fb97da; ApplicationGatewayAffinityCORS=3ef0c0508ad415fb05a4ff3f87fb97da");


var body = @"{
" + "\n" +
@"  ""Key"": "+ GetInvoicId.Data.InvoiceId+@",
" + "\n" +
@"  ""KeyType"": ""invoiceid""
" + "\n" +
@"}";
request.AddParameter("application/json", body,  ParameterType.RequestBody);
IRestResponse response = client.Execute(request);

StatusOfPayment statusrequest = JsonConvert.DeserializeObject<StatusOfPayment>(response.Content);

if(statusrequest.Data.InvoiceStatus!="Paid"){

  if (UPDownMenu.LanguageValue == 1)
        {
	  GameObject g= GameObject.Instantiate(MessageObject, GameObject.FindGameObjectWithTag("MainCanvas").transform);
            MessageObject.SetActive(true);
           g.GetComponent<optionPopUp>().Message.Text = "Please Try Again";
         
            
        }
        else
        {
 GameObject g= GameObject.Instantiate(MessageObject, GameObject.FindGameObjectWithTag("MainCanvas").transform);
            MessageObject.SetActive(true);
           g.GetComponent<optionPopUp>().Message.Text = "حدث خطأ فى الدفع";
	   
         
           

        }
 		
            return;

}
}

catch{
if (UPDownMenu.LanguageValue == 1)
        {
	  GameObject g= GameObject.Instantiate(MessageObject, GameObject.FindGameObjectWithTag("MainCanvas").transform);
            MessageObject.SetActive(true);
           g.GetComponent<optionPopUp>().Message.Text = "Please Try Again";
         
            
        }
        else
        {
 GameObject g= GameObject.Instantiate(MessageObject, GameObject.FindGameObjectWithTag("MainCanvas").transform);
            MessageObject.SetActive(true);
           g.GetComponent<optionPopUp>().Message.Text = "حدث خطأ فى الدفع";
	   
         
           

        }
 		
            return;


}
buyPackage();




}

public void buyPackage(){






var client = new RestClient("http://mymall-kw.com/api/V1/coin-packages/"+id.ToString());
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
if(Request.statsu==1){
           UPDownMenu.coinsnumber+=int.Parse(Coins.Text);
}
else{
if (UPDownMenu.LanguageValue == 1)
        {
	  GameObject g= GameObject.Instantiate(MessageObject, GameObject.FindGameObjectWithTag("MainCanvas").transform);
            MessageObject.SetActive(true);
           g.GetComponent<optionPopUp>().Message.Text = "Please Call Service";
         
            
        }
        else
        {
 GameObject g= GameObject.Instantiate(MessageObject, GameObject.FindGameObjectWithTag("MainCanvas").transform);
            MessageObject.SetActive(true);
           g.GetComponent<optionPopUp>().Message.Text = "حدث خطأ فى الدفع ابلغ الادارة";
	   
         
           

        }

}

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