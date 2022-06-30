using Newtonsoft.Json;
using RestSharp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class REquestStore : MonoBehaviour
{
    // Start is called before the first frame update
    public RawImage[] Banners;
    public Material[] Doors;
    void Start()
    {
        var client = new RestClient("https://mymall-kw.com/api/V1/get-stores-pagination?page=1");
        client.Timeout = -1;
        var request = new RestRequest(Method.GET);
        request.AddHeader("password_api", "mall_2021_m3m");
        request.AddHeader("lang_api", "en");
        request.AlwaysMultipartFormData = true;
        IRestResponse response = client.Execute(request);
       Debug.Log(response.Content);
        IdStores idStores= JsonConvert.DeserializeObject<IdStores>(response.Content);
       Debug.Log("Size   :   " + idStores.data.Capacity);
        for(int x = 0; x < idStores.data.Capacity; x++)
        {
            try
            {
                StartCoroutine(DownloadSpirte("https://mymall-kw.com/public/assets/images/store/banner/banner1.jpg", Banners[x]));
                StartCoroutine(DownloadImage("https://mymall-kw.com/public/assets/images/store/banner/banner1.jpg", Doors[x]));
            }
            catch
            {

            }
        }

    }
    IEnumerator DownloadImage(string MediaUrl, Material renderer)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            renderer.EnableKeyword("_DETAIL_MULX2");
            renderer.SetTexture("_DetailAlbedoMap", ((DownloadHandlerTexture)www.downloadHandler).texture);
        }

      

            }
    IEnumerator DownloadSpirte(string url, RawImage T)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        T.texture = DownloadHandlerTexture.GetContent(www);

       Debug.Log(T);

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public static RequestStore Storeinformation(int id)
    {

        var client = new RestClient("https://mymall-kw.com/api/V1/get-single-store?store_id="+id.ToString());
        client.Timeout = -1;
        var request = new RestRequest(Method.GET);
        request.AddHeader("password_api", "mall_2021_m3m");
        request.AddHeader("lang_api", "ar");
        request.AlwaysMultipartFormData = true;
        IRestResponse response = client.Execute(request);
       Debug.Log(response.Content);
        return JsonConvert.DeserializeObject<RequestStore>(response.Content);

    }

}
