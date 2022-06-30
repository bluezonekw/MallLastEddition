using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RestSharp;
using Newtonsoft.Json;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ScreenAds : MonoBehaviour
{

    public ScreenAdsRequest Requestclass;
    public string Hall, Floor;
    public GameObject imageExample;
    public Transform ImageParent;
    public int index = 0;
    public bool isstartanimate;

    // Start is called before the first frame update
    void Start()
    {

        try
        {

            var client = new RestClient(@"http://mymall-kw.com/api/V1/screens-ads?hall=" + Hall + "&floor=" + Floor);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("password_api", "mall_2021_m3m");
            request.AddHeader("lang_api", "ar");

            request.AlwaysMultipartFormData = true;
            IRestResponse response = client.Execute(request);
           Debug.Log(response.Content);
            Requestclass = JsonConvert.DeserializeObject<ScreenAdsRequest>(response.Content);
            if (Requestclass.data!=null)
            {
                foreach (var image in Requestclass.data)
                {

                    foreach (var slid in image.slider)
                    {
                        GameObject g = GameObject.Instantiate(imageExample, ImageParent);
                        g.name = slid.ads_id.ToString();
                        g.SetActive(true);

                        if (slid.file.EndsWith("GIF") || slid.file.EndsWith("gif"))
                        {

                            try
                            {
                                StartCoroutine(g.GetComponent<UniGifImage>().SetGifFromUrlCoroutine(slid.file));


                            }
                            catch
                            {

                                GameObject.Destroy(g);

                            }

                        }
                        else
                        {
                            Destroy(g.GetComponent<UniGifImage>());
                            Destroy(g.GetComponent<UniGifImageAspectController>());
                            StartCoroutine(DownloadRawImage(slid.file, g.GetComponent<RawImage>()));
                        }
                    }

                }
                index = ImageParent.childCount - 1;
                ImageParent.GetChild(index).gameObject.GetComponent<Animation>().Play("Show");
            }
        }
        catch
        {


        }

    }


    IEnumerator AnimateImages()
    {

        isstartanimate = true;
        if (Requestclass.data.Count == 0)
        {
            ImageParent.GetChild(index).gameObject.GetComponent<Animation>().Play("Hide");
            index++;
            if (index == ImageParent.childCount)
            {
                index = 1;
            }

            ImageParent.GetChild(index).gameObject.GetComponent<Animation>().Play("Show");
            if (ImageParent.GetChild(index).gameObject.GetComponent<UniGifImage>())
            {

                yield return new WaitForSeconds(10f);

            }
            else
            {

                yield return new WaitForSeconds(12f);
            }
            isstartanimate = false;
        }
    }
    IEnumerator DownloadRawImage(string url, RawImage I)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            try
            {
                I.texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            }
            catch
            {

            }
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
    // Update is called once per frame
    void Update()
    {

        if (!isstartanimate && ImageParent.childCount > 1)
        {


            StartCoroutine(AnimateImages());

        }
    }
}
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class SliderScreenAds
{
    public string file { get; set; }
    public string type { get; set; }
    public int ads_id { get; set; }
}

public class DataScreenAds
{
    public int id { get; set; }
    public int sort { get; set; }
    public int floor { get; set; }
    public int hall { get; set; }
    public List<SliderScreenAds> slider { get; set; }
}

public class ScreenAdsRequest
{
    public int statsu { get; set; }
    public string message { get; set; }
    public List<DataScreenAds> data { get; set; }
}