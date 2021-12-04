using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutofillPayment : MonoBehaviour
{
    public bool autofill;
    public InputField NameField, EmailField, PhoneField;
    public InputField City, square, street, apartment, discount, Notes;

    public ArabicText Price,totalprice;


    // Start is called before the first frame update
    void Start()
    {
        if (autofill)
        {
            NameField.text = Name();
            EmailField.text = Email();
            PhoneField.text = Phone();


        }
        Price.Text = CartInfo.price.ToString();
        totalprice.Text = (CartInfo.price + 50).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void destoryPayment()
    {

        GameObject.Destroy(this.gameObject);
        CartInfo.Cartvisible = true;
    }

    public string AuthToken()
    {

        try
        {
            return ApiClasses.Register.data.token;
        }
        catch

        {

            return ApiClasses.Login.data.original.access_token;

        }


    }

    public string Email()
    {

        try
        {
            return ApiClasses.Register.data.user.email;
        }
        catch

        {

            return ApiClasses.Login.data.original.user.email;

        }


    }


    public string Name()
    {

        try
        {
            return ApiClasses.Register.data.user.name;
        }
        catch

        {

            return ApiClasses.Login.data.original.user.name;

        }


    }


    public string Phone()
    {

        try
        {
            return ApiClasses.Register.data.user.phone;
        }
        catch

        {

            return ApiClasses.Login.data.original.user.phone;

        }


    }


}
