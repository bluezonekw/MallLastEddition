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
    // Start is called before the first frame update
    void Start()
    {
        
    }

public void OpenOrderDetails()
{
     var OrderDetailsObject = FindObjectsOfType<OrderDetails>();

OrderDetailsObject[0].gameObject.transform.GetChild(0).gameObject.SetActive(true);
OrderDetailsObject[0].id=idnumber.ToString();
OrderDetailsObject[0].LoadDetails();



}
public IEnumerator DownLoadSprite(string URL)
    {

        WWW www = new WWW(URL);
        yield return www;



        Icon.texture = www.texture;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
