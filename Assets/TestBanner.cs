using Newtonsoft.Json;
using RestSharp;
using System.Collections;

using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;



public class TestBanner : MonoBehaviour
{
    public Hall Hall;
    public Sprite r;
   
    public ShopData s;
    public Image textureImage;
    private void Awake()
    {
      
    }
   
    // Start is called before the first frame update
    void Start()
    {
        
  StartCoroutine(LoadStore());
        
        for(int x=0;x< Hall.data.Count; x++)
        {
           
            if (  s.BannerUrl[Hall.data[x].id] != Hall.data[x].banner)
            {
                s.BannerUrl[Hall.data[x].id] = Hall.data[x].banner;
           
                    StartCoroutine(DownloadBannerFile(Hall.data[x].banner, Hall.data[x].id.ToString()));

              
            }


            if (Hall.data[x].logo != s.DoorUrl[Hall.data[x].id])
            {
                s.DoorUrl[Hall.data[x].id] = Hall.data[x].logo;
                StartCoroutine(DownloadDoorFile(Hall.data[x].logo, Hall.data[x].id.ToString()));
              
                
            }
        }
     
    }



   

    IEnumerator LoadStore()
    {
        var client = new RestClient("http://mymall-kw.com/api/V1/get-stores-pagination?page=1&limit=300&from=1&to=330");
        client.Timeout = -1;
        var request = new RestRequest(Method.GET);
        request.AddHeader("password-api", "mall_2021_m3m");
        request.AddHeader("lang-api", "en");
        request.AlwaysMultipartFormData = true;
        IRestResponse response = client.Execute(request);


        Hall = JsonConvert.DeserializeObject<Hall>(response.Content);
        yield return 0;
    }
    IEnumerator DownloadBannerFile(string URL,string fileName)
    {
        var uwr = new UnityWebRequest(URL, UnityWebRequest.kHttpVerbGET);
        if (!Directory.Exists(Application.persistentDataPath + "/Banner"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Banner");
        }
        string path = Path.Combine(Application.persistentDataPath + "/Banner/" + fileName + ".png");
        uwr.downloadHandler = new DownloadHandlerFile(path);
        yield return uwr.SendWebRequest();
        if (uwr.result != UnityWebRequest.Result.Success)
            Debug.LogError(uwr.error);
        else
        {
         
        }
    }



    IEnumerator DownloadDoorFile(string URL, string fileName)
    {
        var uwr = new UnityWebRequest(URL, UnityWebRequest.kHttpVerbGET);
        if (!Directory.Exists(Application.persistentDataPath + "/Door"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Door");
        }
        string path = Path.Combine(Application.persistentDataPath + "/Door/" + fileName + ".png");
        uwr.downloadHandler = new DownloadHandlerFile(path);
        yield return uwr.SendWebRequest();
        if (uwr.result != UnityWebRequest.Result.Success)
            Debug.LogError(uwr.error);
        else
        {

          //  print(path);
        }
    }













    // Update is called once per frame
    void Update()
    {
        
    }
}
