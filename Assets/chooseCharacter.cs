using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NativeFilePickerNamespace;
using UnityEngine.UI;

public class chooseCharacter : MonoBehaviour
{
    
    
    public NetworkManager n1;
    public GameObject  allScene,ChooseScene;
 
 

    public static bool isChooseChar;

     public GameObject cameranimation;
    public int characterid;
  
    public bool isFemale;


    public GameObject FemaleModel, MaleModel;

     void Awake()
    {
        if (!ApiClasses.Vistor)
        {
            if (ApiClasses.Login.data.original.user.gander == 1 || ApiClasses.Register.data.user.gander == "1")
            {

                isFemale = true;
                FemaleModel.SetActive(true);
            }else
            {
                MaleModel.SetActive(true);
            }
        }


    }
    void Start()
    {
        
        if (ApiClasses.Vistor)
        {

            choosecharacter(1);
          
        }
        else
        {


            cameranimation.GetComponent<Animation>().Play();



           

        }
    }
  
   

 
  





   
  public void choosecharacter(int id)
    {
        if (isFemale)
        {
  characterid = id+3;
        }
        else
        {
            characterid = id ;
        }
       
     
      
        n1.play(characterid);
        allScene.SetActive(true);
        //CameraPostion.transform.localPosition = new Vector3(-0.05f, 1.375f, 0);
        Destroy(ChooseScene);
    }
// Update is called once per frame
void Update()
    {
        
    }
}
