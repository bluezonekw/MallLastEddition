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
    private void Awake()
    {
   
    }

    private Material LocalMat;

    public void restalldoor()
    {
        foreach (Transform child in GetComponentsInChildren<Transform>(true))
        {
            try
            {
                child.GetComponent<MeshRenderer>().materials[0] = null;
            }
            catch
            {

            }


        }
        
    }
    public Texture2D textures;
    public byte[] byteArray;
    public IEnumerator DownloadMatrial()
    {
        foreach (MeshRenderer child in this.GetComponentsInChildren<MeshRenderer>(true))
        {
       
            try { 
                child.materials[0] = new Material(DefaultMat.shader);
                LocalMat = child.materials[0];

                if (File.Exists(Application.persistentDataPath + "/Banner/" + child.gameObject.name + ".png"))

                {
                    try
                    {
                        byteArray = File.ReadAllBytes(Application.persistentDataPath + "/Banner/" + child.gameObject.name + ".png");


                        textures = new Texture2D(1, 1);
                        textures.LoadImage(byteArray);
                        textures.SetPixels(textures.GetPixels(0, 0, textures.width, textures.height));
                        textures.Apply();
                        LocalMat.SetTexture("_BaseMap", textures);
                       

                    }
                    catch
                    {

                    }
                }
            }
            catch
            {

            }
        }
        textures = null;
        byteArray = null;
        LocalMat = null;
        yield return 0;
    }



 




    



  
 





}
