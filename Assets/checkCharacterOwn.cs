using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace StarterAssets
{
public class checkCharacterOwn : MonoBehaviour
{
    public PhotonView p1;
    public GameObject character;
    public Text Name,name2;
    public string NameMainPlayer;
 public    GameObject MainPlayer;
public static string UserIdMain;


 
    // Start is called before the first frame update
    void Start()
    {
        //print("Controller   :"+p1.Controller.NickName+"creator  :"+p1.Owner.NickName);
     
       Name.text=p1.Controller.NickName;
       name2.text=Name.text;
        GameObject[] s=GameObject.FindGameObjectsWithTag("Player");
       
        foreach(var k in s){
            if(k.name==NameMainPlayer){

                MainPlayer=k;
            }
        


        }
      
        if(p1.IsMine){
            gameObject.tag="LocalPlayer";
UserIdMain=p1.Controller.UserId;
character.SetActive(false);
//transform.parent=MainPlayer.transform;
        }else{
           // transform.parent=MainPlayer.transform.parent;
         character.SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
if(SceneManager.GetActiveScene().buildIndex!=3){

DestroyImmediate(this.gameObject);


}
if(p1.IsMine){

character.SetActive(false);
}else{


      character.SetActive(true);
}

         if (transform.hasChanged)
        { transform.hasChanged=false;
             GetComponent<Animator>().SetFloat("Speed",2);
           
            
        }else{

             GetComponent<Animator>().SetFloat("Speed",0);
            
        }
if(p1.IsMine&&(GetComponent<StarterAssetsInputs>().move.x!=0||GetComponent<StarterAssetsInputs>().move.y!=0))
  {
    
   

transform.position=MainPlayer.transform.position;
transform.rotation=MainPlayer.transform.rotation;


}else if(p1.IsMine&&(GetComponent<StarterAssetsInputs>().move.x==0&&GetComponent<StarterAssetsInputs>().move.y==0))
  {  


transform.position=MainPlayer.transform.position;
transform.rotation=MainPlayer.transform.rotation;

}
    }
      void OnApplicationQuit()
    {
     
       if(p1.IsMine){

Destroy(gameObject);

       }
      
    }
}

}