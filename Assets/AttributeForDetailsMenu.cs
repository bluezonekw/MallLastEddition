using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttributeForDetailsMenu : MonoBehaviour
{
    public Transform OptionsPanel;
    public int numberofOptions;
    public float max, min;
    public float valueofx;
    public bool isMoreSelect;
    public ToggleGroup parentToggle;
    public ArabicText AttributeName;

    // Start is called before the first frame update
    void Start()
    {
    foreach(Transform child in OptionsPanel)
        {
            if (!isMoreSelect)
            {
                child.GetComponent<Toggle>().group=parentToggle;
            }

        }

        valueofx = -3.5f;

        if (numberofOptions <= 3)
        {
            max = -3.5f;
            min= -3.5f;
        }
        else if(numberofOptions > 3)
        {
            min=-3.5f; 
            max= -3.5f+numberofOptions-3;

        }
    }
    public void RightPanel()
    {
        if (valueofx > min && valueofx<=max)
        {        valueofx -= 1;

            OptionsPanel.localPosition = new Vector3(valueofx, 0, 0);
        }
     



    }

    public void LeftPanel()
    {
       

        if (valueofx >= min && valueofx < max)
        { valueofx += 1;
            OptionsPanel.localPosition = new Vector3(valueofx, 0, 0);
        }
      



    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
