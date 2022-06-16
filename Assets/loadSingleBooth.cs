using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class loadSingleBooth : MonoBehaviour
{
    public Material DefaultMat;
    public GameObject Logo1, Logo2,logo1_1;
    private Material LocalMat1, LocalMat2, LocalMat1_1;
    
    public BoothResponse booth;
    public RawImage B1, B2,b3;
    public List<Dataforproduct> AllProduct = new List<Dataforproduct>();
    public GameObject productExample;
    // Start is called before the first frame update
    void Start()
    {
        GameObject g = new GameObject();
        try
        {
            var client = new RestClient("http://mymall-kw.com/api/V1/get-single-booth?booth_id=" + gameObject.name);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("password_api", "mall_2021_m3m");
            request.AddHeader("lang_api", "en");
            request.AlwaysMultipartFormData = true;
            IRestResponse response = client.Execute(request);
            booth = JsonConvert.DeserializeObject<BoothResponse>(response.Content);

        }
        catch
        {
            booth = new BoothResponse();
        }
        if (booth.data == null || booth.data.booth.is_active != 1)
        {

            GameObject.Destroy(gameObject);

        }
        else
        {
            StartCoroutine(LoadLogo(booth.data.booth.logo));
          
            ///////to be changed
            StartCoroutine(GetTexture(booth.data.booth.banner,b3));
            StartCoroutine(GetTexture(booth.data.booth.banner_left, B1));
            StartCoroutine(GetTexture(booth.data.booth.banner_right, B2));
            foreach (var product in booth.data.products)
            {
               g = GameObject.Instantiate(productExample, productExample.transform.parent);
                  StartCoroutine(loadTexture(product.img, g.GetComponent<LoadBoothProduct>().Icon));
               
               g.gameObject.name = product.id.ToString();


                g.gameObject.GetComponent<LoadBoothProduct>().Name.text = product.name;

                if (product.sale_price == null)
                {
                    g.gameObject.GetComponent<LoadBoothProduct>().Price.text = product.regular_price.ToString() + " KWD";
                }
                else
                {
                    g.gameObject.GetComponent<LoadBoothProduct>().Price.text = product.sale_price.ToString() + " KWD";

                }

                g.SetActive(true);





            }





        }
       
    }




    // Update is called once per frame
    void Update()
    {

    }




    IEnumerator GetTexture(string url , RawImage r)
    {
        if (url.ToLower().EndsWith("jp"))
        {

            url += "g";
        }
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();
        if (www.result == UnityWebRequest.Result.Success)
        {
            r.texture = DownloadHandlerTexture.GetContent(www);
        }
    }
    IEnumerator LoadLogo(string url)
    {
        
        Logo1.GetComponent<MeshRenderer>().materials[0] = new Material(DefaultMat.shader);
        LocalMat1 = Logo1.GetComponent<MeshRenderer>().materials[0];
        logo1_1.GetComponent<MeshRenderer>().materials[0] = new Material(DefaultMat.shader);
        LocalMat1_1 = logo1_1.GetComponent<MeshRenderer>().materials[0];


       
        Logo2.GetComponent<MeshRenderer>().materials[0] = new Material(DefaultMat.shader);
        LocalMat2 = Logo2.GetComponent<MeshRenderer>().materials[0];
     
        if (url.ToLower().EndsWith("jp"))
        {

            url += "g";
        }
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();
        if (www.result == UnityWebRequest.Result.Success)
        {
            LocalMat1.SetTexture("_BaseMap", DownloadHandlerTexture.GetContent(www));
            LocalMat2.SetTexture("_BaseMap", DownloadHandlerTexture.GetContent(www));
            LocalMat1_1.SetTexture("_BaseMap", DownloadHandlerTexture.GetContent(www));
        }


    }
    IEnumerator loadTexture(string url, RawImage r)
    {
        if (url.ToLower().EndsWith("jp"))
        {

            url += "g";
        }
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();
        if (www.result == UnityWebRequest.Result.Success)
        {
            r.texture = DownloadHandlerTexture.GetContent(www);
        }
    }
}

[System.Serializable]
public class Booth
{
    public int id { get; set; }
    public int is_active { get; set; }
    public int category_id { get; set; }
    public string logo { get; set; }
    public string banner { get; set; }
    public string banner_right { get; set; }
    public string banner_left { get; set; }
    public object parent_id { get; set; }
    public string name { get; set; }
    public string welcome_message { get; set; }
    public BoothProfile profile { get; set; }
    public BoothCategory category { get; set; }
}

public class BoothCategory
{
    public int id { get; set; }
    public string name { get; set; }
    public string icon { get; set; }
    public string sort { get; set; }
    public object parent_id { get; set; }
}

public class BoothData
{
    public Booth booth { get; set; }
    public BoothSliders sliders { get; set; }
    public List<BoothProduct> products { get; set; }
}

public class BoothProduct
{
    public int id { get; set; }
    public string img { get; set; }
    public string name { get; set; }
    public int? sale_price { get; set; }
    public double regular_price { get; set; }
    public int section_id { get; set; }
    public bool in_favorite { get; set; }
    public string description { get; set; }






}

public class BoothProfile
{
    public int id { get; set; }
    public int shipping_charges { get; set; }
    public int delivery_time_days { get; set; }
    public int delivery_time_hours { get; set; }
    public int delivery_time_minutes { get; set; }
    public string phone { get; set; }
    public string phone2 { get; set; }
    public string email_contact { get; set; }
    public string facebook { get; set; }
    public string instagram { get; set; }
    public string whatsapp { get; set; }
    public string twitter { get; set; }
    public bool special_discount { get; set; }
    public int discount_ratio { get; set; }
    public int discount_min_price { get; set; }
    public string how_to_buy { get; set; }
    public string terms { get; set; }
    public string retrieval { get; set; }
    public int store_id { get; set; }
}

public class BoothResponse
{
    public int statsu { get; set; }
    public string message { get; set; }
    public BoothData data { get; set; }
}


public class BoothSliders
{
    public List<object> right { get; set; }
    public List<object> center { get; set; }
    public List<object> left { get; set; }
}


