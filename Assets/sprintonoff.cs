using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StarterAssets
{
    public class sprintonoff : MonoBehaviour
    {
        public UICanvasControllerInput input;
        public bool Pressed;
        // Start is called before the first frame update
        void Start()
        {

        }
        public void sprint()
        {
            Pressed = !Pressed;
        }
        // Update is called once per frame
        void Update()
        {
            if (Pressed)
            {
                input.VirtualSprintInput(true);
                GetComponent<Button>().image.color = Color.gray;

            }
            else
            {
                input.VirtualSprintInput(false);
                GetComponent<Button>().image.color = Color.white;
            }
        }
    }
}
