using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserMenu : MonoBehaviour
{

    public GameObject FavMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CreateFavMenu()
    {

        GameObject.Instantiate(FavMenu);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
