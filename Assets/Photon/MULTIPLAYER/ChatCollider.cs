using System.Collections;
using System.Collections.Generic;
//using DG.Tweening;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class ChatCollider : MonoBehaviour
{
    public GameObject PopUpObject;
    public float popupTime = 1.5f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            MultiplayerManager.Instance.zoneID = 1;
            // Changes By Renish
            PopUpObject.transform.GetChild(0).GetComponent<TMP_Text>().text = "Entering private area!";
            PopUpObject.transform.GetChild(1).GetComponent<TMP_Text>().text = "All communication in this area will be restricted to users in the area.";
            StartCoroutine("ShowPopUp");
            //PopUpObject.transform.DOMove(new Vector3(1, 0, 1), 1.5f);
            PlayerManager pm = other.GetComponent<PlayerManager>();
            Debug.Log("ENTER PLAYER ID:"+ PhotonNetwork.LocalPlayer.ActorNumber);
            pm.SubmitChatStatusOn(PhotonNetwork.LocalPlayer.ActorNumber);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            MultiplayerManager.Instance.zoneID = 0;
            // Changes By Renish
            PopUpObject.transform.GetChild(0).GetComponent<TMP_Text>().text = "Exiting private area!";
            PopUpObject.transform.GetChild(1).GetComponent<TMP_Text>().text = "All communication will now be public.";
            StartCoroutine("ShowPopUp");
            PlayerManager pm = other.GetComponent<PlayerManager>();
            Debug.Log("EXIT PLAYER ID:" + PhotonNetwork.LocalPlayer.ActorNumber);
            pm.SubmitChatStatusOff(PhotonNetwork.LocalPlayer.ActorNumber);
        }
    }

    // Changes By Renish
    public IEnumerator ShowPopUp()
    {
       // PopUpObject.GetComponent<RectTransform>().DOAnchorPos(new Vector2(PopUpObject.GetComponent<RectTransform>().anchoredPosition.x, 375), 0.5f);
        yield return new WaitForSeconds(popupTime);
       // PopUpObject.GetComponent<RectTransform>().DOAnchorPos(new Vector2(PopUpObject.GetComponent<RectTransform>().anchoredPosition.x, 800), 0.5f);
    }
}
