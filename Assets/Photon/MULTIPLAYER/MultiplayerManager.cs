using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
//using APIClasses;
//using Network.Responses;
using System.Linq;
using StarterAssets;

public class MultiplayerManager : MonoBehaviourPunCallbacks
{
    public static MultiplayerManager Instance;
    public int intMaxPlayer = 0;
    public string strJoinRoomName;
    public GameObject PlayerPrefab;

    [Space]
    public Transform trPlayerPosParent;

    [Space]
    public List<Transform> trStartPosPointList;
    public PlayerManager localPlayer;
    public string userInfo;
    public string setJsonUser;
    public string setJsonUserAvatar;
    //public VisitingCardManager _vCardManager;

    public GameObject objPhotonLoding;

    public List<int> connectedPlayerIDList;
    public List<PlayerManager> pmPlayerList;

    public int zoneID = 0;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        zoneID = 0;

        connectedPlayerIDList.Clear();
        objPhotonLoding.SetActive(true);

        intMaxPlayer = 10;
        strJoinRoomName = "Room0";
        trStartPosPointList.Clear();

        for (int i=0;i< trPlayerPosParent.childCount;i++)
        {
            trStartPosPointList.Add(trPlayerPosParent.GetChild(i));
        }

      //  setJsonUserAvatar=LoginServer.userCharacterCosumeData;
    }


    public KeyCode PushButton;

    private void Start()
    {
        SetUserProfile();
        Debug.Log("Start To get User Info:"+userInfo);
    }

    private void Update()
    {
        if (localPlayer == null)
            return;

        if (Input.GetKeyDown(PushButton))
        {
            Debug.Log("SPEAKER ON");
            if (localPlayer.photonView.IsMine)
            {
                //localPlayer.VoiceRecorder.TransmitEnabled = true;
            }

            localPlayer.SubmitVoiceChat(zoneID.ToString());
        }
        else if (Input.GetKeyUp(PushButton))
        {
            Debug.Log("SPEAKER OFF");

            if (localPlayer.photonView.IsMine)
            {
              //  localPlayer.VoiceRecorder.TransmitEnabled = false;
            }

            localPlayer.SubmitVoiceChatOff(zoneID.ToString());
        }
    }

    void SetUserProfile()
    {
        //userInfo = UserData.userData.UserDataList[0].id + "," + UserData.userData.UserDataList[0].Name + "," +
        //    UserData.userData.UserDataList[0].Email + "," + UserData.userData.UserDataList[0].Phone + "," +
        //    UserData.userData.UserDataList[0].Picture + "," + UserData.userData.UserDataList[0].Designation + "," +
        //    UserData.userData.UserDataList[0].CompanyID + "," + UserData.userData.UserDataList[0].CompanyCommonName + "," +
        //    UserData.userData.UserDataList[0].CompanyEmail + "," + UserData.userData.UserDataList[0].CompanyRegisteredName + "," +
        //    UserData.userData.UserDataList[0].CompanyPhone + "," + UserData.userData.UserDataList[0].CompanyWebsite + "," +
        //    UserData.userData.UserDataList[0].Designation + "," + UserData.userData.UserDataList[0].CompanyAddress + "," +
        //    UserData.userData.UserDataList[0].CompanyLogo + "," + UserData.userData.UserDataList[0].user_character + "," +
        //    UserData.userData.UserDataList[0].role_id + "," + UserData.userData.UserDataList[0].Verification + "," +
        //    UserData.userData.UserDataList[0].Token;

      //  setJsonUser = JsonUtility.ToJson(UserData.userData.UserDataList[0]);
        Debug.Log("Set Json Class:"+ setJsonUser);
    }

    public void ConnectToPhoton()
    {
        Debug.Log("Connect To Photon Network");
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.GameVersion = "0.1";
        PhotonNetwork.AutomaticallySyncScene = true;
    }

   
    void JoinOrCreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 10;
        roomOptions.IsOpen = true;
        AddCustomeMwthod(roomOptions);
        PhotonNetwork.JoinOrCreateRoom("Room0", roomOptions, TypedLobby.Default);
    }

    public void AddCustomeMwthod(RoomOptions ro)
    {
        ro.CustomRoomProperties = new ExitGames.Client.Photon.Hashtable();
      //  ro.CustomRoomProperties.Add("id", UserData.userData.UserDataList[0].id.ToString());
    }

    //Change By Renish
    public void ChangePosition(Transform t) 
    {
        Debug.Log("Position--"+t.position);
        localPlayer.transform.GetComponent<ThirdPersonController>().enabled = false;
        localPlayer.transform.gameObject.transform.position = t.position;
        localPlayer.transform.gameObject.transform.rotation =t.rotation;
        localPlayer.transform.GetComponent<ThirdPersonController>().enabled = true;
    }
   
    void LoadMyPlayer()
    {
        int pos = Random.Range(0, trStartPosPointList.Count);
        Vector3 sp = trStartPosPointList[pos].position;
        GameObject go = PhotonNetwork.Instantiate("PlayerPhoton", sp, Quaternion.Euler(0, -180, 0));
        localPlayer = go.GetComponent<PlayerManager>();//
        //localPlayer.gameObject.GetComponent<Transform>().transform.rotation = Quaternion.Euler(0, -180, 0) ;
        // Change By Renish
        //WayPointsCamera.instance.Player.transform.GetComponent<Animator>().enabled = true;
       // StartCoroutine(WayPointsCamera.instance.StartAnim());
        //localPlayer.mPlayer = this;
        Debug.Log("CLone Player ID::" + PhotonNetwork.LocalPlayer.ActorNumber);
        localPlayer.playerID = PhotonNetwork.LocalPlayer.ActorNumber;
        localPlayer.SetComponents();
        PhotonIdInStatusMethod(true, PhotonNetwork.LocalPlayer.ActorNumber);
        objPhotonLoding.SetActive(false);
        //string value = PhotonNetwork.LocalPlayer.customProperties["id"];
        //Debug.Log("CustomProperties::" + value);
        //UIManager.Instance.HomeScreen.enabled = true;

        OnPlayerEnteredRoom(PhotonNetwork.LocalPlayer);
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        Debug.Log("OnPlayerLeftRoom IN ROOM PLAYER ID 1:" + otherPlayer.ActorNumber);
        base.OnPlayerLeftRoom(otherPlayer);
        SubmitLeftPlayer(otherPlayer.ActorNumber);
    }

    public void SubmitLeftPlayer(int player)
    {
        for (int i = 0; i < pmPlayerList.Count; i++)
        {
            if (pmPlayerList[i].playerID == player)
            {
                pmPlayerList.RemoveAt(i);
            }
        }
        Debug.Log("Left ROOM LISt");
    }

    public void StartInputText()
    {
       localPlayer.TextInputScreen(true);
    }

    public void SubmitText(string _text)
    {
       localPlayer.TextInputScreen(false);
       localPlayer.SubmitText(_text,zoneID.ToString());
    }

    #region Photon callbacks


    public override void OnConnected()
    {
        base.OnConnected();
        Debug.Log("Connect");
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("ConnectToMaster");
        JoinOrCreateRoom();
    }


    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("OnJoinRoom:" + PhotonNetwork.CurrentRoom.Name);
        LoadMyPlayer();
    }


    public void SubmitAllPlayerInfo()
    {
        localPlayer.photonView.RPC("SharChatOtherColliderOn", RpcTarget.Others, PhotonNetwork.LocalPlayer.ActorNumber);
    }

    

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        Debug.Log("JOIN PLAYER ID:"+ newPlayer.ActorNumber);
        SubmitAllPlayerInfo();
    }
    #endregion

    public void PhotonIdInStatusMethod(bool isStatus,int id)
    {
        if(isStatus)
        {
            connectedPlayerIDList.Add(id);
            connectedPlayerIDList = connectedPlayerIDList.Distinct().ToList();
        }
       else
        {
            connectedPlayerIDList.Remove(id);
        }
    }
}
