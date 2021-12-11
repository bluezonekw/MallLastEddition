using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch_CT : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
			SceneManager.LoadScene("Demo 1 Structure 1");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
			SceneManager.LoadScene("Demo 2 Structure 2");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
			SceneManager.LoadScene("Demo 3 Structure 3");
        }

		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			SceneManager.LoadScene("Demo 4 Structure 4");
		}

		if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			SceneManager.LoadScene("Demo 5 Structure 5");
		}

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SceneManager.LoadScene("Demo 6 Structure 6");
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SceneManager.LoadScene("Props Furniture and Textures Demo");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
