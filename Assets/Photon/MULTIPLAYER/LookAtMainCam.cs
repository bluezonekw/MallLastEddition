using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMainCam : MonoBehaviour
{

    Transform myTrans;
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = Camera.main.transform;
        myTrans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myTrans.LookAt(target);
    }
}
