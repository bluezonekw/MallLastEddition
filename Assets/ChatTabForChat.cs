using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using Photon.Chat;
using ExitGames.Client.Photon;
using System;

using TMPro;
using RTLTMPro;
using UnityEngine.EventSystems;

public class ChatTabForChat : MonoBehaviourPun, IChatClientListener
{
    public GroupChat Gchat;
 public  ChatClient chatClient;
 
    

    public int ID()
    {
       if(!UPDownMenu.Login)
        {
            return ApiClasses.Register.data.user.id;
        }
        else
        {
            return ApiClasses.Login.data.original.user.id;

        }
    }
 /// <summary>
 /// Awake is called when the script instance is being loaded.
 /// </summary>
 void Awake()
 {
       chatClient = new ChatClient(this);
        // Set your favourite region. "EU", "US", and "ASIA" are currently supported.
        chatClient.ChatRegion = "EU";
        //chatClient.Connect(chatAppId, chatAppVersion, new AuthenticationValues(userID));



        chatClient.Connect("335fb047-4f98-42ee-9811-c4fad884de29", "V2", new Photon.Chat.AuthenticationValues(ID().ToString()));


 }
    public void SendGroupMessage(string message){


         chatClient.PublishMessage("channelA", message);
    }
public  void SendPrivateMessageslocal(string Message,string FriendName)
    {
        try{
                    if (!String.IsNullOrWhiteSpace(Message))
        {
       
           chatClient.SendPrivateMessage(FriendName,Message);
           print("Message Sent");
        }
    }
    catch{

    }
    }











    
    public GameObject privateChatPArent;

    bool privatechatcreated;
     [Header("---------Header------")]
     public GameObject HeaderAllChats;
     public GameObject HeaderPrivateChat;
     public GameObject HeaderGroupChat;
     public GameObject HeaderNewGroup;
     public GameObject HeaderGroupMember;
     public GameObject HeaderAddMembers;
     [Header("---------Body------")]


     public GameObject BodyAllChats;
     public GameObject BodyPrivateChat;
     public GameObject BodyGroupChat;
     public GameObject BodyNewGroup;
     public GameObject BodyGroupMember;
     public GameObject BodyAddMembers;


     [Header("---------Footer------")]
public GameObject FooterMain;
public GameObject FooterPrivateChat;
public GameObject FooterGroupChat;



public static string privateplayername;


public void openPrivateChat(){
privateplayername= EventSystem.current.currentSelectedGameObject.name;

HeaderAllChats.SetActive(false);
HeaderPrivateChat.SetActive(true);
HeaderGroupChat.SetActive(false);
HeaderNewGroup.SetActive(false);
HeaderGroupMember.SetActive(false);
HeaderAddMembers.SetActive(false);


BodyAllChats.SetActive(false);

//BodyPrivateChat.SetActive(true);

privatechatcreated=false;
GameObject g=new GameObject();
foreach(Transform child in privateChatPArent.transform){

if(child.gameObject.name==privateplayername)
{
privatechatcreated=true;
g=child.gameObject;
}

}
if(privatechatcreated){

g.SetActive(true);

}else
{

    GameObject sad=GameObject.Instantiate(BodyPrivateChat,privateChatPArent.transform);
    sad.SetActive(true);
    sad.name=privateplayername;
}



BodyGroupChat.SetActive(false);
BodyNewGroup.SetActive(false);
BodyGroupMember.SetActive(false);
BodyAddMembers.SetActive(false);



FooterMain.SetActive(false);
FooterPrivateChat.SetActive(true);
FooterGroupChat.SetActive(false);

}
public void OpenAllChat(){

HeaderAllChats.SetActive(true);
HeaderPrivateChat.SetActive(false);
HeaderGroupChat.SetActive(false);
HeaderNewGroup.SetActive(false);
HeaderGroupMember.SetActive(false);
HeaderAddMembers.SetActive(false);


BodyAllChats.SetActive(true);



//BodyPrivateChat.SetActive(false);


try{
foreach(Transform child in privateChatPArent.transform){

if(child.gameObject.name==privateplayername)
{
child.gameObject.SetActive(false);
}




}
}
catch{
    
}



BodyGroupChat.SetActive(false);
BodyNewGroup.SetActive(false);
BodyGroupMember.SetActive(false);
BodyAddMembers.SetActive(false);



FooterMain.SetActive(true);
FooterPrivateChat.SetActive(false);
FooterGroupChat.SetActive(false);

}






public void OpenGroupChat(){

HeaderAllChats.SetActive(false);
HeaderPrivateChat.SetActive(false);
HeaderGroupChat.SetActive(true);
HeaderNewGroup.SetActive(false);
HeaderGroupMember.SetActive(false);
HeaderAddMembers.SetActive(false);


BodyAllChats.SetActive(false);
BodyGroupChat.SetActive(true);
BodyNewGroup.SetActive(false);
BodyGroupMember.SetActive(false);
BodyAddMembers.SetActive(false);



FooterMain.SetActive(false);
FooterPrivateChat.SetActive(false);
FooterGroupChat.SetActive(true);

}








    public void DebugReturn(DebugLevel level, string message)
    {
        
    }

    public void OnChatStateChange(ChatState state)
    {
       
    }

    public void OnConnected()
    {
      
    }

    public void OnDisconnected()
    {
       
    }

    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
          print(senders[0]+"      "+ messages[0].ToString()+"      11111111");
      Gchat.OnGetPublicMessages(senders,messages);
    }

    public void OnPrivateMessage(string sender, object message, string channelName)
    {
       
        try{

        
GameObject.Find(sender).GetComponent<privateChat>().iGetPrivateMessagelocal(message.ToString());
 print(sender+"   sssss   "+ message.ToString());
     }
    catch{




    }
    }

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
       
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
        
    }

    public void OnUnsubscribed(string[] channels)
    {
     
    }

    public void OnUserSubscribed(string channel, string user)
    {
        
    }

    public void OnUserUnsubscribed(string channel, string user)
    {
       
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         chatClient.Service();
    }
}
