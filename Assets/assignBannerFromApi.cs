using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;

public class assignBannerFromApi : MonoBehaviour, ILoadImage
{
    
 



    public IEnumerator DownloadMatrial()
    {
        yield return 0;
    }

  
   

  

    IEnumerator ILoadImage.DownloadRawImage()
    {
        if (File.Exists(Path.Combine(Application.persistentDataPath + "/Banner/" +int.Parse( gameObject.name).ToString()+".png")))
        {
            try
            {
                byte[] byteArray = File.ReadAllBytes(Path.Combine(Application.persistentDataPath + "/Banner/" + int.Parse(gameObject.name).ToString() + ".png"));


                Texture2D texture = new Texture2D(8, 8);
                texture.LoadImage(byteArray);
                GetComponent<RawImage>().texture = texture;
            }
            catch
            {

            }
        }
     
          
            yield return 0;
        
    }

}
