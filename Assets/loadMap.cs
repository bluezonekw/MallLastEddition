using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace UI.Pagination
{
    public class loadMap : MonoBehaviour
    {
        public CategoryRequest category;
        public Transform TabLocation;

        public GameObject TabExample;
        GameObject g;
        // Start is called before the first frame update
        void Start()
        {
            try
            {
                var client = new RestClient("http://mymall-kw.com/api/V1/get-all-categories");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AlwaysMultipartFormData = true;
                IRestResponse response = client.Execute(request);
               Debug.Log(response.Content);
                category = JsonConvert.DeserializeObject<CategoryRequest>(response.Content);
                for (int index = 0; index < category.data.Count; index++)
                {
                    g = GameObject.Instantiate(TabExample, TabLocation);
                    g.name = category.data[index].id.ToString();
                    g.GetComponent<Page>().PageTitle = ArabicFixerTool.FixLine(category.data[index].name.Trim());

                }

            }
            catch
            {
                category = null;

            }
        }


        IEnumerator LoadIcon(string url, RawImage s)
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
                    s.texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
                }
                catch
                {

                }
            }




        }



    }
}


public class DataCategory
{
    public int id { get; set; }
    public string name { get; set; }
    public string icon { get; set; }
    public string sort { get; set; }
}

public class CategoryRequest
{
    public int statsu { get; set; }
    public string message { get; set; }
    public List<DataCategory> data { get; set; }
}
