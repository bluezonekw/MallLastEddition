using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Serialization;
using System;

public class NewButton : Button
{
    public bool IsDownclick;

























  public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        Debug.Log("Down");
        //show text
       IsDownclick=true;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        Debug.Log("Up");
        //hide text
       IsDownclick=false;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
