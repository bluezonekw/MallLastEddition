using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RTLTMPro;
using RestSharp;
using Newtonsoft.Json;

public class NotifictionItem : MonoBehaviour
{
    public RawImage Icon;
    public RTLTextMeshPro text,Time;
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
}
