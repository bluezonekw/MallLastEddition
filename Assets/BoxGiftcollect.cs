using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using UnityEngine;
using UnityEngine.UI;
public class BoxGiftcollect : MonoBehaviour
{
    public string code ;
    public int coins,discount, id;
    public GameObject coinCollect;
    public GameObject Code;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    public void loadGift(){
var client = new RestClient("http://mymall-kw.com/api/V1/takeGift/"+id.ToString());
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
GetGift getGift=JsonConvert.DeserializeObject<GetGift>(response.Content);
if(getGift.statsu==0){
GameObject g=  GameObject.Instantiate(Code, GameObject.FindGameObjectWithTag("MainCanvas").transform);

g.GetComponent<optionPopUp>().Message.Text=getGift.message;
return;

}





if(coins!=0){
StartCoroutine(LoadCoins());




}
if(code!=null){
GameObject g=  GameObject.Instantiate(Code, GameObject.FindGameObjectWithTag("MainCanvas").transform);
g.GetComponent<optionPopUp>().Message.Text=code;
Destroy(gameObject);


}



    }


    IEnumerator LoadCoins(){



 GameObject g=  GameObject.Instantiate(coinCollect, GameObject.FindGameObjectWithTag("MainCanvas").transform);
yield return new WaitForSeconds(6);
Destroy(g);
Destroy(gameObject);
    }
}

[System.Serializable]
public class GetGift{


        public int statsu;
        public string message;
       public GetGiftData data;
}

public class GetGiftData{
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