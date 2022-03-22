using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;
using TMPro;

using UnityEngine.InputSystem;
using StarterAssets;

using System.Linq;
using System.Collections.Generic;


public class PlayerManager : MonoBehaviour
{
    public int playerID = 0;
    public MultiplayerManager mPlayer;
    public GameObject PlayerCam;
    public PhotonView photonView;
    public GameObject SpeechBubbleCanvas;
    public TMP_Text tSpeech;

    public GameObject[] goWebGLMaleLOD, goWebGLFemaleLOD;
    public GameObject maleCharWebGL, femaleCharWebGL;

    public Animator animWebMale, animWebFemale;

    public PlayerInput playerInput;

    public GameObject SpeakingIndicator;
    public GameObject SpeakerIndiactorForThisPlayer;

    public ThirdPersonController thirdPersonController;
    public bool isGetUsrDetails;
    public string userInfo;

    //public LoginData userDataClass;
    //public UserAvatar userAvatarClass;

    public bool isPopUpCollider = true;
    public int invokeCounter = 0;
    public bool isShowChat = false;

    //Public =0
    public int chatZoneID = 0;

    //public Recorder VoiceRecorder;
    public AudioSource auVoice;

    // Start is called before the first frame update
    void Start()
    {
        invokeCounter = 0;
        isGetUsrDetails = false;
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(PushButton))
    //    {
    //        Debug.Log("SPEAKER ON");
    //        if (photonView.IsMine)
    //        {
    //            VoiceRecorder.TransmitEnabled = true;
    //        }
    //    }
    //    else if (Input.GetKeyUp(PushButton))
    //    {
    //        Debug.Log("SPEAKER OFF");

    //        if (photonView.IsMine)
    //        {
    //            VoiceRecorder.TransmitEnabled = false;
    //        }
    //    }
    //}

    public void SetComponents()
    {
        PlayerCam.SetActive(true);
        //VoiceRecorder.TransmitEnabled = false;
        auVoice.mute = true;
        this.tag = "Player";
        isShowChat = false;
        isPopUpCollider = false;
        SetInput(true);
        SetController(true);
        MultiplayerManager.Instance.pmPlayerList.Add(this);
        //ExhibitionDetailsManager.instance.CharacterUser = this.gameObject;
        /*CharacterSetup.instance.AssignCharcterModelMethod(goWebGLMaleLOD, goWebGLFemaleLOD, maleCharWebGL, femaleCharWebGL,
            animWebMale, animWebFemale);*/

        //Debug.Log("LoadFromFile AVTART : " + MultiplayerManager.Instance.setJsonUserAvatar);

        if (MultiplayerManager.Instance.setJsonUserAvatar != string.Empty)
        {
            //userAvatarClass = JsonUtility.FromJson<UserAvatar>(MultiplayerManager.Instance.setJsonUserAvatar);
         //   CharacterSetup.instance.SetCotsumeAvatar(userAvatarClass);
        }
       
        InvokeRepeating("SubmitUserInfo", 1f, 2f);
        InvokeRepeating("SubmitUserAvatar", 1f, 2f);

        //Debug.Log("TOTAL PLAYER:" + PhotonNetwork.PlayerList.Length);
        //Debug.Log("Load player:"+ PhotonNetwork.LocalPlayer.ActorNumber);
        //Debug.Log("OwnerActorNr" + photonView.OwnerActorNr);
    }

    void SetInput(bool value)
    {
        playerInput.enabled = value;
    }
    void SetController(bool value)
    {
        thirdPersonController.enabled = value;
    }

    public void TextInputScreen(bool IsOpen)
    {
        SetInput(!IsOpen);
        SetController(!IsOpen);
    }
    

    public void SubmitUserInfo()
    {
        //if (this.invokeCounter == 15)
        //    return;

        if (!photonView.IsMine)
            return;

        photonView.RPC("ShareUserProfile", RpcTarget.All, MultiplayerManager.Instance.setJsonUser.ToString());
    }

    public void WaitToCallCancleInvoke()
    {
        CancelInvoke("SubmitUserAvatar");
    }

    public void SubmitUserAvatar()
    {
        //if (this.invokeCounter == 15)
        //    return;

        if (!photonView.IsMine)
            return;
        photonView.RPC("ShareUserAvatar", RpcTarget.All, MultiplayerManager.Instance.setJsonUserAvatar.ToString());
        //Invoke("WaitToCallCancleInvoke", 3.0f);
    }


    void SetSpeech(string _text,bool status)
    {
        CancelInvoke("HideSpeech");
        tSpeech.text = _text;
        SpeechBubbleCanvas.SetActive(true);
        //CheckPopUpStatus(status);
        Invoke("HideSpeech", 5f);
    }


    public void CheckPopUpStatus(bool status)
    {
        Debug.Log("CheckPopUpStatus ZONE ID::" + chatZoneID +"="+status);

        if(status)
        {
            SpeechBubbleCanvas.SetActive(true);
        }
        else
        {
            for (int i = 0; i < MultiplayerManager.Instance.pmPlayerList.Count; i++)
            {
                if (chatZoneID == MultiplayerManager.Instance.pmPlayerList[i].chatZoneID)
                {
                    SpeechBubbleCanvas.SetActive(true);
                }
            }

            SpeechBubbleCanvas.SetActive(true);
        }
    }

    void HideSpeech()
    {
        SpeechBubbleCanvas.SetActive(false);
    }


    public void SubmitText(string _text,string id)
    {
        Debug.Log("PLAYER ID::"+ playerID);
        Debug.Log("CHATE ZONE ID::" + chatZoneID);

        CancelInvoke("HideSpeech");
        id = MultiplayerManager.Instance.zoneID.ToString();
        tSpeech.text = _text;
        Debug.Log("SEND TEXT:"+ _text);
        SpeechBubbleCanvas.SetActive(true);
        Invoke("HideSpeech", 5f);

        //if (!photonView.IsMine)
        //    return;

        photonView.RPC("ShareText", RpcTarget.Others, _text, id, PhotonNetwork.LocalPlayer.ActorNumber);

    }

    [PunRPC]
    void ShareText(string text, string zID, int actorNumber)
    {
        Debug.Log("OWN CHATE ZONE ID:"+chatZoneID);
        Debug.Log("SHOW TEXT IN PLAYER ID::"+actorNumber);
        Debug.Log("SHOW TEXT IN PLAYER ZONR ID:" + zID);

        List<string> splitStr = new List<string>();
        int zoneID = 0;

        Debug.Log("GET TEXT:" + text);

        if (!string.IsNullOrEmpty(text))
        {
            int.TryParse(zID, out zoneID);
            Debug.Log("SEND PLAYER ZONN ID::" + zoneID);
            Debug.Log("OWN PLAYER ZONN ID::" + MultiplayerManager.Instance.zoneID);

            if (zoneID == 0)
            {
                for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
                {
                    if (PhotonNetwork.PlayerList[i].ActorNumber == actorNumber)
                    {
                        SetSpeech(text, true);
                        break;
                    }
                }
            }
            else
            {
                Debug.Log("NOT 0 PLAYER ID::" + actorNumber);
                Debug.Log("NOT 0 OWN PLAYER ID::" + playerID);

                if (zoneID == MultiplayerManager.Instance.zoneID)
                {
                    for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
                    {
                        if (PhotonNetwork.PlayerList[i].ActorNumber == actorNumber)
                        {
                            SetSpeech(text, true);
                            break;
                        }
                    }
                }
            }
        }
    }


    // Change By Renish
    public void SubmitVoiceChat(string id)
    {
        SpeakerIndiactorForThisPlayer.SetActive(true);
        Debug.Log("PLAYER ID::" + playerID);
        Debug.Log("CHATE ZONE ID::" + chatZoneID);
        id = MultiplayerManager.Instance.zoneID.ToString();
        Debug.Log("SEND VOICE ID:" + id);
        photonView.RPC("ShareVoiceChat", RpcTarget.Others, id, PhotonNetwork.LocalPlayer.ActorNumber);
    }

    [PunRPC]
    void ShareVoiceChat(string zID, int actorNumber)
    {
        SpeakingIndicator.SetActive(true);
        Debug.Log("EGT PLAYER ID::" + actorNumber);
        Debug.Log("GET ZONE ID:" + zID);
        int zoneID = 0;
        int.TryParse(zID, out zoneID);
        Debug.Log("SEND PLAYER ZONN ID::" + zoneID);
        Debug.Log("OWN PLAYER ZONN ID::" + MultiplayerManager.Instance.zoneID);

        if (zoneID == 0)
        {
            for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
            {
                if (PhotonNetwork.PlayerList[i].ActorNumber == actorNumber)
                {
                    SetVoiceChat(false);
                    break;
                }
            }
        }
        else
        {
            Debug.Log("NOT 0 PLAYER ID::" + actorNumber);
            Debug.Log("NOT 0 OWN PLAYER ID::" + playerID);

            if (zoneID == MultiplayerManager.Instance.zoneID)
            {
                Debug.Log("MATCH ZONE ID");
                for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
                {
                    if (PhotonNetwork.PlayerList[i].ActorNumber == actorNumber)
                    {
                        SetVoiceChat(false);
                        break;
                    }
                }
            }
            else
            {
                Debug.Log("NOT MATCH ZONE ID");
                SetVoiceChat(true);
            }
        }
    }

    // Change By Renish
    public void SubmitVoiceChatOff(string id)
    {
        SpeakerIndiactorForThisPlayer.SetActive(false);
        Debug.Log("PLAYER ID::" + playerID);
        id = MultiplayerManager.Instance.zoneID.ToString();
        Debug.Log("SEND VOICE ID:" + id);
        photonView.RPC("ShareVoiceChatOff", RpcTarget.Others, id, PhotonNetwork.LocalPlayer.ActorNumber);
    }

    [PunRPC]
    void ShareVoiceChatOff(string zID, int actorNumber)
    {
        SpeakingIndicator.SetActive(false);
        Debug.Log("GET PLAYER ID::" + actorNumber);
        Debug.Log("GET ZONE ID:" + zID);
        int zoneID = 0;
        int.TryParse(zID, out zoneID);
        Debug.Log("SEND PLAYER ZONN ID::" + zoneID);
        Debug.Log("OWN PLAYER ZONN ID::" + MultiplayerManager.Instance.zoneID);

        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            if (PhotonNetwork.PlayerList[i].ActorNumber == actorNumber)
            {
                SetVoiceChatOff();
                break;
            }
        }
    }


    void SetVoiceChatOff()
    {
        Debug.Log("AUDIO OFFF");
        auVoice.mute = true;
    }

    void SetVoiceChat(bool status)
    {
        Debug.Log("AUDIO SOURCE STATUS::"+ status);
        auVoice.mute = status;
    }

    [PunRPC]
    void ShareUserProfile(string text)
    {
        this.userInfo = text;
       // this.userDataClass = JsonUtility.FromJson<LoginData>(this.userInfo);
    }

    [PunRPC]
    void ShareUserAvatar(string text)
    {
        //this.userAvatarClass = JsonUtility.FromJson<UserAvatar>(text);

       /* if (userAvatarClass.character == "male")
        {
            this.maleCharWebGL.SetActive(true);
            thirdPersonController._animator = animWebMale;
            SetCotsumeMaleAvatarPhoton(this.userAvatarClass.costumeid);
        }
        else
        {
            this.femaleCharWebGL.SetActive(true);
            thirdPersonController._animator = animWebFemale;
            SetCotsumeFeMaleAvatarPhoton(this.userAvatarClass.costumeid);
        }*/
    }

    [PunRPC]
    void SharChatOtherColliderOn(int actorNumber)
    {
        Debug.Log("SubmitAllPlayerInfo PLAYER ID:" + actorNumber);

        for (int i = 0; i < MultiplayerManager.Instance.pmPlayerList.Count; i++)
        {
            Debug.Log("COMPARE :" + actorNumber + "=" + MultiplayerManager.Instance.pmPlayerList[i].playerID);
            if (actorNumber != MultiplayerManager.Instance.pmPlayerList[i].playerID)
            {
                MultiplayerManager.Instance.pmPlayerList.Add(this);
                MultiplayerManager.Instance.pmPlayerList = MultiplayerManager.Instance.pmPlayerList.Distinct().ToList();
                MultiplayerManager.Instance.pmPlayerList[MultiplayerManager.Instance.pmPlayerList.Count - 1].playerID = actorNumber;
                break;
            }
        }
    }

    public void SubmitChatStatusOn(int actorNumber)
    {
        if (!photonView.IsMine)
            return;
        photonView.RPC("SharChatColliderOn", RpcTarget.All, actorNumber);
    }

    [PunRPC]
    void SharChatColliderOn(int actorNumber)
    {
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            if (PhotonNetwork.PlayerList[i].ActorNumber == actorNumber)
            {
                chatZoneID = 1;
                isShowChat = true;
                break;
            }
        }
    }

    public void SubmitChatStatusOff(int actorNumber)
    {
        if (!photonView.IsMine)
            return;
        photonView.RPC("SharChatColliderOff", RpcTarget.All, actorNumber);
    }

    [PunRPC]
    void SharChatColliderOff(int actorNumber)
    {
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            if (PhotonNetwork.PlayerList[i].ActorNumber == actorNumber)
            {
                chatZoneID = 0;
                SpeechBubbleCanvas.SetActive(false);
                isShowChat = false;
                MultiplayerManager.Instance.PhotonIdInStatusMethod(false,actorNumber);
                CancelInvoke("HideSpeech");
                SpeechBubbleCanvas.SetActive(false);
                break;
            }
        }
    }

    public void SetCotsumeMaleAvatarPhoton(int indexCostume)
    {
        //Debug.Log("SetMaleMaterial " + indexCostume);
       // this.goWebGLMaleLOD[0].GetComponent<SkinnedMeshRenderer>().material = CharacterSetup.instance.matMaleCostume[indexCostume];
    }

    void SetCotsumeFeMaleAvatarPhoton(int indexCostume)
    {
        //Debug.Log("SetFemaleMaterial " + indexCostume);

        Material[] mats = this.goWebGLFemaleLOD[0].GetComponent<Renderer>().materials;
     //   mats[0] = CharacterSetup.instance.matFemaleCostume[indexCostume];
      //  mats[1] = CharacterSetup.instance.matFemaleHair[indexCostume];
        this.goWebGLFemaleLOD[0].GetComponent<Renderer>().materials = mats;
    }

    public void OnMouseDown()
    {
        if (!isPopUpCollider)
            return;

        //Debug.Log("Hit Collider");

      /*  if(!MultiplayerManager.Instance._vCardManager.isActiveAndEnabled)
        {
            MultiplayerManager.Instance._vCardManager.gameObject.SetActive(true);
            MultiplayerManager.Instance._vCardManager.GetPhotonUserInformationMethod(userDataClass.id,
           userDataClass.Name, userDataClass.Designation, (long)userDataClass.Phone, userDataClass.Email,
           userDataClass.Picture, userDataClass.user_character, userDataClass.role_id, userDataClass.CompanyID,
           userDataClass.CompanyCommonName, userDataClass.CompanyRegisteredName, userDataClass.CompanyPhone,
           userDataClass.CompanyWebsite, userDataClass.CompanyDescription, userDataClass.CompanyEmail,
           userDataClass.CompanyAddress, userDataClass.CompanyLogo);
        }
        else
        {
        }*/
    }
}