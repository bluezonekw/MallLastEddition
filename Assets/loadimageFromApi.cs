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
    SectionRequest request;
    bool firstslide;
    public static StoreProduct ProductRequst;
    public GameObject DetailsMenu;
    GameObject MenuCreated;
    // Start is called before the first frame update
    void Start()
    {
        Rindex = Lindex = Findex = 0;
        StoreRequest = GetComponent<SingleSToreRequest>();





    }
    public void LoadProduct(int sectionIdLocal)
    {

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
            request.AddHeader("auth-token", AuthToken());
            request.AlwaysMultipartFormData = true;
            IRestResponse response = client.Execute(request);
            ProductRequst = JsonConvert.DeserializeObject<StoreProduct>(response.Content);
            if (ProductRequst.statsu == 1)
            {
                if (sectionIdLocal <= 2 && sectionIdLocal >= 0)
                {
                     MenuCreated = GameObject.Instantiate(DetailsMenu, RS.transform.parent.transform);


                }

                else

                if (sectionIdLocal <= 5 && sectionIdLocal >= 3)
                {
                     MenuCreated = GameObject.Instantiate(DetailsMenu, FS.transform.parent.transform);
                }

                else

                if (sectionIdLocal <= 8  && sectionIdLocal >= 5  )
                {
                     MenuCreated = GameObject.Instantiate(DetailsMenu, LS.transform.parent.transform);
                }
            }
        }
        catch
        {
            Debug.Log("Ana msh fadelkom");
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
            return ApiClasses.Register.data.token;
        }
        catch

        {

            return ApiClasses.Login.data.original.access_token;

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

            /// load RightWall RightPostion
            LoadIntialProduct(Sections[0], StoreRequest.URL1[0], StoreRequest.product1[0], "01", 0, StoreRequest.SectionId[0].ToString());


            /// load RightWall CenterPostion
            LoadIntialProduct(Sections[1], StoreRequest.URL2[0], StoreRequest.product2[0], "01", 0, StoreRequest.SectionId[1].ToString());

            /// load RightWall LeftPostion

            LoadIntialProduct(Sections[2], StoreRequest.URL3[0], StoreRequest.product3[0], "01", 0, StoreRequest.SectionId[2].ToString());




            /// load CenterWall RightPostion
            LoadIntialProduct(Sections[3], StoreRequest.URL4[0], StoreRequest.product4[0], "01", 1, StoreRequest.SectionId[3].ToString());


            /// load CenterWall CenterPostion
            LoadIntialProduct(Sections[4], StoreRequest.URL5[0], StoreRequest.product5[0], "01", 1, StoreRequest.SectionId[4].ToString());

            /// load CenterWall LeftPostion
            try
            {
                LoadIntialProduct(Sections[5], StoreRequest.URL6[0], StoreRequest.product6[0], "01", 1, StoreRequest.SectionId[5].ToString());
            }
            catch
            {

            }



            /// load LeftWall RightPostion
            LoadIntialProduct(Sections[6], StoreRequest.URL7[0], StoreRequest.product7[0], "01", 2, StoreRequest.SectionId[6].ToString());


            /// load LeftWall CenterPostion
            LoadIntialProduct(Sections[7], StoreRequest.URL8[0], StoreRequest.product8[0], "01", 2, StoreRequest.SectionId[7].ToString());

            /// load LeftWall LeftPostion

            LoadIntialProduct(Sections[8], StoreRequest.URL9[0], StoreRequest.product9[0], "01", 2, StoreRequest.SectionId[8].ToString());

           

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
        try
        {
            Sections[sectionIdLocal].transform.GetChild(PostionImage[sectionIdLocal] - 1).gameObject.GetComponent<Animation>().clip = pervious1;
            Sections[sectionIdLocal].transform.GetChild(PostionImage[sectionIdLocal] - 1).gameObject.GetComponent<Animation>().Play();

            Sections[sectionIdLocal].transform.GetChild(PostionImage[sectionIdLocal]).gameObject.GetComponent<Animation>().clip = pervious2;
            Sections[sectionIdLocal].transform.GetChild(PostionImage[sectionIdLocal]).gameObject.GetComponent<Animation>().Play();


            PostionImage[sectionIdLocal]--;
        }
        catch
        {

        }
    }


    public void nextSection(int sectionIdLocal)
    {


        if (!string.IsNullOrEmpty(section_Page[sectionIdLocal]))
        {
            request = StoreRequest.LoadSectionImage(StoreRequest.SectionId[sectionIdLocal].ToString(), section_Page[sectionIdLocal]);

            if (request.statsu == 1)
            {
                if (sectionIdLocal <= 2 && sectionIdLocal >= 0)
                {
                    foreach (SectionRequestData Product in request.data.data.ToArray())
                    {
                        LoadSectionProducts(Sections[sectionIdLocal], Product.img, Product.id.ToString(), 0);


                    }
                }



                if (sectionIdLocal <= 5 && sectionIdLocal >= 3)
                {
                    foreach (SectionRequestData Product in request.data.data.ToArray())
                    {
                        LoadSectionProducts(Sections[sectionIdLocal], Product.img, Product.id.ToString(), 1);


                    }
                }



                if (sectionIdLocal >= 5 && sectionIdLocal <= 8)
                {
                    foreach (SectionRequestData Product in request.data.data.ToArray())
                    {
                        LoadSectionProducts(Sections[sectionIdLocal], Product.img, Product.id.ToString(), 2);


                    }
                }
                if (request.data.next_page_url == null)
                {
                    section_Page[sectionIdLocal] = null;
                }
                else
                {
                    section_Page[sectionIdLocal] = (int.Parse(section_Page[sectionIdLocal]) + 1).ToString();
                }

                /*
               List<GameObject> listOfGAme=new List<GameObject>();
                foreach (Transform child in Sections[sectionIdLocal].transform.ch)
                {

                    listOfGAme.Add(child.gameObject);
                }





                    Products[sectionIdLocal]=listOfGAme.ToArray();
                */


            }
            else
            {
                Debug.Log(request.message + "    "+ request.statsu.ToString());
            }
        }

        //   GameObject[] khag = Products[sectionIdLocal];
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

    }





}
