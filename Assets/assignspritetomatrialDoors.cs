using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class assignspritetomatrialDoors : MonoBehaviour
{
   public Material DefaultMat;
  
private Material LocalMat;


    public IEnumerator DownloadMatrial()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<MeshRenderer>().materials[0] = new Material(DefaultMat.shader);
            LocalMat = child.GetComponent<MeshRenderer>().materials[0];

            if (File.Exists(Application.persistentDataPath + "/Banner/" + child.gameObject.name + ".png"))

            {
                try
                {
                    byte[] byteArray = File.ReadAllBytes(Application.persistentDataPath + "/Banner/" + child.gameObject.name + ".png");

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
        }
        yield return 0;
    }



 




    



  
 





}
