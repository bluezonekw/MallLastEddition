using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class CartPopUp : MonoBehaviour
    {
        public GameObject PopExitShop;
        public UIVirtualJoystick sai;
    // Start is called before the first frame update
    void Start()
    {
        PopExitShop.SetActive(false);

    }
    public void ResetMove()
        {
          sai.magnitudeMultiplier=1;
        }
        public void DestroyPop()
        {
            PopExitShop.SetActive(false);
        }
        // Update is called once per frame
        void Update()
        {
            if (CheckEnterShop.ExitShop)
            {
                PopExitShop.SetActive(true);
               sai.magnitudeMultiplier=0;

                CheckEnterShop.ExitShop = false;
            }

        }
    }
