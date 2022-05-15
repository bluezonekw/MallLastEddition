using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoothProductSlidder : MonoBehaviour
{
    public RectTransform ProductsPanel;
    public float Min=0,Max,Ypos=0,Xpos;

    // Start is called before the first frame update
    void Start()
    {
        
Xpos=ProductsPanel.anchoredPosition.x;
       StartCoroutine(Animate());
      
    }
public void Up(){
Max=ProductsPanel.transform.childCount-7;
Max*=0.4f;
if(Ypos<Max){

Ypos+=0.4f;
ProductsPanel.anchoredPosition=new Vector2(Xpos,Ypos);

}



}

IEnumerator Animate(){
for(int x=0;x<40;x++){
    yield return new WaitForSeconds(3);
    Up();
}
}
public void Down(){

if(Ypos>Min){

Ypos-=0.4f;
ProductsPanel.anchoredPosition=new Vector2(Xpos,Ypos);

}



}
    // Update is called once per frame
    void Update()
    {
        
    }
}
