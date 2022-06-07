using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using RestSharp;
using System;
using UnityEngine.UI;
public class OrderDetails : MonoBehaviour
{
public Transform Item;
public string id;
public OrderDetailsRequestRequest Request;
public ArabicText MainTitle,SubTitle,Items,Amount,Total,TotalHeader,Currency;
public Text TMainTitle,TSubTitle,TTotal,TPrice,TCurrency;
public GameObject ArabicOrder,EnOrder;
GameObject g;


     void Awake()
    {
    
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
public void DisableMenu(){
 this.gameObject.SetActive(false);




}
public void LanguageHeader(){

if (UPDownMenu.LanguageValue == 1)
        {
          //  request.AddHeader("lang_api", "en");
MainTitle.Text="user profile - My orders";
SubTitle.Text="Order details ";
Items.Text="item total";
Amount.Text="No";
Total.Text="items";
TotalHeader.Text="total order";
Currency.Text="K.D";
TMainTitle.alignment= TextAnchor.MiddleLeft;
TSubTitle.alignment= TextAnchor.MiddleLeft;
TTotal.alignment= TextAnchor.MiddleLeft;
TMainTitle.alignment= TextAnchor.MiddleLeft;
TCurrency.alignment= TextAnchor.MiddleRight;
        }
        else
        {

//            request.AddHeader("lang_api", "ar");
MainTitle.Text="الملف الشخصي - طلباتى";
SubTitle.Text="تفاصيل الطلب";
Items.Text="المشتريات";
Amount.Text="العدد";
Total.Text="الإجمالى";
TotalHeader.Text="الإجمالى";
Currency.Text="د.ك";
TMainTitle.alignment= TextAnchor.MiddleRight;
TSubTitle.alignment= TextAnchor.MiddleRight;
TTotal.alignment= TextAnchor.MiddleRight;
TMainTitle.alignment= TextAnchor.MiddleRight;
TCurrency.alignment= TextAnchor.MiddleLeft;
        }



}
public void LoadDetails(){


try{
foreach (Transform child in Item.transform) {
     GameObject.Destroy(child.gameObject);
 }

 }
catch{}
LanguageHeader();
try{
var client = new RestClient("http://mymall-kw.com/api/V1/orders/"+id);
client.Timeout = -1;
var request = new RestRequest(Method.GET);
request.AddHeader("password-api", "mall_2021_m3m");
 if (UPDownMenu.LanguageValue == 1)
        {
            request.AddHeader("lang_api", "en");

        }
        else
        {

            request.AddHeader("lang_api", "ar");

        }
request.AddHeader("auth-token", AuthToken());
request.AlwaysMultipartFormData = true;
IRestResponse response = client.Execute(request);
print(response.Content);
Request=JsonConvert.DeserializeObject<OrderDetailsRequestRequest>(response.Content);
TPrice.text=Request.data.final_price.ToString();

foreach(var i in Request.data.carts)
{
if (UPDownMenu.LanguageValue == 1)
        {

g=GameObject.Instantiate(EnOrder, Item);

}
else
        {

g=GameObject.Instantiate( ArabicOrder, Item);
}

g.GetComponent<orderItemWithdetails>().Name.Text=i.name;
g.GetComponent<orderItemWithdetails>().Amount.text=i.quantity.ToString();
g.GetComponent<orderItemWithdetails>().TotalPrice.text=i.total_price.ToString();
g.GetComponent<orderItemWithdetails>().Price.text=i.price.ToString();
StartCoroutine(DownLoadSprite(i.img.ToString(),g.GetComponent<orderItemWithdetails>().Icon));

}
}
catch{}

}
IEnumerator DownLoadSprite(string URL,RawImage I1)
    {

        WWW www = new WWW(URL);
        yield return www;



        I1.texture = www.texture;

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


 public class OrderDetailsRequestCart
    {
        public int id { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public List<object> attributes { get; set; }
        public object img { get; set; }
        public int total_price { get; set; }
        public string name { get; set; }
    }

    public class OrderDetailsRequestShippingAddress
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string city { get; set; }
        public string zone { get; set; }
        public string street { get; set; }
        public string building { get; set; }
    }

    public class OrderDetailsRequestParentId
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public string sort { get; set; }
        public object parent_id { get; set; }
    }

    public class OrderDetailsRequestCategory
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public string sort { get; set; }
        public object parent_id { get; set; }
    }

    public class OrderDetailsRequestStore
    {
        public int id { get; set; }
        public string email { get; set; }
        public int is_active { get; set; }
        public int can_login { get; set; }
        public string logo { get; set; }
        public int position_id { get; set; }
        public int category_id { get; set; }
        public string password_text { get; set; }
        public string banner { get; set; }
        public string type { get; set; }
        public object floor { get; set; }
        public object hall { get; set; }
        public OrderDetailsRequestParentId parent_id { get; set; }
        public string name { get; set; }
        public string welcome_message { get; set; }
        public OrderDetailsRequestCategory category { get; set; }
    }

    public class OrderDetailsRequestData
    {
        public int id { get; set; }
        public int products_count { get; set; }
        public int order_price { get; set; }
        public int shipping_price { get; set; }
        public int final_price { get; set; }
        public object coupon_code { get; set; }
        public string discount_type { get; set; }
        public string note { get; set; }
        public string status { get; set; }
        public string payment_method { get; set; }
        public int delivery_time { get; set; }
        public int created_at { get; set; }
        public int discount { get; set; }
        public int coins { get; set; }
        public string type { get; set; }
        public string image { get; set; }
        public List<OrderDetailsRequestCart> carts { get; set; }
        public OrderDetailsRequestShippingAddress shipping_address { get; set; }
        public OrderDetailsRequestStore store { get; set; }
    }

    public class OrderDetailsRequestRequest
    {
        public int statsu { get; set; }
        public string message { get; set; }
        public OrderDetailsRequestData data { get; set; }
    }


