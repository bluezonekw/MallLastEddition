using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Voice;
using System.Linq;
using System;
using StarterAssets;
public class newGameManager : MonoBehaviourPunCallbacks
{

 public  chooseCharacter  s ;
    
 public  int countRoom=0;
    public List<GameObject> player=new List<GameObject>();
    public Cinemachine.CinemachineVirtualCamera virtualCamera;
    public UICanvasControllerInput i1, i2;
public int ID()
    {
       if(!UPDownMenu.Login)
        {
            return ApiClasses.Register.data.user.id;
        }
        else
        {
            return ApiClasses.Login.data.original.user.id;

        }
    }

  
    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
       
     Debug.Log(newPlayer.ToStringFull());
   
    }
    [PunRPC]
    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        Debug.Log(otherPlayer.ToStringFull());
       
        PhotonNetwork.DestroyPlayerObjects(otherPlayer);
      foreach(var p in player)
        {
            if (p.name == otherPlayer.NickName)
            {
                Destroy(p);
                player.Remove(p);
            }
            print(otherPlayer.NickName + "          destory");
        }
       
    }
    public void createLocalplayer(int charcterid)
    {
        countRoom++;
        print(Name() + "     pllll     Created");


      
            //go = PhotonNetwork.Instantiate("Char/" +charcterid, new Vector3(-60.2f, -0.8f, -85f), Quaternion.identity);
            //go.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
            //go.GetComponent<checkCharacterOwn>().character.SetActive(false);
            go = PhotonNetwork.Instantiate("Char/" + charcterid, new Vector3(-60.2f, -0.8f, -85f), Quaternion.identity);
            go.name = Name();
            go.tag = "Player";
            player.Add(go);
      
       virtualCamera.Follow = go.transform.GetChild(1);
        i1.starterAssetsInputs = i2.starterAssetsInputs = go.GetComponent<StarterAssetsInputs>();








    }



    GameObject go;
   // Start is called before the first frame update
   [PunRPC]
    public void createplayer(string name,int charcterid){
countRoom++;
        print(name + "          Created");
        

        if (name != Name())
        {
            //go = PhotonNetwork.Instantiate("Char/" +charcterid, new Vector3(-60.2f, -0.8f, -85f), Quaternion.identity);
            //go.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
            //go.GetComponent<checkCharacterOwn>().character.SetActive(false);
              go = PhotonNetwork.Instantiate("Char/" + charcterid, new Vector3(-60.2f, -0.8f, -85f), Quaternion.identity);
            go.name = name;
            player.Add(go);
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
    void Start()
    {
        go = new GameObject();
        foreach (var p in PhotonNetwork.CurrentRoom.Players)
        {
            if(p.Value.NickName.Split(new string[] { "%%" }, StringSplitOptions.None)[1]!=Name())
            createplayer(p.Value.NickName.Split(new string[] { "%%" }, StringSplitOptions.None)[1],s.characterid);
        }
        //createplayer(Name(), s.characterid);
       
   
    
   
        
       
          countRoom=PhotonNetwork.CurrentRoom.Players.Count;
          
        
     
    
    }

  

}
