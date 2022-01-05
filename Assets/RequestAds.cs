using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RestSharp;
using Newtonsoft.Json;
public class RequestAds : MonoBehaviour
{
    public Material DefaultMat;
    public AdsRequest AdsRequest1;
    public GameObject BackRight, BackLeft, FrontRight, FrontLeft;
    public GameObject BackeExample, FrontExample;
    public string Hall00, Floor00;
    public GameObject Right, Left;
    bool startAnimation1,startAnimation2,startAnimation3,startAnimation4;
    int index0, index1, index2, index3;
    public GameObject g;
    public List<GameObject> LeftFront, LeftBack, Rightfront, RightBack;
    // Start is called before the first frame update
    void Start()
    {
        index0 = index1 = index2 = index3 = 0;
        var client = new RestClient(@"http://mymall-kw.com/api/V1/stands-ads?hall=" + Hall00 + @"&floor=" + Floor00);
        client.Timeout = -1;
        var request = new RestRequest(Method.GET);
        request.AddHeader("password_api", "mall_2021_m3m");
        if (UPDownMenu.LanguageValue == 1)
        {
            request.AddHeader("lang_api", "en");

        }
        else
        {

            request.AddHeader("lang_api", "ar");

        }

        request.AddHeader("auth_token", AuthToken());
        request.AlwaysMultipartFormData = true;
        IRestResponse response = client.Execute(request);
        AdsRequest1 = JsonConvert.DeserializeObject<AdsRequest>(response.Content);
        ///Front1
        try
        {
            foreach (FrontSlider FS in AdsRequest1.data[0].front_slider)
            {
                g = GameObject.Instantiate(FrontExample, FrontLeft.transform);
                g.GetComponent<MeshRenderer>().materials[0] = new Material(DefaultMat.shader);
                StartCoroutine(DownloadRawImage(FS.file, g.GetComponent<MeshRenderer>().materials[0]));
g.transform.localScale= new Vector3(0, 1, 1);
                LeftFront.Add(g);

            }
            if (AdsRequest1.data[0].front_slider.Count == 0)
            {
                Left.SetActive(false);
            }
        }
        catch
        {
            Left.SetActive(false);
        }


        ///Front2
        try
        {
            foreach (FrontSlider FS in AdsRequest1.data[1].front_slider)
            {
                g = GameObject.Instantiate(FrontExample, FrontRight.transform);
                g.GetComponent<MeshRenderer>().materials[0] = new Material(DefaultMat.shader);

                StartCoroutine(DownloadRawImage(FS.file, g.GetComponent<MeshRenderer>().materials[0]));
g.transform.localScale= new Vector3(0, 1, 1);
                Rightfront.Add(g);
            }
            if (AdsRequest1.data[1].front_slider.Count == 0)
            {
                Right.SetActive(false);
            }
        }
        catch
        {
            Right.SetActive(false);
        }


        ///back1
        try
        {
            foreach (BackSlider BS in AdsRequest1.data[0].back_slider)
            {
                g = GameObject.Instantiate(BackeExample, BackLeft.transform);
                g.GetComponent<MeshRenderer>().materials[0] = new Material(DefaultMat.shader);
                g.GetComponent<MeshRenderer>().materials[0].SetTextureScale("_MainTex", new Vector2(-1f, -1f));

                StartCoroutine(DownloadRawImage(BS.file, g.GetComponent<MeshRenderer>().materials[0]));
g.transform.localScale= new Vector3(0, 1, 1);
                LeftBack.Add(g);
            }
            if (AdsRequest1.data[0].back_slider.Count == 0)
            {
                Left.SetActive(false);
            }




          
        }
        catch
        {
            Left.SetActive(false);
        }

        ///back2
        try
        {
            foreach (BackSlider BS in AdsRequest1.data[1].back_slider)
            {
                g = GameObject.Instantiate(BackeExample, BackRight.transform);
                g.GetComponent<MeshRenderer>().materials[0] = new Material(DefaultMat.shader);
                g.GetComponent<MeshRenderer>().materials[0].SetTextureScale("_MainTex", new Vector2(-1f, -1f));

                StartCoroutine(DownloadRawImage(BS.file, g.GetComponent<MeshRenderer>().materials[0]));
g.transform.localScale= new Vector3(0, 1, 1);
                RightBack.Add(g);
            }
            if (AdsRequest1.data[1].back_slider.Count == 0)
            {
                Right.SetActive(false);
            }


        }
        catch
        {
            Right.SetActive(false);
        }



        startAnimation1=startAnimation2=startAnimation3=startAnimation4 = true;

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

    IEnumerator DownloadRawImage(string url, Material I)
    {


        WWW www = new WWW(url);
        yield return www;
        try
        {

            I.SetTexture("_MainTex", www.texture);

        }
        catch
        {


        }

    }
    // Update is called once per frame
    void Update()
    {
 


        if (startAnimation1)
        {
		if(LeftFront.Count>1){
					 StartCoroutine(LeftFront1());
  				     }
		else
		 if(LeftFront.Count==1){

						LeftFront[0].transform.localScale= new Vector3(1, 1, 1);
startAnimation1=false;

				        }       

           
       }
      

    if (startAnimation2)
        {
		if(Rightfront.Count>1){
					 StartCoroutine(RightFront2());
  				     }
		else
		 if(Rightfront.Count==1){

						Rightfront[0].transform.localScale= new Vector3(1, 1, 1);
startAnimation2=false;

				        }       

           
       }




  if (startAnimation3)
        {
		if(LeftBack.Count>1){
					 StartCoroutine(LeftBack1());
  				     }
		else
		 if(LeftBack.Count==1){

						LeftBack[0].transform.localScale= new Vector3(1, 1, 1);
startAnimation3=false;

				        }       

           
       }


if (startAnimation4)
        {
		if(RightBack.Count>1){
					 StartCoroutine(RightBack2());
  				     }
		else
		 if(RightBack.Count==1){

						RightBack[0].transform.localScale= new Vector3(1, 1, 1);
startAnimation4=false;

				        }       

           
       }




 
    }






   IEnumerator LeftFront1()
    {
  	 startAnimation1=false;
      

     
        
LeftFront[index0].GetComponent<Animation>().Play("right");
if(index0+1>LeftFront.Count-1){

LeftFront[0].GetComponent<Animation>().Play("left");
index0=0;
}
else
{
LeftFront[index0+1].GetComponent<Animation>().Play("left");
index0++;
}
     
        
yield return new WaitForSeconds(6);

startAnimation1=true;
    }







 IEnumerator RightFront2()
    {
  	 startAnimation2=false;
      

     
        
Rightfront[index1].GetComponent<Animation>().Play("right");
if(index1 + 1>Rightfront.Count-1){

Rightfront[0].GetComponent<Animation>().Play("left");
index1=0;
}
else
{
Rightfront[index1 + 1].GetComponent<Animation>().Play("left");
index1++;
}
     
        
yield return new WaitForSeconds(6);

startAnimation2=true;
    }







IEnumerator LeftBack1()
    {
  	 startAnimation3=false;
      

     
        
LeftBack[index2].GetComponent<Animation>().Play("right");
if(index2 + 1>LeftBack.Count-1){

LeftBack[0].GetComponent<Animation>().Play("left");
index2=0;
}
else
{
LeftBack[index2 + 1].GetComponent<Animation>().Play("left");
index2++;
}
     
        
yield return new WaitForSeconds(6);

startAnimation3=true;
    }



IEnumerator RightBack2()
    {
  	 startAnimation4=false;
      

     
        
RightBack[index3].GetComponent<Animation>().Play("right");
if(index3 + 1>RightBack.Count-1){

RightBack[0].GetComponent<Animation>().Play("left");
index3=0;
}
else
{
RightBack[index3 + 1].GetComponent<Animation>().Play("left");
index3++;
}
     
        
yield return new WaitForSeconds(6);

startAnimation4=true;
    }















 
}


public class FrontSlider
{
    public string file { get; set; }
    public string type { get; set; }
    public int ads_id { get; set; }
}

public class BackSlider
{
    public string file { get; set; }
    public string type { get; set; }
    public int ads_id { get; set; }
}

public class DataForAds
{
    public int id { get; set; }
    public int sort { get; set; }
    public int floor { get; set; }
    public int hall { get; set; }
    public List<FrontSlider> front_slider { get; set; }
    public List<BackSlider> back_slider { get; set; }
}

public class AdsRequest
{
    public int statsu { get; set; }
    public string message { get; set; }
    public List<DataForAds> data { get; set; }
}
