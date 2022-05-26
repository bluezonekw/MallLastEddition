using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class loadSingleBooth : MonoBehaviour
{
    public BoothResponse booth;
    public RawImage B1,B2;
     public List<Dataforproduct> AllProduct =new List<Dataforproduct>(); 
     public GameObject productExample;
    // Start is called before the first frame update
    void Start()
    {
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
if(booth.data==null ||booth.data.booth.is_active!=1){

            GameObject.Destroy(gameObject);
  
}else{
 StartCoroutine(GetTexture(booth.data.booth.logo));
foreach (var section in booth.data.sections){

if(section.product!=null){
  
loadSectionProduct(gameObject.name,section.id.ToString());




}

}
GameObject g=new GameObject();
if(AllProduct.Count!=0){

foreach(var product in AllProduct){
    
 g=GameObject.Instantiate(productExample,productExample.transform.parent);
 StartCoroutine(loadTexture(product.img, g.GetComponent<LoadBoothProduct>().Icon));
 g.gameObject.name=product.id.ToString();

 
 g.gameObject.GetComponent<LoadBoothProduct>().Name.text=product.name;
 
 if(product.sale_price==null){
g.gameObject.GetComponent<LoadBoothProduct>().Price.text=product.regular_price.ToString()+" KWD";
 }else{
g.gameObject.GetComponent<LoadBoothProduct>().Price.text=product.sale_price.ToString()+ " KWD";

 }
  
 g.SetActive(true);




}



}



}
    }


    public void loadSectionProduct(string StoreId,string SectionId){
var client = new RestClient("http://mymall-kw.com/api/V1/get-products-pagination?store_id=" + StoreId + "&section_id=" + SectionId + "&page=1&limit=10000" );
        client.Timeout = -1;
        var request1 = new RestRequest(Method.GET);
        request1.AddHeader("password_api", "mall_2021_m3m");
        request1.AddHeader("lang_api", "en");
        request1.AlwaysMultipartFormData = true;
        IRestResponse response = client.Execute(request1);
      SectionRequest  request= JsonConvert.DeserializeObject<SectionRequest>(response.Content);
    
foreach(var product in request.data.data ){

    AllProduct.Add(product);
}

   



    }

    // Update is called once per frame
    void Update()
    {
        
    }




    IEnumerator GetTexture(string url) {
        if(url.ToLower().EndsWith("jp")){

            url+="g";
        }
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();
if (www.result == UnityWebRequest.Result.Success)  {
        B1.texture=B2.texture = DownloadHandlerTexture.GetContent(www);
    }
    }

      IEnumerator loadTexture(string url,RawImage r) {
        if(url.ToLower().EndsWith("jp")){

            url+="g";
        }
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();
if (www.result == UnityWebRequest.Result.Success) {
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
        public List<BoothSection> sections { get; set; }
    }

    public class BoothProduct
    {
    public int id { get; set; }
    public string img { get; set; }
    public string name { get; set; }
    public int sale_price { get; set; }
    public int regular_price { get; set; }
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

    public class BoothSection
    {
        public int id { get; set; }
        public string wall { get; set; }
        public string position { get; set; }
        public BoothProduct product { get; set; }
    }

    public class BoothSliders
    {
        public List<object> right { get; set; }
        public List<object> center { get; set; }
        public List<object> left { get; set; }
    }


