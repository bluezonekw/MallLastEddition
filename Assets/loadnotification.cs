using Newtonsoft.Json;
using RestSharp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadnotification : MonoBehaviour
{
    public NotificationResponse notification;
    public GameObject item;
    public Text NumberofNotification;
    private void Awake()
    {
     
    }
     void OnEnable()
    {
        var client = new RestClient("http://mymall-kw.com/api/V1/notifications");
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
        IRestResponse response = client.Execute(request);
        notification = JsonConvert.DeserializeObject<NotificationResponse>(response.Content);
        print(response.Content);
        NumberofNotification.text = notification.data.Count.ToString();
        foreach (var n in notification.data)
        {
            GameObject g = GameObject.Instantiate(item, item.transform.parent);
            g.name = n.id.ToString();
            g.GetComponent<NotifictionItem>().text.text = n.title_general;
            StartCoroutine(DownloadRawImage(n.image, g.GetComponent<NotifictionItem>().Icon));
            g.GetComponent<NotifictionItem>().Time.text = "";

          g.SetActive(true);
        }
    }
    public string AuthToken()
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
    IEnumerator DownloadRawImage(string url,RawImage image)
    {
      

            WWW www = new WWW(url);
            yield return www;

          image.texture = www.texture;

     

         
       
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public class NotificationData
{
    public int id;
    public string title_general;
    public string image;
    public string type;
    public int? type_id;
    public int is_new;
    public List<NotificationTranslation> translations;
    public object updated_at;
    public object created_at;
}
public class NotificationResponse
{
        public int statsu;
        public string message;
        public List<NotificationData> data;
}

public class NotificationTranslation
{
    public string title;
    public string description;
}