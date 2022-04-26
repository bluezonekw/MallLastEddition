using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animateescalator : MonoBehaviour
{
       
    public List<Transform> Childs;
    public int y;
    public Transform start,end;
    public Animation anim ;
    public int startv,endv;
    public bool isstartanimation=true;
    // Start is called before the first frame update
    void Start()
    {
           anim = this.gameObject.AddComponent<Animation>();
        AnimationCurve curve;

        // create a new AnimationClip
        AnimationClip clip = new AnimationClip();
        clip.legacy = true;
        y =int.Parse(gameObject.name.ToString());
         Keyframe[] keys;

 keys = new Keyframe[Childs.Count+1];



         for(int i =0;i<Childs.Count;i++){

if(y==Childs.Count){
        y=0;
}
if(Childs[y]==start)
{
        startv=i;
}
else 
if(Childs[y]==end)
{
        endv=i;
}
 keys[i]=new Keyframe(0.0f+( i), Childs[y].localPosition.x);
 y++;
         }
         if(y!=Childs.Count){
                 keys[Childs.Count]=new Keyframe(0.0f+( Childs.Count+1), Childs[y].localPosition.x);
         }else{

                  keys[Childs.Count]=new Keyframe(0.0f+( Childs.Count+1), Childs[0].localPosition.x);
         }
          y =int.Parse(gameObject.name.ToString());
curve = new AnimationCurve(keys);
clip.SetCurve("", typeof(Transform), "m_LocalPosition.x", curve);
AnimationEvent a1=new AnimationEvent();
a1.time=startv;
a1.functionName="StartAnimation0";
clip.AddEvent(a1);
AnimationEvent a2=new AnimationEvent();
a2.time=endv;
a2.functionName="StartAnimation1";
clip.AddEvent(a2);

        for(int i =0;i<Childs.Count;i++){
if(y==Childs.Count){
        y=0;
}
 keys[i]=new Keyframe(0.0f+( i), Childs[y].localPosition.y);
 y++;
         }

          if(y!=Childs.Count){
                 keys[Childs.Count]=new Keyframe(0.0f+( Childs.Count+1), Childs[y].localPosition.y);
         }else{

                  keys[Childs.Count]=new Keyframe(0.0f+( Childs.Count+1), Childs[0].localPosition.y);
         }
          y =int.Parse(gameObject.name.ToString());


         curve = new AnimationCurve(keys);
clip.SetCurve("", typeof(Transform), "m_LocalPosition.y", curve);



 for(int i =0;i<Childs.Count;i++){
if(y==Childs.Count){
        y=0;
}
 keys[i]=new Keyframe(0.0f+( i), Childs[y].localPosition.z);
 y++;
         }
   if(y!=Childs.Count){
                 keys[Childs.Count]=new Keyframe(0.0f+( Childs.Count+1), Childs[y].localPosition.z);
         }else{

                  keys[Childs.Count]=new Keyframe(0.0f+( Childs.Count+1), Childs[0].localPosition.z);
         }
         curve = new AnimationCurve(keys);
clip.SetCurve("", typeof(Transform), "m_LocalPosition.z", curve);



         /*
for(int i =0;i<Childs.Count;i++){
       

y=i+1;
if(y==Childs.Count){

    y=0;
}

        keys = new Keyframe[2];
        keys[0] = new Keyframe(0.0f+(3*i), Childs[i].localPosition.x);
        
        keys[1] = new Keyframe(3.0f+(3*i),Childs[y].localPosition.x);
       
        curve = new AnimationCurve(keys);

        clip.SetCurve("", typeof(Transform), "m_LocalPosition.x", curve);

 keys[0] = new Keyframe(0.0f+(3*i), Childs[i].localPosition.y);
        
        keys[1] = new Keyframe(3.0f+(3*i),Childs[y].localPosition.y);
       
        curve = new AnimationCurve(keys);

        clip.SetCurve("", typeof(Transform), "m_LocalPosition.y", curve);

 keys[0] = new Keyframe(0.0f+(3*i), Childs[i].localPosition.z);
        
        keys[1] = new Keyframe(3.0f+(3*i),Childs[y].localPosition.z);
       
        curve = new AnimationCurve(keys);

        clip.SetCurve("", typeof(Transform), "m_LocalPosition.z", curve);
 keys[0] = new Keyframe(0.0f+(3*i), Childs[i].localRotation.x);
        
        keys[1] = new Keyframe(3.0f+(3*i),Childs[y].localRotation.x);
       
        curve = new AnimationCurve(keys);

       
        clip.SetCurve("", typeof(Transform), "m_LocalRotation.x", curve);

keys[0] = new Keyframe(0.0f+(3*i), Childs[i].localRotation.y);
        
        keys[1] = new Keyframe(3.0f+(3*i),Childs[y].localRotation.y);
       
        curve = new AnimationCurve(keys);

        clip.SetCurve("", typeof(Transform), "m_LocalRotation.y", curve);

keys[0] = new Keyframe(0.0f+(3*i), Childs[i].localRotation.z);
        
        keys[1] = new Keyframe(3.0f+(3*i),Childs[y].localRotation.z);
        curve = new AnimationCurve(keys);

        clip.SetCurve("", typeof(Transform), "m_LocalRotation.z", curve); 

keys[0] = new Keyframe(0.0f+(3*i), Childs[i].localRotation.w);
        
        keys[1] = new Keyframe(3.0f+(3*i),Childs[y].localRotation.w);
       
        curve = new AnimationCurve(keys);

        clip.SetCurve("", typeof(Transform), "m_LocalRotation.w", curve);
clip.wrapMode=WrapMode.Loop;
  


}*/
clip.wrapMode=WrapMode.Loop;
anim.AddClip(clip,"Test");
anim.Play("Test");
        // now animate the GameObject

    }
    public void StartAnimation0(){
            isstartanimation=true;
    }
    public void StartAnimation1(){
            isstartanimation=false;
    }
void LateUpdate()
    {
          
  if( !isstartanimation){

this.GetComponent<Collider>().enabled=false;
this.GetComponent<MeshRenderer>().enabled=false;

     }
     else{


this.GetComponent<Collider>().enabled=true;
this.GetComponent<MeshRenderer>().enabled=true;


     }
    }
    // Update is called once per frame
    void Update()
    {
   
    }
    
}
