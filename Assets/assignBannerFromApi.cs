using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;

public class assignBannerFromApi : MonoBehaviour
{


    private void Awake()
    {
    }



 

  public   void deleteallbanners()
    {
        foreach (Transform child in this.GetComponentsInChildren<Transform>(true))
        {
            try
            {


                child.gameObject.GetComponent<RawImage>().texture = null;
            }
            catch
            {

            }


        }

        }

  
    public Texture2D textures;
    public byte[] byteArray;
    public  IEnumerator DownloadRawImage()
    {
        foreach (RawImage child in GetComponentsInChildren<RawImage>(true))
        {
            
      
            try {
              

                if (File.Exists(Path.Combine(Application.persistentDataPath + "/Door/" + int.Parse(child.gameObject.name).ToString() + ".png")))
                {


                    try
                    {
                        byteArray = File.ReadAllBytes(Path.Combine(Application.persistentDataPath + "/Door/" + int.Parse(child.gameObject.name).ToString() + ".png"));



                        textures = new Texture2D(1, 1);
                        textures.SetPixels(textures.GetPixels(0, 0, textures.width, textures.height));
                        textures.Apply();

                        textures.LoadImage(byteArray);
                    
                        child.texture = textures;
                        print(Path.Combine(Application.persistentDataPath + "/Door/" + int.Parse(child.gameObject.name).ToString() + ".png"));
                     
                    }
                    catch (Exception ex)
                    {
                        print(ex.Message);
                    }


                }
            }
            catch
            {

            }
            
            }
        textures = new Texture2D(1, 1);
        textures.SetPixels(textures.GetPixels(0, 0, textures.width, textures.height));
        textures.Apply();
        byteArray = null;
        yield return 0;
        
    }

}
