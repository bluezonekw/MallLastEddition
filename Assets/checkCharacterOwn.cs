using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using StarterAssets;
using Photon.Voice.Unity;

public class checkCharacterOwn : MonoBehaviour
{
    public PhotonView p1;
    public GameObject character;
    public Text Name,name2;
    public string NameMainPlayer;
 public  static  GameObject MainPlayer;
public static string UserIdMain;
    public AudioSource a;
    public Recorder R;
    public void Openvoice()
    {

      R.TransmitEnabled = true;
        a.mute = false;
    }
    public void closeVoice()
    {
        R.TransmitEnabled = false;
        a.mute = true;


    }
 
    // Start is called before the first frame update
    void Start()
    {
        //print("Controller   :"+p1.Controller.NickName+"creator  :"+p1.Owner.NickName);
        if (gameObject.name != NameMainPlayer)
        {
            Name.text = gameObject.name;
            name2.text = gameObject.name;
            GameObject[] s = GameObject.FindGameObjectsWithTag("MultiPlayer");

            foreach (var k in s)
            {
                if (k.name == NameMainPlayer)
                {

                    MainPlayer = k;

                }



            }

            if (p1.IsMine)
            {
                //gameObject.tag = "LocalPlayer";
                //UserIdMain = p1.Controller.UserId;
                //character.SetActive(false);
                //transform.parent=MainPlayer.transform;
            }
            else
            {
                // transform.parent=MainPlayer.transform.parent;
                //character.SetActive(true);
            }
            if (p1.IsMine)
            {


                //character.SetActive(false);
            }
            else
            {


                //character.SetActive(true);
            }
        }
        }
        
        // Update is called once per frame
        void Update()
    {
if(SceneManager.GetActiveScene().buildIndex!=2){

Destroy(this.gameObject);


            }
           
        }
    
}
