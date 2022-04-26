using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class bl_AutoJoin : MonoBehaviourPunCallbacks
{

    public string PlayerName = "Player";
    public byte Version = 1;
    public Text PlayerNameText;
    [Space(5)]
    public GameObject PlayerNameInput;

    public void Start()
    {
        PhotonNetwork.JoinLobby();    // we join randomly. always. no need to join a lobby to get the list of rooms.
    }

    // to react to events "connected" and (expected) error "failed to join random room", we implement some methods. PhotonNetworkingMessage lists all available methods!
    public override void OnConnectedToMaster()
    {
/*
 if (PhotonNetwork.networkingPeer.AvailableRegions != null)
  Debug.LogWarning("List of available regions counts " + PhotonNetwork.networkingPeer.AvailableRegions.Count + ". First: " + PhotonNetwork.networkingPeer.AvailableRegions[0] + " \t Current Region: " + PhotonNetwork.networkingPeer.CloudRegion);
       
        Debug.Log("OnConnectedToMaster() was called by PUN. Now this client is connected and could join a room. Calling: PhotonNetwork.JoinRandomRoom();");
  */
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
         Debug.Log("OnPhotonRandomJoinFailed() was called by PUN. No random room available, so we create one. Calling: PhotonNetwork.CreateRoom(null, new RoomOptions() {maxPlayers = 4}, null);");
        PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = 4 }, null);
    }

   

    public void SendPlayerName(InputField field)
    {
        string t = field.text;
        if (string.IsNullOrEmpty(t))
            return;

        PhotonNetwork.NickName = t;
        PhotonNetwork.ConnectUsingSettings();

        PlayerNameInput.SetActive(false);
    }
    // the following methods are implemented to give you some context. re-implement them as needed.
    public override void OnCustomAuthenticationFailed(string debugMessage)
    {
      Debug.LogError("Cause: " + debugMessage);
    }
   

    
}