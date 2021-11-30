using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StarterAssets
{
    public class UICanvasForPartsOfMall : UICanvasControllerInput 
    {
        public static StarterAssetsInputs uicanvas;
        // Start is called before the first frame update
        void Start()
        {
            try
            {

                uicanvas = GameObject.FindWithTag("Player").GetComponent<StarterAssetsInputs>();

                starterAssetsInputs = uicanvas;
            }
            catch
            {
            }

        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}