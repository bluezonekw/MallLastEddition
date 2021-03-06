using Newtonsoft.Json;
using RestSharp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CartInfo : MonoBehaviour
{
    public ArabicText totalPrice;
    public ArabicText counterController;
    public static double price,Shipping;
    public Transform CartItemTransform;

    public static bool Cartvisible;

    public bool ResumeBuying;
    public ArabicText CartText, TotalText,ClearaCarttext,Paytext,ResumeBuyingText;

public GameObject Buybtn,Clearbtn;
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
    public void CreatePayment()
    {
 if (UPDownMenu.LanguageValue == 1)
        {
 GameObject g=GameObject.Instantiate(Resources.Load<GameObject>("Payment/PayymentPanel(En)"), GameObject.FindGameObjectWithTag("MainCanvas").transform);}

else
        {
     GameObject g=GameObject.Instantiate(Resources.Load<GameObject>("Payment/PayymentPanel(Ar)"), GameObject.FindGameObjectWithTag("MainCanvas").transform);
}
        Destroy(gameObject);


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
       Debug.Log(response.Content);
        CheckEnterShop.CartEmpty=true;
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
       if (UPDownMenu.LanguageValue == 1)
        {

            CartText.Text = "Cart";
            TotalText.Text = "Total";
            if (ResumeBuying)
            {
                ResumeBuyingText.Text = "Resume Buying";
            }
            Paytext.Text = "Pay Now";
            ClearaCarttext.Text = "Clear Cart";
         
            
        }
        else
        {

            CartText.Text = "السلة";
            TotalText.Text = "الاجمالى";
            if (ResumeBuying)
            {
                ResumeBuyingText.Text = "متابعة عملية الشراء";
            }
            Paytext.Text = "ادفع الان";
            ClearaCarttext.Text = "تفريغ السلة";
         
           


        }

        Cartvisible = true;
        price = 0;
        Shipping = 0;
        GameObject g;

var client = new RestClient("http://mymall-kw.com/api/V1/carts");
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
       Debug.Log(response.Content);


        cartController.CartResponse=JsonConvert.DeserializeObject<CartResponse>(response.Content);

        if (cartController.CartResponse.statsu == 1)
        {
            foreach (CartData i in cartController.CartResponse.data.Carts)
            {
                g = GameObject.Instantiate(Resources.Load<GameObject>("Cart/ItemInCart"), CartItemTransform);
                price += i.total_price;

                StartCoroutine(DownLoadSprite(i.img, g.GetComponent<CartItemInfo>().ProductImage));
                g.GetComponent<CartItemInfo>().Quntity.text = i.quantity.ToString();
                g.GetComponent<CartItemInfo>().RealQuntity = i.quantity;
                g.GetComponent<CartItemInfo>().ProductPrice.Text = i.price.ToString() + " K.D";

                g.GetComponent<CartItemInfo>().ProductId = i.id;

                g.GetComponent<CartItemInfo>().PriceOne = i.price;

                g.GetComponent<CartItemInfo>().ProductName.Text = i.name;
            }
            totalPrice.Text = price.ToString() + " K.D";
            counterController.Text = cartController.CartResponse.data.Carts.Count.ToString();
            Shipping = cartController.CartResponse.data.shipping_price;
        }
        else
        {

           Debug.Log(cartController.CartResponse.message.ToString());

        }


    }
    public void CloseCartPanel()
    {
var foundCanvasObjects = FindObjectsOfType<UPDownMenu>();
foundCanvasObjects[0].UpdateCartCount();
        if (ResumeBuying || cartController.CartResponse.data.Carts.Count == 0) {

          
            Destroy(gameObject);




        }


        else
        {
            
            var client = new RestClient("http://mymall-kw.com/api/V1/carts");
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
           Debug.Log(response.Content);
            cartController.CartResponse = JsonConvert.DeserializeObject<CartResponse>(response.Content);
           Debug.Log(response.Content);
            if (cartController.CartResponse.data.Carts.Count == 0)
            {
              
                Destroy(gameObject);

            }
        }
    }
    IEnumerator DownLoadSprite(string URL, RawImage s)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(URL);
        yield return www.SendWebRequest();


        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            s.texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
           
        }

        www = null;
    }
    // Update is called once per frame
    void Update()
    {
        transform.GetChild(1).gameObject.SetActive(Cartvisible);
        totalPrice.Text = price.ToString() + " K.D";
try{

if (cartController.CartResponse.data.Carts.Count==0){

Buybtn.GetComponent<Button>().enabled=false;
Clearbtn.GetComponent<Button>().enabled=false;


}else

{

Buybtn.GetComponent<Button>().enabled=true;
Clearbtn.GetComponent<Button>().enabled=true;


}
}
catch{

Buybtn.GetComponent<Button>().enabled=false;
Clearbtn.GetComponent<Button>().enabled=false;


}

    }
}
