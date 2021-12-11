using Newtonsoft.Json;
using RestSharp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class favMenu : MonoBehaviour
{
    public GameObject FullMenu, EmptyMenu;
    public static FavRequest FavRequest;
    // Start is called before the first frame update
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
    void Start()
    {
        EmptyMenu.SetActive(false);
        var client = new RestClient("http://mymall-kw.com/api/V1/favorite");
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
        FavRequest = JsonConvert.DeserializeObject<FavRequest>(response.Content);
        if (FavRequest.data.data.Count == 0)
        {

            EmptyMenu.SetActive(true);

        }
        else
        {
            GameObject.Instantiate(FullMenu, this.transform);

        }
        print(response.Content);
    }
    public void  DestroyFav()
    {


        GameObject.Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
