using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAllBehavior : MonoBehaviour
{
    MonoBehaviour[] comps;
    // Start is called before the first frame update
    void Start()
    {
      comps = GetComponentsInChildren<MonoBehaviour>();

        foreach (MonoBehaviour c in comps)
        {
            c.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
      /*  foreach (MonoBehaviour c in comps)
        {
            c.enabled = true;
        }*/
    }
}
