using UnityEngine;
using System;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
public class PhotonConnection : MonoBehaviourPunCallbacks 
{
   #region Unity Method
private void Start() {
    
    string randomname=$"Tester{Guid.NewGuid().ToString()}";
    ConnectToPhoton(randomname);
}

   #endregion



   #region Private Methods

private void ConnectToPhoton(string nickname){


Debug.Log($"connect to photon as {nickname}");
PhotonNetwork.AuthValues=new AuthenticationValues(nickname);
PhotonNetwork.AutomaticallySyncScene=true;
PhotonNetwork.NickName=nickname;
PhotonNetwork.ConnectUsingSettings();
}
private void CreatePhotonRoom(string RoomName){
RoomOptions  ro=new RoomOptions();
ro.IsOpen=true;
ro.IsVisible=true;
ro.MaxPlayers=4;
PhotonNetwork.JoinOrCreateRoom(RoomName,ro,TypedLobby.Default);



}
   #endregion



   #region Public Methods



   #endregion



   #region Photon Callbacks

public override void OnConnectedToMaster(){



    Debug.Log("You connected to photon master server ");
    if (!PhotonNetwork.InLobby)
    {
        PhotonNetwork.JoinLobby();
    }

}
public override void OnJoinedLobby(){

Debug.Log("You have connected to photon lobby");
CreatePhotonRoom("TestRoom");


}


public override void OnCreatedRoom(){

Debug.Log($"You Have Created a Photon Room Named {PhotonNetwork.CurrentRoom.Name}");



}
public override void OnJoinedRoom(){
Debug.Log($"You Have Joined The Photon Room Named {PhotonNetwork.CurrentRoom.Name}");



}

public override  void OnJoinRandomFailed(short returnCode,string message){

Debug.Log($"You Failed To Join a Photon Room : {message}");




}
public override void OnPlayerEnteredRoom(Photon.Realtime.Player  newplayer){
Debug.Log($"Another Player has joined The Room {newplayer.UserId}");




}
public override void OnPlayerLeftRoom(Photon.Realtime.Player  otherplayer){
Debug.Log($" Player has left The Room {otherplayer.UserId}");




}
public override void OnMasterClientSwitched(Photon.Realtime.Player  newMasterClient){
Debug.Log($" new master client is  {newMasterClient.UserId}");




}


   #endregion
  
}
