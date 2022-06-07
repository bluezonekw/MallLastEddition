using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class assignspritetomatrialDoors : MonoBehaviour,ILoadImage
{
   public Material DefaultMat;
  
private Material LocalMat;


    public IEnumerator DownloadMatrial()
    {

        GetComponent<MeshRenderer>().materials[0] = new Material(DefaultMat.shader);
        LocalMat = GetComponent<MeshRenderer>().materials[0];

        if (File.Exists(Application.persistentDataPath + "/Door/" + gameObject.name+ ".png"))
       
        {
            try
            {
                byte[] byteArray = File.ReadAllBytes(Application.persistentDataPath + "/Door/" + gameObject.name + ".png");
               
                Texture2D texture = new Texture2D(1, 1);

                texture.LoadImage(byteArray);
                texture.SetPixels(texture.GetPixels(0, 0, texture.width, texture.height));
                texture.Apply();
                LocalMat.SetTexture("_BaseMap", texture);
                texture = null;
            }
            catch
            {

            }
        }
        else
        {
            
          
        }
        yield return 0;
    }

    public IEnumerator DownloadRawImage()
    {
        yield return 0;
    }

 




    



  
 





}
