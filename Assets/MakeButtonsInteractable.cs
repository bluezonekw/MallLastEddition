using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeButtonsInteractable : MonoBehaviour
{
    public Button[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        buttons = GetComponentsInChildren<Button>();
        foreach (Button b in buttons)
        {
            b.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckEnterShop.EnterShop)
        {
            foreach(Button b in buttons)
            {
                b.interactable = true;
            }
        }
        else
        {


            foreach (Button b in buttons)
            {
                b.interactable = false;
            }
        }
        
    }
}
