using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Threading;

public class MallLoader : MonoBehaviour
{
    
    public Transform T1;
    bool[] sceneloaded= { false, false, false, false, false, false, false, false, false, false,false} ;

public GameObject s1,s2,s3,s4,s5,s6,s7,s8,s9,s10;
    // Start is called before the first frame update
    void Start()
    {
       


       
    }
IEnumerator LoadNewScene(string x)
    {
        
        SceneManager.LoadSceneAsync(x, LoadSceneMode.Additive);
       yield return null;
       
    }



IEnumerator UnLoadNewScene(string x)
    {
SceneManager.UnloadSceneAsync(x);
        yield return null;

    }
    // Update is called once per frame
    void Update()
    {

        if (T1.position.z < 10 )
        {
            try
            {
//StartCoroutine(UnLoadNewScene("03"));

                SceneManager.UnloadSceneAsync("03");

		//Destroy(GameObject.FindGameObjectWithTag("03"));
                sceneloaded[03] = false;
            }
            catch
            {

            }
            if (!sceneloaded[01])
            {
//StartCoroutine(LoadNewScene("01"));
                SceneManager.LoadSceneAsync("01", LoadSceneMode.Additive);

		//	GameObject.Instantiate(s1);

                sceneloaded[01] = true;
            }
            if (!sceneloaded[02])
            {
//StartCoroutine(LoadNewScene("02"));
                SceneManager.LoadSceneAsync("02", LoadSceneMode.Additive);
		//	GameObject.Instantiate(s2);
                sceneloaded[02] = true;

            }
        }
        else
        if (T1.position.z > 10 && T1.position.z < 90)
        {
            try
            {
            //    StartCoroutine(UnLoadNewScene("01"));
SceneManager.UnloadSceneAsync("01");

	//	Destroy(GameObject.FindGameObjectWithTag("01"));
                sceneloaded[01] = false;


            }
            catch
            {

            }

            try
            {
//StartCoroutine(UnLoadNewScene("04"));
                SceneManager.UnloadSceneAsync("04");
		//Destroy(GameObject.FindGameObjectWithTag("04"));
                sceneloaded[04] = false;

            }
            catch
            {

            }

            if (!sceneloaded[03])
            {
//StartCoroutine(LoadNewScene("03"));
                SceneManager.LoadSceneAsync("03", LoadSceneMode.Additive);
		//GameObject.Instantiate(s3);
                sceneloaded[03] = true;


            }
            if (!sceneloaded[02])
            {

//StartCoroutine(LoadNewScene("02"));
                SceneManager.LoadSceneAsync("02", LoadSceneMode.Additive);
		//GameObject.Instantiate(s2);
                sceneloaded[02] = true;

            }
        }
        else
            if (T1.position.z > 90 && T1.position.z < 170 )
        {
            try
            {
               // StartCoroutine(UnLoadNewScene("02"));
SceneManager.UnloadSceneAsync("02");
		//Destroy(GameObject.FindGameObjectWithTag("02"));
                sceneloaded[02] = false;

            }
            catch
            {

            }

            try
            {
            //StartCoroutine(UnLoadNewScene("05"));
    SceneManager.UnloadSceneAsync("05");
		//Destroy(GameObject.FindGameObjectWithTag("05"));
                sceneloaded[05] = false;

            }
            catch
            {

            }
            if (!sceneloaded[04])
            {

//StartCoroutine(LoadNewScene("04"));
                SceneManager.LoadSceneAsync("04", LoadSceneMode.Additive);
		//GameObject.Instantiate(s4);
                sceneloaded[04] = true;

            }
            if (!sceneloaded[03])
            {

//StartCoroutine(LoadNewScene("03"));
                SceneManager.LoadSceneAsync("03", LoadSceneMode.Additive);
		//GameObject.Instantiate(s3);
                sceneloaded[03] = true;

            }
        }


        else
            if (T1.position.z > 170 && T1.position.z < 250 )
        {
            try
            {
//StartCoroutine(UnLoadNewScene("03"));             
   SceneManager.UnloadSceneAsync("03");
		//Destroy(GameObject.FindGameObjectWithTag("03"));
                sceneloaded[03] = false;

            }
            catch
            {

            }

            try
            {
          //     StartCoroutine(UnLoadNewScene("06"));
 SceneManager.UnloadSceneAsync("06");
		//	Destroy(GameObject.FindGameObjectWithTag("06"));
                sceneloaded[06] = false;

            }
            catch
            {

            }

            if (!sceneloaded[05])
            {
//StartCoroutine(LoadNewScene("05"));
                SceneManager.LoadSceneAsync("05", LoadSceneMode.Additive);
//GameObject.Instantiate(s5);

                sceneloaded[05] = true;

            }
            if (!sceneloaded[04])
            {

//StartCoroutine(LoadNewScene("04"));
                SceneManager.LoadSceneAsync("04", LoadSceneMode.Additive);
//GameObject.Instantiate(s4);
                sceneloaded[04] = true;

            }
        }

        else
            if (T1.position.z > 250 && T1.position.z < 330 )
        {
            try
            {
//StartCoroutine(UnLoadNewScene("04"));           
     SceneManager.UnloadSceneAsync("04");
		//Destroy(GameObject.FindGameObjectWithTag("04"));
                sceneloaded[04] = false;

            }
            catch
            {

            }

            try
            {
//StartCoroutine(UnLoadNewScene("07"));             
   SceneManager.UnloadSceneAsync("07");
		//Destroy(GameObject.FindGameObjectWithTag("07"));
                sceneloaded[07] = false;

            }
            catch
            {

            }
            if (!sceneloaded[06])
            {
//StartCoroutine(LoadNewScene("06"));
                SceneManager.LoadSceneAsync("06", LoadSceneMode.Additive);
//GameObject.Instantiate(s6);
                sceneloaded[06] = true;

            }
            if (!sceneloaded[05])
            {
//StartCoroutine(LoadNewScene("05"));
                SceneManager.LoadSceneAsync("05", LoadSceneMode.Additive);
//GameObject.Instantiate(s5);
                sceneloaded[05] = true;

            }
        }


        else
            if (T1.position.z > 330 && T1.position.z < 410 )
        {
            try
            {
     //       StartCoroutine(UnLoadNewScene("05"));
    SceneManager.UnloadSceneAsync("05");
		//	Destroy(GameObject.FindGameObjectWithTag("05"));
                sceneloaded[05] = false;

            }
            catch
            {

            }

            try
            {
//StartCoroutine(UnLoadNewScene("08"));            
    SceneManager.UnloadSceneAsync("08");
		//Destroy(GameObject.FindGameObjectWithTag("08"));
                sceneloaded[08] = false;

            }
            catch
            {

            }

            if (!sceneloaded[07])
            {

//StartCoroutine(LoadNewScene("07"));
               SceneManager.LoadSceneAsync("07", LoadSceneMode.Additive);
//GameObject.Instantiate(s7);
                sceneloaded[07] = true;


            }
            if (!sceneloaded[06])
            {
          //    StartCoroutine(LoadNewScene("06"));
  SceneManager.LoadSceneAsync("06", LoadSceneMode.Additive);
//GameObject.Instantiate(s6);
                sceneloaded[06] = true;


            }
        }

        else
            if (T1.position.z > 410 && T1.position.z < 490 )
        {
            try
            {
//StartCoroutine(UnLoadNewScene("06"));               
 SceneManager.UnloadSceneAsync("06");
		//Destroy(GameObject.FindGameObjectWithTag("06"));
                sceneloaded[06] = false;

            }
            catch
            {

            }

            try
            {
//StartCoroutine(UnLoadNewScene("09"));
                SceneManager.UnloadSceneAsync("09");
		//	Destroy(GameObject.FindGameObjectWithTag("09"));
                sceneloaded[09] = false;

            }
            catch
            {

            }

            if (!sceneloaded[08])
            {
//StartCoroutine(LoadNewScene("08"));
                SceneManager.LoadSceneAsync("08", LoadSceneMode.Additive);
//GameObject.Instantiate(s8);
                sceneloaded[08] = true;

            }
            if (!sceneloaded[07])
            {
//StartCoroutine(LoadNewScene("07"));
               SceneManager.LoadSceneAsync("07", LoadSceneMode.Additive);
//GameObject.Instantiate(s7);
                sceneloaded[07] = true;

            }
        }


        else
            if (T1.position.z > 490 && T1.position.z < 570)
        {
            try
            {
//StartCoroutine(UnLoadNewScene("07"));
                SceneManager.UnloadSceneAsync("07");
			//Destroy(GameObject.FindGameObjectWithTag("07"));
                sceneloaded[07] = false;

            }
            catch
            {

            }

            try
            {
//StartCoroutine(UnLoadNewScene("10"));
               SceneManager.UnloadSceneAsync("10");
		//Destroy(GameObject.FindGameObjectWithTag("10"));
                sceneloaded[10] = false;

            }
            catch
            {

            }

            if (!sceneloaded[09])
            {
//StartCoroutine(LoadNewScene("09"));
                SceneManager.LoadSceneAsync("09", LoadSceneMode.Additive);
			//GameObject.Instantiate(s9);
                sceneloaded[09] = true;

            }
            if (!sceneloaded[08])
            {
//StartCoroutine(LoadNewScene("08"));
                SceneManager.LoadSceneAsync("08", LoadSceneMode.Additive);
		//GameObject.Instantiate(s8);
                sceneloaded[08] = true;

            }
        }

        else
            if (T1.position.z > 570 )
        {
            try
            {
//StartCoroutine(UnLoadNewScene("08"));
                SceneManager.UnloadSceneAsync("08");
		//Destroy(GameObject.FindGameObjectWithTag("08"));
                sceneloaded[08] = false;

            }
            catch
            {

            }

            if (!sceneloaded[10])
            {
//StartCoroutine(LoadNewScene("10"));
                SceneManager.LoadSceneAsync("10", LoadSceneMode.Additive);
		//	GameObject.Instantiate(s10);
                sceneloaded[10] = true;

            }
        }
    }
}
