using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using System;
public class NetworkManager : MonoBehaviourPunCallbacks
{
    
    public GameObject newgamemanager;
    public InputField i1;
     public  PhotonView pv;
    // Start is called before the first frame update
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
    void Start()
    {
        //connect();
        // i1.text="sad"+DateTime.Now.Second.ToString();
        
 ConnectToPhoton(UserName());
      // pv.Owner.NickName=i1.text;
  
    }
    private void CreatePhotonRoom(string RoomName){
RoomOptions  ro=new RoomOptions();
ro.IsOpen=true;
ro.IsVisible=true;
ro.MaxPlayers=10;
PhotonNetwork.CreateRoom(RoomName,ro,TypedLobby.Default);




}
private void ConnectToPhoton(string nickname){

try{
Debug.Log($"connect to photon as {nickname}");
PhotonNetwork.AuthValues=new AuthenticationValues(nickname);
PhotonNetwork.AutomaticallySyncScene=true;
PhotonNetwork.NickName=nickname;
PhotonNetwork.ConnectUsingSettings();
}
catch(Exception ex){

    print(ex.Message);
}
}

public void play(){
  PhotonNetwork.JoinRoom("Mymall");
//PhotonNetwork.JoinLobby();


}
    
  
    public override void OnJoinedRoom()
    {
        print("joined Room Y--y");
        newgamemanager.SetActive(true);
//PhotonNetwork.LoadLevel(0);



       
    }
    public override void OnConnectedToMaster()
    {
     //  i1.text+="     Entered";
       
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        print(message);
        CreatePhotonRoom("Mymall");

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
