using Newtonsoft.Json;
using RestSharp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Networking;
using System.Linq;

public class CountNotification
{

    public int statsu;
    public string message;
    public int data;
}
public class UPDownMenu : MonoBehaviour
{


    public static UPDownMenu instance;
    public List<Vector3> StoreLocation;






    bool openchat;

    public Text NotificationText;
    public GameObject Chat;
    public void OpenCloseChat()
    {
        if (!ApiClasses.Vistor)
        {
            if (!openchat)
            {
                CloseAllMenus();
            }

            openchat = !openchat;
            Chat.SetActive(openchat);
        }
        else
        {
            GameObject.Instantiate(loginGameobject, GameObject.FindGameObjectWithTag("MainCanvas").transform);
        }

    }
    public bool notifiyopen;
    public void openNotification()
    {
        notifiyopen = !notifiyopen;
        if (notifiyopen)
        {
            if (!ApiClasses.Vistor)
            {
                GameObject.Instantiate(Resources.Load<GameObject>("Notifications"), GameObject.FindGameObjectWithTag("MainCanvas").transform);
            }
            else
            {
                GameObject.Instantiate(loginGameobject, GameObject.FindGameObjectWithTag("MainCanvas").transform);
            }
        }
        else
        {

            CloseAllMenus();

        }

    }
    public static bool Login;
    bool IsShow;
    public AnimationClip Up, Down;
    public Animation A1;

    public static int LanguageValue;
    public Dropdown D1;
    public GameObject Map;
    public static int coinsnumber;
    public GameObject B1;
    public GameObject FavoriteMenu;
    public GameObject CoinsMenu;
    public Text CartCount;
    public GameObject MainCanvasObject;
    public GameObject profile;
    public Text TCoinsNumber;

    public GameObject loginGameobject;
    public Text RoomMember;
    public newGameManager mainmanager;
    public OrderDetails OrderDetailsObject;

    public bool profileopend;
    public void openprofile()
    {
        if (!ApiClasses.Vistor)
        {
            if (!profileopend)
            {
                CloseAllMenus();
            }
            profileopend = !profileopend;
            profile.SetActive(true);
        }
        else
        {
            GameObject.Instantiate(loginGameobject, GameObject.FindGameObjectWithTag("MainCanvas").transform);
        }


    }
    public void UpdateCoinsNumber()
    {
        if (coinsnumber > 1000 && coinsnumber < 1000000)
        {
            double xy = coinsnumber / 1000;
            TCoinsNumber.text = Math.Round(xy, 2).ToString() + "K";



        }
        else if (coinsnumber > 1000000)
        {

            double xy = coinsnumber / 1000000;
            TCoinsNumber.text = Math.Round(xy, 2).ToString() + "M";
        }
        else
        {





            TCoinsNumber.text = coinsnumber.ToString();

        }




    }




    public void UpdateCartCount()
    {
        try
        {
            var client = new RestClient("http://mymall-kw.com/api/V1/carts");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("password-api", "mall_2021_m3m");
            if (LanguageValue == 1)
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

            CartCount.text = cartController.CartResponse.data.Carts.Count.ToString();

        }
        catch
        {

            CartCount.text = "0";


        }

    }



    public void CloseAllMenus()
    {
        try
        {
            foreach (Transform child in MainCanvasObject.transform)
            {
                GameObject.Destroy(child.gameObject);
            }

        }
        catch { }
        LoadStores.isactive = false;
        Map.SetActive(false);
        profile.SetActive(false);
        Chat.SetActive(false);

    }




    // Start is called before the first frame update
    public void CreateFavotite()
    {
        if (!ApiClasses.Vistor)
        {
            GameObject.Instantiate(FavoriteMenu, GameObject.FindGameObjectWithTag("MainCanvas").transform);
        }
        else
        {
            GameObject.Instantiate(loginGameobject, GameObject.FindGameObjectWithTag("MainCanvas").transform);
        }

    }
  
    public void CreateCoins()
    {
        if (!ApiClasses.Vistor)
        {
           
                CloseAllMenus();


                GameObject.Instantiate(CoinsMenu, GameObject.FindGameObjectWithTag("MainCanvas").transform);
           
        }
        else
        {
            GameObject.Instantiate(loginGameobject, GameObject.FindGameObjectWithTag("MainCanvas").transform);
        }

    }

    public void UpdateNotificationCount()
    {



        var client = new RestClient("http://mymall-kw.com/api/V1/notifications/count");
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
        IRestResponse response = client.Execute(request);
       Debug.Log(response.Content);
        CountNotification notification = JsonConvert.DeserializeObject<CountNotification>(response.Content);
        NotificationText.text = notification.data.ToString();
    }
    void Awake()
    {
        instance = this;

    }






    void Start()
    {











        if (!ApiClasses.Vistor)
        {
            UpdateCartCount();
            UpdateNotificationCount();

            if (cartController.CartResponse.data.Carts.Count > 0)
            {

                OpenCart2();




            }

            coinsnumber = Coins();
        }
        else
        {
            coinsnumber = 0;
            UpdateCoinsNumber();

            CartCount.text = "0";


        }
















        if (!ApiClasses.Vistor)
        {
            UpdateCoinsNumber();
        }
        IsShow = true;
        LanguageValue = 0;


    }
    public void Show_HidePanel()
    {
        if (IsShow)
        {
            A1.clip = Up;
            A1.Play();

        }
        else
        {

            A1.clip = Down;
            A1.Play();
        }



        IsShow = !IsShow;
    }
    public void ShowHideMap()
    {
        if (!LoadStores.isactive)
        {
            CloseAllMenus();
        }
        LoadStores.isactive = !LoadStores.isactive;

        Map.SetActive(LoadStores.isactive);
    }
    public List<LangaueChange> langaueChanges;
    public void assignChangeLangueInterface()
    {
        try
        {
            if (langaueChanges.Count != 0 || langaueChanges != null)
            {
                langaueChanges.Clear();
            }  
            langaueChanges.AddRange(FindObjectsOfType<MonoBehaviour>().OfType<LangaueChange>());
            langaueChanges.ForEach(x => x.ChangeLangaue(D1.value));
        }
        catch
        {

        }
      

    }
    public void ChangeLanguage()
    {
        LanguageValue = D1.value;
        UpdateCartCount();
        assignChangeLangueInterface();
       
       


    }

    public void OpenCart()
    {
        try
        {
            if (!ApiClasses.Vistor)
            {   
              
                    CloseAllMenus();
                 

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
                    GameObject.Instantiate(Resources.Load<GameObject>("CartInShopMain"), GameObject.FindGameObjectWithTag("MainCanvas").transform);
               
            }

            else
            {
                GameObject.Instantiate(loginGameobject, GameObject.FindGameObjectWithTag("MainCanvas").transform);
            }
        }
        catch
        {

        }
    }



    public void OpenCart2()
    {
        try
        {
            if (!ApiClasses.Vistor)
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
                GameObject.Instantiate(Resources.Load<GameObject>("CartOutShop"), GameObject.FindGameObjectWithTag("MainCanvas").transform);
            }
            else
            {
                GameObject.Instantiate(loginGameobject, GameObject.FindGameObjectWithTag("MainCanvas").transform);
            }
        }
        catch
        {

        }
    }


    public string AuthToken()
    {

        if (!Login)
        {
            return ApiClasses.Register.data.token;
        }
        else

        {

            return ApiClasses.Login.data.original.access_token;

        }


    }
    // Update is called once per frame
    void Update()
    {
        if (CheckEnterShop.EnterShop)
        {

            B1.GetComponent<Button>().enabled = false;


        }

        if (!CheckEnterShop.EnterShop)
        {

            B1.GetComponent<Button>().enabled = true;


        }


        RoomMember.text = mainmanager.countRoom.ToString();

    }
    public int Coins()
    {
        try
        {
            if (Login)
            {
                return ApiClasses.Login.data.original.user.coins;
            }
            else

            {

                return ApiClasses.Register.data.user.coins;


            }


        }
        catch
        {
            return 0;
        }
    }
}







