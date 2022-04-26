using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VoiceNote : MonoBehaviour
{
    public AudioSource audioSource;
    public Button Button;
public AudioClip clip;
    public void PLayAudio(){
audioSource.clip=clip;
audioSource.Play();


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
