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
      
        if (gameObject.name != NameMainPlayer)
        {
            Name.text = gameObject.name;
            name2.text = gameObject.name;
           

          

           
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
