using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RestSharp;
using Newtonsoft.Json;

public class RequesStoresInHall : MonoBehaviour
{
    public int numberOfStores;
    public Hall Halls_info;
    private void Awake()
    {

        var client = new RestClient(@"https://mymall-kw.com/api/V1/get-stores-pagination?page=1&limit=" + numberOfStores);
        client.Timeout = -1;
        var request = new RestRequest(Method.GET);
        request.AddHeader("password_api", "mall_2021_m3m");
        request.AddHeader("lang_api", "en");
        request.AlwaysMultipartFormData = true;
        IRestResponse response = client.Execute(request);
        Halls_info = JsonConvert.DeserializeObject<Hall>(response.Content);
     
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
