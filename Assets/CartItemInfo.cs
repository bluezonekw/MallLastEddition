using RestSharp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CartItemInfo : MonoBehaviour
{
    public RawImage ProductImage;
    public ArabicText ProductName, ProductPrice;
    public Text Quntity;
    public float RealQuntity;
    public int ProductId;
    public double PriceOne;

    // Start is called before the first frame update
    void Start()
    {


    }

    public void AddValueQuntity(bool x)
    {

        if (x)
        {
            if (RealQuntity >= 0)
            {

                RealQuntity += 1;
                CartInfo.price += PriceOne;
            }
        }
        else
        {
            if (RealQuntity > 0)
            {
                RealQuntity -= 1;
                CartInfo.price-= PriceOne;

            }

        }
        Quntity.text = RealQuntity.ToString();

        var client = new RestClient("http://mymall-kw.com/api/V1/carts/"+ProductId.ToString());
        client.Timeout = -1;
        var request = new RestRequest(Method.POST);
        request.AddHeader("password-api", "mall_2021_m3m");
        request.AddHeader("lang-api", "ar");
        request.AddHeader("auth-token", AuthToken());
        request.AlwaysMultipartFormData = true;
        request.AddParameter("quantity", RealQuntity);
        request.AddParameter("_method", "put");
        IRestResponse response = client.Execute(request);



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
