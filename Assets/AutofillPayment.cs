using RestSharp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System;
public class AutofillPayment : MonoBehaviour
{
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
    public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
    {
        // Unix timestamp is seconds past epoch
        System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
        dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
        return dtDateTime;
    }
    public void CompleteBuying()
    {
        if (NameField.text == "")
        {
            Messageobject.SetActive(true);
            MessageErorr.Text = "لا تترك حقل الاسم فارغ";
            return;
        }
        if (PhoneField.text == "")
        {
            Messageobject.SetActive(true);
            MessageErorr.Text = "لا تترك حقل رقم الهاتف فارغ";

            return;

        }


        if (EmailField.text == "")
        {
            Messageobject.SetActive(true);
            MessageErorr.Text = "لا تترك حقل الايميل فارغ";

            return;

        }

        if (City.text == "")
        {
            Messageobject.SetActive(true);
            MessageErorr.Text = "لاتترك حقل المدينة فارغ";

            return;

        }


        if (square.text == "")
        {

            Messageobject.SetActive(true);
            MessageErorr.Text = "لاتترك حقل القطعة فارغ";
            return;

        }


        if (street.text == "")
        {
            Messageobject.SetActive(true);
            MessageErorr.Text = "لاتترك حقل الشارع فارغ";

            return;

        }

        if (apartment.text == "")
        {
            
            Messageobject.SetActive(true);
            MessageErorr.Text = "لاتترك حقل رقم البناية فارغ";
            return;

        }
        StartCoroutine(createorder());
        

        GameObject g = GameObject.Instantiate(Recipt,GameObject.FindGameObjectWithTag("MainCanvas").transform);
        screenshotscript = g.GetComponent<ScreenshotNow>();
        if (orderinfo.statsu == 1) {
            screenshotscript.Name.Text = NameField.text;
            screenshotscript.Phone.Text = PhoneField.text;
            screenshotscript.OrderNumber.Text = orderinfo.data.id.ToString();
            screenshotscript.Price.Text = orderinfo.data.order_price.ToString()+" K.D";
            screenshotscript.Dateorder.Text = UnixTimeStampToDateTime(orderinfo.data.created_at).ToString();
            screenshotscript.DateArrival.Text = UnixTimeStampToDateTime(orderinfo.data.delivery_time).ToString();



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
    IEnumerator createorder()
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
        request.AddParameter("store_id", SingleSToreRequest.StaticStoreId);
        request.AddParameter("name", NameField.text);
        request.AddParameter("phone", PhoneField.text);
        request.AddParameter("email", EmailField.text);
        request.AddParameter("city", City.text);
        request.AddParameter("zone", square.text);
        request.AddParameter("street", street.text);
        request.AddParameter("building", apartment.text);
        request.AddParameter("note", Notes.text);
        request.AddParameter("coupon_code", discount.text);
        request.AddParameter("payment_method", "cash");
        IRestResponse response = client.Execute(request);
         orderinfo= JsonConvert.DeserializeObject<Order>(response.Content);
        yield return response.Content;

    }
    public void destoryPayment()
    {

        GameObject.Destroy(this.gameObject);
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

    public string Email()
    {

        try
        {
            return ApiClasses.Register.data.user.email;
        }
        catch

        {

            return ApiClasses.Login.data.original.user.email;

        }


    }


    public string Name()
    {

        try
        {
            return ApiClasses.Register.data.user.name;
        }
        catch

        {

            return ApiClasses.Login.data.original.user.name;

        }


    }


    public string Phone()
    {

        try
        {
            return ApiClasses.Register.data.user.phone;
        }
        catch

        {

            return ApiClasses.Login.data.original.user.phone;

        }


    }


}
