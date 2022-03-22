using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class newGameManager : MonoBehaviourPunCallbacks
{
 public  IPunPrefabPool  s ;
    public GameObject playerPerfab;
 public int countRoom=0;
 [PunRPC]
    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
       
      
    PhotonNetwork.InstantiateRoomObject(playerPerfab.name,new Vector3(-60.2f,-0.8f,-85f),Quaternion.identity);
      
       
    }
    [PunRPC]
    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        PhotonNetwork.DestroyPlayerObjects(otherPlayer);
       
    }
    // Start is called before the first frame update
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
        try{
         
         if(!PhotonNetwork.IsMasterClient){

            PhotonNetwork.InstantiateRoomObject(playerPerfab.name,new Vector3(-60.2f,-0.8f,-85f),Quaternion.identity);
            print("Shetan Wal Llabd");
         }
          countRoom=PhotonNetwork.CurrentRoom.Players.Count;
foreach(var p in PhotonNetwork.CurrentRoom.Players){


   PhotonNetwork.InstantiateRoomObject(playerPerfab.name,new Vector3(-60.2f,-0.8f,-85f),Quaternion.identity);


}
        }
        catch{

        }
        
     
      // PhotonNetwork.Instantiate(playerPerfab.name,new Vector3(-60.2f,-0.8f,-85f),Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
      try{
       
      if(countRoom<PhotonNetwork.CurrentRoom.Players.Count){
       
for(int x=0;x<PhotonNetwork.CurrentRoom.Players.Count-countRoom;x++){
print("01017800204");
 PhotonNetwork.InstantiateRoomObject(playerPerfab.name,new Vector3(-60.2f,-0.8f,-85f),Quaternion.identity);

}

      countRoom=PhotonNetwork.CurrentRoom.Players.Count;
    }
      }
      catch{

      }    
    }

}
