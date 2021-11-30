using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.UI.Extensions
{
    public class NextscreenPlay : MonoBehaviour
    {
        bool Paused;
        // Start is called before the first frame update
        void Start()
        {
        }
        public void PuseItem()
        {
            Paused = !Paused;
        }
        // Update is called once per frame
        void Update()
        {
           
        }
       
    }
}
