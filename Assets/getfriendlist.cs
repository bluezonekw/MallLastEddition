using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using RestSharp;
using System;
using UnityEngine.UI;

public class getfriendlist : MonoBehaviour
{
   public bool IsLoadFriends;
   public bool IsLoadSearchlist;

    public FriendListRequest friendList;
    public Transform Prentfriendlist;
    public GameObject Friend;
    // Start is called before the first frame update
    void Start()
    {
     /*  if(FriendsTabForChat.FriendsType==FriendsTabForChat.Friends.YourFriends){
         LoadFrienList();
        }
        else
         if(FriendsTabForChat.FriendsType==FriendsTabForChat.Friends.SearchFriends)
        {
LoadSearchlist("");
        }
        else
        {
             LoadFriendRequests();
        }*/
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
    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    { 
        if(IsLoadFriends){
        LoadFrienList();
    FriendsTabForChat.FriendsType=FriendsTabForChat.Friends.YourFriends;
        }
  else  if(IsLoadSearchlist)
  
   {
       FriendsTabForChat.FriendsType=FriendsTabForChat.Friends.SearchFriends;
       LoadSearchlist("");
   }
   else{
     FriendsTabForChat.FriendsType=FriendsTabForChat.Friends.FriendReques;
            LoadFriendRequests();
      
        
  }
    }
public void friendSearch(string Namefriend){

var client = new RestClient("http://mymall-kw.com/api/V1/friends/search?text="+Namefriend);
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


friendList=JsonConvert.DeserializeObject<FriendListRequest>(response.Content);
GameObject g=new GameObject();
if(friendList.statsu==0)
{return;

}
else{

    foreach(Transform child in Prentfriendlist){
        if(child.gameObject.active){
      GameObject.Destroy(child.gameObject);
        }
    }
}
foreach(var frienddata in friendList.data){
g=GameObject.Instantiate(Friend,Prentfriendlist);
g.SetActive(true);
g.name=frienddata.id.ToString();
g.GetComponent<MyFriendData>().Name.text=frienddata.name;
StartCoroutine(GetText(g.GetComponent<MyFriendData>().Icon,frienddata.image));
}





}
    
    public void LoadFrienList(){
try{
 var client = new RestClient("http://mymall-kw.com/api/V1/friends");
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
friendList=JsonConvert.DeserializeObject<FriendListRequest>(response.Content);
GameObject g=new GameObject();
if(friendList.statsu==0)
{
    return;

}
else{

    foreach(Transform child in Prentfriendlist){
        if(child.gameObject.active){
      GameObject.Destroy(child.gameObject);
        }
    }

}
foreach(var frienddata in friendList.data){
g=GameObject.Instantiate(Friend,Prentfriendlist);
g.SetActive(true);
g.name=frienddata.id.ToString()+"$"+frienddata.name;
g.GetComponent<MyFriendData>().Name.text=frienddata.name;
g.GetComponent<MyFriendData>().Chat=frienddata.id.ToString();

StartCoroutine(GetText(g.GetComponent<MyFriendData>().Icon,frienddata.image));

}



}
catch{

}

    }

 IEnumerator GetText(RawImage t,string url)
    {
         if(!string.IsNullOrEmpty( url)){
            url=@"https://mymall-kw.com/assets/users/"+url;

                WWW wWW =new WWW(url);
       yield return wWW;
       print(wWW.texture.EncodeToPNG().Length);
       t.texture=wWW.texture;
         }else{

        yield  return null;
         }
   
    }
public void LoadFriendRequests(){

var client = new RestClient("http://mymall-kw.com/api/V1/friends/show-requests");
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
FriendRequests      FriendRequests=JsonConvert.DeserializeObject<FriendRequests>(response.Content);
GameObject g=new GameObject();
if(FriendRequests.statsu==0)
{return;

}
else{

    foreach(Transform child in Prentfriendlist){
        if(child.gameObject.active){
      GameObject.Destroy(child.gameObject);
        }
    }
}
foreach(var frienddata in FriendRequests.data){
g=GameObject.Instantiate(Friend,Prentfriendlist);
g.SetActive(true);
g.name=frienddata.user_send.id.ToString();
g.GetComponent<MyFriendData>().Name.text=frienddata.user_send.name;
StartCoroutine(GetText(g.GetComponent<MyFriendData>().Icon,frienddata.user_send.image));

}




}








    public void LoadSearchlist(string searchtext){

 var client = new RestClient("http://mymall-kw.com/api/V1/friends/search-user?text="+searchtext);
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
friendList=JsonConvert.DeserializeObject<FriendListRequest>(response.Content);
GameObject g=new GameObject();
if(friendList.statsu==0)
{return;

}
else{

    foreach(Transform child in Prentfriendlist){
        if(child.gameObject.active){
      GameObject.Destroy(child.gameObject);
        }
    }
}
foreach(var frienddata in friendList.data){
g=GameObject.Instantiate(Friend,Prentfriendlist);
g.SetActive(true);
g.name=frienddata.id.ToString();
g.GetComponent<MyFriendData>().Name.text=frienddata.name;
StartCoroutine(GetText(g.GetComponent<MyFriendData>().Icon,frienddata.image));

}









    }
}

 public class DataFrienList
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public object email_verified_at { get; set; }
        public int gander { get; set; }
        public int coins { get; set; }
         public string image { get; set; }
        public int total_orders_cost { get; set; }
        public int total_coins_spend { get; set; }
     
    }

    public class FriendListRequest
    {
        public int statsu { get; set; }
        public string message { get; set; }
        public List<DataFrienList> data { get; set; }
    }


 public class UserSend
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public object email_verified_at { get; set; }
        public int gander { get; set; }
        public int coins { get; set; }
         public string image { get; set; }
        public int total_orders_cost { get; set; }
        public int total_coins_spend { get; set; }
    }

    public class DataFriendRequests
    {
    
        public UserSend user_send { get; set; }
    }

    public class FriendRequests
    {
        public int statsu { get; set; }
        public string message { get; set; }
        public List<DataFriendRequests> data { get; set; }
    }

