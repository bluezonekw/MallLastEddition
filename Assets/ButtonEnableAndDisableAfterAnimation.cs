using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEnableAndDisableAfterAnimation : MonoBehaviour
{
    public Button[] buttons;
    public void EnableBtn(int index)
    {
        buttons[index].interactable = true;
    }
 
}
