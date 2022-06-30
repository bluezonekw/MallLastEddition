using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTLTMPro;
using UnityEngine.UI;
using Newtonsoft.Json;
using RestSharp;
public class MyFriendData : MonoBehaviour
{
    public RTLTextMeshPro Name;
    public RawImage Icon;
    public string Chat;
    public RTLTextMeshPro Description , Time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
public void RmoveFriend(){

var client = new RestClient("http://mymall-kw.com/api/V1/friends/remove?user_id="+gameObject.name);
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
        AcceptRequest myDeserializedClass = JsonConvert.DeserializeObject<AcceptRequest>(response.Content);
if(myDeserializedClass.statsu==0){

    return;
}
else{
    Destroy(gameObject);
}




}

public void RejectRequest(){

var client = new RestClient("http://mymall-kw.com/api/V1/friends/rejection?user_id="+gameObject.name);
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
        AcceptRequest myDeserializedClass = JsonConvert.DeserializeObject<AcceptRequest>(response.Content);
if(myDeserializedClass.statsu==0){

    return;
}
else{
    Destroy(gameObject);
}




}
    public void AcceptFriend(){

var client = new RestClient("http://mymall-kw.com/api/V1/friends/accept?user_id="+gameObject.name);
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

        AcceptRequest myDeserializedClass = JsonConvert.DeserializeObject<AcceptRequest>(response.Content);
if(myDeserializedClass.statsu==0){

    return;
}
else{
    Destroy(gameObject);
}

    }





public void AddFriend(){
var client = new RestClient("http://mymall-kw.com/api/V1/friends/send-request");
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
request.AddParameter("user_id", gameObject.name);
IRestResponse response = client.Execute(request);
       Debug.Log(response.Content);
        AcceptRequest myDeserializedClass = JsonConvert.DeserializeObject<AcceptRequest>(response.Content);
if(myDeserializedClass.statsu==0){

    return;
}
else{
    Destroy(gameObject);
}










}


}
 public class AcceptRequest
    {
        public int statsu { get; set; }
        public string message { get; set; }
        public object data { get; set; }
    }