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
 
    void Awake()
    {
            
            var client = new RestClient("http://mymall-kw.com/api/V1/get-all-categories");
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
        category = JsonConvert.DeserializeObject<CategoryRequest>(response.Content);

            for (int index= 0;index < category.data.Count;index++)
        {
            g= GameObject.Instantiate(TabExample, TabLocation);
            g.name = category.data[index].id.ToString();
            g.GetComponent<Page>().PageTitle = category.data[index].name.Trim();

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
