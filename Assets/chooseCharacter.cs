using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chooseCharacter : MonoBehaviour
{
    public GameObject  Male1, Male2, Male3, Female,allScene,ChooseScene;
    public GameObject Message;
    public Avatar MaleAvatar1, MaleAvatar2, MaleAvatar3, FemaleAvater;
    public Animator a1;
    public static bool isChooseChar;
    // Start is called before the first frame update
    void Start()
    {
        if(ApiClasses.Vistor){

chooseMale3();

        }
    }
    public void chooseMale1()
    {

        Male1.SetActive(true);
        a1.avatar = MaleAvatar1;
        ChooseScene.SetActive(false);
        allScene.SetActive(true);
        Message.SetActive(true);
        isChooseChar = true;

    }

    public void chooseMale2()
    {

        Male2.SetActive(true);
        a1.avatar = MaleAvatar2;
        ChooseScene.SetActive(false);
        allScene.SetActive(true);
        Message.SetActive(true);
        isChooseChar = true;
    }
    public void chooseMale3()
    {

        Male3.SetActive(true);
        a1.avatar = MaleAvatar3;
        ChooseScene.SetActive(false);
        allScene.SetActive(true);
        Message.SetActive(true);
        isChooseChar = true;
    }

    private void Awake()
{
    if(UPDownMenu.Login)
    {
      
        if (ApiClasses.Login.data.original.user.gander == 1)
        {
                
            Female.SetActive(true);
            a1.avatar = FemaleAvater;
                ChooseScene.SetActive(false);
                allScene.SetActive(true);
                Message.SetActive(true);
                isChooseChar = true;
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
                    Message.SetActive(true);
                    isChooseChar = true;
                }
            }
        catch
        {
          
        }
    }
}

// Update is called once per frame
void Update()
    {
        
    }
}
