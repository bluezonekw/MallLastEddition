using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class changeTextureForMaterial : MonoBehaviour
{
public List<Texture> A;
public Material DefaultMat; 
public AudioSource a1;
int x=0;
    // Start is called before the first frame update
    void Start()
    {
     DefaultMat.SetTexture("_MainTex",A[x]);   
    }
public void AddChangePhoto(){

try{
x++;
 DefaultMat.SetTexture("_MainTex",A[x]);   
}
catch{
x--;
}

}
public void changeaudio(){
a1.enabled=!a1.enabled;
}
public void BackChangePhoto(){

try{
x--;
 DefaultMat.SetTexture("_MainTex",A[x]);   
}
catch{
x++;
}

}

    // Update is called once per frame
    void Update()
    {
        
    }
}
