using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RestSharp;
using Newtonsoft.Json;
using UnityEngine.UI;

public class RequestDiscount : MonoBehaviour
{
    public InputField CouponCode;
    int Discountvalue;
    public AutofillPayment a;
    // Start is called before the first frame update
    void Start()
    {
        Discountvalue = 0;
    }
    public void ApplyDiscount()
    {

        StartCoroutine(checkCoupon(CouponCode.text, Discountvalue));
        a.applyDiscountOnPrice(Discountvalue);



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
    IEnumerator checkCoupon(string CouponCode,int discountValue)
    {
        var client = new RestClient("http://mymall-kw.com/api/V1/check-coupon");
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
        request.AddHeader("auth-token",AuthToken());
        request.AlwaysMultipartFormData = true;
        request.AddParameter("coupon_code", CouponCode);
        request.AddParameter("store_id", SingleSToreRequest.StaticStoreId);
        IRestResponse response = client.Execute(request);
        coupon coupon= JsonConvert.DeserializeObject<coupon>(response.Content);
        if (coupon.statsu == 1)
        {
            discountValue = coupon.data.discount;
        }
        else
        {
            discountValue = 0;
        }
        yield return response.Content;


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
