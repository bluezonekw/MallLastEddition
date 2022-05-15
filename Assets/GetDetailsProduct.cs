using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using RestSharp;
using Newtonsoft.Json;

public class GetDetailsProduct : MonoBehaviour
{

    public ArabicText Name, Price, SpecialPrice, desc;
    public GameObject spcialPriceobject;
    public AnimationClip anim1, anim2;
    public GameObject ImageExample;
    GameObject g;
    /// <summary>
    /// Gameobject MainDetailsofProduct
    /// </summary>
    public GameObject Panel;
    public ArabicText CostText;
    private float cost,Costdetails;
    int indedeximage;
    public ArabicText SecondDesc, SecondName;
    public FavoriteSign signs;
   public List<Toggle> Toggles;
    public List<string> OptionsId;
    public static bool isaddtocart;
    public Text Quntity;
    public static AddTocart addTocartrequest;
    public GameObject Popup;

    
    public ArabicText CostwithDetails;



    public GameObject MessageObject;
   
    public ArabicText MoreDetails;

    public ArabicText Total, Buy, Options;

    public GameObject Main, More;

 public static StoreProduct ProductRequst;
public GameObject CartMenu;
    public void OpenMain()
    {

        More.SetActive(false);
        Main.SetActive(true);
        Main.SetActive(false);
        Main.SetActive(true);



    }
    public void OpenMore()
    {
        Main.SetActive(false);
        More.SetActive(true);
        More.SetActive(false);
        More.SetActive(true);



    }
    // Start is called before the first frame update
    void Start()
    {
        
        
        startAnimation1=true;
        if (UPDownMenu.LanguageValue == 1)
        {

            Price.UseHinduNumbers = false;
            SpecialPrice.UseHinduNumbers = false;
            MoreDetails.Text = "More Dtails";
            Buy.Text = "Add To Cart";
            Total.Text = "Total";
            Options.Text = "Choose Options";
            Total.transform.localPosition=new Vector3(-110f,-130f,0f);
            CostwithDetails.transform.localPosition = new Vector3(70f,-130f,0f);
desc.GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
SecondDesc.GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
        }
        else
        {
            Price.UseHinduNumbers = false;
            SpecialPrice.UseHinduNumbers = false;
            MoreDetails.Text = "المزيد من التفاصيل";
            Buy.Text = "أضافة الى حقيبة التسوق";
            Total.Text = "الأجمالى";
            Options.Text = "اختر الاضافات المناسبة";
            Total.transform.localPosition = new Vector3(70f, -130f, 0f);
            CostwithDetails.transform.localPosition = new Vector3(-110f, -130f, 0f);
desc.GetComponent<Text>().alignment = TextAnchor.MiddleRight;
SecondDesc.GetComponent<Text>().alignment = TextAnchor.MiddleRight;

        }
        isaddtocart = false;

        indedeximage = 0;



if(loadimageFromApi.ProductRequst==null){
           Name.Text =ProductRequst.data.name;
        SecondName.Text =ProductRequst.data.name;
        cost =ProductRequst.data.regular_price;
       // Cost.Text = cost.ToString();
        if (ProductRequst.data.in_favorite)
        {
            signs.selected = true;
        }
        if (ProductRequst.data.sale_price != null)
        {
            spcialPriceobject.SetActive(true);
            Price.Text=ProductRequst.data.sale_price.ToString() + " K.D";
            SpecialPrice.Text =ProductRequst.data.regular_price.ToString() + " K.D";
        }
        else
        {
            spcialPriceobject.SetActive(false);
            Price.Text =ProductRequst.data.regular_price.ToString() + " K.D";
        }
        desc.Text=ProductRequst.data.description;

       
        StartCoroutine(DownLoadImagetexture(ProductRequst.data.img, ImageExample.GetComponent<RawImage>()));
        foreach (string s in ProductRequst.data.slider)
        {
            
                g = GameObject.Instantiate(ImageExample, ImageExample.transform.parent.transform);
                StartCoroutine(DownLoadImagetexture(s, g.GetComponent<RawImage>()));
            
        }



        if (ProductRequst.data.sale_price != null)
        {
            cost = float.Parse(ProductRequst.data.sale_price.ToString());

        }
        else
        {
            cost = float.Parse(ProductRequst.data.regular_price.ToString());

        }
        CostText.Text = cost.ToString() + " K.D";
 CostwithDetails.Text = CostText.Text;




 ////////////
            
        }
else


        {
       
        Name.Text = loadimageFromApi.ProductRequst.data.name;
        SecondName.Text = loadimageFromApi.ProductRequst.data.name;
        cost = loadimageFromApi.ProductRequst.data.regular_price;
       // Cost.Text = cost.ToString();
        if (loadimageFromApi.ProductRequst.data.in_favorite)
        {
            signs.selected = true;
        }
        if (loadimageFromApi.ProductRequst.data.sale_price != null)
        {
            spcialPriceobject.SetActive(true);
            Price.Text= loadimageFromApi.ProductRequst.data.sale_price.ToString() + " K.D";
            SpecialPrice.Text = loadimageFromApi.ProductRequst.data.regular_price.ToString() + " K.D";
        }
        else
        {
            spcialPriceobject.SetActive(false);
            Price.Text = loadimageFromApi.ProductRequst.data.regular_price.ToString() + " K.D";
        }
        desc.Text= loadimageFromApi.ProductRequst.data.description;

       
        StartCoroutine(DownLoadImagetexture(loadimageFromApi.ProductRequst.data.img, ImageExample.GetComponent<RawImage>()));
        foreach (string s in loadimageFromApi.ProductRequst.data.slider)
        {
            
                g = GameObject.Instantiate(ImageExample, ImageExample.transform.parent.transform);
                StartCoroutine(DownLoadImagetexture(s, g.GetComponent<RawImage>()));
            
        }



        if (loadimageFromApi.ProductRequst.data.sale_price != null)
        {
            cost = float.Parse(loadimageFromApi.ProductRequst.data.sale_price.ToString());

        }
        else
        {
            cost = float.Parse(loadimageFromApi.ProductRequst.data.regular_price.ToString());

        }
        CostText.Text = cost.ToString() + " K.D";
 CostwithDetails.Text = CostText.Text;}
    }
    IEnumerator DownLoadImagetexture(string URL, RawImage s)
    {
        WWW www = new WWW(URL);
        yield return www;
        s.texture = www.texture;
        // image.texture = www.texture;
    }

    public void Calculate()
    {
        

        

    OptionsId.Clear();
        Costdetails = 0;

if(loadimageFromApi.ProductRequst==null){

    if (ProductRequst.data.sale_price != null)
        {
            cost =float.Parse(ProductRequst.data.sale_price.ToString());

        }
        else
        {
            cost = float.Parse(ProductRequst.data.regular_price.ToString());

        }

}
else{

        if (loadimageFromApi.ProductRequst.data.sale_price != null)
        {
            cost =float.Parse(loadimageFromApi.ProductRequst.data.sale_price.ToString());

        }
        else
        {
            cost = float.Parse(loadimageFromApi.ProductRequst.data.regular_price.ToString());

        }

}
foreach(Transform child in transform.GetComponentsInChildren<Transform>(true)){

if(child.gameObject.tag=="OptionToggle")
{
if(child.gameObject.GetComponent<Toggle>().isOn){


 OptionsId.Add(child.gameObject.name);



try{
Costdetails+=float.Parse(child.gameObject.GetComponent<OptionForAttribute>().PriceOption.Text.ToString().Replace("\n","").Replace(" K.D",""));
 }
 catch{

Costdetails+=float.Parse("0");
 }
}

}


}


        cost = (cost + Costdetails) ;
        CostText.Text= cost.ToString()+" K.D";
        CostwithDetails.Text = CostText.Text;
     
    }
   
    public void AddTocart()
    {
if(!ApiClasses.Vistor){


if(loadimageFromApi.ProductRequst==null){
   if (OptionsId.Count == 0&&ProductRequst.data.attributes.Count!=0)
        {
	GameObject g= GameObject.Instantiate(MessageObject, GameObject.FindGameObjectWithTag("MainCanvas").transform);
            MessageObject.SetActive(true);
 if (UPDownMenu.LanguageValue == 1)
        {
           g.GetComponent<optionPopUp>().Message.Text = "Please Choose Options";
}else
{
 g.GetComponent<optionPopUp>().Message.Text = "من فضلك حدد الخيارات";
}
            return;


        }
}
else{
        if (OptionsId.Count == 0&&loadimageFromApi.ProductRequst.data.attributes.Count!=0)
        {
	GameObject g= GameObject.Instantiate(MessageObject, GameObject.FindGameObjectWithTag("MainCanvas").transform);
            MessageObject.SetActive(true);
 if (UPDownMenu.LanguageValue == 1)
        {
           g.GetComponent<optionPopUp>().Message.Text = "Please Choose Options";
}else
{
 g.GetComponent<optionPopUp>().Message.Text = "من فضلك حدد الخيارات";
}
            return;


        }
}
        var client = new RestClient("http://mymall-kw.com/api/V1/carts");
        client.Timeout = -1;
        var request = new RestRequest(Method.POST);
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
        if(loadimageFromApi.ProductRequst==null){
             request.AddParameter("product_id", ProductRequst.data.id.ToString());
        }
        else{
        request.AddParameter("product_id", loadimageFromApi.ProductRequst.data.id.ToString());}
        request.AddParameter("quantity","1" );
        for(int x = 0; x < OptionsId.Count; x++)
        {

            request.AddParameter("options["+x.ToString()+"]", OptionsId[x]);
        }
        IRestResponse response = client.Execute(request);
        print(response.Content);
        addTocartrequest= JsonConvert.DeserializeObject<AddTocart>(response.Content);
        if (addTocartrequest.statsu == 0)
        {
GameObject g= GameObject.Instantiate(MessageObject, GameObject.FindGameObjectWithTag("MainCanvas").transform);
            MessageObject.SetActive(true);
           g.GetComponent<optionPopUp>().Message.Text = addTocartrequest.message;


          
            return;

        }
try{
        GameObject.Instantiate(Popup,GameObject.FindGameObjectWithTag("MainCanvas").transform);
}
catch{
GameObject.Instantiate(CartMenu,GameObject.FindGameObjectWithTag("MainCanvas").transform);
}    
    GameObject.Destroy(gameObject);
CheckEnterShop.CartEmpty=false;



}
else{
 GameObject.Instantiate(loginGameobject, GameObject.FindGameObjectWithTag("MainCanvas").transform);


}

    }
public GameObject loginGameobject;

    public string AuthToken()
    {

        if(!UPDownMenu.Login)
        {
            return ApiClasses.Register.data.token;
        }
        else

        {

            return ApiClasses.Login.data.original.access_token;

        }


    }
 bool startAnimation1;

 IEnumerator ImageAnimation()
    {
  	 startAnimation1=false;
      

     
        
ImageExample.transform.parent.GetChild(indedeximage).gameObject.GetComponent<Animation>().Play("02");
if(indedeximage+1>ImageExample.transform.parent.childCount-1){

ImageExample.transform.parent.GetChild(0).gameObject.GetComponent<Animation>().Play("01");
indedeximage=0;
}
else
{
ImageExample.transform.parent.GetChild(indedeximage+1).gameObject.GetComponent<Animation>().Play("01");
indedeximage++;
}
     
        
yield return new WaitForSeconds(3);

startAnimation1=true;
    }

    // Update is called once per frame
    void Update()
    {

 if (startAnimation1)
        {
		if(ImageExample.transform.parent.childCount>1){
					 StartCoroutine(ImageAnimation());
  				     }
		else
		 if(ImageExample.transform.parent.childCount==1){
ImageExample.transform.parent.GetChild(indedeximage).transform.localPosition = new Vector3(1.5f, 0, 0);
						
startAnimation1=false;

				        }       

           
       }
      



       /*
        try
        {
            if (ImageExample.transform.parent.GetChild(indedeximage).transform.localPosition == new Vector3(1.5f, 0, 0))
            {
                print(indedeximage.ToString() + "    anim1");

                ImageExample.transform.parent.GetChild(indedeximage).gameObject.GetComponent<Animation>().clip = anim1;
                ImageExample.transform.parent.GetChild(indedeximage).gameObject.GetComponent<Animation>().Play();

            }
            else
              if (ImageExample.transform.parent.GetChild(indedeximage).transform.localPosition == new Vector3(0, 0, 0) )
            {
                print(indedeximage.ToString() + "    anim2");
                ImageExample.transform.parent.GetChild(indedeximage).gameObject.GetComponent<Animation>().clip = anim2;
                ImageExample.transform.parent.GetChild(indedeximage).gameObject.GetComponent<Animation>().Play();

                indedeximage++;

            }
        }
        catch
        {
            print(indedeximage.ToString() + "    catch");
            indedeximage = 0;
        }*/
    }
    public string FindSubstringStartandEnd(string Full,char start,char end)
    {
        string value = "";
        bool x = false;

        foreach(char c in Full)
        {

            if (c == start)
            {
                x = true;
                continue;

            }
            if (c == end)
            {

                x = false;

            }

            if (x)
            {

                value += c;
            }



        }
       

        return value;



    }
}
