using Newtonsoft.Json;
using RestSharp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

    public class UPDownMenu : MonoBehaviour
    {
public static bool Login;
        bool IsShow;
        public AnimationClip Up, Down;
        public Animation A1;
        public GameObject Cart;
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
public GameObject Cart2;
public GameObject loginGameobject;
public void openprofile(){
 if(!ApiClasses.Vistor){
    profile.SetActive(true);
 }else
 {
     GameObject.Instantiate(loginGameobject, GameObject.FindGameObjectWithTag("MainCanvas").transform);
 }


}
public void UpdateCoinsNumber(){
if(coinsnumber<1000){
TCoinsNumber.text=coinsnumber.ToString();




}
else{
double xy=coinsnumber/1000;


TCoinsNumber.text=Math.Round(xy, 2).ToString()+"K";



}




}




public void UpdateCartCount(){
try{
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



cartController.CartResponse=JsonConvert.DeserializeObject<CartResponse>(response.Content);

CartCount.text=cartController.CartResponse.data.Carts.Count.ToString();

}catch{

CartCount.text="0";


}

}



public void CloseAllMenus(){
try{
foreach (Transform child in MainCanvasObject.transform) {
     GameObject.Destroy(child.gameObject);
 }

 }
catch{}
LoadStores.isactive = false; 
        Map.SetActive(LoadStores.isactive);
profile.SetActive(false);



}




        // Start is called before the first frame update
public void CreateFavotite(){
 if(!ApiClasses.Vistor){
GameObject.Instantiate(FavoriteMenu, GameObject.FindGameObjectWithTag("MainCanvas").transform);
 }
 else
 {
     GameObject.Instantiate(loginGameobject, GameObject.FindGameObjectWithTag("MainCanvas").transform);
 }

}

public void CreateCoins(){
 if(!ApiClasses.Vistor){
GameObject.Instantiate(CoinsMenu, GameObject.FindGameObjectWithTag("MainCanvas").transform);
}
else
 {
     GameObject.Instantiate(loginGameobject, GameObject.FindGameObjectWithTag("MainCanvas").transform);
 }

}

 void Awake()
    {
         if(!ApiClasses.Vistor){
UpdateCartCount();
         

if(cartController.CartResponse.data.Carts.Count>0){

OpenCart2();




}
         
coinsnumber=Coins();
}
else{
    coinsnumber=0;
    UpdateCoinsNumber();

CartCount.text="0";


}

  

}
        void Start()
        {
             if(!ApiClasses.Vistor){
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
        
            LoadStores.isactive = !LoadStores.isactive; 
        Map.SetActive(LoadStores.isactive);
    }
        public void ChangeLanguage()
        {

            LanguageValue = D1.value;
UpdateCartCount();


        }
        public void OpenCart()
        {
            try{
 if(!ApiClasses.Vistor){


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

 else
 {
     GameObject.Instantiate(loginGameobject, GameObject.FindGameObjectWithTag("MainCanvas").transform);
 }
            }
            catch{

            }
        }



 public void OpenCart2()
        {
            try{
 if(!ApiClasses.Vistor){


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
            print(response.Content);
            cartController.CartResponse = JsonConvert.DeserializeObject<CartResponse>(response.Content);
            GameObject.Instantiate(Cart2, GameObject.FindGameObjectWithTag("MainCanvas").transform);
 }
 else
 {
     GameObject.Instantiate(loginGameobject, GameObject.FindGameObjectWithTag("MainCanvas").transform);
 }
            }
            catch{
                
            }
        }


        public string AuthToken()
        {

            if(!Login)
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
if(CheckEnterShop.EnterShop ){

B1.GetComponent<Button>().enabled=false;


}

if( !CheckEnterShop.EnterShop){

B1.GetComponent<Button>().enabled=true;


}

        }
public int Coins(){
try{
 if(Login)
            {
                 return ApiClasses.Login.data.original.user.coins;
            }
            else

            {

 return ApiClasses.Register.data.user.coins;
              

            }


}
catch{
    return 0;
}
}
    }







