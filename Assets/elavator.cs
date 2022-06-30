using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class elavator : MonoBehaviour
{
    Rigidbody rigidbody;
    public int Stepindex=0;
    public GameObject ParentOfsteps;
     public List<Transform> steps;
    public List<Vector3> Elavators;
         public float speed = 5f;
         public double currentindex;
         public enum typeofElavator{
             Up,Down
         }
         public typeofElavator UPOrDown;
         private double Stepper; 
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody=GetComponent<Rigidbody>();
        currentindex=double.Parse(gameObject.name);
foreach(Transform child in ParentOfsteps.transform)
 {
    Debug.Log(child.gameObject.name);
     steps.Add(child);
 }        if(UPOrDown==typeofElavator.Up){
Stepper=-1f;

        }
        else{
Stepper=1;
        }
      
        for(int x=0;x<37;x++){
 try{
   
Elavators.Add(steps[int.Parse(currentindex.ToString())].localPosition);
 }
 catch{
    
 }
if(currentindex==0&&Stepper==-1){
currentindex=36;

}else if(currentindex==36&&Stepper==1){

    currentindex=0;
}
else{
    currentindex+=Stepper;
}
        }
      StartCoroutine(move());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
try{

   
   

}
catch{
print(Elavators.Count.ToString()+"   "+gameObject.name);
}
    }
    IEnumerator wait23()
         {

  yield return new WaitForSecondsRealtime(5);

         }
       IEnumerator move()
         {
           
              WaitForSeconds waitTime = new WaitForSeconds(.5f);
    //          Vector3 newPosition;
             while(true){
 //newPosition = rigidbody.position + transform.TransformDirection (Elavators[Stepindex]);
//rigidbody.MovePosition (newPosition);


     transform.localPosition =  Elavators[Stepindex];
     if(Stepindex==36){
                 Stepindex=0;
             }else{
             Stepindex++;
             }

    Debug.Log("HaHaahhhh"+"    "+Stepindex.ToString()+"            "+ gameObject.name);
      yield return waitTime;
      }
             
           
            /* while (transform.position != pointB.position)
             {
                 Vector3.Lerp(transform.position, pointB.position, speed);
                 yield return new WaitForEndOfFrame();
             }*/
             }
}
