using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RTLTMPro;
using RestSharp;
using Newtonsoft.Json;
using System;
public class NotifictionItem : MonoBehaviour
{
    public GameObject Player;
    public RawImage Icon;
    public RTLTextMeshPro text, Time;
    public string typeid, type;
    public GameObject ProductPanel, OrderItem;
    public GameObject Viewbtn;

    public GameObject Loading;
    // Start is called before the first frame update
    public void ShowNotification()
    {

        var client = new RestClient("http://mymall-kw.com/api/V1/notifications/show");
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
        request.AddParameter("notificaton_id", gameObject.name);
        IRestResponse response = client.Execute(request);

        print(response.Content);


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




    public void view()
    {

        if (type == "Product")
        {
            var client = new RestClient("http://mymall-kw.com/api/V1/get-single-product/" + typeid);
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

            print(response.Content);

            GameObject g = GameObject.Instantiate(ProductPanel, GameObject.FindGameObjectWithTag("MainCanvas").transform);
            GetDetailsProduct.ProductRequst = JsonConvert.DeserializeObject<StoreProduct>(response.Content);


        }
        else


        if (type == "Order")
        {
            GameObject g = GameObject.Instantiate(OrderItem, GameObject.FindGameObjectWithTag("MainCanvas").transform);
            g.GetComponent<OrderDetails>().id = typeid;
            g.GetComponent<OrderDetails>().LoadDetails();

        }

        else


        if (type == "FriendRequest")
        {
            GameObject g = GameObject.Find("ChatCanvas").transform.GetChild(0).gameObject;
            g.SetActive(true);
            g.GetComponent<MainButtonInchat>().ClickOnCalls();
            g.transform.GetChild(1).gameObject.GetComponent<FriendsTabForChat>().ClickOnFriendReques();


        }
        else


        if (type == "FriendAccept")
        {
            GameObject g = GameObject.Find("ChatCanvas").transform.GetChild(0).gameObject;
            g.SetActive(true);
            g.GetComponent<MainButtonInchat>().ClickOnCalls();
            g.transform.GetChild(1).gameObject.GetComponent<FriendsTabForChat>().ClickOnYourFriends();


        }
        else
        if (type == "Store")
        {
            Gotostore(int.Parse(typeid) - 1);


        }
        else
        {
            Viewbtn.SetActive(false);
        }

        show();




    }

    public void show()
    {
        var client = new RestClient("http://mymall-kw.com/api/V1/notifications/show");
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
        request.AddParameter("notificaton_id", gameObject.name);
        IRestResponse response = client.Execute(request);

        print(gameObject.name + response.Content);
        UPDownMenu.instance.UpdateNotificationCount();
        n.NumberofNotification.text = UPDownMenu.instance.NotificationText.text;
    }
    public loadnotification n;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        n = FindObjectOfType<loadnotification>();

        n.NumberofNotification.text = UPDownMenu.instance.NotificationText.text;
    }









    public GameObject g;
    public void Gotostore(int storeid)
    {

        g = GameObject.Instantiate(Loading, GameObject.FindGameObjectWithTag("MainCanvas").transform);
        Player.GetComponent<CharacterController>().enabled = false;
        try
        {
            Player.transform.localPosition = UPDownMenu.instance.StoreLocation[storeid];
        }
        catch
        {

            Player.transform.localPosition = UPDownMenu.instance.StoreLocation[0];
        }

        Player.GetComponent<CharacterController>().enabled = true;

        StartCoroutine(ExampleCoroutine(storeid));


    }


    IEnumerator ExampleCoroutine(int storeid)
    {


        Player.GetComponent<CharacterController>().enabled = false;

        try
        {
            Player.transform.localPosition = UPDownMenu.instance.StoreLocation[storeid];
            if (Player.transform.localPosition.x == 19)

            {

                Player.transform.localPosition += new Vector3(-1, 0, 0);


            }
            if (Player.transform.localPosition.x == -19f)

            {
                Player.transform.localPosition += new Vector3(1, 0, 0);
            }
        }
        catch
        {

            Player.transform.localPosition = UPDownMenu.instance.StoreLocation[0];
        }

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);
        /*while (MallLoader.Isload){
        yield return new WaitForSeconds(1);
        }
         */
        Destroy(g);


        Player.GetComponent<CharacterController>().enabled = true;
        LoadStores.isactive = false;
        GameObject.Destroy(n.gameObject);
    }


}
