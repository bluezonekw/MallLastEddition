using UnityEngine;
using System.Collections;


using UnityEngine.UI;
using RTLTMPro;

public class cameraCapture : MonoBehaviour
{ 


 int currentCamIndex = 0;

   WebCamTexture tex;

    public RawImage display;

    public RTLTextMeshPro startStopText;





  public void SwapCam_Clicked()
    {
        if (WebCamTexture.devices.Length > 0)
        {
            currentCamIndex += 1;
            currentCamIndex %= WebCamTexture.devices.Length;

            // if tex is not null:
            // stop the web cam
            // start the web cam

            if (tex != null)
            {
                StopWebCam();
                StartStopCam_Clicked();
            }
        }
    }



   public void StartStopCam_Clicked()
    {
        if (tex != null) // Stop the camera
        {
            StopWebCam();
            startStopText.text = "Start Camera";
        }
        else // Start the camera
        {
            WebCamDevice device = WebCamTexture.devices[currentCamIndex];
            tex = new WebCamTexture(device.name);
            display.texture = tex;

            tex.Play();
            startStopText.text = "Stop Camera";
        }
    }

    private void StopWebCam()
    {
        display.texture = null;
        tex.Stop();
        tex = null;
    }





















      
     
    
   
    bool open;
    
     public CaptureAndSave snapShot;
    
    // Start is called before the first frame update
    void Start()
    {
     
           
    
     
        
        
    }
void OnEnable()
{
    try{
     WebCamDevice device = WebCamTexture.devices[currentCamIndex];
            tex = new WebCamTexture(device.name);
            display.texture = tex;

            tex.Play();
    }
    catch{

    }
}

/// <summary>
/// This function is called when the behaviour becomes disabled or inactive.
/// </summary>
void OnDisable()
{ try{
      StopWebCam();
}
catch{

}
}

    // Update is called once per frame
    void Update()
    {
        
    }
 

  public  void TakePicture()
    {  

        
snapShot.CaptureAndSaveToAlbum(ImageType.JPG);
 
  
        StartCoroutine( waitse());
        //snapShot.CaptureAndSaveToAlbum(ImageType.JPG);

    }
  
IEnumerator waitse(){


  tex.Stop();

    yield return new WaitForSeconds(1.5f);
//tex.Play();
}
   
}
