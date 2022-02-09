using RestSharp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontLeaveShop : MonoBehaviour
{
    public GameObject Cart;
    public ArabicText Pay, Clear, Message;
    // Start is called before the first frame update
    void Start()
    {
        if (UPDownMenu.LanguageValue == 1)
        {
            Pay.Text = "Pay";
            Clear.Text = "Clear Cart";
            Message.Text = "Don't Leave You Have Discount !!";




        }
        else
        {
            Pay.Text = "الدفع";
            Clear.Text = "تفريغ السلة";
            Message.Text = "!! لاتغادر هناك فرصة لخصم إضافي";




        }
    }
    public void RestMovepMove(){
        CartPopUp.MovementValue = 1;


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
    public void ClearCart()
    {
        var client = new RestClient("http://mymall-kw.com/api/V1/clear-cart");
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
        CheckEnterShop.CartEmpty=true;
        RestMovepMove();
        DestroyThisObject();




    }
    public void DestroyThisObject()
    {

        GameObject.Destroy(gameObject);


    }
    public void ResumePay()
    {
        RestMovepMove();
        DestroyThisObject();
        GameObject.Instantiate(Cart,GameObject.FindGameObjectWithTag("MainCanvas").transform);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
