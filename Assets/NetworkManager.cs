using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using System;

/*
#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif
*/

public class NetworkManager : MonoBehaviourPunCallbacks
{

    public GameObject newgamemanager;
    public InputField i1;
    public PhotonView pv;
    // Start is called before the first frame update
    private void Awake()
    {
        if (!ApiClasses.Vistor)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public int ID()
    {
        if (!UPDownMenu.Login)
        {
            return ApiClasses.Register.data.user.id;
        }
        else
        {
            return ApiClasses.Login.data.original.user.id;

        }
    }
    public string Name()
    {
        if (!UPDownMenu.Login)
        {
            return ApiClasses.Register.data.user.name;
        }
        else
        {
            return ApiClasses.Login.data.original.user.name;

        }
    }
    GameObject dialog = null;

    void Start()
    {
        if (!ApiClasses.Vistor)
        {
            try
            {
                ConnectToPhoton(ID().ToString() + "%%" + Name());
            }
            catch
            {

            }
        }
       

    }
    private void CreatePhotonRoom(string RoomName)
    {
        RoomOptions ro = new RoomOptions();
        ro.IsOpen = true;
        ro.IsVisible = true;
        ro.MaxPlayers = 255;
        PhotonNetwork.CreateRoom(RoomName, ro, TypedLobby.Default);




    }
    public void JoinOrcreateRoom(string RoomName)
    {

        if (PhotonNetwork.CurrentRoom != null)
        {

            if (PhotonNetwork.LeaveRoom())
            {

               Debug.Log("ssssssssssssssss      ");
            }
        }




        RoomOptions ro = new RoomOptions();
        ro.IsOpen = true;
        ro.IsVisible = true;
        ro.MaxPlayers = 255;

        if (PhotonNetwork.CurrentRoom == null)
        {

            if (!PhotonNetwork.JoinRoom(RoomName))
            {
                CreatePhotonRoom(RoomName);
                PhotonNetwork.JoinRoom(RoomName);
            }


           Debug.Log("aaaaaaaaaaaaaaaaaSS      " + PhotonNetwork.CurrentRoom);

        }

    }
    private void ConnectToPhoton(string nickname)
    {

        try
        {

            PhotonNetwork.AuthValues = new AuthenticationValues(nickname);
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.NickName = nickname;
            PhotonNetwork.ConnectUsingSettings();
        }
        catch (Exception ex)
        {

           Debug.Log(ex.Message);
        }
    }
    IEnumerator joinRoomIntime()
    {

        yield return new WaitUntil(()=> isconnected);
        try
        {

            PhotonNetwork.JoinRoom("Mymall");
         
        }
        catch
        {
            try
            {
                try
                {

                    PhotonNetwork.JoinRoom("Mymall2");
                 
                }
                catch
                {

                }
            }
            catch
            {

            }
        }

    }
    public int charid;
    public void play(int id)
    {

        //PhotonNetwork.JoinLobby();
        charid = id;
        StartCoroutine(joinRoomIntime());
    }


    public override void OnJoinedRoom()
    {
       Debug.Log(PhotonNetwork.CurrentRoom);
        newgamemanager.SetActive(true);

        //PhotonNetwork.LoadLevel(0);

        newgamemanager.GetComponent<newGameManager>().createLocalplayer(charid);


    }
    public bool isconnected;
    public override void OnConnectedToMaster()
    {
       // PhotonNetwork.JoinLobby(TypedLobby.Default);
        //PhotonNetwork.AutomaticallySyncScene = true;

        //  i1.text+="     Entered";
        isconnected = true;

    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
       Debug.Log(message);
        try
        {
            CreatePhotonRoom("Mymall");
        }
        catch
        {
            CreatePhotonRoom("Mymall2");
        }

    }
    public override void OnJoinedLobby()
    {


    }

    public bool FindFriends(string[] friendsUserIds)
    {
        return PhotonNetwork.FindFriends(friendsUserIds);
    }
    public override void OnFriendListUpdate(List<FriendInfo> friendsInfo)
    {
        for (int i = 0; i < friendsInfo.Count; i++)
        {
            FriendInfo friend = friendsInfo[i];
            Debug.LogFormat("{0}", friend);
        }
    }
   
  
}
