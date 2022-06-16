using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RestSharp;
using Newtonsoft.Json;

public class loadimageFromApi : MonoBehaviour
{

    public AnimationClip First, Last, ProductNext1, ProductNext2, pervious1, pervious2;
    public GameObject SliddderDefault;
    public GameObject RS, LS, FS;
    public GameObject[] Sections;
    private int Rindex, Lindex, Findex;
    private SingleSToreRequest StoreRequest;
    private RawImage Loaded;
    bool Startassign;
    public GameObject ProductDefault;
    GameObject childObject;
    public List<string> section_Page;
    public List<GameObject[]> Products;
    public List<int> PostionImage;
    public List<GameObject> LG;

    public SectionRequest request;
    bool firstslide;
    public static StoreProduct ProductRequst;
    public GameObject DetailsMenu;
    GameObject MenuCreated;
    bool startAnimation1;
    public IEnumerator Load5Image()
    {


        //loadallProductinsections(0);
        //loadallProductinsections(1);
        //loadallProductinsections(2);
        //loadallProductinsections(3);
        //loadallProductinsections(4);
        //loadallProductinsections(5);
        //loadallProductinsections(6);
        //loadallProductinsections(0);

        //loadallProductinsections(7);
        //loadallProductinsections(8);

      
       
       

        for (int x = 0; x < 5; x++)
        {


            yield return new WaitForSeconds(5);
            nextSection(0);
            nextSection(1);
            nextSection(2);
            nextSection(3);
            nextSection(4);
            nextSection(5);
            nextSection(6);
            nextSection(7);
            nextSection(8);
        }




    }
    // Start is called before the first frame update
    void Start()
    {




        startAnimation1 = true;
        Rindex = Lindex = Findex = 0;
        StoreRequest = GetComponent<SingleSToreRequest>();





    }
    bool loadproduct;
    IEnumerator ChangeProduct(int sectionIdLocal)


    {

        try
        {

            Sections[sectionIdLocal].transform.GetChild(PostionImage[sectionIdLocal] + 1).gameObject.GetComponent<Animation>().clip = ProductNext1;
            Sections[sectionIdLocal].transform.GetChild(PostionImage[sectionIdLocal] + 1).gameObject.GetComponent<Animation>().Play();

            Sections[sectionIdLocal].transform.GetChild(PostionImage[sectionIdLocal]).gameObject.GetComponent<Animation>().clip = ProductNext2;
            Sections[sectionIdLocal].transform.GetChild(PostionImage[sectionIdLocal]).gameObject.GetComponent<Animation>().Play();


            PostionImage[sectionIdLocal]++;
        }
        catch
        {

        }
        yield return new WaitForSeconds(1);

    }
    public void LoadProduct(int sectionIdLocal)
    {




        print(Sections[sectionIdLocal].transform.GetChild(PostionImage[sectionIdLocal] ).gameObject.name + "      product id");

        try
        {
            if (MenuCreated!=null) {
                GameObject.DestroyImmediate(MenuCreated);
            }
           
            var client = new RestClient(@"http://mymall-kw.com/api/V1/get-single-product/" + Sections[sectionIdLocal].transform.GetChild(PostionImage[sectionIdLocal] ).gameObject.name);
        
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("password-api", "mall_2021_m3m");
            if (UPDownMenu.LanguageValue == 1)
            {
                request.AddHeader("lang-api", "en");
            }
            else
            {

                request.AddHeader("lang-api", "ar");

            }
            if(AuthToken()!="0"){
            request.AddHeader("auth-token", AuthToken());
          
            }
            request.AlwaysMultipartFormData = true;
            IRestResponse response = client.Execute(request);
           
            ProductRequst = JsonConvert.DeserializeObject<StoreProduct>(response.Content);
            
            if (ProductRequst.statsu == 1)
            {
            
                     MenuCreated = GameObject.Instantiate(DetailsMenu, GameObject.FindGameObjectWithTag("MainCanvas").transform);


               
            }
        }
        catch
        {
            Debug.Log("FailedTolaod");
        }


       
    }
    public void Loadslidders(GameObject Parent, string Url, int Rotation)
    {

        childObject = Instantiate(SliddderDefault) as GameObject;
        childObject.transform.parent = Parent.transform;
        childObject.transform.localPosition = new Vector3(4f, 0, 0);
        childObject.transform.localScale = new Vector3(1, 1, 1);
        StartCoroutine(DownLoadSprite(Url, childObject.GetComponent<RawImage>()));
        if (Rotation == 1)
        {
            childObject.transform.Rotate(new Vector3(0, -90, 0));
        }
        if (Rotation == 2)
        {
            childObject.transform.Rotate(new Vector3(0, 180, 0));
        }




    }













    IEnumerator DownLoadSprite(string URL, RawImage s)
    {

        WWW www = new WWW(URL);
        yield return www;



        s.texture = www.texture;

    }
    public string AuthToken()
    {
        try
        {
            if (!UPDownMenu.Login)
            {
                return ApiClasses.Register.data.token;
            }
            else

            {

                return ApiClasses.Login.data.original.access_token;

            }
        }
        catch
        {
            return "0";
        }

    }
    public void slideRight()
    {

        if (Startassign)
        {
            try
            {
                if (RS.transform.GetChild(Rindex).transform.localPosition == new Vector3(4, 0, 0))
                {

                    RS.transform.GetChild(Rindex).gameObject.GetComponent<Animation>().clip = First;
                    RS.transform.GetChild(Rindex).gameObject.GetComponent<Animation>().Play();

                }
                else
                if (RS.transform.GetChild(Rindex).transform.localPosition == new Vector3(0, 0, 0) && RS.transform.GetChild(Rindex).transform.localScale == new Vector3(1, 1, 1))
                {
                    RS.transform.GetChild(Rindex).gameObject.GetComponent<Animation>().clip = Last;
                    RS.transform.GetChild(Rindex).gameObject.GetComponent<Animation>().Play();

                    Rindex++;

                }
            }
            catch
            {
                Rindex = 0;

            }





        }


    }






    public void slideLeft()
    {

        if (Startassign)
        {
            try
            {
                if (LS.transform.GetChild(Lindex).transform.localPosition == new Vector3(4, 0, 0))
                {

                    LS.transform.GetChild(Lindex).gameObject.GetComponent<Animation>().clip = First;
                    LS.transform.GetChild(Lindex).gameObject.GetComponent<Animation>().Play();

                }
                else
                if (LS.transform.GetChild(Lindex).transform.localPosition == new Vector3(0, 0, 0) && LS.transform.GetChild(Lindex).transform.localScale == new Vector3(1, 1, 1))
                {
                    LS.transform.GetChild(Lindex).gameObject.GetComponent<Animation>().clip = Last;
                    LS.transform.GetChild(Lindex).gameObject.GetComponent<Animation>().Play();

                    Lindex++;

                }
            }
            catch
            {
                Lindex = 0;

            }





        }


    }



    public void slideLFront()
    {

        if (Startassign)
        {
            try
            {
                if (FS.transform.GetChild(Findex).transform.localPosition == new Vector3(4, 0, 0))
                {

                    FS.transform.GetChild(Findex).gameObject.GetComponent<Animation>().clip = First;
                    FS.transform.GetChild(Findex).gameObject.GetComponent<Animation>().Play();

                }
                else
                if (FS.transform.GetChild(Findex).transform.localPosition == new Vector3(0, 0, 0) && FS.transform.GetChild(Findex).transform.localScale == new Vector3(1, 1, 1))
                {
                    FS.transform.GetChild(Findex).gameObject.GetComponent<Animation>().clip = Last;
                    FS.transform.GetChild(Findex).gameObject.GetComponent<Animation>().Play();

                    Findex++;

                }
            }
            catch
            {
                Findex = 0;

            }





        }


    }





    // Update is called once per frame
    void Update()
    {
        slideRight();
        slideLeft();
        slideLFront();

        if (StoreRequest.Loaded && !Startassign)
        {
            StartCoroutine(Load5Image());
            Startassign = true;
            foreach (string s in StoreRequest.sliddderFront)
            {

                Loadslidders(FS, s, 1);


            }

            ///// Load RightSlidder
            foreach (string s in StoreRequest.SlidderRight)
            {

                Loadslidders(RS, s, 0);


            }
            ///// Load LeftSlidder
            foreach (string s in StoreRequest.slidderLeft)
            {

                Loadslidders(LS, s, 2);


            }
            try
            {

                for (int i = 0; i < StoreRequest.URL1.Count; i++)
                {
                    LoadIntialProduct(Sections[0], StoreRequest.URL1[i], StoreRequest.product1[i], "01", 0, StoreRequest.SectionId[0].ToString());
                }

            }
            catch
            {



            }

            try
            {
                for (int i = 0; i < StoreRequest.URL2.Count; i++)
                {
                    /// load RightWall CenterPostion
                    LoadIntialProduct(Sections[1], StoreRequest.URL2[i], StoreRequest.product2[i], "01", 0, StoreRequest.SectionId[1].ToString());
                }
            }
            catch
            {



            }
            try
            {
                for (int i = 0; i < StoreRequest.URL3.Count; i++)
                {
                    /// load RightWall LeftPostion

                    LoadIntialProduct(Sections[2], StoreRequest.URL3[i], StoreRequest.product3[i], "01", 0, StoreRequest.SectionId[2].ToString());
                }
            }
            catch
            {



            }


            try
            {
                for (int i = 0; i < StoreRequest.URL4.Count; i++)
                {
                    /// load CenterWall RightPostion
                    LoadIntialProduct(Sections[3], StoreRequest.URL4[i], StoreRequest.product4[i], "01", 1, StoreRequest.SectionId[3].ToString());
                }
            }
            catch
            {



            }

            try
            {
                for (int i = 0; i < StoreRequest.URL5.Count; i++)
                {
                    /// load CenterWall CenterPostion
                    LoadIntialProduct(Sections[4], StoreRequest.URL5[i], StoreRequest.product5[i], "01", 1, StoreRequest.SectionId[4].ToString());
                }
            }
            catch
            {



            }
            /// load CenterWall LeftPostion
            try
            {
                for (int i = 0; i < StoreRequest.URL6.Count; i++)
                {
                    LoadIntialProduct(Sections[5], StoreRequest.URL6[i], StoreRequest.product6[i], "01", 1, StoreRequest.SectionId[5].ToString());
                }
            }
            catch
            {

            }


            try
            {
                for (int i = 0; i < StoreRequest.URL7.Count; i++)
                {
                    /// load LeftWall RightPostion
                    LoadIntialProduct(Sections[6], StoreRequest.URL7[i], StoreRequest.product7[i], "01", 2, StoreRequest.SectionId[6].ToString());
                }
            }
            catch
            {



            }
            try
            {
                for (int i = 0; i < StoreRequest.URL8.Count; i++)
                {
                    /// load LeftWall CenterPostion
                    LoadIntialProduct(Sections[7], StoreRequest.URL8[i], StoreRequest.product8[i], "01", 2, StoreRequest.SectionId[7].ToString());
                }
            }
            catch
            {



            }

            try
            {
                /// load LeftWall LeftPostion
                for (int i = 0; i < StoreRequest.URL9.Count; i++)
                {
                    LoadIntialProduct(Sections[8], StoreRequest.URL9[i], StoreRequest.product9[i], "01", 2, StoreRequest.SectionId[8].ToString());
                }
            }
            catch
            {



            }

        }


    }
    public void LoadIntialProduct(GameObject Parent, string Url, string ID, string AnimitionName, int Rotation, string SectionID)
    {

        childObject = Instantiate(ProductDefault) as GameObject;
        childObject.transform.parent = Parent.transform;
        childObject.transform.localPosition = new Vector3(0, 0, 0);
        childObject.transform.localScale = new Vector3(1, 1, 1);
        StartCoroutine(DownLoadSprite(Url, childObject.GetComponent<RawImage>()));
        childObject.GetComponent<Animation>().Play(AnimitionName);
        childObject.name = ID;
        childObject.transform.parent.gameObject.name = SectionID;
        if (Rotation == 1)
        {
            childObject.transform.Rotate(new Vector3(0, -90, 0));
        }
        if (Rotation == 2)
        {
            childObject.transform.Rotate(new Vector3(0, 180, 0));
        }





    }




    public void LoadSectionProducts(GameObject Parent, string Url, string ID, int Rotation)
    {

        childObject = Instantiate(ProductDefault) as GameObject;
        childObject.transform.parent = Parent.transform;
        childObject.transform.localPosition = new Vector3(1.5f, 0, 0);
        childObject.transform.localScale = new Vector3(1, 1, 1);
        StartCoroutine(DownLoadSprite(Url, childObject.GetComponent<RawImage>()));
        childObject.name = ID;
        if (Rotation == 1)
        {
            childObject.transform.Rotate(new Vector3(0, -90, 0));
        }
        if (Rotation == 2)
        {
            childObject.transform.Rotate(new Vector3(0, 180, 0));
        }




    }


    public void PerviousSection(int sectionIdLocal)
    {
        if (Sections[sectionIdLocal].transform.childCount > 1)
        {
            if (PostionImage[sectionIdLocal] == 0)
        {
            Sections[sectionIdLocal].transform.GetChild(Sections[sectionIdLocal].transform.childCount - 1).gameObject.GetComponent<Animation>().clip = pervious1;
            Sections[sectionIdLocal].transform.GetChild(Sections[sectionIdLocal].transform.childCount - 1).gameObject.GetComponent<Animation>().Play();
        }
        else
        {
            Sections[sectionIdLocal].transform.GetChild(PostionImage[sectionIdLocal] - 1).gameObject.GetComponent<Animation>().clip = pervious1;
            Sections[sectionIdLocal].transform.GetChild(PostionImage[sectionIdLocal] - 1).gameObject.GetComponent<Animation>().Play();

        }
        Sections[sectionIdLocal].transform.GetChild(PostionImage[sectionIdLocal]).gameObject.GetComponent<Animation>().clip = pervious2;
        Sections[sectionIdLocal].transform.GetChild(PostionImage[sectionIdLocal]).gameObject.GetComponent<Animation>().Play();


        PostionImage[sectionIdLocal]--;

        if (PostionImage[sectionIdLocal] == -1)
        {
            PostionImage[sectionIdLocal] = Sections[sectionIdLocal].transform.childCount - 1;
        }

    }
    }
    public void nextSection(int sectionIdLocal)
    {







        if (Sections[sectionIdLocal].transform.childCount > 1)
        {

            if (PostionImage[sectionIdLocal] + 1 < Sections[sectionIdLocal].transform.childCount)
            {
                Sections[sectionIdLocal].transform.GetChild(PostionImage[sectionIdLocal] + 1).gameObject.GetComponent<Animation>().clip = ProductNext1;
                Sections[sectionIdLocal].transform.GetChild(PostionImage[sectionIdLocal] + 1).gameObject.GetComponent<Animation>().Play();
            }
            else
            {
                Sections[sectionIdLocal].transform.GetChild(0).gameObject.GetComponent<Animation>().clip = ProductNext1;
                Sections[sectionIdLocal].transform.GetChild(0).gameObject.GetComponent<Animation>().Play();

            }
            Sections[sectionIdLocal].transform.GetChild(PostionImage[sectionIdLocal]).gameObject.GetComponent<Animation>().clip = ProductNext2;
            Sections[sectionIdLocal].transform.GetChild(PostionImage[sectionIdLocal]).gameObject.GetComponent<Animation>().Play();


            PostionImage[sectionIdLocal]++;


            if (PostionImage[sectionIdLocal] == Sections[sectionIdLocal].transform.childCount)
            {

                PostionImage[sectionIdLocal] = 0;
            }
        }

    }



    //bool loadAllProduct;
    //public void loadallProductinsections(int sectionIdLocal)
    //{
    //    if (loadAllProduct)
    //    {

    //        return;
    //    }
    //    else
    //    {
    //        loadAllProduct = true;
    //        try
    //        {
    //            switch (sectionIdLocal)
    //            {
    //                case 0:
    //                    for (int i = 0; i < StoreRequest.URL1.Count; i++)
    //                    {
    //                        LoadSectionProducts(Sections[sectionIdLocal], StoreRequest.URL1[i], StoreRequest.product1[i], 0);


    //                    }

    //                    break;
    //                case 1:
    //                    for (int i = 0; i < StoreRequest.URL2.Count; i++)
    //                    {
    //                        LoadSectionProducts(Sections[sectionIdLocal], StoreRequest.URL2[i], StoreRequest.product2[i], 0);


    //                    }

    //                    break;



    //                case 2:
    //                    for (int i = 0; i < StoreRequest.URL3.Count; i++)
    //                    {
    //                        LoadSectionProducts(Sections[sectionIdLocal], StoreRequest.URL3[i], StoreRequest.product3[i], 0);


    //                    }

    //                    break;



    //                case 3:
    //                    for (int i = 0; i < StoreRequest.URL4.Count; i++)
    //                    {
    //                        LoadSectionProducts(Sections[sectionIdLocal], StoreRequest.URL4[i], StoreRequest.product4[i], 1);


    //                    }

    //                    break;





    //                case 4:
    //                    for (int i = 0; i < StoreRequest.URL5.Count; i++)
    //                    {
    //                        LoadSectionProducts(Sections[sectionIdLocal], StoreRequest.URL5[i], StoreRequest.product5[i], 1);


    //                    }

    //                    break;



    //                case 5:
    //                    for (int i = 0; i < StoreRequest.URL6.Count; i++)
    //                    {
    //                        LoadSectionProducts(Sections[sectionIdLocal], StoreRequest.URL6[i], StoreRequest.product6[i], 1);


    //                    }

    //                    break;



    //                case 6:
    //                    for (int i = 0; i < StoreRequest.URL7.Count; i++)
    //                    {
    //                        LoadSectionProducts(Sections[sectionIdLocal], StoreRequest.URL7[i], StoreRequest.product7[i], 2);


    //                    }

    //                    break;



    //                case 7:
    //                    for (int i = 0; i < StoreRequest.URL8.Count; i++)
    //                    {
    //                        LoadSectionProducts(Sections[sectionIdLocal], StoreRequest.URL8[i], StoreRequest.product8[i], 2);


    //                    }

    //                    break;



    //                case 8:
    //                    for (int i = 0; i < StoreRequest.URL9.Count; i++)
    //                    {
    //                        LoadSectionProducts(Sections[sectionIdLocal], StoreRequest.URL9[i], StoreRequest.product9[i], 2);


    //                    }

    //                    break;
    //            }







    //        }
    //        catch
    //        {
    //            print("Failed");



    //        }
    //    }
    //}




}
