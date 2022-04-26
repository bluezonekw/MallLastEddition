using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RemoveDuplicateID : MonoBehaviourPunCallbacks
{
    public static List<string>  Names=new List<string>();
    public static List<bool> Stutes=new List<bool>();
    private string currentName;
    [Tooltip("The local player instance. Use this to know if the local player is represented in the Scene")]
public static GameObject LocalPlayerInstance;
    // Start is called before the first frame update
    void Start()
    {
      

        try{
            currentName=GetComponent<PhotonView>().Controller.NickName;
if(Stutes[Names.IndexOf(currentName)])
{
    
    
PhotonView.Destroy(gameObject);

}
else{
    
Stutes[Names.IndexOf(currentName)]=false;


}

        }catch{

Names.Add(currentName);
Stutes.Add(true);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    public void Awake() {
        // #Important
// used in GameManager.cs: we keep track of the localPlayer instance to prevent instantiation when levels are synchronized
if (photonView.IsMine)
{
    LocalPlayerInstance = this.gameObject;
}
// #Critical
// we flag as don't destroy on load so that instance survives level synchronization, thus giving a seamless experience when levels load.
DontDestroyOnLoad(this.gameObject);
    }
    */
}