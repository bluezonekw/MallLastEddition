using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Photon.Voice.PUN
{
public class voiceManger : MonoBehaviour
{
    public PhotonVoiceNetwork vv;
    // Start is called before the first frame update
    void Start()
    {
        vv.ConnectAndJoinRoom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
}