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



public class PUN2_Chat : MonoBehaviourPun, IChatClientListener
{
 

    [Header("PrivateChat")]

    public RTLTextMeshPro FrineName;
    public GameObject FrinedExample;
    public Transform FriendListParent;
    public Image friendicon;
    public bool PrivateChatisOpen;
    public GameObject privateChatG;
public RTLTextMeshPro TitlePrivateChat;
 public TMP_InputField WriteMessageprivate;
public GameObject privateChatSend,PrivateChatReciev;
public TextMeshProUGUI privateSend,PrivateRecieve;
public Scrollbar privateScroll;

    [Header("PublicChat")]

    public Scrollbar Rectscroll;
    public InputField inpui;






    public Text MessageText;
    public bool isopen;
    public Text Title;
    public GameObject publicChat;
    public GameObject examplemessagesend, examplemessageRecieve;
    public TextMeshProUGUI sender, reciever;
    public Transform messageparent;
    bool isChatting = false;
    string chatInput = "";

    bool EnterChat = false;
    [System.Serializable]
    public class ChatMessage
    {
        public string sender = "";
        public string message = "";
        public float timer = 0;
    }

    List<ChatMessage> chatMessages = new List<ChatMessage>();
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

    // Start is called before the first frame update
    void Start()
    {
        sizescroll = Rectscroll.size;
   privatesizescroll= privateScroll.size;
        // In the C# SDKs, the callbacks are defined in the `IChatClientListener` interface.
        // In the demos, we instantiate and use the ChatClient class to implement the IChatClientListener interface.
        chatClient = new ChatClient(this);
        // Set your favourite region. "EU", "US", and "ASIA" are currently supported.
        chatClient.ChatRegion = "EU";
        //chatClient.Connect(chatAppId, chatAppVersion, new AuthenticationValues(userID));



        chatClient.Connect("335fb047-4f98-42ee-9811-c4fad884de29", "V2", new Photon.Chat.AuthenticationValues(ID().ToString()));

        //Initialize Photon View
        if (gameObject.GetComponent<PhotonView>() == null)
        {
            PhotonView photonView = gameObject.AddComponent<PhotonView>();
            photonView.ViewID = 1;
        }
        else
        {
            photonView.ViewID = 1;
        }

    }
    public float sizescroll,privatesizescroll;
    // Update is called once per frame
    void Update()
    {


        if (Rectscroll.size != sizescroll)
        {

            Rectscroll.value = 0;

            sizescroll = Rectscroll.size;


        }



if (privateScroll.size != privatesizescroll)
        {

            privateScroll.value = 0;

            privatesizescroll = privateScroll.size;


        }


        try
        {
            chatClient.Service();
        }
        catch
        {


        }
        if (//Input.GetKeyUp(KeyCode.T)
        EnterChat && !isChatting)
        {
            isChatting = true;
            EnterChat = false;
            chatInput = "";
        }
        if (isChatting)
        {
            isChatting = false;
            if (chatInput.Replace(" ", "") != "")
            {
                //Send message
                // photonView.RPC("SendChat", RpcTarget.All, PhotonNetwork.LocalPlayer, chatInput);

                chatInput = "";


            }
            if (chatMessages.Count != 0)
            {
                if (chatMessages[0].sender == ID().ToString())
                {

                    if (UPDownMenu.LanguageValue == 1)
                    {
                        sender.text = chatMessages[0].sender + ": " + chatMessages[0].message;

                    }
                    else
                    {

                        sender.text = chatMessages[0].message + ": " + chatMessages[0].sender;

                    }
                    var createdtext = GameObject.Instantiate(examplemessagesend);
                    createdtext.transform.parent = messageparent;
                    createdtext.transform.localScale = new Vector3(0.2540775f, 0.2540775f, 0.2540775f);
                    createdtext.SetActive(true);

                    Rectscroll.value = 0;
                }
                else
                {



                    if (UPDownMenu.LanguageValue == 1)
                    {
                        reciever.text = chatMessages[0].sender + ": " + chatMessages[0].message;

                    }
                    else
                    {

                        reciever.text = chatMessages[0].message + ": " + chatMessages[0].sender;

                    }
                    var createdtext = GameObject.Instantiate(examplemessageRecieve);

                    createdtext.transform.parent = messageparent;
                    createdtext.transform.localScale = new Vector3(0.2540775f, 0.2540775f, 0.2540775f);
                    createdtext.SetActive(true);

                    Rectscroll.value = 0;
                }
                Rectscroll.SetValueWithoutNotify(0);

            }



        }
        //Hide messages after timer is expired
        /*    for (int i = 0; i < chatMessages.Count; i++)
            {
                if (chatMessages[i].timer > 0)
                {
                    chatMessages[i].timer -= Time.deltaTime;
                }
            }*/
    }
    /*
        void OnGUI()
        {
            if (!isChatting)
            {
           //     GUI.Label(new Rect(255, Screen.height - 25, 200, 25), "Press 'T' to chat");
            }
            else
            {
               // if (  Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.Return)            

               {
                    //isChatting = false;

                    if(chatInput.Replace(" ", "") != "")
                    {
                        //Send message
                        photonView.RPC("SendChat", RpcTarget.All, PhotonNetwork.LocalPlayer, chatInput);
                    }
                    chatInput = "";
                }

               // GUI.SetNextControlName("ChatField");
                //GUI.Label(new Rect(5, Screen.height - 25, 200, 25), "Say:");
                //GUIStyle inputStyle = GUI.skin.GetStyle("box");
                //inputStyle.alignment = TextAnchor.MiddleLeft;
                //chatInput = GUI.TextField(new Rect(10 + 25, Screen.height - 27, 400, 22), chatInput, 60, inputStyle);

                //GUI.FocusControl("ChatField");
            }


        //GUI.contentColor = Color.black;
            //Show messages
            for(int i = 0; i < chatMessages.Count; i++)
            {
               if(chatMessages[i].timer > 0 || isChatting)
                {
          //          GUI.Label(new Rect(5, Screen.height - 50 - 25 * i, 500, 25), chatMessages[i].sender + ": " + chatMessages[i].message);
    var createdtext=Instantiate(examplemessage)as Text;
    createdtext.text= chatMessages[i].sender + ": " + chatMessages[i].message;

    createdtext.gameObject.SetActive(true);

              //  }
            } 
        }
       */
    public void OpenPublicChat()
    {
        isopen = !isopen;
        publicChat.SetActive(isopen);
        if (UPDownMenu.LanguageValue == 1)
        {

            Title.text = "Public chat";
            sender.alignment = TextAlignmentOptions.MidlineLeft;
            reciever.alignment = TextAlignmentOptions.MidlineLeft;

        }
        else
        {

            Title.text = "ﯽﻋﺎﻤﺠﻟا تﺎﺸﻟا";
            sender.alignment = TextAlignmentOptions.MidlineRight;
            reciever.alignment = TextAlignmentOptions.MidlineRight;

        }
    }





 public void OpenPrivateChat()
    {
        PrivateChatisOpen = !PrivateChatisOpen;
        publicChat.SetActive(PrivateChatisOpen);
        if (UPDownMenu.LanguageValue == 1)
        {

            TitlePrivateChat.text = " chat";
            privateSend.alignment = TextAlignmentOptions.MidlineLeft;
            PrivateRecieve.alignment = TextAlignmentOptions.MidlineLeft;

        }
        else
        {

            TitlePrivateChat.text = " تﺎﺸﻟا";
            privateSend.alignment = TextAlignmentOptions.MidlineRight;
            PrivateRecieve.alignment = TextAlignmentOptions.MidlineRight;

        }
    }
 public void SendPrivateMessage(string playername)
    {
        if (!String.IsNullOrWhiteSpace(MessageText.text))
        {
            EnterChat = true;

            SendChat(PhotonNetwork.LocalPlayer, MessageText.text);
            MessageText.text = "";
            Rectscroll.value = 0;
        }
    }







    public void SendMessageMall()
    {
        if (!String.IsNullOrWhiteSpace(MessageText.text))
        {
            EnterChat = true;

            SendChat(PhotonNetwork.LocalPlayer, MessageText.text);
            MessageText.text = "";
            Rectscroll.value = 0;
        }
    }

    [PunRPC]
    void SendChat(Photon.Realtime.Player sender, string message)
    {
        ChatMessage m = new ChatMessage();
        m.sender = sender.NickName;
        m.message = message;
        m.timer = 15.0f;
        //   chatClient.Subscribe("channelA");
        if (!String.IsNullOrEmpty(message))
        {
            chatClient.PublishMessage("channelA", message);
            Rectscroll.value = 0;
            inpui.text = "";
            chatMessages.Insert(0, m);
            if (chatMessages.Count > 8)
            {
                chatMessages.RemoveAt(chatMessages.Count - 1);
            }
        }
        else
        {
            print("message is spare");
        }

    }




    public void sendPrivateChat(string playername, string messagesent)
    {



    }




    public void DebugReturn(DebugLevel level, string message)
    {
        Debug.Log(message);
    }

    public void OnDisconnected()
    {
        //   throw new System.NotImplementedException();
    }

    public void OnConnected()
    {
        Debug.Log("Connect chat");
        chatClient.Subscribe(new string[] { "channelA", "channelB" });
        chatClient.SetOnlineStatus(ChatUserStatus.Online, "Mostly Harmless");
        List<string> friends = new List<string>() { "api test 2", "Ahmed", "Bluezonekw", "45611202", "Bazar", "Ahmmed", "7mooodii03", "haidar", "Ahmed", "Openshop", "abeer", "d96", "ahmed", "sasa", "Ahmad", "Mostafa Mahmoud", "MostafaB", "Mostafa a", "3nab", "sasa" };
        chatClient.AddFriends(friends.ToArray());
        /*List<string> friendsStatus=new List<string>();
        PhotonNetwork.FindFriends(friendsStatus.ToArray());
        print(friendsStatus.Count);
         foreach(var p in  PhotonNetwork.PlayerList )
         {
        print(p.ToStringFull());


         }*/
    }

    public void OnChatStateChange(ChatState state)
    {
        Debug.Log(state.ToString());
        //        throw new System.NotImplementedException();
    }

    public async void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        for (int i = 0; i < messages.Length; i++)
        {
            if (senders[i] != ID().ToString())
            {
                ChatMessage m = new ChatMessage();
                m.sender = senders[i];
                m.message = messages[i].ToString();
                chatMessages.Insert(0, m);
                print(messages[i] + "/" + senders[i]);
                EnterChat = true;
            }
        }
    }

    public void OnPrivateMessage(string sender, object message, string channelName)
    {
        //   throw new System.NotImplementedException();
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
        Debug.Log(channels[0] + "/" + results[0]);
        //  throw new System.NotImplementedException();
    }

    public void OnUnsubscribed(string[] channels)
    {
        Debug.Log(channels[0]);
        // throw new System.NotImplementedException();
    }

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
        Debug.Log(user + "    " + status.ToString() + "         " + gotMessage.ToString() + "        " + message.ToString());
        //  throw new System.NotImplementedException();
    }

    public void OnUserSubscribed(string channel, string user)
    {
        Debug.Log(channel);
        //    throw new System.NotImplementedException();
    }

    public void OnUserUnsubscribed(string channel, string user)
    {
        Debug.Log(channel);
        // throw new System.NotImplementedException();
    }
}