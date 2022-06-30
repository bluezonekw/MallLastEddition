using Newtonsoft.Json;
using RestSharp;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CheckVerisionApp : MonoBehaviour
{
    public GameObject AppStart, Error;
    private string verisionNumber;
    // Start is called before the first frame update
     void Awake()
    {
        var client = new RestClient("http://mymall-kw.com/api/V1/get-version");
        client.Timeout = -1;
        var request = new RestRequest(Method.GET);
        request.AlwaysMultipartFormData = true;
        IRestResponse response = client.Execute(request);
       Debug.Log(response.Content);
        VerisionApi myDeserializedClass = JsonConvert.DeserializeObject<VerisionApi>(response.Content);
        verisionNumber = myDeserializedClass.data;
       
        if (Application.version== verisionNumber)
        {
            AppStart.SetActive(true);
        }
        else
        {
            Error.SetActive(true);
           
        }
        
    }

    public void DestoryMessage()
    {

 AppStart.SetActive(true);
   Error.SetActive(false);
    }
    public void tryAgain()
    {

        if (Application.version == verisionNumber)
        {
            AppStart.SetActive(true);
        }
        else
        {
            Error.SetActive(true);
        }


    }
}


public class VerisionApi
{
    public int statsu { get; set; }
    public string message { get; set; }
    public string data { get; set; }
}