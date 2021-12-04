using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullMenuFav : MonoBehaviour
{
    public ArabicText itemCounter;
    public Transform ItemLocation;
    public GameObject ItemFav;
    private GameObject g;
    // Start is called before the first frame update
    void Start()
    {
        itemCounter.Text = favMenu.FavRequest.data.data.Count.ToString();



        foreach (FavData f in favMenu.FavRequest.data.data)
        {


            g = GameObject.Instantiate(ItemFav, ItemLocation);

            g.GetComponent<FavItem>().Name.Text = f.name;
            g.GetComponent<FavItem>().PeoductId = f.id;
            if (f.sale_price == null)
            {
                g.GetComponent<FavItem>().Price.Text = f.regular_price.ToString();

            }
            else
            {

                g.GetComponent<FavItem>().Price.Text = f.sale_price.ToString();

            }

            StartCoroutine(DownLoadSprite(f.img, g.GetComponent<FavItem>().FavImage));
        }
    }
    IEnumerator DownLoadSprite(string URL, RawImage s)
    {

        WWW www = new WWW(URL);
        yield return www;



        s.texture = www.texture;

    }
    public void DestroyFavMenu()
    {

        transform.parent.GetComponent<favMenu>().DestroyFav();


    }
    // Update is called once per frame
    void Update()
    {

    }
}
