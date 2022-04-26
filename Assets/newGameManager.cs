using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Voice;
public class newGameManager : MonoBehaviourPunCallbacks
{

 public  IPunPrefabPool  s ;
    public GameObject playerPerfab;
 public  int countRoom=0;


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
  
 [PunRPC]
    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
       
      print(newPlayer.ToStringFull());
      createplayer(newPlayer.NickName);
 //   PhotonNetwork.InstantiateRoomObject(playerPerfab.name,new Vector3(-60.2f,-0.8f,-85f),Quaternion.identity);
      
       
    }
    [PunRPC]
    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        PhotonNetwork.DestroyPlayerObjects(otherPlayer);
       
    }
    // Start is called before the first frame update
    [PunRPC]
    public void createplayer(string name){

var go= PhotonNetwork.Instantiate(playerPerfab.name,new Vector3(-60.2f,-0.8f,-85f),Quaternion.identity);
            go.name= name;
            if(name==ID().ToString()){
DontDestroyOnLoad(go);
            }
    }
    void Start()
    {
      
          DefaultPool pool=new DefaultPool();
        try{
         pool = PhotonNetwork.PrefabPool as DefaultPool;
        }
        catch{
if (pool != null && this.playerPerfab != null)
        {
             pool.ResourceCache.Add(playerPerfab.name, playerPerfab);
        }
        }
   
         createplayer(ID().ToString());
   
        
       
          countRoom=PhotonNetwork.CurrentRoom.Players.Count;
          
        
     
    
    }

    // Update is called once per frame
    void Update()
    {
      try{
       
    

      countRoom=PhotonNetwork.CurrentRoom.Players.Count;
    }
      
      catch{

      }    
    }

}
