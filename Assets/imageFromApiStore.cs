using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class imageFromApiStore : MonoBehaviour
{
    public storewithIdRequest ScriptGetStoreInfo;
    private Image _image;
    // Start is called before the first frame update
    void Start()
    {
        _image = this.GetComponent<Image>();

    }
    Texture2D t;
    IEnumerator DownloadImage(string url,Image I)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();


        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
           Debug.Log(url);
             t = ((DownloadHandlerTexture)www.downloadHandler).texture;
 I.sprite = Sprite.Create(t, new Rect(0, 0, t.width, t.height), new Vector2(0, 0));
        }
        t = null;
        www = null;
    }
    // Update is called once per frame
    void Update()
    {
       

           // StartCoroutine(DownloadImage(ScriptGetStoreInfo.store.data.store.logo_path + @"/" + ScriptGetStoreInfo.store.data.store.logo));
       
        
    }
}
