using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class profileIconsName : MonoBehaviour
{
public ArabicText Data,Credit,Favorite,Orders,LogOut;

public ArabicText Title,Address,Email,Mobile,Gender;
public Text  tAddress,tEmail,tMobile,tGender;

public Text  shAddress,shEmail,shMobile;

public ArabicText Male,Female;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {if (UPDownMenu.LanguageValue == 1)
        {
Data.Text="Profile";  
Credit.Text="Coins";  
Favorite.Text="Favorite";  
Orders.Text="My Orders";  
LogOut.Text="Log Out";  
Title.Text="Profile";
 Address.Text="Address";   
 Email.Text="Email";    
 Mobile.Text="Mobile";    
 Gender.Text="Gender"; 
 Male.Text="Male";
 Female.Text="Female";  

tAddress.alignment= TextAnchor.MiddleLeft;
tEmail.alignment= TextAnchor.MiddleLeft;
tMobile.alignment= TextAnchor.MiddleLeft;
tGender.alignment= TextAnchor.MiddleLeft; 



shAddress.alignment= TextAnchor.MiddleLeft;
shEmail.alignment= TextAnchor.MiddleLeft;
shMobile.alignment= TextAnchor.MiddleLeft;
  
        }
        else
        {

 Data.Text="الملف الشخصى";  
Credit.Text="الرصيد";  
Favorite.Text="المفضلة";  
Orders.Text="طلباتى";  
LogOut.Text="تسجيل الخروج";  
 Title.Text="الملف الشخصى";  


Address.Text="العنوان";   
 Email.Text="البريد الالكترونى";    
 Mobile.Text="رقم الهاتف";    
 Gender.Text="النوع";   
Male.Text="ذكر";
 Female.Text="انثى";
tAddress.alignment= TextAnchor.MiddleRight;
tEmail.alignment= TextAnchor.MiddleRight;
tMobile.alignment= TextAnchor.MiddleRight;
tGender.alignment= TextAnchor.MiddleRight; 




shAddress.alignment= TextAnchor.MiddleRight;
shEmail.alignment= TextAnchor.MiddleRight;
shMobile.alignment= TextAnchor.MiddleRight;

        }
        
    }
}
