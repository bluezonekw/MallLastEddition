using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NativeFilePickerNamespace;
using UnityEngine.UI;

public class chooseCharacter : MonoBehaviour
{
    
    
    public NetworkManager n1;
    public GameObject  Male1, Male2, Male3, Female,allScene,ChooseScene;
 
    public Avatar MaleAvatar1, MaleAvatar2, MaleAvatar3, FemaleAvater;
    public Animator a1;
    public GameObject CameraPostion;
    public static bool isChooseChar;
    public GameObject Playerobject;
     public GameObject cameranimation;
     
    //public NetworkManager n1; 
    // Start is called before the first frame update
    void Start()
    {
        
        if (ApiClasses.Vistor)
        {

            chooseMale3();

        }
        else
        {





            if (UPDownMenu.Login)
            {

                if (ApiClasses.Login.data.original.user.gander == 1)
                {

                    Female.SetActive(true);
                    a1.avatar = FemaleAvater;
                    ChooseScene.SetActive(false);
                    allScene.SetActive(true);
                  
                    isChooseChar = true;
                    n1.play();
                    CameraPostion.transform.localPosition = new Vector3(-0.05f, 1.375f, 0);
                    Playerobject.SetActive(true);
                }
                else
                {
                    cameranimation.GetComponent<Animation>().Play();

                }
            }
            else
            {
                try
                {

                    if (ApiClasses.Register.data.user.gander == "1")
                    {

                        Female.SetActive(true);
                        a1.avatar = FemaleAvater;
                        ChooseScene.SetActive(false);
                        allScene.SetActive(true);
                      
                        isChooseChar = true;
                        n1.play();
                        CameraPostion.transform.localPosition = new Vector3(-0.05f, 1.375f, 0);
                        Playerobject.SetActive(true);
                    }
                    else
                    {
                        cameranimation.GetComponent<Animation>().Play();

                    }
                }
                catch
                {

                }
            }





        }
    }
  
    public void chooseMale1()
    {

        Male1.SetActive(true);
        a1.avatar = MaleAvatar1;
        ChooseScene.SetActive(false);
        allScene.SetActive(true);

        isChooseChar = true;
n1.play();

CameraPostion.transform.localPosition=new Vector3 (-0.05f,1.375f,0);
Playerobject.SetActive(true);
    }

    public void chooseMale2()
    {

        Male2.SetActive(true);
        a1.avatar = MaleAvatar2;
        ChooseScene.SetActive(false);
        allScene.SetActive(true);

        isChooseChar = true;
       n1.play();
       CameraPostion.transform.localPosition=new Vector3 (-0.05f,1.375f,0);
       Playerobject.SetActive(true);
    }
    public void chooseMale3()
    {

        Male3.SetActive(true);
        a1.avatar = MaleAvatar3;
        ChooseScene.SetActive(false);
        allScene.SetActive(true);

        isChooseChar = true;
        if(!ApiClasses.Vistor){
       n1.play();
       
        }
        CameraPostion.transform.localPosition=new Vector3 (-0.05f,1.375f,0);
        Playerobject.SetActive(true);
    }

   

// Update is called once per frame
void Update()
    {
        
    }
}
