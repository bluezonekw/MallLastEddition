using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Threading;
//using UnityEngine.AddressableAssets;
//using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;
public class MallLoader : MonoBehaviour
{
private double lastInterval;
//public AssetReference[] Allscene;
    public Transform T1;
    bool[] sceneloaded = { false, false, false, false, false, false, false, false, false, false, false };
public GameObject Loading;
   
public static bool Isload;
GameObject g;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    IEnumerator LoadYourAsyncScene(string Scene)
    {
      /*

  // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(Scene, LoadSceneMode.Additive);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {

            yield return null;
        }
*/

//Addressables.LoadSceneAsync(Allscene[int.Parse(Scene)-1],UnityEngine.SceneManagement.LoadSceneMode.Additive).Completed  += SceneLoadComplete;
lastInterval= Time.realtimeSinceStartup;
print("The first time   /"+ lastInterval);
//g=GameObject.Instantiate(Loading, GameObject.FindGameObjectWithTag("MainCanvas").transform);
Isload=true;
yield return null;


    }

/*private void SceneLoadComplete(AsyncOperationHandle<UnityEngine.ResourceManagement.ResourceProviders.SceneInstance> obj)     {  
       if (obj.Status == AsyncOperationStatus.Succeeded) 
{
lastInterval=-Time.realtimeSinceStartup;
print("The time after end    /"+lastInterval);
//Destroy(g);
Isload=false;

}
        }   

*/
  IEnumerator Load2Sec()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(10);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }




    // Update is called once per frame
    void Update()
    {

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
StartCoroutine(Load2Sec());



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


