using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class orderItem : MonoBehaviour
{
public ArabicText Id,Price;
public RawImage Icon;
public ArabicText DateArrive;
public int idnumber;
    public  OrderDetails OrderDetailsObject;
    // Start is called before the first frame update
    void Start()
    {
        OrderDetailsObject = UPDownMenu.instance.OrderDetailsObject;
    }

public void OpenOrderDetails()
{


        OrderDetailsObject.gameObject.SetActive(true);
        OrderDetailsObject.id=idnumber.ToString();
        OrderDetailsObject.LoadDetails();



}
public IEnumerator DownLoadSprite(string URL)
    {

        UnityWebRequest www = UnityWebRequestTexture.GetTexture(URL);
        yield return www.SendWebRequest();


        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
           Debug.Log(URL);
            Icon.texture = ((DownloadHandlerTexture)www.downloadHandler).texture;

        }
        www = null;


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
