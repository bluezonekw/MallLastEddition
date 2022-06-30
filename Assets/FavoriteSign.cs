using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RestSharp;
using Newtonsoft;
using UnityEngine.EventSystems;

public class FavoriteSign : MonoBehaviour
{
    private Button CurrentB;
    public bool selected;
    public GameObject loginGameobject;
    // Start is called before the first frame update
    public BaseEventData Onselct, Deselect;
    void Start()
    {
        CurrentB = GetComponent<Button>();

    }
    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            CurrentB.GetComponent<Image>().color = CurrentB.colors.pressedColor;


        }
        else
        {
            CurrentB.GetComponent<Image>().color = Color.white;
        }
    }
    public void addandremoveproductfavorite()
    {
        if (!ApiClasses.Vistor)
        {



            var client = new RestClient("http://mymall-kw.com/api/V1/favorite");
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
            request.AddParameter("product_id", loadimageFromApi.ProductRequst.data.id.ToString());
            IRestResponse response = client.Execute(request);
           Debug.Log(response.Content);
            selected = !selected;
            if (selected)
            {
                CurrentB.GetComponent<Image>().color = CurrentB.colors.pressedColor;


            }
            else
            {
                CurrentB.GetComponent<Image>().color = Color.white;
            }
        }
        else
        {


            GameObject.Instantiate(loginGameobject, GameObject.FindGameObjectWithTag("MainCanvas").transform);
        }

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


}
