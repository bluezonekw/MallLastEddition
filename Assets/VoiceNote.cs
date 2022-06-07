using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VoiceNote : MonoBehaviour
{
    public Sprite Play,Pause;
     public Slider audioSlider;
    public AudioSource audioSource;
    public Image Button;
public AudioClip clip;
    public void PLayAudio(){


if(audioSource.time==0||audioSource.time==clip.length){
         audioSlider.direction = Slider.Direction.LeftToRight;
         audioSlider.minValue = 0;
         audioSlider.maxValue = clip.length;


}
if(audioSource.clip!=clip){
audioSource.clip=clip;
}
Button.sprite=Pause;
audioSource.Play();

    }
     public void pauseAudio(){

       Button.sprite=Play;
audioSource.Pause();


    }
    public void PlayPause(){
print("PLayPause");
if(Button.sprite==Play){

PLayAudio();

}else{
pauseAudio();

}



    }
    // Start is called before the first frame update
    void Start()
    {
      audioSlider.direction = Slider.Direction.LeftToRight;
         audioSlider.minValue = 0;
         audioSlider.maxValue = clip.length;
        Button.sprite=Play;
         audioSlider.value=0;
    }

    // Update is called once per frame
    void Update()
    {
      
        if(audioSource.clip==clip){
           audioSlider.value = audioSource.time;

        }
        else
        {
            Button.sprite = Play;
            audioSlider.value = 0;

        }
       
            if (audioSlider.value == audioSlider.maxValue)
            {
                pauseAudio();
            }
      
    }
}
