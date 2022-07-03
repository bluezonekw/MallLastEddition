using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RestSharp;
using Newtonsoft;
using Newtonsoft.Json;
using System;
using System.IO;

public class SingleSToreRequest : MonoBehaviour
{
    public GameObject CategoryParent;
    public RequesStoresInHall requesStores;
    public bool Loaded;
    public FirstStoreRequest SingleStore;
    public List<string> product1, URL1, product2, URL2, product3, URL3, product4, URL4, product5, URL5, product6, URL6, product7, URL7, product8, URL8, product9, URL9;
    public Dictionary<int, int> SectionId = new Dictionary<int, int>(9);
    public List<String> SlidderRight, slidderLeft, sliddderFront;
    SectionRequest s1;
    public static int StaticStoreId;
    public int StoreId;
    public int NumberOFProductPerRequest;

    //public List<Transform> Childreen;

    private void OnDisable()
    {

    }

    // Start is called before the first frame update
    public GameObject GiftBox;
    void Start()
    {
        texture = new Texture2D(1, 1);
        try
        {
            foreach (var gift in loadAllshops.AllGiftBox.data)
            {
                if (gift.stores.Contains(gameObject.name))
                {
                   Debug.Log(gift.name);
                    GameObject g = GameObject.Instantiate(GiftBox, transform);
                    g.GetComponent<BoxGiftcollect>().code = gift.code;
                    g.GetComponent<BoxGiftcollect>().coins = 0;
                    g.GetComponent<BoxGiftcollect>().discount = gift.discount;
                    g.GetComponent<BoxGiftcollect>().id = gift.id;
                }
            }

        }
        catch
        {

        }
        StoreId = int.Parse(gameObject.name);
        StaticStoreId = StoreId;

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
            return " ";
        }

    }
    IEnumerator LoadStoreInfo()
    {



        var client = new RestClient(@"https://mymall-kw.com/api/V1/get-single-store?store_id=" + StoreId.ToString());
        client.Timeout = -1;
        var request = new RestRequest(Method.GET);
        request.AddHeader("password_api", "mall_2021_m3m");
        request.AddHeader("lang_api", "en");
        request.AddHeader("auth-token", AuthToken());
        request.AlwaysMultipartFormData = true;
        IRestResponse response = client.Execute(request);
        SingleStore = JsonConvert.DeserializeObject<FirstStoreRequest>(response.Content);
        if (SingleStore.data.store.parent_id == null)
        {



            // GameObject.Instantiate(requesStores.Category[SingleStore.data.store.category_id - 1], CategoryParent.transform);
            GameObject.Instantiate(Resources.Load<GameObject>("Category Fbx/"+ loadAllshops.CtegoryShop[SingleStore.data.store.category_id - 1])  , CategoryParent.transform);
        }
        else
        {


            // GameObject.Instantiate(requesStores.Category[int.Parse(SingleStore.data.store.parent_id) - 1], CategoryParent.transform);

            GameObject.Instantiate(Resources.Load<GameObject>("Category Fbx/" + loadAllshops.CtegoryShop[int.Parse(SingleStore.data.store.parent_id) - 1]), CategoryParent.transform);
        }
        yield return response.Content;
    }
    public void RequestBanneAndLogo()
    {



        if (CheckEnterShop.EnterShop && CheckEnterShop.EnteredStore == this.gameObject.name)
        {
            welc = GameObject.Instantiate(requesStores.WelcomMessage, GameObject.FindGameObjectWithTag("MainCanvas").transform);
            StartCoroutine(WaitWelcomeMessage());
            StartCoroutine(LoadStoreInfo());
            Loaded = true;


            try
            {
                foreach (LeftSlidder s in SingleStore.data.sliders.left)
                {
                    slidderLeft.Add(s.src);



                }

            }
            catch
            {



            }

            try
            {
                foreach (RightSlidder s in SingleStore.data.sliders.right)
                {
                    SlidderRight.Add(s.src);


                }

            }
            catch
            {



            }

            try
            {
                foreach (CenterSlidder s in SingleStore.data.sliders.center)
                {
                    sliddderFront.Add(s.src);



                }

            }
            catch
            {



            }

            foreach (var sectionms in SingleStore.data.sections)
            {


                if (sectionms.wall == "right" && sectionms.position == "right")
                {
                    SectionId.Add(0, sectionms.id);


                    if (sectionms.products.Count != 0)
                    {
                        foreach (var product in sectionms.products)
                        {
                            product1.Add(product.id.ToString());
                            URL1.Add(product.img);
                        }

                    }


                }
                if (sectionms.wall == "right" && sectionms.position == "center")
                {
                    SectionId.Add(1, sectionms.id);

                    if (sectionms.products.Count != 0)
                    {
                        foreach (var product in sectionms.products)
                        {
                            product2.Add(product.id.ToString());
                            URL2.Add(product.img);
                        }
                    }
                }

                if (sectionms.wall == "right" && sectionms.position == "left")
                {
                    SectionId.Add(2, sectionms.id);

                    if (sectionms.products.Count != 0)
                    {
                        foreach (var product in sectionms.products)
                        {
                            product3.Add(product.id.ToString());
                            URL3.Add(product.img);
                        }
                    }
                }


                if (sectionms.wall == "center" && sectionms.position == "right")
                {
                    SectionId.Add(3, sectionms.id);

                    if (sectionms.products.Count != 0)
                    {
                        foreach (var product in sectionms.products)
                        {
                            product4.Add(product.id.ToString());
                            URL4.Add(product.img);
                        }
                    }
                }

                if (sectionms.wall == "center" && sectionms.position == "center")
                {
                    SectionId.Add(4, sectionms.id);

                    if (sectionms.products.Count != 0)
                    {
                        foreach (var product in sectionms.products)
                        {
                            product5.Add(product.id.ToString());
                            URL5.Add(product.img);
                        }
                    }
                }



                if (sectionms.wall == "center" && sectionms.position == "left")
                {
                    SectionId.Add(5, sectionms.id);

                    if (sectionms.products.Count != 0)
                    {
                        foreach (var product in sectionms.products)
                        {
                            product6.Add(product.id.ToString());
                            URL6.Add(product.img);
                        }
                    }
                }




                if (sectionms.wall == "left" && sectionms.position == "right")
                {
                    SectionId.Add(6, sectionms.id);

                    if (sectionms.products.Count != 0)
                    {
                        foreach (var product in sectionms.products)
                        {
                            product7.Add(product.id.ToString());
                            URL7.Add(product.img);
                        }
                    }
                }


                if (sectionms.wall == "left" && sectionms.position == "center")
                {
                    SectionId.Add(7, sectionms.id);

                    if (sectionms.products.Count != 0)
                    {
                        foreach (var product in sectionms.products)
                        {
                            product8.Add(product.id.ToString());
                            URL8.Add(product.img);
                        }
                    }
                }






                if (sectionms.wall == "left" && sectionms.position == "left")
                {
                    SectionId.Add(8, sectionms.id);

                    if (sectionms.products.Count != 0)
                    {
                        foreach (var product in sectionms.products)
                        {
                            product9.Add(product.id.ToString());
                            URL9.Add(product.img);
                        }
                    }
                }


            }














        }

    }
    GameObject welc;
    // Update is called once per frame
    void Update()
    {

        if (!Loaded)
        {
            RequestBanneAndLogo();


        }

    }


    IEnumerator WaitWelcomeMessage()
    {
        StartCoroutine(DownloadRawImage(welc.GetComponent<WelcomeMessageToShop>().ShopLogo));
        welc.GetComponent<WelcomeMessageToShop>().ShopName.Text = loadAllshops.s.NameShop[int.Parse(gameObject.name)];

        yield return new WaitForSeconds(5);
        Destroy(welc);
    }
    Texture2D texture;
    byte[] byteArray;
    IEnumerator DownloadRawImage(RawImage I)
    {

        if (File.Exists(Application.persistentDataPath + "/Door/" + gameObject.name + ".png"))

        {
 byteArray = File.ReadAllBytes(Application.persistentDataPath + "/Door/" + gameObject.name + ".png");
            yield return byteArray;
         
            texture.SetPixels(texture.GetPixels(0, 0, texture.width, texture.height));
            texture.Apply();
            texture.LoadImage(byteArray);

            I.texture = texture;
            texture = null;
        }
        else
        {

            yield return 0;
        }
        texture=null;
        byteArray=null;
    }

}
