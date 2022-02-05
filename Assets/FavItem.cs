using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RestSharp;
using Newtonsoft.Json;

public class FavItem : MonoBehaviour
{
    public Sprite Sign, Unsign;
    public RawImage FavImage;
    public Image Favicon;
    public ArabicText Name, Price;
    public int PeoductId;
    bool issign;
public GameObject ProductPanel;
    // Start is called before the first frame update
    void Start()
    {
        Favicon.sprite = Sign;
        issign = true;
    }
    public string AuthToken()
    {

        try
        {
            return ApiClasses.Register.data.token;
        }
        catch

        {

            return ApiClasses.Login.data.original.access_token;

        }


    }

public void ProductDetailsMenu ()
{
		try{
			var client = new RestClient("http://mymall-kw.com/api/V1/get-single-product/"+PeoductId.ToString());
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
			request.AddHeader("auth-token",AuthToken());
			request.AlwaysMultipartFormData = true;
			IRestResponse response = client.Execute(request);

			loadimageFromApi.ProductRequst=JsonConvert.DeserializeObject<StoreProduct>(response.Content);

GameObject.Instantiate(ProductPanel,GameObject.FindGameObjectWithTag("MainCanvas").transform);
			}
		catch{


			}
}


    public void Addtofav()
    {
        try
        {
            var client = new RestClient("http://mymall-kw.com/api/V1/favorite");
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
            request.AddParameter("product_id", PeoductId);
            IRestResponse response = client.Execute(request);
            
            issign = !issign;
            if (issign)
            {
                Favicon.sprite = Sign;


            }
            else
            {

                Favicon.sprite = Unsign;

            }
        }
        catch
        {
            print("conectionFailed");
        }
var foundCanvasObjects = FindObjectsOfType<FavMenuConfig>();
foundCanvasObjects[0].Counts.Text=(int.Parse(foundCanvasObjects[0].Counts.Text)-1).ToString();
Destroy(this.gameObject);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
