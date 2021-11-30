using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlidderBottomData : MonoBehaviour
{
   
   
    public float isFinishAnimation1, isFinishAnimation2;
    // Start is called before the first frame update
    void Start()
    {
        isFinishAnimation1= isFinishAnimation2 = 0;
    }
    public void checkanimation1(float finish)
    {

        isFinishAnimation1 = finish;


    }


    


   

    public void checkanimation2(float finish)
    {

        isFinishAnimation2 = finish;


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
