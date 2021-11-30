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
    IEnumerator DownloadImage(string url,Image I)
    {
        WWW www = new WWW(url);
        yield return www;
        I.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));

    }
    // Update is called once per frame
    void Update()
    {
       

           // StartCoroutine(DownloadImage(ScriptGetStoreInfo.store.data.store.logo_path + @"/" + ScriptGetStoreInfo.store.data.store.logo));
       
        
    }
}
