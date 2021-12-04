using Newtonsoft.Json;
using RestSharp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CartInfo : MonoBehaviour
{
    public ArabicText totalPrice;
    public ArabicText counterController;
    public static double price;
    public Transform CartItemTransform;
    public GameObject CartItemGameObject;
    public static bool Cartvisible;
    public GameObject PaymentPanel;

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
    public void CreatePayment()
    {
        GameObject.Instantiate(PaymentPanel);

        Cartvisible = false;



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

        cartController.CartResponse = null;
        foreach(Transform child in CartItemTransform)
        {

            Destroy(child.gameObject);
        }
        totalPrice.Text = "0" + " K.D";
        counterController.Text = "0";

    }
    // Start is called before the first frame update
    void Start()
    {
        Cartvisible = true;
        price = 0;
        GameObject g;
        foreach (var i in cartController.CartResponse.data)
        { 
            g = GameObject.Instantiate(CartItemGameObject, CartItemTransform);
            price += i.total_price;

            StartCoroutine(DownLoadSprite(i.img,g.GetComponent<CartItemInfo>().ProductImage));
            g.GetComponent<CartItemInfo>().Quntity.text = i.quantity.ToString();
            g.GetComponent<CartItemInfo>().RealQuntity = i.quantity;
            g.GetComponent<CartItemInfo>().ProductPrice.Text = i.price.ToString() + " K.D";

            g.GetComponent<CartItemInfo>().ProductId = i.id;

            g.GetComponent<CartItemInfo>().PriceOne = i.price ;

            g.GetComponent<CartItemInfo>().ProductName.Text = i.name;
            print("name is   " + i.name);
    }
        totalPrice.Text = price.ToString() + " K.D";
        counterController.Text = cartController.CartResponse.data.Count.ToString();



    }
    public void CloseCartPanel()
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
        if (cartController.CartResponse.data.Count == 0)
        {
            Destroy(gameObject);

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
        transform.GetChild(1).gameObject.SetActive(Cartvisible);
        totalPrice.Text = price.ToString() + " K.D";

    }
}
