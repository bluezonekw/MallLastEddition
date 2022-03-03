using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RestSharp;
using Newtonsoft.Json;
public class loadAllshops : MonoBehaviour
{
 public static Hall Halls_info;
public static DataStore[] d;
    // Start is called before the first frame update
    void Awake()
    {
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
int y=0;
 for (int x=0;x<330;x++)
      	  {


try{
if(Halls_info.data[y].id==x+1){

d[x]=Halls_info.data[y];
y++;


}else{

d[x]=null;


}
}catch{d[x]=null;}


}
        }
        catch{

            
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
