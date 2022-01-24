using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnterShop : MonoBehaviour
{
    CharacterController CC;
    public static bool EnterShop,ExitShop;
    public static string EnteredStore;
public static bool  CartEmpty;
    // Start is called before the first frame update
    void Start()
    {
       CartEmpty=true;
            CC = GetComponent<CharacterController>();
       

       
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "FloorShop"&&!ExitShop)
        {
           EnteredStore=hit.gameObject.transform.parent.name;
           EnterShop = true;
SingleSToreRequest.StaticStoreId=int.Parse(  EnteredStore);
hit.gameObject.transform.parent.GetComponent<loadimageFromApi>().enabled = true;
hit.gameObject.transform.parent.GetComponent<SingleSToreRequest>().enabled = true;
        }
     
        if (EnterShop&& hit.gameObject.tag == "Gate" )
        {
            EnterShop = false;
            ExitShop = true;
hit.gameObject.transform.parent.GetComponent<loadimageFromApi>().enabled = false;
hit.gameObject.transform.parent.GetComponent<SingleSToreRequest>().enabled = false;

        }
                }
    
}
