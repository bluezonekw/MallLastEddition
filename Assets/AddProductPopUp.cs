using Newtonsoft.Json;
using RestSharp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddProductPopUp : MonoBehaviour
{
    public GameObject  Message1,Message2;
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        if (GetDetailsProduct.addTocartrequest.statsu == 1)
        {
            Message1.SetActive(true);
        }else
        {
            Message2.SetActive(true);
            button.SetActive(false);
        }

    }
    IEnumerator DownLoadSprite(string URL, RawImage s)
    {

        WWW www = new WWW(URL);
        yield return www;



        s.texture = www.texture;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void DestroyCurrent()
    {
        GameObject.Destroy(gameObject);
    }
    public void ResumeToCart()
    {
        var client = new RestClient("http://mymall-kw.com/api/V1/carts");
        client.Timeout = -1;
        var request = new RestRequest(Method.GET);
        request.AddHeader("password-api", "mall_2021_m3m");
        request.AddHeader("lang-api", "ar");
        request.AddHeader("auth-token", AuthToken());
        request.AlwaysMultipartFormData = true;
        IRestResponse response = client.Execute(request);
        cartController.CartResponse = JsonConvert.DeserializeObject<CartResponse>(response.Content);
        print(response.Content);
        cartController.ValueUpdated = true;
        cartController.ActiveCart=true;
        cartController.ActiveContainer = true;
        DestroyCurrent();



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
}
