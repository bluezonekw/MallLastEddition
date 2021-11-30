using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storewithIdRequest : MonoBehaviour
{
    public int id;
    public RequestStore store;
    public bool GetData,Request;
    /// <summary>
    /// Bottom in Walls {Slidders}
    /// </summary>
    public  List<Texture> RightSlidersUrlImages, LeftSlidersUrlImages, FrontSlidersUrlImages;
    public bool SliderLoaded;

    // Start is called before the first frame update
    void Start()
    {
        Request = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (CheckEnterShop.ExitShop)
        {
            Request = true;
        }


        if (Request&&CheckEnterShop .EnterShop && CheckEnterShop.EnteredStore == id.ToString())
        {
            store=REquestStore.Storeinformation(id);

            for (int x = 0; x < store.data.store.sliders.Capacity; x++)
            {

                // Right
                if (store.data.store.sliders[x].wall == "right")
                {

                    StartCoroutine(LoadTextureFromUrl(store.data.store.sliders[x].src_path + @"/" + store.data.store.sliders[x].src,RightSlidersUrlImages));
                }
                //Left
                if (store.data.store.sliders[x].wall == "left")
                {

                    StartCoroutine(LoadTextureFromUrl(store.data.store.sliders[x].src_path + @"/" + store.data.store.sliders[x].src, LeftSlidersUrlImages));
                }
                //Center
                if (store.data.store.sliders[x].wall == "center")
                {

                    StartCoroutine(LoadTextureFromUrl(store.data.store.sliders[x].src_path + @"/" + store.data.store.sliders[x].src, FrontSlidersUrlImages));
                }

                SliderLoaded = true;

            }


            GetData = true;
            Request = false;
        }
        else
        {
            GetData = false;
        }
    }
    IEnumerator LoadTextureFromUrl(string url, List<Texture> Slider)
    {
        Debug.Log("Loading .... " + url);
        WWW www = new WWW(url);
        yield return www;
        Slider.Add(www.texture);

    }
}
