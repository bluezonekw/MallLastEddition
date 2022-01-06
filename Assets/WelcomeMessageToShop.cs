using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WelcomeMessageToShop : MonoBehaviour
{
public RawImage ShopLogo;
public ArabicText ShopName;
public Sprite ARImage,EnImage;

    // Start is called before the first frame update
    void Start()
    {
          if (UPDownMenu.LanguageValue == 1)
        {
GetComponent<Image>().sprite=EnImage;           

        }
        else
        {

GetComponent<Image>().sprite=ARImage;            

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

public void DestroyMyObject(){

Destroy(gameObject);


}
}
