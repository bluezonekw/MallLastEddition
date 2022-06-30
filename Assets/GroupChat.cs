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
public class GroupChat : MonoBehaviour
{
    public ChatTabForChat mainchat;
public string FriendNameInserver;
      [Header("PrivateChat")]

    
    public Transform MessageListParent;
   
  
 public TMP_InputField WriteMessageprivate;
public GameObject privateChatSend,PrivateChatReciev;
public TextMeshProUGUI privateSend,PrivateRecieve;
public Scrollbar privateScroll;
public float privatesizescroll;

    




   

    public void OnGetPublicMessages(string[] senders, object[] messages)
    { 
       Debug.Log(senders[0]+"      "+ messages[0].ToString()+"       00000000");
       for(int i=0 ;i<senders.Length ;i++){
           if(senders[i]!=ID().ToString()){
 PrivateRecieve.text=messages[i].ToString()+"   : "+senders[i];
           var createdtext = GameObject.Instantiate(PrivateChatReciev);
            createdtext.transform.parent = MessageListParent;
               createdtext.transform.localScale = new Vector3(1f, 1f, 1f);
          createdtext.SetActive(true);
       }
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

   
    // Start is called before the first frame update
    void Start()
    {
          privatesizescroll= privateScroll.size;
    }

    // Update is called once per frame
    void Update()
    {
        if (privateScroll.size != privatesizescroll)
        {

            privateScroll.value = 0;

            privatesizescroll = privateScroll.size;


        }
    }


      public void SendPrivateMessage()
    {
        
        try{
            
            
                    if (!String.IsNullOrWhiteSpace(WriteMessageprivate.text))
        {
           mainchat.SendGroupMessage( WriteMessageprivate.text);
            privateSend.text=WriteMessageprivate.text+"   : "+ID().ToString();
           var createdtext = GameObject.Instantiate(privateChatSend);
            createdtext.transform.parent = MessageListParent;
             createdtext.transform.localScale = new Vector3(1f, 1f, 1f);
          createdtext.SetActive(true);
          WriteMessageprivate.text="";
        }
    }
    catch{

    }
    }
}
