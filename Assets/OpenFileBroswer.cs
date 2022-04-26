using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
public class OpenFileBroswer :  MonoBehaviour
{
public string path;


/*
public void OpenFileExplorer(){

   Texture2D texture = Selection.activeObject as Texture2D;
     if (texture == null)
        {
            EditorUtility.DisplayDialog("Select Texture", "You must select a texture first!", "OK");
            return;
        }

   path = EditorUtility.OpenFilePanel("Overwrite with png", "", "png,Jpg");
        if (path.Length != 0)
        {
            var fileContent = File.ReadAllBytes(path);
            texture.LoadImage(fileContent);
        }


}
*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
