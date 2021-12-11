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
    GameObject g,T;
    /// <summary>
    /// Gameobject MainDetailsofProduct
    /// </summary>
    public GameObject Panel;
    public Transform PanelLocation;
    public ArabicText CostText;
    bool isdestroy;
    private float cost,Costdetails;
    int indedeximage;
    public ArabicText SecondDesc, SecondName;
    public FavoriteSign signs;
   public List<Toggle> Toggles;
    public Toggle.ToggleEvent toggleEvent;
    public List<string> OptionsId;
    public static bool isaddtocart;
    public Text Quntity;
    public static AddTocart addTocartrequest;
    public GameObject Popup;

    public GameObject ToggleExample;
    
    public ArabicText CostwithDetails;



    public GameObject MessageObject;
    public ArabicText MessageErorr;
    public ArabicText MoreDetails;

    public ArabicText Total, Buy, Options;

    public GameObject Main, More;

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

        }
        else
        {
            Price.UseHinduNumbers = true;
            SpecialPrice.UseHinduNumbers = true;
            MoreDetails.Text = "المزيد من التفاصيل";
            Buy.Text = "أضافة الى حقيبة التسوق";
            Total.Text = "الأجمالى";
            Options.Text = "اختر الاضافات المناسبة";
            Total.transform.localPosition = new Vector3(70f, -130f, 0f);
            CostwithDetails.transform.localPosition = new Vector3(-110f, -130f, 0f);

        }
        isaddtocart = false;

        indedeximage = 0;
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
        SecondDesc.Text = desc.Text;
        StartCoroutine(DownLoadImagetexture(loadimageFromApi.ProductRequst.data.img, ImageExample.GetComponent<RawImage>()));
     //   PanelLocation.GetComponent<RectTransform>().sizeDelta = new Vector2(3.2431f, 0.5f*(loadimageFromApi.ProductRequst.data.attributes.Capacity ));
        foreach (string s in loadimageFromApi.ProductRequst.data.slider)
        {
            
                g = GameObject.Instantiate(ImageExample, ImageExample.transform.parent.transform);
                StartCoroutine(DownLoadImagetexture(s, g.GetComponent<RawImage>()));
            
        }
        foreach (ProductAttribute p in loadimageFromApi.ProductRequst.data.attributes)
        {

            
                g = GameObject.Instantiate(Panel, PanelLocation.transform);
//g.GetComponent<AspectRatioFitter>().
         /*   g.GetComponent<RectTransform>().anchorMin.Set(0, 0);
            g.GetComponent<RectTransform>().anchorMax.Set(1,1);
            g.GetComponent<RectTransform>().pivot.Set(0.5f, 0.5f);
            g.GetComponent<RectTransform>().anchoredPosition.Set( 0, 0);

            g.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0, 0);
            g.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, 0);
            g.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, 0, 0);
            g.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, 0);
         */
            g.name = p.id.ToString();
                g.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<ArabicText>().Text = p.name;












             //   isdestroy = false;
            if(  p.selection_type!= "single")
            {




                ToggleExample.GetComponent<Toggle>().group = null;



            }
            else
            {

                ToggleExample.GetComponent<Toggle>().group = g.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).GetComponent<ToggleGroup>();


            }
            foreach (ProductOption optionss in p.options)
                {
                    T = GameObject.Instantiate(ToggleExample, g.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0));
                T.transform.GetChild(2).GetComponent<ArabicText>().Text = optionss.name;
                T.transform.GetChild(3).GetComponent<ArabicText>().Text = optionss.price + " K.D";
                    T.name = optionss.id.ToString();
                Toggles.Add(T.GetComponent<Toggle>());
                T.GetComponent<Toggle>().onValueChanged = toggleEvent;





                }

            }


        Calculate();
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
        if (loadimageFromApi.ProductRequst.data.sale_price != null)
        {
            cost =float.Parse(loadimageFromApi.ProductRequst.data.sale_price.ToString());

        }
        else
        {
            cost = float.Parse(loadimageFromApi.ProductRequst.data.regular_price.ToString());

        }

        foreach (Toggle Tog in Toggles)
        {
            if (Tog.isOn)
            {
                OptionsId.Add(Tog.gameObject.name);
                Costdetails += float.Parse(Tog.transform.GetChild(3).GetComponent<ArabicText>().Text.ToString().Replace(" K.D", ""));
            }

        }
        cost = (cost + Costdetails) * int.Parse(Quntity.text.ToString());
        CostText.Text= cost.ToString()+" K.D";
        CostwithDetails.Text = CostText.Text;
     
    }
    public void MessageDisable()
    {

        MessageObject.SetActive(false);

    }
    public void AddTocart()
    {
        if (OptionsId.Count == 0)
        {
            MessageObject.SetActive(true);
            MessageErorr.Text = "من فضلك حدد الخيارات";
            return;


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
        request.AddParameter("product_id", loadimageFromApi.ProductRequst.data.id.ToString());
        request.AddParameter("quantity",Quntity.text );
        for(int x = 0; x < OptionsId.Count; x++)
        {
            print(OptionsId[x] + "     id ");

            request.AddParameter("options["+x.ToString()+"]", OptionsId[x]);
        }
        IRestResponse response = client.Execute(request);
        print(response.Content);
        addTocartrequest= JsonConvert.DeserializeObject<AddTocart>(response.Content);
        if (addTocartrequest.statsu == 0)
        {
            MessageObject.SetActive(true);
            MessageErorr.Text = addTocartrequest.message;
            return;

        }
        GameObject.Instantiate(Popup,GameObject.FindGameObjectWithTag("MainCanvas").transform);
        GameObject.Destroy(gameObject);


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
    // Update is called once per frame
    void Update()
    {
        try
        {
            if (ImageExample.transform.parent.GetChild(indedeximage).transform.localPosition == new Vector3(1.5f, 0, 0))
            {

                ImageExample.transform.parent.GetChild(indedeximage).gameObject.GetComponent<Animation>().clip = anim1;
                ImageExample.transform.parent.GetChild(indedeximage).gameObject.GetComponent<Animation>().Play();

            }
            else
              if (ImageExample.transform.parent.GetChild(indedeximage).transform.localPosition == new Vector3(0, 0, 0) )
            {
                ImageExample.transform.parent.GetChild(indedeximage).gameObject.GetComponent<Animation>().clip = anim2;
                ImageExample.transform.parent.GetChild(indedeximage).gameObject.GetComponent<Animation>().Play();

                indedeximage++;

            }
        }
        catch
        {
            indedeximage = 0;
        }
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
