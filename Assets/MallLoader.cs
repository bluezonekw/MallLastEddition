using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Threading;

public class MallLoader : MonoBehaviour
{

    public Transform T1;
    bool[] sceneloaded = { false, false, false, false, false, false, false, false, false, false, false };
public GameObject Loading;
    public GameObject s1, s2, s3, s4, s5, s6, s7, s8, s9, s10;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    IEnumerator LoadYourAsyncScene(string Scene)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(Scene, LoadSceneMode.Additive);
GameObject g=GameObject.Instantiate(Loading, GameObject.FindGameObjectWithTag("MainCanvas").transform);
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {

            yield return null;
        }
Destroy(g);
    }









    // Update is called once per frame
    void Update()
    {
print (T1.position.z +"        How DA");
        if (T1.position.z < -31f  )//Scene1
        {
            try
            {


                SceneManager.UnloadSceneAsync("03");
                sceneloaded[3] = false;
            }
            catch
            {

            }


            try
            {


                SceneManager.UnloadSceneAsync("04");
                sceneloaded[4] = false;
            }
            catch
            {

            }




            try
            {


                SceneManager.UnloadSceneAsync("05");
                sceneloaded[5] = false;
            }
            catch
            {

            }

            try
            {


                SceneManager.UnloadSceneAsync("06");
                sceneloaded[6] = false;

            }
            catch
            {

            }

            try
            {


                SceneManager.UnloadSceneAsync("07");


                sceneloaded[7] = false;
            }
            catch
            {

            }



            try
            {


                SceneManager.UnloadSceneAsync("08");
                sceneloaded[8] = false;
            }
            catch
            {

            }



            try
            {


                SceneManager.UnloadSceneAsync("09");


                sceneloaded[9] = false;

            }
            catch
            {

            }


            try
            {


                SceneManager.UnloadSceneAsync("10");


                sceneloaded[10] = false;

            }
            catch
            {

            }





            if (!sceneloaded[01])
            {

                StartCoroutine(LoadYourAsyncScene("01"));




                sceneloaded[01] = true;
            }
            if (!sceneloaded[02])
            {

                StartCoroutine(LoadYourAsyncScene("02"));

                sceneloaded[02] = true;

            }
        }
        else
        if (T1.position.z > -31f && T1.position.z < 57)//scen2
        {


            try
            {

                SceneManager.UnloadSceneAsync("04");

                sceneloaded[04] = false;

            }
            catch
            {

            }


            try
            {

                SceneManager.UnloadSceneAsync("05");


                sceneloaded[05] = false;


            }
            catch
            {

            } try
            {

                SceneManager.UnloadSceneAsync("06");


                sceneloaded[06] = false;


            }
            catch
            {

            } try
            {

                SceneManager.UnloadSceneAsync("07");


                sceneloaded[07] = false;


            }
            catch
            {

            } try
            {

                SceneManager.UnloadSceneAsync("08");


                sceneloaded[08] = false;


            }
            catch
            {

            } try
            {

                SceneManager.UnloadSceneAsync("09");


                sceneloaded[09] = false;


            }
            catch
            {

            } try
            {

                SceneManager.UnloadSceneAsync("10");


                sceneloaded[10] = false;


            }
            catch
            {

            }

            if (!sceneloaded[02])
            {


                StartCoroutine(LoadYourAsyncScene("02"));

                sceneloaded[02] = true;

            }

            if (!sceneloaded[01])
            {


                StartCoroutine(LoadYourAsyncScene("01"));

                sceneloaded[01] = true;

            }


            if (!sceneloaded[03])
            {
print ("I enter 3");
                StartCoroutine(LoadYourAsyncScene("03"));

                sceneloaded[03] = true;


            }
        }
        else
            if (T1.position.z > 57 && T1.position.z < 135)                        //InScen3
        {




            try
            {

                SceneManager.UnloadSceneAsync("01");

                sceneloaded[01] = false;

            }
            catch
            {

            }



            try
            {

                SceneManager.UnloadSceneAsync("05");

                sceneloaded[05] = false;

            }
            catch
            {

            }



            try
            {

                SceneManager.UnloadSceneAsync("06");

                sceneloaded[06] = false;

            }
            catch
            {

            }

            try
            {

                SceneManager.UnloadSceneAsync("07");

                sceneloaded[07] = false;

            }
            catch
            {

            }



            try
            {

                SceneManager.UnloadSceneAsync("08");

                sceneloaded[08] = false;

            }
            catch
            {

            }



            try
            {

                SceneManager.UnloadSceneAsync("09");

                sceneloaded[09] = false;

            }
            catch
            {

            }






            try
            {

                SceneManager.UnloadSceneAsync("10");

                sceneloaded[10] = false;

            }
            catch
            {

            }




            if (!sceneloaded[03])
            {


                StartCoroutine(LoadYourAsyncScene("03"));

                sceneloaded[03] = true;

            }




            if (!sceneloaded[04])
            {


                StartCoroutine(LoadYourAsyncScene("04"));

                sceneloaded[04] = true;

            }





            if (!sceneloaded[02])
            {


                StartCoroutine(LoadYourAsyncScene("02"));

                sceneloaded[02] = true;

            }


        }


        else
            if (T1.position.z > 135  && T1.position.z < 215  )			//Scen4
        {
            try
            {

                SceneManager.UnloadSceneAsync("01");

                sceneloaded[01] = false;

            }
            catch
            {

            }

            try
            {

                SceneManager.UnloadSceneAsync("02");

                sceneloaded[02] = false;

            }
            catch
            {

            }


            try
            {

                SceneManager.UnloadSceneAsync("06");

                sceneloaded[06] = false;

            }
            catch
            {

            }

            try
            {

                SceneManager.UnloadSceneAsync("07");

                sceneloaded[07] = false;

            }
            catch
            {

            }

            try
            {

                SceneManager.UnloadSceneAsync("08");

                sceneloaded[08] = false;

            }
            catch
            {

            }
            try
            {

                SceneManager.UnloadSceneAsync("09");

                sceneloaded[09] = false;

            }
            catch
            {

            }

            try
            {

                SceneManager.UnloadSceneAsync("10");

                sceneloaded[10] = false;

            }
            catch
            {

            }


            if (!sceneloaded[04])
            {


                StartCoroutine(LoadYourAsyncScene("04"));

                sceneloaded[04] = true;

            }


            if (!sceneloaded[03])
            {


                StartCoroutine(LoadYourAsyncScene("03"));

                sceneloaded[03] = true;

            }




            if (!sceneloaded[05])
            {


                StartCoroutine(LoadYourAsyncScene("05"));

                sceneloaded[05] = true;

            }



        }

        else
            if (T1.position.z > 215  && T1.position.z < 290)						// Scene5
        {
            try
            {

                SceneManager.UnloadSceneAsync("01");

                sceneloaded[01] = false;

            }
            catch
            {

            }

            try
            {

                SceneManager.UnloadSceneAsync("02");

                sceneloaded[02] = false;

            }
            catch
            {

            }


            try
            {

                SceneManager.UnloadSceneAsync("03");

                sceneloaded[03] = false;

            }
            catch
            {

            }


            try
            {

                SceneManager.UnloadSceneAsync("07");

                sceneloaded[07] = false;

            }
            catch
            {

            }


            try
            {

                SceneManager.UnloadSceneAsync("08");

                sceneloaded[08] = false;

            }
            catch
            {

            }


            try
            {

                SceneManager.UnloadSceneAsync("09");

                sceneloaded[09] = false;

            }
            catch
            {

            }

            try
            {

                SceneManager.UnloadSceneAsync("10");

                sceneloaded[10] = false;

            }
            catch
            {

            }

            if (!sceneloaded[05])
            {

                StartCoroutine(LoadYourAsyncScene("05"));

                sceneloaded[05] = true;

            }





            if (!sceneloaded[06])
            {

                StartCoroutine(LoadYourAsyncScene("06"));

                sceneloaded[06] = true;

            }


            if (!sceneloaded[04])
            {

                StartCoroutine(LoadYourAsyncScene("04"));

                sceneloaded[04] = true;

            }



        }


        else
            if (T1.position.z > 290 && T1.position.z < 370)			//Scene6
        {


            try
            {

                SceneManager.UnloadSceneAsync("01");

                sceneloaded[01] = false;

            }
            catch
            {

            }

            try
            {

                SceneManager.UnloadSceneAsync("02");

                sceneloaded[02] = false;

            }
            catch
            {

            }


            try
            {

                SceneManager.UnloadSceneAsync("03");

                sceneloaded[03] = false;

            }
            catch
            {

            }


            try
            {

                SceneManager.UnloadSceneAsync("04");

                sceneloaded[04] = false;

            }
            catch
            {

            }


            try
            {

                SceneManager.UnloadSceneAsync("08");

                sceneloaded[08] = false;

            }
            catch
            {

            }



            try
            {

                SceneManager.UnloadSceneAsync("09");

                sceneloaded[09] = false;

            }
            catch
            {

            }

            try
            {

                SceneManager.UnloadSceneAsync("10");

                sceneloaded[10] = false;

            }
            catch
            {

            }


            if (!sceneloaded[06])
            {


                StartCoroutine(LoadYourAsyncScene("06"));
                sceneloaded[06] = true;


            }

            if (!sceneloaded[07])
            {



                StartCoroutine(LoadYourAsyncScene("07"));
                sceneloaded[07] = true;


            }
            if (!sceneloaded[05])
            {


                StartCoroutine(LoadYourAsyncScene("05"));
                sceneloaded[05] = true;


            }

        }

        else
            if (T1.position.z > 370 && T1.position.z < 450)			//Scene7
        {
            try
            {

                SceneManager.UnloadSceneAsync("01");

                sceneloaded[01] = false;

            }
            catch
            {

            }

            

                try
                {

                    SceneManager.UnloadSceneAsync("02");

                    sceneloaded[02] = false;

                }
                catch
                {

                }
                try
                {

                    SceneManager.UnloadSceneAsync("03");

                    sceneloaded[03] = false;

                }
                catch
                {

                }
                try
                {

                    SceneManager.UnloadSceneAsync("04");

                    sceneloaded[04] = false;

                }
                catch
                {

                }
                try
                {

                    SceneManager.UnloadSceneAsync("05");

                    sceneloaded[05] = false;

                }
                catch
                {

                }
                try
                {

                    SceneManager.UnloadSceneAsync("09");

                    sceneloaded[09] = false;

                }
                catch
                {

                }
                try
                {

                    SceneManager.UnloadSceneAsync("10");

                    sceneloaded[10] = false;

                }
                catch
                {

                }



                if (!sceneloaded[07])
                {


                    StartCoroutine(LoadYourAsyncScene("07"));
                    sceneloaded[07] = true;

                }

                if (!sceneloaded[08])
                {


                    StartCoroutine(LoadYourAsyncScene("08"));
                    sceneloaded[08] = true;

                }

                if (!sceneloaded[09])
                {


                    StartCoroutine(LoadYourAsyncScene("09"));
                    sceneloaded[09] = true;

                }

            }


        else
            if (T1.position.z > 450  && T1.position.z < 530)     //Scene8
            {
                try
                {

                    SceneManager.UnloadSceneAsync("01");

                    sceneloaded[01] = false;

                }
                catch
                {

                }


                try
                {

                    SceneManager.UnloadSceneAsync("02");

                    sceneloaded[02] = false;

                }
                catch
                {

                }


                try
                {

                    SceneManager.UnloadSceneAsync("03");

                    sceneloaded[03] = false;

                }
                catch
                {

                }

                try
                {

                    SceneManager.UnloadSceneAsync("04");

                    sceneloaded[04] = false;

                }
                catch
                {

                }



                try
                {

                    SceneManager.UnloadSceneAsync("05");

                    sceneloaded[05] = false;

                }
                catch
                {

                }
                try
                {

                    SceneManager.UnloadSceneAsync("06");

                    sceneloaded[06] = false;

                }
                catch
                {

                }



                try
                {

                    SceneManager.UnloadSceneAsync("10");

                    sceneloaded[10] = false;

                }
                catch
                {

                }

                if (!sceneloaded[08])
                {


                    StartCoroutine(LoadYourAsyncScene("08"));
                    sceneloaded[08] = true;

                }


                if (!sceneloaded[09])
                {


                    StartCoroutine(LoadYourAsyncScene("09"));
                    sceneloaded[09] = true;

                }
                if (!sceneloaded[10])
                {


                    StartCoroutine(LoadYourAsyncScene("10"));
                    sceneloaded[10] = true;

                }
            }

            else
            if (T1.position.z > 530 && T1.position.z < 610)  //In_Scene_9
            {
                try
                {

                    SceneManager.UnloadSceneAsync("01");

                    sceneloaded[01] = false;

                }
                catch
                {

                }

            try
            {

                SceneManager.UnloadSceneAsync("02");

                sceneloaded[02] = false;

            }
            catch
            {

            }
            try
            {

                SceneManager.UnloadSceneAsync("03");

                sceneloaded[03] = false;

            }
            catch
            {

            }
            try
            {

                SceneManager.UnloadSceneAsync("04");

                sceneloaded[04] = false;

            }
            catch
            {

            }
            try
            {

                SceneManager.UnloadSceneAsync("05");

                sceneloaded[05] = false;

            }
            catch
            {

            }
            try
            {

                SceneManager.UnloadSceneAsync("06");

                sceneloaded[06] = false;

            }
            catch
            {

            }
            try
            {

                SceneManager.UnloadSceneAsync("07");

                sceneloaded[07] = false;

            }
            catch
            {

            }




            if (!sceneloaded[09])
            {


                StartCoroutine(LoadYourAsyncScene("09"));
                sceneloaded[09] = true;

            }

            if (!sceneloaded[08])
            {


                StartCoroutine(LoadYourAsyncScene("09"));
                sceneloaded[08] = true;

            }



            if (!sceneloaded[10])
            {


                StartCoroutine(LoadYourAsyncScene("10"));
                sceneloaded[10] = true;

            }


        }
        else
            if (T1.position.z > 610  )  //In_Scene_10
        {
            try
            {

                SceneManager.UnloadSceneAsync("01");

                sceneloaded[01] = false;

            }
            catch
            {

            }

            try
            {

                SceneManager.UnloadSceneAsync("02");

                sceneloaded[02] = false;

            }
            catch
            {

            }
            try
            {

                SceneManager.UnloadSceneAsync("03");

                sceneloaded[03] = false;

            }
            catch
            {

            }
            try
            {

                SceneManager.UnloadSceneAsync("04");

                sceneloaded[04] = false;

            }
            catch
            {

            }
            try
            {

                SceneManager.UnloadSceneAsync("05");

                sceneloaded[05] = false;

            }
            catch
            {

            }
            try
            {

                SceneManager.UnloadSceneAsync("06");

                sceneloaded[06] = false;

            }
            catch
            {

            }
            try
            {

                SceneManager.UnloadSceneAsync("07");

                sceneloaded[07] = false;

            }
            catch
            {

            }
            try
            {

                SceneManager.UnloadSceneAsync("08");

                sceneloaded[08] = false;

            }
            catch
            {

            }



            if (!sceneloaded[09])
            {


                StartCoroutine(LoadYourAsyncScene("09"));
                sceneloaded[09] = true;

            }

           

            if (!sceneloaded[10])
            {


                StartCoroutine(LoadYourAsyncScene("10"));
                sceneloaded[10] = true;

            }


        }




    }
} 


