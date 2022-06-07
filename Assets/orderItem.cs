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

        WWW www = new WWW(URL);
        yield return www;



        Icon.texture = www.texture;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
