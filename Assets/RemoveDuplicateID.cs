using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RemoveDuplicateID : MonoBehaviourPunCallbacks
{
    public static List<string>  Names=new List<string>();
    public static List<bool> Stutes=new List<bool>();
    private string currentName;
    // Start is called before the first frame update
    void Start()
    {
      currentName=GetComponent<PhotonView>().Controller.NickName;

        try{
if(Stutes[Names.IndexOf(currentName)])
{
    print("sahea");
    
PhotonView.Destroy(gameObject);

}
else{
    print("Newaaaa");
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
}