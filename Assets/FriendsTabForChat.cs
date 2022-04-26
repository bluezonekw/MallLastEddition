using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RTLTMPro;
using TMPro;
public class FriendsTabForChat : MonoBehaviour
{  
    public TMP_InputField Searchinput;
    
     [Header("---------color------")]
public Color Blue;
public Color White;
 [Header("---------Header------")]
 public Image YourFriendsImage;
 public Image SearchFriendsImage;
 public Image FriendRequestImage;
 public RTLTextMeshPro YourFriendsText;
  public RTLTextMeshPro SearchFriendsText;
 public RTLTextMeshPro FriendRequestText;
[Header("---------Body------")]
public GameObject YourFriends;
 public GameObject SearchFriends;
 public GameObject FriendRequest;

public enum Friends{
    YourFriends,SearchFriends,FriendReques
}
public static Friends FriendsType;
    // Start is called before the first frame update
    void Start()
    {
        ClickOnYourFriends();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


public void ClickOnYourFriends()
{
FriendsType=Friends.YourFriends;
YourFriendsImage.fillAmount=1;
SearchFriendsImage.fillAmount=0;
FriendRequestImage.fillAmount=0;
YourFriendsText.color=Blue;
SearchFriendsText.color=White;
FriendRequestText.color=White;
YourFriends.SetActive(true);
SearchFriends.SetActive(false);
FriendRequest.SetActive(false);
}



public void ClickOnSearchFriends()
{
FriendsType=Friends.SearchFriends;
YourFriendsImage.fillAmount=0;
SearchFriendsImage.fillAmount=1;
FriendRequestImage.fillAmount=0;
YourFriendsText.color=White;
SearchFriendsText.color=Blue;
FriendRequestText.color=White;
YourFriends.SetActive(false);
SearchFriends.SetActive(true);
FriendRequest.SetActive(false);
}






public void ClickOnFriendReques()
{
FriendsType=Friends.FriendReques;
YourFriendsImage.fillAmount=0;
SearchFriendsImage.fillAmount=0;
FriendRequestImage.fillAmount=1;
YourFriendsText.color=White;
SearchFriendsText.color=White;
FriendRequestText.color=Blue;
YourFriends.SetActive(false);
SearchFriends.SetActive(false);
FriendRequest.SetActive(true);
}


public void SearcheFriend(){
if(FriendsType==Friends.YourFriends){

YourFriends.GetComponent<getfriendlist>().friendSearch(Searchinput.text);

}else
if(FriendsType==Friends.SearchFriends)
{

SearchFriends.GetComponent<getfriendlist>().LoadSearchlist(Searchinput.text);

}
else{




}





}

}
