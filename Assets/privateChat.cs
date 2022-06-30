using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using Photon.Chat;
using ExitGames.Client.Photon;
using System;
using Photon.Voice.Unity;
using TMPro;
using RTLTMPro;
using UnityEngine.EventSystems;
using Photon.Voice.PUN;
using UnityEngine.UI;
using RestSharp;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using System.IO;
using NativeFilePickerNamespace;
public enum TypeOFMessage{
Image,Text


}
public class MessageChat{
public  TypeOFMessage Type {get;set;}
public Texture Image {get;set;}
public string Text {get;set;} 





}

public class privateChat : MonoBehaviour
{
public AudioClip StartRecords,EndRecords,sendmessage,erorrmessage;
public string ArrayOfFloatToString(float [] data){

string aa = string.Join("$", data);
return aa;

}
    public float[] stringtoarrayoffloat(string Audiostring){
 string[] s=Audiostring.Split('$');
         List<float> test=new List<float>();
     foreach(var number in s){
test.Add(float.Parse( number));
          

     }
        clipLength = test.Count;
     return test.ToArray();
    }

    public int clipLength;

 [Header("VoiceChat")]
 public AudioClip recordingNew;
public GameObject sendVoiceNote;
public GameObject RecieveVoiceNote;
public NewButton VoiceButton;
 string devicename;
 AudioClip recording;
 bool isplay;
bool isdown;
private float startRecordingTime=0;
    public Button SendPhoto;
    public ChatTabForChat MainChat;
    public TMP_InputField InputMessage;
public string FriendNameInserver;
      [Header("PrivateChat")]

    public RTLTextMeshPro FrinedName;
    public Transform MessageListParent;
    public RawImage friendicon;
    public static bool PrivateChatisOpen;
 public TMP_InputField WriteMessageprivate;
public GameObject privateChatSend,PrivateChatReciev;
public TextMeshProUGUI privateSend,PrivateRecieve;
public Scrollbar privateScroll;
public float privatesizescroll;

   public GameObject SendImageGameobj,RecievImageGameobj;
 public RawImage SendImage,RecievImage;


public void Create_Recieve_Voice(string MessageVoice,string id){
        float[] data = stringtoarrayoffloat(MessageVoice);
      
            //  recordingNew = AudioClip.Create(recording.name, (int)((Time.time - startRecordingTime) * recording.frequency), recording.channels, recording.frequency, false);
            recordingNew = AudioClip.Create(id, clipLength, 1, 8000, false);
            recordingNew.SetData(data, 0);

            var createdtext = GameObject.Instantiate(RecieveVoiceNote);
            createdtext.GetComponent<VoiceNote>().clip = recordingNew;
            createdtext.transform.parent = MessageListParent;
            createdtext.transform.localScale = new Vector3(1f, 1f, 1f);
            createdtext.SetActive(true);
      
}


public void Create_Recieve_Image(Texture message){
 RecievImage.texture=message;
           var createdtext = GameObject.Instantiate(RecievImageGameobj);
            createdtext.transform.parent = MessageListParent;
             createdtext.transform.localScale = new Vector3(1f, 1f, 1f);
          createdtext.SetActive(true);
}

public void Create_Recieve_Text(string message){


 PrivateRecieve.text=message;
           var createdtext = GameObject.Instantiate(PrivateChatReciev);
            createdtext.transform.parent = MessageListParent;
             createdtext.transform.localScale = new Vector3(1f, 1f, 1f);
          createdtext.SetActive(true);




}






public void iGetPrivateMessagelocal(string Message,string id){
 if(Message.Split(new string[] { "$$$" }, StringSplitOptions.None)[0]=="Image")
 {
byte[] bytes;
Texture2D t=new Texture2D(1,1) ;
bytes=Convert.FromBase64String(Message.Split(new string[] { "$$$" }, StringSplitOptions.None)[1]);
t.LoadImage(bytes);
Create_Recieve_Image(t);

 }
 else  if(Message.Split(new string[] { "$$$" }, StringSplitOptions.None)[0]=="Text")
 {
Create_Recieve_Text(Message.Split(new string[] { "$$$" }, StringSplitOptions.None)[1]);
     
 }
 else  if(Message.Split(new string[] { "$$$" }, StringSplitOptions.None)[0]=="Voice")
 {

         
          
Create_Recieve_Voice(Message.Split(new string[] { "$$$" }, StringSplitOptions.None)[1],id);
         
          


         

        }
     


 
             
         



         



}


    void OnEnable() {
        try{
        InputMessage.onEndEdit.RemoveAllListeners();
        InputMessage.onEndEdit.AddListener(this.SendPrivateMessage);
SendPhoto.onClick.RemoveAllListeners();
SendPhoto.onClick.AddListener(this.SendPrivateImage);


        }
        catch{
SendPhoto.onClick.AddListener(this.SendPrivateImage);
 InputMessage.onEndEdit.AddListener(this.SendPrivateMessage);
        }
if(EventSystem.current.currentSelectedGameObject.name.Contains("$"))
{
      FriendNameInserver=EventSystem.current.currentSelectedGameObject.name;
       friendicon.texture=EventSystem.current.currentSelectedGameObject.GetComponent<MyFriendData>().Icon.texture;
}else{
   FriendNameInserver=EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.name;
    friendicon.texture=EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.GetComponent<MyFriendData>().Icon.texture;
}
     
     Debug.Log( FriendNameInserver+"              00       "+gameObject.name);
     



      FrinedName.text=FriendNameInserver.Split('$')[1];
   FriendNameInserver= FriendNameInserver.Split('$')[0];
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


    
    public int position = 0;
    public int samplerate = 8000;
    public float frequency = 440;

     
    // Start is called before the first frame update
    void Start()
    {
          



var client = new RestClient("http://mymall-kw.com/api/V1/friends/chat");
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
request.AddParameter("paginat", "100");
request.AddParameter("friend_id",gameObject.name);
IRestResponse response = client.Execute(request);
       Debug.Log(response.Content);
        ChatHistory chatHistory=JsonConvert.DeserializeObject<ChatHistory>(response.Content);
           
if(chatHistory.statsu==1){
foreach(var message in chatHistory.data){

if(message.type_user=="sender"){

 if(message.text.Split(new string[] { "$$$" }, StringSplitOptions.None)[0]=="Image")
 {
byte[] bytes;
Texture2D t=new Texture2D(1,1) ;
bytes=Convert.FromBase64String(message.text.Split(new string[] { "$$$" }, StringSplitOptions.None)[1]);
t.LoadImage(bytes);
Create_Send_Image(t);

 }
 else  if(message.text.Split(new string[] { "$$$" }, StringSplitOptions.None)[0]=="Text")
 {
Create_Send_Text(message.text.Split(new string[] { "$$$" }, StringSplitOptions.None)[1]);
     
 }
 else  if(message.text.Split(new string[] { "$$$" }, StringSplitOptions.None)[0]=="Voice")
 {
     
      float[] data =  stringtoarrayoffloat(message.text.Split(new string[] { "$$$" }, StringSplitOptions.None)[1]);
                        recordingNew = AudioClip.Create(message.id.ToString(), clipLength, 1, 8000, false);

                        recordingNew.SetData(data,0);
Create_Send_Voice(recordingNew, message.id.ToString());

   
 }else{

    Debug.Log(message.text);
 }



}else{
iGetPrivateMessagelocal(message.text,message.id.ToString());




}





}






}





     






    }

    // Update is called once per frame
    void Update()
    {
       
       if(VoiceButton.IsDownclick&&!isdown){
isdown=true;
isplay=true;
StartRecord();
      }

      if(!VoiceButton.IsDownclick&&isplay){

isplay=false;
isdown=false;
SendPrivateVoice();
      }
       




    }

public void SendPrivateImage(){
 Texture2D tex = new Texture2D(2, 2);
 
 if( NativeFilePicker.IsFilePickerBusy() )
			return;
      byte [] bytes;
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

			Debug.Log( "Permission result: " + permission );



////////////////////

       

  try{ 
            

              bytes = File.ReadAllBytes(path);
             Debug.Log(bytes.Length);
              
            tex.LoadImage(bytes);
            tex.Apply();
            string enc = Convert.ToBase64String(bytes);
         
       MainChat.SendPrivateMessageslocal("Image$$$"+enc,FriendNameInserver);
       if(!SendMessageInMallServer("Image$$$"+enc,FriendNameInserver,"Image")){

         return;
       }
        Create_Send_Image(tex);
         
          
       
    }
    catch{

    }



}



public void StartRecord(){

 foreach (var device in Microphone.devices)
        {
       devicename= device;
        }
if(string.IsNullOrEmpty( devicename)){
GetComponent<AudioSource>().clip=erorrmessage;
GetComponent<AudioSource>().Play();
return;

}
        int minFreq;
        int maxFreq;
        int freq = 8000;
        Microphone.GetDeviceCaps(devicename, out minFreq, out maxFreq);
        if (maxFreq < 8000)
            freq = maxFreq;

        //Start the recording, the length of 300 gives it a cap of 5 minutes
        recording = Microphone.Start(devicename, false, 300, 8000);
        startRecordingTime = Time.time;

GetComponent<AudioSource>().clip=StartRecords;
GetComponent<AudioSource>().Play();



}

public void SendPrivateVoice(){
   Microphone.End(devicename);

       

        //Trim the audioclip by the length of the recording
         recordingNew = AudioClip.Create(recording.name, (int)((Time.time - startRecordingTime) * recording.frequency), recording.channels, recording.frequency, false);
        float[] data = new float[(int)((Time.time - startRecordingTime) * recording.frequency)];
        recording.GetData(data, 0);
       recordingNew.SetData(data, 0);

           Debug.Log("Length   "+((int)((Time.time - startRecordingTime) * recording.frequency)).ToString()+  "   channels  "+recording.channels.ToString()+   "  frequency  "+recording.frequency.ToString());
print(data.Length.ToString());
             
            string enc = ArrayOfFloatToString(data);
         
       MainChat.SendPrivateMessageslocal("Voice$$$"+enc,FriendNameInserver);
       if(!SendMessageInMallServer("Voice$$$"+enc,FriendNameInserver,"Voice")){

         return;
       }
      Create_Send_Voice(recordingNew,"Send");
         GetComponent<AudioSource>().clip=EndRecords;
GetComponent<AudioSource>().Play();



}















public void Create_Send_Voice(AudioClip message,string id){
 
           var createdtext = GameObject.Instantiate(sendVoiceNote);
           createdtext.GetComponent<VoiceNote>().clip=message;
        createdtext.GetComponent<VoiceNote>().clip.name = id;
       Debug.Log(id);
            createdtext.transform.parent = MessageListParent;
             createdtext.transform.localScale = new Vector3(1f, 1f, 1f);
          createdtext.SetActive(true);
}


public void Create_Send_Image(Texture message){
 SendImage.texture=message;
           var createdtext = GameObject.Instantiate(SendImageGameobj);
            createdtext.transform.parent = MessageListParent;
             createdtext.transform.localScale = new Vector3(1f, 1f, 1f);
          createdtext.SetActive(true);
}

public void Create_Send_Text(string message){


 privateSend.text=message;
           var createdtext = GameObject.Instantiate(privateChatSend);
            createdtext.transform.parent = MessageListParent;
             createdtext.transform.localScale = new Vector3(1f, 1f, 1f);
          createdtext.SetActive(true);




}
public bool SendMessageInMallServer(string message,string id,string type){

var client = new RestClient("http://mymall-kw.com/api/V1/friends/chat/send");
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
request.AddParameter("text", message);
request.AddParameter("friend_id", id);
request.AddParameter("type", type);
IRestResponse response = client.Execute(request);
       Debug.Log(response.Content);

        AcceptRequest a=JsonConvert.DeserializeObject<AcceptRequest>(response.Content);
       Debug.Log(response.Content);
if(a.statsu==0){
  return false;
}
else{
GetComponent<AudioSource>().clip=sendmessage;
GetComponent<AudioSource>().Play();
return true;

}



}
     public void SendPrivateMessage(string k)
    {
      
       
        try{ 
            
                   if (!String.IsNullOrWhiteSpace(WriteMessageprivate.text))
        {
       MainChat.SendPrivateMessageslocal("Text$$$"+WriteMessageprivate.text,FriendNameInserver);
          if(!SendMessageInMallServer("Text$$$"+WriteMessageprivate.text,FriendNameInserver,"Text")){
                   Debug.Log("failed  " + "Text$$$" + WriteMessageprivate.text+"  "+ FriendNameInserver);
         return;
       }

       Create_Send_Text(WriteMessageprivate.text);
               Debug.Log("success  " + "Text$$$" + WriteMessageprivate.text + "  " + FriendNameInserver);
                WriteMessageprivate.text="";
        }
    }
    catch{
           Debug.Log("catch  " + "Text$$$" + WriteMessageprivate.text + "  " + FriendNameInserver);
        }
    }
}










  public class DataFriendNameById
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public int gander { get; set; }
        public int coins { get; set; }
        public int total_orders_cost { get; set; }
        public int total_coins_spend { get; set; }
    }

    public class FriendNameById
    {
        public int statsu { get; set; }
        public string message { get; set; }
        public List<DataFriendNameById> data { get; set; }
    }


public class SenderHistory
{
    public int id { get; set; }
    public string name { get; set; }
    public string image { get; set; }
}




public class DataChatHistory
    {
        public int id { get; set; }
        public string text { get; set; }
        public string type { get; set; }
        public string type_user { get; set; }
    public int is_new { get; set; }
    public string created_at { get; set; }
    public SenderHistory sender { get; set; }
}

    public class ChatHistory
    {
        public int statsu { get; set; }
        public string message { get; set; }
        public List<DataChatHistory> data { get; set; }
    }