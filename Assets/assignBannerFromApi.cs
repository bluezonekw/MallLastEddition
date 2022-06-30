using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;

public class assignBannerFromApi : MonoBehaviour
{
    
 





  

  public  IEnumerator DownloadRawImage()
    {
        foreach (Transform child in transform)
        {
            if (File.Exists(Path.Combine(Application.persistentDataPath + "/Door/" + int.Parse(child.gameObject.name).ToString() + ".png")))
            {
                
                
                try
                {
                    byte[] byteArray = File.ReadAllBytes(Path.Combine(Application.persistentDataPath + "/Door/" + int.Parse(child.gameObject.name).ToString() + ".png"));


                    Texture2D texture = new Texture2D(1, 1);
                    texture.SetPixels(texture.GetPixels(0, 0, texture.width, texture.height));
                    texture.Apply();
                    texture.LoadImage(byteArray);
                    child.gameObject.GetComponent<RawImage>().texture = texture;
                    texture = null;
                }
                catch
                {

                }
            }
        }
          
            yield return 0;
        
    }

}
