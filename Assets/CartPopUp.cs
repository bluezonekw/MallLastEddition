using Newtonsoft.Json;
using RestSharp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class CartPopUp : MonoBehaviour
    {
        public GameObject PopExitShop;
    private GameObject gameObject;
        public UIVirtualJoystick sai;
    public static float MovementValue;
    // Start is called before the first frame update
    void Start()
    {
        MovementValue = 1;
    }
    
      
        // Update is called once per frame
        void Update()
    {
        sai.magnitudeMultiplier = MovementValue;

        if (CheckEnterShop.ExitShop)
            {
            CheckEnterShop.ExitShop = false;
	if(!CheckEnterShop.CartEmpty){
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
            if (cartController.CartResponse.data.Carts.Count >0)
            {
                gameObject = GameObject.Instantiate(PopExitShop,GameObject.FindGameObjectWithTag("MainCanvas").transform);
                MovementValue = 0;
            }
            }
}

        }
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
}
