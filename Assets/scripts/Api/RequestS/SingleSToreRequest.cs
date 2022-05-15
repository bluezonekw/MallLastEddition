using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RestSharp;
using Newtonsoft;
using Newtonsoft.Json;
using System;

public class SingleSToreRequest : MonoBehaviour
{
    public GameObject CategoryParent;
    public RequesStoresInHall requesStores;
    public bool Loaded;
    public FirstStoreRequest SingleStore;
    public List<string> product1, URL1, product2, URL2, product3, URL3, product4, URL4, product5, URL5, product6, URL6, product7, URL7, product8, URL8, product9, URL9;
    public List<int> SectionId;
    public List<String> SlidderRight, slidderLeft, sliddderFront;
    SectionRequest s1;
    public static int StaticStoreId;
    public int StoreId;
    public int NumberOFProductPerRequest;

public Transform[] Childreen;
private void OnEnable() {
    for(int i=0;i<Childreen.Length;i++){

if(Childreen[i].tag=="UIShop"){
    Childreen[i].gameObject.SetActive(true);
}


    }
}

private void OnDisable() {
       for(int i=0;i<Childreen.Length;i++){

if(Childreen[i].tag=="UIShop"){
    Childreen[i].gameObject.SetActive(false);
}


    }
}
 void Awake() {
    Childreen=this.transform.GetComponentsInChildren<Transform>(true);
}
    // Start is called before the first frame update
    public GameObject GiftBox;
    void Start()
    {
        // System.Random random = new System.Random();

          foreach(var gift in loadAllshops.AllGiftBox.data){
        if(gift.stores.Contains(gameObject.name)){
GameObject g=GameObject.Instantiate(GiftBox,transform);
g.GetComponent<BoxGiftcollect>().code=gift.code;
g.GetComponent<BoxGiftcollect>().coins=0;
g.GetComponent<BoxGiftcollect>().discount=gift.discount;
g.GetComponent<BoxGiftcollect>().id=gift.id;
        }
        }
StoreId=int.Parse( gameObject.name);
       StaticStoreId=StoreId;

    }
  public string AuthToken()
    {
        try{

        if(!UPDownMenu.Login)
        {
            return ApiClasses.Register.data.token;
        }
        else

        {

            return ApiClasses.Login.data.original.access_token;

        }
        }
        catch{
            return " ";
        }

    }
    IEnumerator LoadStoreInfo()
    {


       // StoreId = requesStores.Halls_info.data.data.ToArray()[int.Parse(gameObject.name) - 1].id;
        SectionId.Clear();
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



                GameObject.Instantiate(requesStores.Category[SingleStore.data.store.category_id - 1], CategoryParent.transform);
            }
            else
            {


                GameObject.Instantiate(requesStores.Category[int.Parse(SingleStore.data.store.parent_id) - 1], CategoryParent.transform);

            }
        yield return response.Content;
    }
    public void RequestBanneAndLogo()
    {



        if (CheckEnterShop.EnterShop && CheckEnterShop.EnteredStore == this.gameObject.name)
        {
           
            StartCoroutine(LoadStoreInfo());
            Loaded = true;
            welc=GameObject.Instantiate(requesStores.WelcomMessage, GameObject.FindGameObjectWithTag("MainCanvas").transform);
    	    StartCoroutine(WaitWelcomeMessage());

try{
                foreach (LeftSlidder s in SingleStore.data.sliders.left)
                {
                    slidderLeft.Add(s.src);



                }

}
catch{



}

try{
                foreach (RightSlidder s in SingleStore.data.sliders.right)
                {
                    SlidderRight.Add(s.src);


                }

}
catch{



}

try{
                foreach (CenterSlidder s in SingleStore.data.sliders.center)
                {
                    sliddderFront.Add(s.src);



                }

}
catch{



}

                foreach (var sectionms in SingleStore.data.sections)
                {
                    
                    
                    if (sectionms.wall == "right" && sectionms.position == "right")
                    {
                        SectionId.Add(sectionms.id);


if(sectionms.product!=null)
{
                        product1.Add(sectionms.product.id.ToString());
                        URL1.Add(sectionms.product.img);

}


                    }
                    if (sectionms.wall == "right" && sectionms.position == "center")
                    {
                        SectionId.Add(sectionms.id);
if(sectionms.product!=null)
{
                        product2.Add(sectionms.product.id.ToString());
                        URL2.Add(sectionms.product.img);
}
                    }

                    if (sectionms.wall == "right" && sectionms.position == "left")
                    {
                        SectionId.Add(sectionms.id);
if(sectionms.product!=null)
{
                        product3.Add(sectionms.product.id.ToString());
                        URL3.Add(sectionms.product.img);
}
                    }


                    if (sectionms.wall == "center" && sectionms.position == "right")
                    {
                        SectionId.Add(sectionms.id);
if(sectionms.product!=null)
{
                        product4.Add(sectionms.product.id.ToString());
                        URL4.Add(sectionms.product.img);
}
                    }

                    if (sectionms.wall == "center" && sectionms.position == "center")
                    {
                        SectionId.Add(sectionms.id);
if(sectionms.product!=null)
{
                        product5.Add(sectionms.product.id.ToString());
                        URL5.Add(sectionms.product.img);
}
                    }



                    if (sectionms.wall == "center" && sectionms.position == "left")
                    {
                        SectionId.Add(sectionms.id);
if(sectionms.product!=null)
{
                        product6.Add(sectionms.product.id.ToString());
                        URL6.Add(sectionms.product.img);
}
                    }




                    if (sectionms.wall == "left" && sectionms.position == "right")
                    {
                        SectionId.Add(sectionms.id);
if(sectionms.product!=null)
{
                        product7.Add(sectionms.product.id.ToString());
                        URL7.Add(sectionms.product.img);
}
                    }


                    if (sectionms.wall == "left" && sectionms.position == "center")
                    {
                        SectionId.Add(sectionms.id);
if(sectionms.product!=null)
{
                        product8.Add(sectionms.product.id.ToString());
                        URL8.Add(sectionms.product.img);
}
                    }






                    if (sectionms.wall == "left" && sectionms.position == "left")
                    {
                        SectionId.Add(sectionms.id);
if(sectionms.product!=null)
{
                        product9.Add(sectionms.product.id.ToString());
                        URL9.Add(sectionms.product.img);
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


IEnumerator WaitWelcomeMessage(){

welc.GetComponent<WelcomeMessageToShop>().ShopName.Text=SingleStore.data.store.name;
            StartCoroutine(DownloadRawImage(SingleStore.data.store.logo, welc.GetComponent<WelcomeMessageToShop>().ShopLogo));
yield return new WaitForSeconds(10);
Destroy(welc);
}


   IEnumerator DownloadRawImage(string url, RawImage I)
    {


        WWW www = new WWW(url);
        yield return www;
        
try
        {
            I.texture=www.texture;

        }
        catch (Exception ex)
        {


        }

    }

}
