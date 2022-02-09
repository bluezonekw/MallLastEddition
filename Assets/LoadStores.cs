using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RestSharp;
using Newtonsoft.Json;
public class LoadStores : MonoBehaviour
{
    public StoreCategory Store;
    public GameObject Child;
    public RectTransform ViewPort;
    private GameObject g;
    public Transform ChildLocation;
    public static bool isactive;
bool fristShow;
    // Start is called before the first frame update
    void Start()
    {


    }

public void  OnShowPanel(){

if(!fristShow){
fristShow=true;

        var client = new RestClient("http://mymall-kw.com/api/V1/get-stores-pagination-where-Categories?category_id="+gameObject.name);
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
        request.AlwaysMultipartFormData = true;
        IRestResponse response = client.Execute(request);
        Store = JsonConvert.DeserializeObject<StoreCategory>(response.Content);
        int x = Store.data.Count / 6;
        if (x == 0)
        {
            x = 1;
        }
       ViewPort.sizeDelta = new Vector2(ViewPort.sizeDelta.x, (450 * (x+1)));
        foreach (var s in Store.data)
        {
            g = GameObject.Instantiate(Child, ChildLocation);
            g.name = s.id.ToString();
            g.transform.GetChild(1).GetComponent<ArabicText>().Text = s.name;
            StartCoroutine(LoadIcon(s.logo, g.transform.GetChild(0).GetComponent<RawImage>()));


        }



}



}
    IEnumerator LoadIcon(string url, RawImage s)
    {


        WWW www = new WWW(url);
        yield return www;
        s.texture = www.texture;

    }
    // Update is called once per frame
    void Update()
    {
        transform.parent.parent.parent.gameObject.SetActive(isactive);

    }
}
public class DataStoreinCategory
{
    public int id { get; set; }
    public int is_active { get; set; }
    public string logo { get; set; }
    public string banner { get; set; }
    public int category_id { get; set; }
    public string name { get; set; }
    public string welcome_message { get; set; }
}

public class StoreCategory
{
    public int statsu { get; set; }
    public string message { get; set; }
    public List<DataStoreinCategory> data { get; set; }
}