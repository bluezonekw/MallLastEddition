using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GetData : MonoBehaviour
{
    public InputField EmailI, PhoneI;
    public Text NameI, AdressI;
    public UnityEngine.UI.Toggle Male, Female;
    public RawImage ProfilePic;
    public string Adress()
    {

        if(!UPDownMenu.Login)
        {
            return ApiClasses.Register.data.user.address;
        }
        else
        {
            return ApiClasses.Login.data.original.user.address;

        }


    }
    public void Gender()
    {

        if(!UPDownMenu.Login)
        {
            if (ApiClasses.Register.data.user.gander =="0")
            {
                Male.isOn = true;

            }
            if (ApiClasses.Register.data.user.gander == "1")
            {
                Female.isOn = true;
            }
        }
        else
        {

            if (ApiClasses.Login.data.original.user.gander == 0)
            {
                Male.isOn = true;
              

            }
            if (ApiClasses.Login.data.original.user.gander == 1)
            {
                Female.isOn = true;
              
            }

        }

    }
    public string UserName()
    {
       if(!UPDownMenu.Login)
        {
            return ApiClasses.Register.data.user.name;
        }
        else
        {
            return ApiClasses.Login.data.original.user.name;

        }
    }


    public string Email()
    {
        if(!UPDownMenu.Login)
        {
            return ApiClasses.Register.data.user.email;
        }
        else
        {
            return ApiClasses.Login.data.original.user.email;
        }
    }
    public string Phone()
    {

        if(!UPDownMenu.Login)
        {
            return ApiClasses.Register.data.user.phone;
        }
        else
        {
            return ApiClasses.Login.data.original.user.phone;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        NameI.GetComponent<ArabicText>().Text =  UserName();
        EmailI.text = Email();
        PhoneI.text = Phone();
        AdressI.text = Adress();
    StartCoroutine( GetText(  ProfilePic));
    }

    IEnumerator GetText(RawImage t)
    {string url="";
           
       if(!UPDownMenu.Login)
        {
            url=ApiClasses.Register.data.user.image;
        }
        else
        {
            url= ApiClasses.Login.data.original.user.image;

        }
         if(url!=""){
            url=@"https://mymall-kw.com/assets/users/"+url;

                WWW wWW =new WWW(url);
       yield return wWW;
       print(wWW.texture.EncodeToPNG().Length);
       t.texture=wWW.texture;
         }else{
        yield  return null;
         }
   
    }
    
public void changeProfilePic(){
   
if( NativeFilePicker.IsFilePickerBusy() )
			return;
      
string path="";
/////////////////

NativeFilePicker.Permission permission = NativeFilePicker.PickFile( ( paths ) =>
			{
				if( paths == null )
					{
                        return;
                      
                    
                    }
				else
				{
					path=paths.ToString();
						Debug.Log( "Picked file: " + paths );
				}
			}, new string [] {"image/*"} );


var client = new RestClient("http://mymall-kw.com/api/V1/upload-image");
client.Timeout = -1;
var request = new RestRequest(Method.POST);
request.AddHeader("password-api", "mall_2021_m3m");
request.AddHeader("lang-api", "en");
request.AddHeader("auth-token", AuthToken());
request.AddFile("image", path);
IRestResponse response = client.Execute(request);

UploadImageResponse UploadImageResponse=JsonConvert.DeserializeObject<UploadImageResponse>(response.Content);

    if(UploadImageResponse.statsu==1){

   if(!UPDownMenu.Login)
        {
           ApiClasses.Register.data.user.image=UploadImageResponse.data.image;
        }
        else
        {
          ApiClasses.Login.data.original.user.image=UploadImageResponse.data.image;

        }
 StartCoroutine( GetText(  ProfilePic));

    }else{
        return;
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
    private void Awake()
    {
        Gender();




    }
    // Update is called once per frame
    void Update()
    {
    }
}
 public class UploadImageResponse
    {
        public int statsu { get; set; }
        public string message { get; set; }
        public UploadImageResponsedata data { get; set; }
    }
      public class UploadImageResponsedata
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
