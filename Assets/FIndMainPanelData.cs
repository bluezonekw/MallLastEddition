using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIndMainPanelData : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void trycalc()
    {

        GameObject g = GameObject.FindGameObjectWithTag("MainDetailsPanl");
        try
        {
           g.GetComponent<GetDetailsProduct>().Calculate();
        }
        catch
        {
            print(g.name);


        }
    }
}
