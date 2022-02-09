using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GetData : MonoBehaviour
{
    public InputField EmailI, PhoneI;
    public Text NameI, AdressI;
    public UnityEngine.UI.Toggle Male, Female;
    public string Adress()
    {

        if(!UPDownMenu.Login)
        {
            return ApiClasses.Register.data.user.address;
        }
        else
        {
            return ApiClasses.Login.data.original.user.address;

        }


    }
    public void Gender()
    {

        if(!UPDownMenu.Login)
        {
            if (ApiClasses.Register.data.user.gander =="0")
            {
                Male.isOn = true;

            }
            if (ApiClasses.Register.data.user.gander == "1")
            {
                Female.isOn = true;
            }
        }
        else
        {

            if (ApiClasses.Login.data.original.user.gander == 0)
            {
                Male.isOn = true;
              

            }
            if (ApiClasses.Login.data.original.user.gander == 1)
            {
                Female.isOn = true;
              
            }

        }

    }
    public string UserName()
    {
       if(!UPDownMenu.Login)
        {
            return ApiClasses.Register.data.user.name;
        }
        else
        {
            return ApiClasses.Login.data.original.user.name;

        }
    }
    public string Email()
    {
        if(!UPDownMenu.Login)
        {
            return ApiClasses.Register.data.user.email;
        }
        else
        {
            return ApiClasses.Login.data.original.user.email;
        }
    }
    public string Phone()
    {

        if(!UPDownMenu.Login)
        {
            return ApiClasses.Register.data.user.phone;
        }
        else
        {
            return ApiClasses.Login.data.original.user.phone;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        NameI.GetComponent<ArabicText>().Text =  UserName();
        EmailI.text = Email();
        PhoneI.text = Phone();
        AdressI.text = Adress();
    }
    private void Awake()
    {
        Gender();




    }
    // Update is called once per frame
    void Update()
    {
    }
}
