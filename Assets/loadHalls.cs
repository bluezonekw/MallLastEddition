using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadHalls : MonoBehaviour
{

    
public GameObject[] Halls; 


     Transform T1;
    bool[] sceneloaded = { false, false, false, false, false, false, false, false, false, false, false };
  public static int NumberOfFloor=1;

    // Start is called before the first frame update
    void Start()
    {
 
       T1=this.transform;




    }

    // Update is called once per frame
    void LateUpdate()
    {
if(T1.localPosition.y<3)
{
NumberOfFloor=1;
}else
if(T1.localPosition.y>3 &&T1.localPosition.y<10)
{
NumberOfFloor=2;
}else
if(T1.localPosition.y>10 )
{
NumberOfFloor=3;
}

        if (T1.position.z < -31f  )//Scene1
        {
                        

            try
            {


                Halls[2].SetActive(false);
                sceneloaded[3] = false;
            }
            catch
            {

            }


            try
            {


                Halls[3].SetActive(false);
                sceneloaded[4] = false;
            }
            catch
            {

            }




            try
            {


                Halls[4].SetActive(false);
                sceneloaded[5] = false;
            }
            catch
            {

            }

            try
            {


               Halls[5].SetActive(false);
                sceneloaded[6] = false;

            }
            catch
            {

            }

            try
            {


                Halls[6].SetActive(false);


                sceneloaded[7] = false;
            }
            catch
            {

            }



            try
            {


               Halls[7].SetActive(false);
                sceneloaded[8] = false;
            }
            catch
            {

            }



            try
            {


               Halls[8].SetActive(false);


                sceneloaded[9] = false;

            }
            catch
            {

            }


            try
            {


                Halls[9].SetActive(false);


                sceneloaded[10] = false;

            }
            catch
            {

            }





            if (!sceneloaded[01])
            {
Halls[0].SetActive(true);
                        sceneloaded[01] = true;
            }
            if (!sceneloaded[02])
            {

                Halls[1].SetActive(true);

                sceneloaded[02] = true;

            }
        }
        else
        if (T1.position.z > -31f && T1.position.z < 57)//scen2
        {


            try
            {

                Halls[3].SetActive(false);

                sceneloaded[04] = false;

            }
            catch
            {

            }


            try
            {

                Halls[4].SetActive(false);


                sceneloaded[05] = false;


            }
            catch
            {

            } try
            {

                Halls[5].SetActive(false);


                sceneloaded[06] = false;


            }
            catch
            {

            } try
            {

                Halls[6].SetActive(false);


                sceneloaded[07] = false;


            }
            catch
            {

            } try
            {

                Halls[7].SetActive(false);


                sceneloaded[08] = false;


            }
            catch
            {

            } try
            {

                Halls[8].SetActive(false);


                sceneloaded[09] = false;


            }
            catch
            {

            } try
            {

                Halls[9].SetActive(false);


                sceneloaded[10] = false;


            }
            catch
            {

            }

            if (!sceneloaded[02])
            {


                Halls[1].SetActive(true);

                sceneloaded[02] = true;

            }

            if (!sceneloaded[01])
            {


              Halls[0].SetActive(true);

                sceneloaded[01] = true;

            }


            if (!sceneloaded[03])
            {

               Halls[2].SetActive(true);

                sceneloaded[03] = true;


            }
        }
        else
            if (T1.position.z > 57 && T1.position.z < 135)                        //InScen3
        {




            try
            {

               Halls[0].SetActive(false);

                sceneloaded[01] = false;

            }
            catch
            {

            }



            try
            {

               Halls[4].SetActive(false);

                sceneloaded[05] = false;

            }
            catch
            {

            }



            try
            {

                Halls[5].SetActive(false);

                sceneloaded[06] = false;

            }
            catch
            {

            }

            try
            {

                Halls[6].SetActive(false);

                sceneloaded[07] = false;

            }
            catch
            {

            }



            try
            {

                Halls[7].SetActive(false);

                sceneloaded[08] = false;

            }
            catch
            {

            }



            try
            {

                Halls[8].SetActive(false);

                sceneloaded[09] = false;

            }
            catch
            {

            }






            try
            {

                Halls[9].SetActive(false);

                sceneloaded[10] = false;

            }
            catch
            {

            }




            if (!sceneloaded[03])
            {


               Halls[2].SetActive(true);

                sceneloaded[03] = true;

            }




            if (!sceneloaded[04])
            {


               Halls[3].SetActive(true);

                sceneloaded[04] = true;

            }





            if (!sceneloaded[02])
            {


                Halls[1].SetActive(true);

                sceneloaded[02] = true;

            }


        }


        else
            if (T1.position.z > 135  && T1.position.z < 215  )			//Scen4
        {
            try
            {

                Halls[0].SetActive(false);

                sceneloaded[01] = false;

            }
            catch
            {

            }

            try
            {

               Halls[1].SetActive(false);

                sceneloaded[02] = false;

            }
            catch
            {

            }


            try
            {

                Halls[5].SetActive(false);

                sceneloaded[06] = false;

            }
            catch
            {

            }

            try
            {

                Halls[6].SetActive(false);

                sceneloaded[07] = false;

            }
            catch
            {

            }

            try
            {

                Halls[7].SetActive(false);

                sceneloaded[08] = false;

            }
            catch
            {

            }
            try
            {

                Halls[8].SetActive(false);

                sceneloaded[09] = false;

            }
            catch
            {

            }

            try
            {

               Halls[9].SetActive(false);

                sceneloaded[10] = false;

            }
            catch
            {

            }


            if (!sceneloaded[04])
            {


                Halls[3].SetActive(true);

                sceneloaded[04] = true;

            }


            if (!sceneloaded[03])
            {


                 Halls[2].SetActive(true);
                sceneloaded[03] = true;

            }




            if (!sceneloaded[05])
            {


                Halls[4].SetActive(true);

                sceneloaded[05] = true;

            }



        }

        else
            if (T1.position.z > 215  && T1.position.z < 290)						// Scene5
        {
            try
            {

                 Halls[0].SetActive(false);

                sceneloaded[01] = false;

            }
            catch
            {

            }

            try
            {

                 Halls[1].SetActive(false);

                sceneloaded[02] = false;

            }
            catch
            {

            }


            try
            {

                 Halls[2].SetActive(false);

                sceneloaded[03] = false;

            }
            catch
            {

            }


            try
            {

                 Halls[6].SetActive(false);

                sceneloaded[07] = false;

            }
            catch
            {

            }


            try
            {

                 Halls[7].SetActive(false);

                sceneloaded[08] = false;

            }
            catch
            {

            }


            try
            {

                 Halls[8].SetActive(false);

                sceneloaded[09] = false;

            }
            catch
            {

            }

            try
            {

                 Halls[9].SetActive(false);

                sceneloaded[10] = false;

            }
            catch
            {

            }

            if (!sceneloaded[05])
            {

                 Halls[4].SetActive(true);

                sceneloaded[05] = true;

            }





            if (!sceneloaded[06])
            {

                 Halls[5].SetActive(true);

                sceneloaded[06] = true;

            }


            if (!sceneloaded[04])
            {

                 Halls[3].SetActive(true);

                sceneloaded[04] = true;

            }



        }


        else
            if (T1.position.z > 290 && T1.position.z < 370)			//Scene6
        {


            try
            {

                 Halls[0].SetActive(false);

                sceneloaded[01] = false;

            }
            catch
            {

            }

            try
            {

                 Halls[1].SetActive(false);

                sceneloaded[02] = false;

            }
            catch
            {

            }


            try
            {

                 Halls[2].SetActive(false);

                sceneloaded[03] = false;

            }
            catch
            {

            }


            try
            {

                 Halls[3].SetActive(false);

                sceneloaded[04] = false;

            }
            catch
            {

            }


            try
            {

                 Halls[7].SetActive(false);

                sceneloaded[08] = false;

            }
            catch
            {

            }



            try
            {

                 Halls[8].SetActive(false);

                sceneloaded[09] = false;

            }
            catch
            {

            }

            try
            {

                 Halls[9].SetActive(false);

                sceneloaded[10] = false;

            }
            catch
            {

            }


            if (!sceneloaded[06])
            {


                 Halls[5].SetActive(true);
                sceneloaded[06] = true;


            }

            if (!sceneloaded[07])
            {



                 Halls[6].SetActive(true);
                sceneloaded[07] = true;


            }
            if (!sceneloaded[05])
            {


                 Halls[4].SetActive(true);
                sceneloaded[05] = true;


            }

        }

        else
            if (T1.position.z > 370 && T1.position.z < 450)			//Scene7
        {
            try
            {

                 Halls[0].SetActive(false);

                sceneloaded[01] = false;

            }
            catch
            {

            }

            

                try
                {

                     Halls[1].SetActive(false);

                    sceneloaded[02] = false;

                }
                catch
                {

                }
                try
                {

                     Halls[2].SetActive(false);

                    sceneloaded[03] = false;

                }
                catch
                {

                }
                try
                {

                     Halls[3].SetActive(false);

                    sceneloaded[04] = false;

                }
                catch
                {

                }
                try
                {

                     Halls[4].SetActive(false);

                    sceneloaded[05] = false;

                }
                catch
                {

                }
                try
                {

                     Halls[8].SetActive(false);

                    sceneloaded[09] = false;

                }
                catch
                {

                }
                try
                {

                     Halls[9].SetActive(false);

                    sceneloaded[10] = false;

                }
                catch
                {

                }



                if (!sceneloaded[07])
                {


                     Halls[6].SetActive(true);
                    sceneloaded[07] = true;

                }

                if (!sceneloaded[08])
                {


                     Halls[7].SetActive(true);
                    sceneloaded[08] = true;

                }

                if (!sceneloaded[06])
                {


                     Halls[5].SetActive(true);
                    sceneloaded[06] = true;

                }

            }


        else
            if (T1.position.z > 450  && T1.position.z < 530)     //Scene8
            {
                try
                {

                     Halls[0].SetActive(false);

                    sceneloaded[01] = false;

                }
                catch
                {

                }


                try
                {

                     Halls[1].SetActive(false);

                    sceneloaded[02] = false;

                }
                catch
                {

                }


                try
                {

                     Halls[2].SetActive(false);

                    sceneloaded[03] = false;

                }
                catch
                {

                }

                try
                {

                     Halls[3].SetActive(false);

                    sceneloaded[04] = false;

                }
                catch
                {

                }



                try
                {

                     Halls[4].SetActive(false);

                    sceneloaded[05] = false;

                }
                catch
                {

                }
                try
                {

                     Halls[5].SetActive(false);

                    sceneloaded[06] = false;

                }
                catch
                {

                }



                try
                {

                     Halls[9].SetActive(false);

                    sceneloaded[10] = false;

                }
                catch
                {

                }

                if (!sceneloaded[08])
                {


                     Halls[7].SetActive(true);
                    sceneloaded[08] = true;

                }


                if (!sceneloaded[9])
                {


                     Halls[8].SetActive(true);
                    sceneloaded[09] = true;

                }
                if (!sceneloaded[7])
                {


                     Halls[6].SetActive(true);
                    sceneloaded[7] = true;

                }
            }

            else
            if (T1.position.z > 530 && T1.position.z < 610)  //In_Scene_9
            {
                try
                {

                     Halls[0].SetActive(false);

                    sceneloaded[01] = false;

                }
                catch
                {

                }

            try
            {

                 Halls[1].SetActive(false);

                sceneloaded[02] = false;

            }
            catch
            {

            }
            try
            {

                 Halls[2].SetActive(false);

                sceneloaded[03] = false;

            }
            catch
            {

            }
            try
            {

                 Halls[3].SetActive(false);

                sceneloaded[04] = false;

            }
            catch
            {

            }
            try
            {

                 Halls[4].SetActive(false);

                sceneloaded[05] = false;

            }
            catch
            {

            }
            try
            {

                 Halls[5].SetActive(false);

                sceneloaded[06] = false;

            }
            catch
            {

            }
            try
            {

                 Halls[6].SetActive(false);

                sceneloaded[07] = false;

            }
            catch
            {

            }




            if (!sceneloaded[09])
            {


                 Halls[8].SetActive(true);
                sceneloaded[09] = true;

            }

            if (!sceneloaded[08])
            {


                 Halls[7].SetActive(true);
                sceneloaded[08] = true;

            }



            if (!sceneloaded[10])
            {


                 Halls[9].SetActive(true);
                sceneloaded[10] = true;

            }


        }
        else
            if (T1.position.z > 610  )  //In_Scene_10
        {
            try
            {

                 Halls[0].SetActive(false);

                sceneloaded[01] = false;

            }
            catch
            {

            }

            try
            {

                 Halls[1].SetActive(false);

                sceneloaded[02] = false;

            }
            catch
            {

            }
            try
            {

                 Halls[2].SetActive(false);

                sceneloaded[03] = false;

            }
            catch
            {

            }
            try
            {

                 Halls[3].SetActive(false);

                sceneloaded[04] = false;

            }
            catch
            {

            }
            try
            {

                 Halls[4].SetActive(false);

                sceneloaded[05] = false;

            }
            catch
            {

            }
            try
            {

                 Halls[5].SetActive(false);

                sceneloaded[06] = false;

            }
            catch
            {

            }
            try
            {

                 Halls[6].SetActive(false);

                sceneloaded[07] = false;

            }
            catch
            {

            }
            try
            {

                 Halls[7].SetActive(false);

                sceneloaded[08] = false;

            }
            catch
            {

            }



            if (!sceneloaded[09])
            {


                 Halls[8].SetActive(true);
                sceneloaded[09] = true;

            }

           

            if (!sceneloaded[10])
            {


                 Halls[9].SetActive(true);
                sceneloaded[10] = true;

            }


        }




    }
} 









