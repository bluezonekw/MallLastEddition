using Newtonsoft.Json;
using RestSharp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    public class UPDownMenu : MonoBehaviour
    {
        bool IsShow;
        public AnimationClip Up, Down;
        public Animation A1;
        public GameObject Cart;
        public static int LanguageValue;
        public Dropdown D1;
    public GameObject Map;
public GameObject B1;
public GameObject FavoriteMenu;
        // Start is called before the first frame update
public void CreateFavotite(){

GameObject.Instantiate(FavoriteMenu, GameObject.FindGameObjectWithTag("MainCanvas").transform);

}

 void Awake()
    {

   Map.SetActive(true);

}
        void Start()
        {
            IsShow = true;
            LanguageValue = 0;

Map.SetActive(false);
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
        
            LoadStores.isactive = !LoadStores.isactive; 
        Map.SetActive(LoadStores.isactive);
    }
        public void ChangeLanguage()
        {

            LanguageValue = D1.value;



        }
        public void OpenCart()
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
            GameObject.Instantiate(Cart, GameObject.FindGameObjectWithTag("MainCanvas").transform);
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
if(CheckEnterShop.EnterShop ){

B1.GetComponent<Button>().enabled=false;


}

if( !CheckEnterShop.EnterShop){

B1.GetComponent<Button>().enabled=true;


}

        }
    }
