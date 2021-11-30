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


    public ArabicText CostwithDetails;
    // Start is called before the first frame update
    void Start()
    {
        isaddtocart = false;

        indedeximage = 0;
        Name.Text = loadimageFromApi.ProductRequst.data.name;
        SecondName.Text = loadimageFromApi.ProductRequst.data.name;
        cost = loadimageFromApi.ProductRequst.data.regular_price;
       // Cost.Text = cost.ToString();
        if (loadimageFromApi.ProductRequst.data.in_favorite)
        {
            print(loadimageFromApi.ProductRequst.data.in_favorite.ToString()+"       ssss");
            signs.selected = true;
        }
        if (loadimageFromApi.ProductRequst.data.sale_price != null)
        {
            spcialPriceobject.SetActive(true);
            Price.Text= loadimageFromApi.ProductRequst.data.sale_price.ToString() + " Ïß";
            SpecialPrice.Text = loadimageFromApi.ProductRequst.data.regular_price.ToString() + " Ïß";
        }
        else
        {
            spcialPriceobject.SetActive(false);
            Price.Text = loadimageFromApi.ProductRequst.data.regular_price.ToString() + " Ïß";
        }
        desc.Text= loadimageFromApi.ProductRequst.data.description;
        SecondDesc.Text = desc.Text;
        StartCoroutine(DownLoadImagetexture(loadimageFromApi.ProductRequst.data.img, ImageExample.GetComponent<RawImage>()));
        PanelLocation.GetComponent<RectTransform>().sizeDelta = new Vector2(3.2431f, 0.5f*(loadimageFromApi.ProductRequst.data.attributes.Capacity ));
        foreach (string s in loadimageFromApi.ProductRequst.data.slider)
        {
            
                g = GameObject.Instantiate(ImageExample, ImageExample.transform.parent.transform);
                StartCoroutine(DownLoadImagetexture(s, g.GetComponent<RawImage>()));
            
        }
        foreach (ProductAttribute p in loadimageFromApi.ProductRequst.data.attributes)
        {

            
                g = GameObject.Instantiate(Panel);
                g.transform.parent = PanelLocation.transform;
                g.name = p.id.ToString();
                g.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<ArabicText>().Text = p.name;
                g.transform.localPosition = new Vector3(g.transform.localPosition.x, g.transform.localPosition.y, 0);
                g.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));












                isdestroy = false;
            if(  p.selection_type!= "single")
            {




                g.transform.GetChild(1).gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Toggle>().group = null;



            }
                foreach (ProductOption optionss in p.options)
                {
                    T = GameObject.Instantiate(g.transform.GetChild(1).gameObject.transform.GetChild(0).transform.GetChild(0).gameObject, g.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).transform.parent.transform);
                T.transform.GetChild(1).GetComponent<ArabicText>().Text = optionss.name;
                T.transform.GetChild(2).GetComponent<ArabicText>().Text = optionss.price + " K.D";
                    T.name = optionss.id.ToString();
                Toggles.Add(T.GetComponent<Toggle>());
                T.GetComponent<Toggle>().onValueChanged = toggleEvent;





                if (!isdestroy)
                    {

                        GameObject.Destroy(g.transform.GetChild(1).gameObject.transform.GetChild(0).transform.GetChild(0).gameObject);
                        isdestroy = true;
                    }

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
                Costdetails += float.Parse(Tog.transform.GetChild(2).GetComponent<ArabicText>().Text.ToString().Replace(" K.D", ""));
            }

        }
        cost = (cost * int.Parse(Quntity.text.ToString()))+Costdetails;
   CostText.Text= cost.ToString()+" K.D";
        CostwithDetails.Text = CostText.Text;
     
    }
    public void AddTocart()
    {
        var client = new RestClient("http://mymall-kw.com/api/V1/carts");
        client.Timeout = -1;
        var request = new RestRequest(Method.POST);
        request.AddHeader("password-api", "mall_2021_m3m");
        request.AddHeader("lang-api", "ar");
        request.AddHeader("auth-token", AuthToken());
        request.AlwaysMultipartFormData = true;
        request.AddParameter("product_id", loadimageFromApi.ProductRequst.data.id.ToString());
        request.AddParameter("quantity",Quntity.text );

        for(int x = 0; x < OptionsId.Count-1; x++)
        {
           
            request.AddParameter("options["+x.ToString()+"]", OptionsId[x]);
        }
        IRestResponse response = client.Execute(request);
        addTocartrequest= JsonConvert.DeserializeObject<AddTocart>(response.Content);

        GameObject.Instantiate(Popup);
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
