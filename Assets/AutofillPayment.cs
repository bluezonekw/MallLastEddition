using RestSharp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System;
public class AutofillPayment : MonoBehaviour
{
  public static REsponseMyfatoraah GetInvoicId;
    public bool autofill;
    public InputField NameField, EmailField, PhoneField;
    public InputField City, square, street, apartment, discount, Notes;

    public ArabicText Price,totalprice;
    public Order orderinfo;
    public GameObject Recipt;
    private ScreenshotNow screenshotscript;
    public ArabicText Shippingprice;
    public GameObject Cart;
    public GameObject Messageobject;
    public ArabicText MessageErorr;
public BrowserOpener BrowserOpenr1;
public Toggle Qnet,Visa,Cash;
    public  void applyDiscountOnPrice (double Discount)
    {
        if (CartInfo.price > Discount)
        {
            Price.Text = (CartInfo.price - Discount).ToString();
            totalprice.Text = ((CartInfo.price - Discount) + CartInfo.Shipping).ToString();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    
        if (autofill)
        {
            NameField.text = Name();
            EmailField.text = Email();
            PhoneField.text = Phone();


        }
        Price.Text = CartInfo.price.ToString();
        totalprice.Text = (CartInfo.price + CartInfo.Shipping).ToString();
        Shippingprice.Text = CartInfo.Shipping.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Back()
    {
        GameObject.Instantiate(Cart,GameObject.FindGameObjectWithTag("MainCanvas").transform);
        destoryPayment();


    }
public void EmptyFieldMessageAR(){



		Messageobject.SetActive(true);
            MessageErorr.Text = "من فضلك لاتترك اى حقل فارغ";
}
public void EmptyFieldMessageEN(){



		Messageobject.SetActive(true);
            MessageErorr.Text = "Complete All Fields";
}
    public static string  UnixTimeStampToDateTime(double unixTimeStamp)
    {
        // Unix timestamp is seconds past epoch
        System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
        dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
        return dtDateTime.ToString("dd/MM/yyyy");
    }
    public void CompleteBuying()
    {
        if (NameField.text == ""||PhoneField.text == ""||EmailField.text == ""||City.text == ""||square.text == ""||street.text == ""||apartment.text == "")
        {

if (UPDownMenu.LanguageValue == 1)
        {
EmptyFieldMessageEN();
            
        }
        else
        {
EmptyFieldMessageAR();
           

        }


            return;
        }
      

       

     


        


      
          






if(Qnet.isOn ||Visa.isOn)
{
try{
var client = new RestClient("https://api.myfatoorah.com/v2/SendPayment");
client.Timeout = -1;
var request = new RestRequest(Method.POST);

request.AddHeader("Authorization", "Bearer Fadv8OV_71a-BP6RJMl8uH9NnrwO-2eWMwEiwqHJlcQWdJxg1AU2r3nz39b8diV140RdF7PKq6RdhcnBdToV6TByHy1OM8B8Hr1qcF97nmW5EUgDBNfo49pNELogtQEbzSV1m5OwwlGfZD-u_1D62LH2NidNfpB1y3Mq2klkGCB6wydGSbmud9-iBnXJb1ef-KxXC20-ILlOB7rYkXKsCo4E2T4Ci7djt3HHLTnhE08NBlL1hk8DHpj0PSKtoC1Kv33KCAHmPDyiEbnpaDDN26CPKFC_CTZQs-pkIUwCIWFNIezP7r-Djw7C-PQoANQk6AmDGW5NVM2Bd_G8fnRqoLpFIrAubqWnW9TSsWghU38d6Jd2SORm9jCbzRqE2UYhduPxUIqo8kehZ1abKRA9scoSr5lyGcFR6sWyptmCSMWa9LBSVHsnP-Gz4-4s5pooHK7xV49PIbB2cAoHRzI15aBjMIcImyU2-095xzQPjC0g7Ctvu_-hygb2sLmJBVkS87iYWoF-arr-h803-5IcF91teigQVjKp7RWZu4mbcy6GLIsOzt4WpTumc82y7TEoLbLWY6FowaCzxEPeMHV2Yx-CjbR4EqD4no_GtaLDN8rB55B1fkgHO_alFFSfZvGh_QT7RFyIKDOnct9iZWhMILR2bDj7KZMhEZPHjPJUvGT2lCJep_JHioKJPdC_urpQJ7Ie5w");
request.AddHeader("Content-Type", "application/json");
request.AddHeader("Cookie", "ApplicationGatewayAffinity=3ef0c0508ad415fb05a4ff3f87fb97da; ApplicationGatewayAffinityCORS=3ef0c0508ad415fb05a4ff3f87fb97da");
string MainBody="";

if (UPDownMenu.LanguageValue == 1)
        {
MainBody=@"{" + "\n" +@"    ""CustomerName"": """+NameField.text+@"""," + "\n" +@"    ""NotificationOption"": ""LNK""," + "\n" +@"    ""MobileCountryCode"": ""+965""," + "\n" +@"    ""CustomerMobile"": """+PhoneField.text+@"""," + "\n" +@"    ""CustomerEmail"": """+ EmailField.text+@"""," + "\n" +@"    ""InvoiceValue"": "+totalprice.Text+@"," + "\n" +@"    ""DisplayCurrencyIso"": ""kwd""," + "\n" +@"    ""CallBackUrl"": ""https://mymall-kw.com/""," + "\n" +@"    ""ErrorUrl"": ""https://mymall-kw.com/""," + "\n" +@"    ""Language"": ""En"",""InvoiceItems"": [";
            
        }
        else
        {


MainBody=@"{" + "\n" +@"    ""CustomerName"": """+NameField.text+@"""," + "\n" +@"    ""NotificationOption"": ""LNK""," + "\n" +@"    ""MobileCountryCode"": ""+965""," + "\n" +@"    ""CustomerMobile"": """+PhoneField.text+@"""," + "\n" +@"    ""CustomerEmail"": """+ EmailField.text+@"""," + "\n" +@"    ""InvoiceValue"": "+totalprice.Text+@"," + "\n" +@"    ""DisplayCurrencyIso"": ""kwd""," + "\n" +@"    ""CallBackUrl"": ""https://mymall-kw.com/""," + "\n" +@"    ""ErrorUrl"": ""https://mymall-kw.com/""," + "\n" +@"    ""Language"": ""AR"",""InvoiceItems"": [";          

        }



string Items51="";
bool x=false;

foreach (CartData i in cartController.CartResponse.data.Carts)
            {
if(!x){

Items51=@"{""ItemName"": """+i.name+@""",""Quantity"": "+i.quantity.ToString()+@",""UnitPrice"": "+i.price.ToString()+"}";



x=true;
}else{
Items51=@",{""ItemName"": """+i.name+@""",""Quantity"": "+i.quantity.ToString()+@",""UnitPrice"": "+i.price.ToString()+"}";




}



}

var body="";
if (UPDownMenu.LanguageValue == 1)
        {
body = MainBody+Items51+@",{""ItemName"": ""Shipment"",""Quantity"": 1,""UnitPrice"": "+CartInfo.Shipping.ToString()+@"} ] }";
            
        }
        else
        {
body = MainBody+Items51+@",{""ItemName"": ""الشحن"",""Quantity"": 1,""UnitPrice"": "+CartInfo.Shipping.ToString()+@"} ] }";

           

        }
           

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
EmptyFieldMessageEN();
            
        }
        else
        {
EmptyFieldMessageAR();
           

        }


            return;
}

}else{

       createorder();
        

        if (orderinfo.statsu == 1) {

        GameObject g = GameObject.Instantiate(Recipt,GameObject.FindGameObjectWithTag("MainCanvas").transform);
        screenshotscript = g.GetComponent<ScreenshotNow>();
            screenshotscript.Name.Text = NameField.text;
            screenshotscript.Phone.Text = PhoneField.text;
            screenshotscript.OrderNumber.Text = orderinfo.data.id.ToString();
            screenshotscript.Price.Text = orderinfo.data.final_price.ToString()+" K.D";
            screenshotscript.Dateorder.Text = UnixTimeStampToDateTime(orderinfo.data.created_at).ToString();
            screenshotscript.DateArrival.Text = UnixTimeStampToDateTime(orderinfo.data.delivery_time).ToString();
CheckEnterShop.CartEmpty=true;


                }
        else
        {
            Messageobject.SetActive(true);
            MessageErorr.Text = orderinfo.message;
            return;
        }

        destoryPayment();
}
    }


public void backFromWeb(){
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
	    Messageobject.SetActive(true);
            MessageErorr.Text = "Please Try Again";
            
        }
        else
        {
	    Messageobject.SetActive(true);
            MessageErorr.Text = "حدث خطأ فى الدفع";
           

        }
 		
            return;

}




}
catch{
if (UPDownMenu.LanguageValue == 1)
        {
	    Messageobject.SetActive(true);
            MessageErorr.Text = "Please Try Again";
            
        }
        else
        {
	    Messageobject.SetActive(true);
            MessageErorr.Text = "حدث خطأ فى الدفع";
           

        }
 		
            return;


}


 createorder();
        

        if (orderinfo.statsu == 1) {

        GameObject g = GameObject.Instantiate(Recipt,GameObject.FindGameObjectWithTag("MainCanvas").transform);
        screenshotscript = g.GetComponent<ScreenshotNow>();
            screenshotscript.Name.Text = NameField.text;
            screenshotscript.Phone.Text = PhoneField.text;
            screenshotscript.OrderNumber.Text = orderinfo.data.id.ToString();
            screenshotscript.Price.Text = orderinfo.data.final_price.ToString()+" K.D";
            screenshotscript.Dateorder.Text = UnixTimeStampToDateTime(orderinfo.data.created_at).ToString();
            screenshotscript.DateArrival.Text = UnixTimeStampToDateTime(orderinfo.data.delivery_time).ToString();
CheckEnterShop.CartEmpty=true;


                }
        else
        {
            Messageobject.SetActive(true);
            MessageErorr.Text = orderinfo.message;
            return;
        }

        destoryPayment();
}


    public void MessageDisable()
    {

        Messageobject.SetActive(false);

    }
    public void createorder()
    {

var client = new RestClient("http://mymall-kw.com/api/V1/orders");
        client.Timeout = -1;
        var request = new RestRequest(Method.POST);
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

        request.AddParameter("store_id",cartController.CartResponse.data.store_id); 

//SingleSToreRequest.StaticStoreId);
        request.AddParameter("name", NameField.text);
        request.AddParameter("phone", PhoneField.text);
        request.AddParameter("email", EmailField.text);
        request.AddParameter("city", City.text);
        request.AddParameter("zone", square.text);
        request.AddParameter("street", street.text);
        request.AddParameter("building", apartment.text);
        request.AddParameter("note", Notes.text);
        request.AddParameter("coupon_code", discount.text);
if(Qnet.isOn){

 
        request.AddParameter("payment_method", "visa");

      


}else if(Visa.isOn){


        request.AddParameter("payment_method", "visa");


}
   else if(Cash.isOn){

 
        request.AddParameter("payment_method", "cash");

       

}    
      request.AddParameter("special_discount", "0");
  IRestResponse response = client.Execute(request);
print(response.Content);
         orderinfo= JsonConvert.DeserializeObject<Order>(response.Content);
       


    }
    public void destoryPayment()
    {
var foundObjects = FindObjectsOfType<UPDownMenu>();
foundObjects[0].UpdateCartCount();
        GameObject.Destroy(this.gameObject);
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


}







  public class InvoiceItem
    {
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public object Weight { get; set; }
        public object Width { get; set; }
        public object Height { get; set; }
        public object Depth { get; set; }
    }

    public class InvoiceTransaction
    {
        public DateTime TransactionDate { get; set; }
        public string PaymentGateway { get; set; }
        public string ReferenceId { get; set; }
        public string TrackId { get; set; }
        public string TransactionId { get; set; }
        public string PaymentId { get; set; }
        public string AuthorizationId { get; set; }
        public string TransactionStatus { get; set; }
        public string TransationValue { get; set; }
        public string CustomerServiceCharge { get; set; }
        public string DueValue { get; set; }
        public string PaidCurrency { get; set; }
        public string PaidCurrencyValue { get; set; }
        public string IpAddress { get; set; }
        public string Country { get; set; }
        public string Currency { get; set; }
        public string Error { get; set; }
        public object CardNumber { get; set; }
        public string ErrorCode { get; set; }
    }

    public class StatusOfPaymentData
    {
        public int InvoiceId { get; set; }
        public string InvoiceStatus { get; set; }
        public string InvoiceReference { get; set; }
        public object CustomerReference { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ExpiryDate { get; set; }
        public string ExpiryTime { get; set; }
        public double InvoiceValue { get; set; }
        public object Comments { get; set; }
        public string CustomerName { get; set; }
        public string CustomerMobile { get; set; }
        public string CustomerEmail { get; set; }
        public object UserDefinedField { get; set; }
        public string InvoiceDisplayValue { get; set; }
        public List<InvoiceItem> InvoiceItems { get; set; }
        public List<InvoiceTransaction> InvoiceTransactions { get; set; }
        public List<object> Suppliers { get; set; }
    }

    public class StatusOfPayment
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object ValidationErrors { get; set; }
        public StatusOfPaymentData Data { get; set; }
    }

