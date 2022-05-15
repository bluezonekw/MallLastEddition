using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTLTMPro;
using UnityEngine.UI;
public class MainButtonInchat : MonoBehaviour
{
public enum ChatMenu{

Friends,Chats,Calls,Camera


}

public static ChatMenu  chatMenuChooser;

       [Header("---------Header GameObject Chat------")]
 
public GameObject HeaderFriends;
public GameObject HeaderChats;
public GameObject HeaderCalls;
public GameObject HeaderCamera;
   [Header("---------Body GameObject Chat------")]

public GameObject BodyFriends;
public GameObject BodyChats;
public GameObject BodyCalls;
public GameObject BodyCamera;

[Header("---------Footer GameObject Chat------")]

public GameObject FooterMain;
public GameObject FooterPrivateChat;
public GameObject FooterGroupChat;
public GameObject FooterCamera;
[Header("---------   Main Footer  ------")]
public GameObject MainFooterFriends;
public RTLTextMeshPro MainFooterFriendsText;
public Image MainFooterFriendsImage;
public GameObject MainFooterChat;
public RTLTextMeshPro MainFooterChatText;
public Image MainFooterChatImage;

public GameObject MainFooterCalls;
public RTLTextMeshPro MainFooterCallsText;
public Image MainFooterCallsImage;
public GameObject MainFooterCamera;
public RTLTextMeshPro MainFooterCameraText;
public Image MainFooterCameraImage;
[Header("---------   Main Color  ------")]
public Color Blue;
public Color Black;

 void OnEnable() {
  ClickOnChats();
}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

public void ClickOnFriends(){
chatMenuChooser=ChatMenu.Friends;
HeaderFriends.SetActive(true);
 HeaderChats.SetActive(false);
 HeaderCalls.SetActive(false);
 HeaderCamera.SetActive(false);
BodyFriends.SetActive(false);
 BodyFriends.SetActive(true);
BodyChats.SetActive(false);
 BodyCalls.SetActive(false);
BodyCamera.SetActive(false);

 FooterMain.SetActive(true);
 FooterPrivateChat.SetActive(false);
 FooterGroupChat.SetActive(false);
 FooterCamera.SetActive(false);


 MainFooterFriendsText.color= Blue;
  MainFooterFriendsImage.color=Blue;


MainFooterChatText.color= Black;
MainFooterChatImage.color=Black;


MainFooterCallsText.color= Black;
MainFooterCallsImage.color=Black;



MainFooterCameraText.color= Black;
MainFooterCameraImage.color=Black;










}





public void ClickOnChats(){
chatMenuChooser=ChatMenu.Chats;
HeaderFriends.SetActive(false);
 HeaderChats.SetActive(true);
 HeaderCalls.SetActive(false);
 HeaderCamera.SetActive(false);

 BodyFriends.SetActive(false);
BodyChats.SetActive(true);
 BodyCalls.SetActive(false);
BodyCamera.SetActive(false);

FooterMain.SetActive(true);
 FooterPrivateChat.SetActive(false);
 FooterGroupChat.SetActive(false);
 FooterCamera.SetActive(false);


 MainFooterFriendsText.color= Black;
  MainFooterFriendsImage.color=Black;


MainFooterChatText.color= Blue;
MainFooterChatImage.color=Blue;


MainFooterCallsText.color= Black;
MainFooterCallsImage.color=Black;



MainFooterCameraText.color= Black;
MainFooterCameraImage.color=Black;










}


public void ClickOnCalls(){
chatMenuChooser=ChatMenu.Calls;
HeaderFriends.SetActive(true);
 HeaderChats.SetActive(false);
 HeaderCalls.SetActive(false);
 HeaderCamera.SetActive(false);

 BodyFriends.SetActive(true);
BodyChats.SetActive(false);
 BodyCalls.SetActive(false);
BodyCamera.SetActive(false);

 FooterMain.SetActive(true);
 FooterPrivateChat.SetActive(false);
 FooterGroupChat.SetActive(false);
 FooterCamera.SetActive(false);


 MainFooterFriendsText.color= Black;
  MainFooterFriendsImage.color=Black;


MainFooterChatText.color= Black;
MainFooterChatImage.color=Black;


MainFooterCallsText.color= Blue;
MainFooterCallsImage.color=Blue;



MainFooterCameraText.color= Black;
MainFooterCameraImage.color=Black;










}


public void ClickOnCamera(){
chatMenuChooser=ChatMenu.Camera;
HeaderFriends.SetActive(false);
 HeaderChats.SetActive(false);
 HeaderCalls.SetActive(false);
 HeaderCamera.SetActive(true);

 BodyFriends.SetActive(false);
BodyChats.SetActive(false);
 BodyCalls.SetActive(false);
BodyCamera.SetActive(true);

 FooterMain.SetActive(false);
 FooterPrivateChat.SetActive(false);
 FooterGroupChat.SetActive(false);
 FooterCamera.SetActive(true);


 MainFooterFriendsText.color= Black;
  MainFooterFriendsImage.color=Black;


MainFooterChatText.color= Black;
MainFooterChatImage.color=Black;


MainFooterCallsText.color= Black;
MainFooterCallsImage.color=Black;



MainFooterCameraText.color= Blue;
MainFooterCameraImage.color=Blue;










}



}
