using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Photon.Pun;

public class bl_FriendList : MonoBehaviour {

    [HideInInspector]
    public List<string> Friends = new List<string>();
    public Canvas m_FriendCanvas = null;
    [Space(5)]
    [Range(1,60)]
    public float UpdateEvery = 15f;

    public const string FriendSaveKey = "LSFriendList";
    private char splitChar = '|';

    public const string FriendListName = "LSFriendList";
    [HideInInspector] public bool WaitForEvent = false;
    private bl_FriendListUI FriendUI;

    /// <summary>
    /// 
    /// </summary>
    void Awake()
    {
        FriendUI = FindObjectOfType<bl_FriendListUI>();
        this.gameObject.name = FriendListName;
        m_FriendCanvas.enabled = false;
    }

    /// <summary>
    /// 
    /// </summary>
    void GetFriendsStore()
    {
        //Get all friends saved 
        string cacheFriend = PlayerPrefs.GetString(SaveKey, "Null");
        if (!string.IsNullOrEmpty(cacheFriend))
        {
            string[] splitFriends = cacheFriend.Split(splitChar);
            Friends.AddRange(splitFriends);
        }
        //Find all friends names in photon list.
        if (Friends.Count > 0)
        {
            PhotonNetwork.FindFriends(Friends.ToArray());
            //Update the list UI 
            this.GetComponent<bl_FriendListUI>().UpdateFriendList(true);
        }
        else
        {
            Debug.Log("Anyone friend store");
            return;
        }
    }

    /// <summary>
    /// Call For Update List of friends.
    /// </summary>
    void UpdateList()
    {
        if (!PhotonNetwork.IsConnected || bl_FriendListUI.FriensList == null)
            return;
        if (Friends.Count > 0)
        {
            if (Friends.Count > 1 && Friends.Contains("Null"))
            {
                Friends.Remove("Null");
                Friends.Remove("Null");
                SaveFriends();
            }
            PhotonNetwork.FindFriends(Friends.ToArray());
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void SaveFriends()
    {
        string allfriends = string.Join(splitChar.ToString(), Friends.ToArray());
        PlayerPrefs.SetString(SaveKey, allfriends);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="field"></param>
    public void AddFriend(InputField field)
    {
        string t = field.text;
        if (string.IsNullOrEmpty(t))
            return;

        if(FriendUI != null && FriendUI.hasThisFriend(t))
        {
            FriendUI.ShowLog("Already has added this friend.");
            return;
        }

        Friends.Add(t);
        PhotonNetwork.FindFriends(Friends.ToArray());
        this.GetComponent<bl_FriendListUI>().UpdateFriendList(true);
        SaveFriends();
        WaitForEvent = true;

        field.text = string.Empty;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="field"></param>
    public void AddFriend(string friend)
    {
        Friends.Add(friend);
        PhotonNetwork.FindFriends(Friends.ToArray());
        this.GetComponent<bl_FriendListUI>().UpdateFriendList(true);
        SaveFriends();
        WaitForEvent = true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="friend"></param>
    public void RemoveFriend(string friend)
    {
        if (Friends.Contains(friend))
        {
            Friends.Remove(friend);
            SaveFriends();
            if (Friends.Count > 0)
            {
                if(Friends.Count > 1 && Friends.Contains("Null"))
                {
                    Friends.Remove("Null");
                    Friends.Remove("Null");
                    SaveFriends();
                }
                PhotonNetwork.FindFriends(Friends.ToArray());
            }
            else
            {
                AddFriend("Null");
                PhotonNetwork.FindFriends(Friends.ToArray());
            }

            this.GetComponent<bl_FriendListUI>().UpdateFriendList(true);
            WaitForEvent = true;
        }
        else { Debug.Log("This user doesn't exist"); }
    }
    /// <summary>
    /// 
    /// </summary>
    void OnJoinedLobby()
    {
        Debug.Log("Friend Start");
        GetFriendsStore();
        InvokeRepeating("UpdateList", 1, UpdateEvery);
        m_FriendCanvas.enabled = true;
    }

    /// <summary>
    /// custom key for each player can save multiple friend list in a same device.
    /// </summary>
    private string SaveKey
    {
        get
        {
            return PhotonNetwork.NickName + FriendSaveKey;
        }
    }
}