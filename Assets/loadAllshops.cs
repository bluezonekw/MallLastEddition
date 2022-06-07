using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RestSharp;
using Newtonsoft.Json;
using System;
using UnityEngine.Networking;
using System.IO;
using TMPro;
using System.Runtime.Serialization.Formatters.Binary;

public class loadAllshops : MonoBehaviour
{
    public static AllGiftBox AllGiftBox;
    public Material Day,Night;
 public static Hall Halls_info;
public static DataStore[] d;
    public static ShopData s;
  

    // Start is called before the first frame update
    void Awake()
    {
        s = new ShopData();
        s.BannerUrl = new string[331];
        s.DoorUrl = new string[331];
        s.NameShop = new string[331];
        try
        {
           
            
          
            if (File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar+"Shop.txt"))
            {

                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + Path.DirectorySeparatorChar + "Shop.txt", FileMode.Open);
                JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), s);
                file.Close();

            }
        }
        catch
        {

        }

       
        loadAllGift();
      
        
 if(int.Parse( DateTime.Now.ToString("HH"))>18 || int.Parse( DateTime.Now.ToString("HH"))<6){

RenderSettings.skybox=Night;


 }
else{

RenderSettings.skybox=Day;


}
        try{
d=new DataStore[330];
        var client = new RestClient(@"http://mymall-kw.com/api/V1/get-stores-pagination?from=1&to=330");
        client.Timeout = -1;
        var request = new RestRequest(Method.GET);
        request.AddHeader("password_api", "mall_2021_m3m");
        request.AddHeader("lang_api", "en");
        request.AlwaysMultipartFormData = true;
        IRestResponse response = client.Execute(request);
        Halls_info = JsonConvert.DeserializeObject<Hall>(response.Content);


            int y = 0;
            for (int x = 0; x < 330; x++)
            {


                try
                {
                    if (Halls_info.data[y].id == x + 1)
                    {

                        d[x] = Halls_info.data[y];
                        y++;


                    }
                    else
                    {

                        d[x] = null;


                    }
                }
                catch { d[x] = null; }


            }
           
            for (int x = 0; x < Halls_info.data.Count; x++)
            {
                s.NameShop[Halls_info.data[x].id] = Halls_info.data[x].name;
                
                if (s.BannerUrl[Halls_info.data[x].id] != Halls_info.data[x].banner)
                {
                    s.BannerUrl[Halls_info.data[x].id] = Halls_info.data[x].banner;

                    StartCoroutine(DownloadBannerFile(Halls_info.data[x].banner, Halls_info.data[x].id.ToString()));

                  
                }


                if (Halls_info.data[x].logo != s.DoorUrl[Halls_info.data[x].id])
                {
                    s.DoorUrl[Halls_info.data[x].id] = Halls_info.data[x].logo;
                    StartCoroutine(DownloadDoorFile(Halls_info.data[x].logo, Halls_info.data[x].id.ToString()));


                }
            }

            if (!File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + "Shop.txt"))
            {

                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Create(Application.persistentDataPath + Path.DirectorySeparatorChar + "Shop.txt");
                var json = JsonUtility.ToJson(s);
                bf.Serialize(file, json);
                file.Close();
            }
            else
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + Path.DirectorySeparatorChar + "Shop.txt", FileMode.Create);
                var json = JsonUtility.ToJson(s);
                bf.Serialize(file, json);
                file.Close();
            }



        }
        catch
        {

            
        }

    }


    IEnumerator DownloadBannerFile(string URL, string fileName)
    {
        var uwr = new UnityWebRequest(URL, UnityWebRequest.kHttpVerbGET);
        if (!Directory.Exists(Application.persistentDataPath + "/Banner"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Banner");
        }
       // Debug.Log(Application.persistentDataPath + "/Banner/" + fileName + ".png");
       
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

           
        }
    }
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
    public void loadAllGift(){
        try
        {
            var client = new RestClient("http://mymall-kw.com/api/V1/gifts");
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


            AllGiftBox = JsonConvert.DeserializeObject<AllGiftBox>(response.Content);


        }
        catch
        {
            AllGiftBox = null;
        }
    }
}
[System.Serializable]
    public class GiftBoxData
    {
        public int id { get; set; }
        public string name { get; set; }
        public int floor { get; set; }
        public List<string> hall { get; set; }
        public List<string> stores { get; set; }
        public string code { get; set; }
        public int discount { get; set; }
        public int min_price_discount { get; set; }
        public int coins { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public List<int> users { get; set; }
        public int is_active { get; set; }
    }

    public class AllGiftBox
    {
        public int statsu { get; set; }
        public string message { get; set; }
        public List<GiftBoxData> data { get; set; }
    }

