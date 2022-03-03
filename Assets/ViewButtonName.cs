using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ViewButtonName : MonoBehaviour
{
    private Text t1;
    // Start is called before the first frame update
    void Start()
    {
        try{
        t1=this.transform.GetChild(0).GetComponent<Text>();
        }
        catch{

        }
    }

    // Update is called once per frame
    void Update()
    {
        try{
         if (UPDownMenu.LanguageValue == 1)
            {
                t1.text="View";
            }
            else{
t1.text="ﺽﺮﻋ";
            }
    }
    catch{



    }
    }
    
}
