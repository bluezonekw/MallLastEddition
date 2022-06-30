using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using Photon.Chat;
using Photon.Realtime;
using AuthenticationValues = Photon.Chat.AuthenticationValues;
using ExitGames.Client.Photon;
#if PHOTON_UNITY_NETWORKING
using Photon.Pun;
#endif
namespace StarterAssets
{
public class chatManagerForMall : MonoBehaviour , IChatClientListener
{

   [SerializeField] private string nickName;

   
  #region IChatClientListener implementation

    public void DebugReturn (ExitGames.Client.Photon.DebugLevel level, string message)
    {
       
       Debug.Log(message);
    }

    public void OnDisconnected ()
    {
      Console.WriteLine("connected    no");
    }

    public void OnConnected ()
    {
         Console.WriteLine("connected    yes");
    }

    public void OnChatStateChange (ChatState state)
    {
       Console.WriteLine(state.ToString());
    }

    public void OnGetMessages (string channelName, string[] senders, object[] messages)
    {
        string msgs = "";
       for ( int i = 0; i < senders.Length; i++ )
       {
           msgs = string.Format("{0}{1}={2}, ", msgs, senders[i], messages[i]);
       }
       Console.WriteLine( "OnGetMessages: {0} ({1}) > {2}", channelName, senders.Length, msgs );
       // All public messages are automatically cached in `Dictionary<string, ChatChannel> PublicChannels`.
       // So you don't have to keep track of them.
       // The channel name is the key for `PublicChannels`.
       // In very long or active conversations, you might want to trim each channels history.
    }

    public void OnPrivateMessage (string sender, object message, string channelName)
    {
          Console.WriteLine( "OnPrivateMessage: {0} ({1}) > {2}", channelName, sender, message );
    }

    public void OnSubscribed (string[] channels, bool[] results)
    {
   string msgs = "Subscribed ";
       for ( int i = 0; i < channels.Length; i++ )
       {
           msgs = string.Format("{0}{1}={2}, ", msgs, channels[i], results[i]);
       }
       Console.WriteLine( "OnGetMessages: {0} ({1}) > {2}", channels, results.Length, msgs );
    }

    public void OnUnsubscribed (string[] channels)
    {
        throw new System.NotImplementedException ();
    }

    public void OnStatusUpdate (string user, int status, bool gotMessage, object message)
    {
         Console.WriteLine( "Status change for: {0} to: {1}", user, status );
    }
void Photon.Chat.IChatClientListener.OnUserSubscribed	(	string 	channel,string 	user)
{


}
void Photon.Chat.IChatClientListener.OnUserUnsubscribed	(	string 	channel,string 	user)	
{




}


    #endregion

        private ChatClient chatClient;
public string chatAppId,chatAppVersion;
        public static Action<string, string> OnRoomInvite = delegate { };
        public static Action<ChatClient> OnChatConnected = delegate { };
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
public async void Awake() {
    
// In the C# SDKs, the callbacks are defined in the `IChatClientListener` interface.
// In the demos, we instantiate and use the ChatClient class to implement the IChatClientListener interface.
chatClient = new ChatClient( this );
// Set your favourite region. "EU", "US", and "ASIA" are currently supported.
chatClient.ChatRegion = "EU";
//chatClient.Connect(chatAppId, chatAppVersion, new AuthenticationValues(userID));



chatClient.Connect(chatAppId, chatAppVersion, new AuthenticationValues(UserName()));

chatClient.SetOnlineStatus( ChatUserStatus.Online, "Mostly Harmless" );

List<string> friends = new List<string>() { "sasa", "3nab", "Mostafa a", "api test 2" };


		


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
}