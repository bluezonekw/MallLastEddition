using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class opencamera : MonoBehaviour
{
    public RawImage RI;
    public WebCamTexture webcamTexture;
    // Start is called before the first frame update
    void Start()
    {
          webcamTexture = new WebCamTexture();
       
       RI.texture = webcamTexture;
       webcamTexture.Play();
    }
/// <summary>
/// This function is called when the object becomes enabled and active.
/// </summary>
void OnEnable()
{
     webcamTexture.Play();
}

/// <summary>
/// This function is called when the behaviour becomes disabled or inactive.
/// </summary>
void OnDisable()
{
     webcamTexture.Stop();
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
