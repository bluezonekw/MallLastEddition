using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
public class RcordVoice :MonoBehaviour
{ 
public NewButton b;
    public Microphone M;
    public AudioSource A;
   private float startRecordingTime;
    public string devicename;
 AudioClip recording;

public string ArrayOfFloatToString(float [] data){

string aa = string.Join("$", data);
return aa;

}
    public float[] stringtoarrayoffloat(string Audiostring){
 string[] s=Audiostring.Split('$');
         List<float> test=new List<float>();
     foreach(var number in s){
test.Add(float.Parse( number));



     }

     return test.ToArray();
    }


    // Start is called before the first frame update
    void Start()
    {
    
     
    }
public void StartRecord(){
      foreach (var device in Microphone.devices)
        {
       devicename= device;
        }
if(string.IsNullOrEmpty( devicename)){

return;

}
        int minFreq;
        int maxFreq;
        int freq = 44100;
        Microphone.GetDeviceCaps(devicename, out minFreq, out maxFreq);
        if (maxFreq < 44100)
            freq = maxFreq;

        //Start the recording, the length of 300 gives it a cap of 5 minutes
        recording = Microphone.Start(devicename, false, 300, 44100);
        startRecordingTime = Time.time;


}



public void playAudio(){



     /// A.Play();
       // Debug.Log("play");

        //this.recording = recordingNew;
      

    

     
    




        //Play recording
        Microphone.End(devicename);

        Microphone.End(devicename);

        //Trim the audioclip by the length of the recording
        AudioClip recordingNew = AudioClip.Create(recording.name, (int)((Time.time - startRecordingTime) * recording.frequency), recording.channels, recording.frequency, false);
        float[] data = new float[(int)((Time.time - startRecordingTime) * recording.frequency)];
        recording.GetData(data, 0);
       recordingNew.SetData(data, 0);
    A.clip=recordingNew;
    
        A.Play();
}
bool isplay;
bool isdown;
    // Update is called once per frame
    void Update()
    {
      if(b.IsDownclick&&!isdown){
isdown=true;
isplay=false;
StartRecord();
      }

      if(!b.IsDownclick&&!isplay){

isplay=true;
isdown=false;
playAudio();
      }
    }

   
}













  
  
 
 
   






