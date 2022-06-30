using Newtonsoft.Json;
using RestSharp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddProductPopUp : MonoBehaviour, LangaueChange
{
    public ArabicText Message1, Open, Resume;
    public GameObject button;
    public GameObject Cart;
    // Start is called before the first frame update
    void Start()
    {

        if (GetDetailsProduct.addTocartrequest.statsu == 1)
        {
            var foundObjects = FindObjectsOfType<UPDownMenu>();
            foundObjects[0].UpdateCartCount();
            button.SetActive(true);


        }
        else
        {
            button.SetActive(false);


        }
        ChangeLangaue(UPDownMenu.LanguageValue);

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
        cartController.CartResponse = JsonConvert.DeserializeObject<CartResponse>(response.Content);
       Debug.Log(response.Content);
        GameObject.Instantiate(Cart, GameObject.FindGameObjectWithTag("MainCanvas").transform);
        DestroyCurrent();



    }



    public string AuthToken()
    {

        if (!UPDownMenu.Login)
        {
            return ApiClasses.Register.data.token;
        }
        else

        {

            return ApiClasses.Login.data.original.access_token;

        }


    }

    public void ChangeLangaue(int Vaule)
    {
        if (GetDetailsProduct.addTocartrequest.statsu == 1)
        {
            if (Vaule == 1)
            {

                Message1.Text = "Order Added Sucessfully";
                Open.Text = "Go To Cart";
                Resume.Text = "Resume Buying";




            }

            else
            {

                Message1.Text = "تم الاضافة بنجاح";

                Open.Text = "الذهاب الى السلة";
                Resume.Text = "متابعة الشراء";





            }
        }
        else
        {

            if (Vaule == 1)
            {



                Message1.Text = "Please Try Again !!";
                Resume.Text = "Resume Buying";

            }

            else
            {




                Message1.Text = "من فضلك حاول مرة اخرى ";
                Resume.Text = "متابعة الشراء";

            }



        }



    }
}
