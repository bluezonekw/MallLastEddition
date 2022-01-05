using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UI.Pagination
{
    public class GotoStore : MonoBehaviour
{
    public List<Vector3> StoreLocation;
    private GameObject Player;
    int storeid;
    // Start is called before the first frame update
    void Start()
    {
        storeid = 0;
        Player = GameObject.FindWithTag("Player");
      

           storeid= int.Parse(gameObject.name)-1;
               
            
    
       
        }
        void MoveTowardsTarget(Vector3 target)
        {
            var cc =Player.GetComponent<CharacterController>();
            var offset = target - transform.position;
            //Get the difference.
            if (offset.magnitude > .1f)
            {
                //If we're further away than .1 unit, move towards the target.
                //The minimum allowable tolerance varies with the speed of the object and the framerate. 
                // 2 * tolerance must be >= moveSpeed / framerate or the object will jump right over the stop.
                offset = offset.normalized * 10;
                //normalize it and account for movement speed.
                cc.Move(offset * Time.deltaTime);
                //actually move the character.
            }
        }
            public void Gotostore()
    {
            

	    Player.GetComponent<CharacterController>().enabled = false;
try{
 	    Player.transform.localPosition=StoreLocation[storeid];
}catch{

 	    Player.transform.localPosition=StoreLocation[0];
}

            Player.GetComponent<CharacterController>().enabled = true;

            LoadStores.isactive = false;

   //  Player.GetComponent<CharacterController>().Move(StoreLocation[storeid]);
            
          //  print(Player.transform.localPosition.ToString() + "          After");
        
          

           // Player.transform.Translate(StoreLocation[storeid], Space.Self);
          //  print(Player.transform.localPosition.ToString() + "          lasttry");
          
        }
    // Update is called once per frame
    void Update()
    {
        
    }
}}
