using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VisitorLogin : MonoBehaviour
{
    public ArabicText loginText;
    public static bool logout;
    // Start is called before the first frame update
    public void closeMenue(){
Destroy(this.gameObject);



    }
    void Start()
    {
        if (UPDownMenu.LanguageValue == 1)
            {
            loginText.Text="Login";


            }
            else
    {
loginText.Text="تسجيل الدخول";
    }
    }
public void Login(){
logout=true;
SceneManager.LoadScene("UI");



}
    // Update is called once per frame
    void Update()
    {
        
    }
}
