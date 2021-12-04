using RestSharp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontLeaveShop : MonoBehaviour
{
    public GameObject Cart;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void RestMovepMove(){
        CartPopUp.MovementValue = 1;


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
    public void ClearCart()
    {
        var client = new RestClient("http://mymall-kw.com/api/V1/clear-cart");
        client.Timeout = -1;
        var request = new RestRequest(Method.GET);
        request.AddHeader("password-api", "mall_2021_m3m");
        request.AddHeader("lang-api", "ar");
        request.AddHeader("auth-token", AuthToken());
        request.AlwaysMultipartFormData = true;
        IRestResponse response = client.Execute(request);
        print(response.Content);
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
        GameObject.Instantiate(Cart);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
