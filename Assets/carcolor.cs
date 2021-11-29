using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carcolor : MonoBehaviour
{
    public Material m1;
    // Start is called before the first frame update
    void Start()
    {
        ColorGray();


    }
    public void ColorRed()
    {

        m1.color = Color.red;
    }
    public void ColorGray()
    {

        m1.color = Color.gray;
    }
    public void ColorBlack()
    {

        m1.color = Color.black;
    }
    public void ColorBlue()
    {

        m1.color = Color.blue;
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
