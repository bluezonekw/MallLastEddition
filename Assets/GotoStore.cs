using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UI.Pagination
{
    public class GotoStore : MonoBehaviour
{

    public GameObject Player;
    int storeid;
public GameObject Loading;
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
        public GameObject g;
            public void Gotostore()
    {

             g = GameObject.Instantiate(Loading, GameObject.FindGameObjectWithTag("MainCanvas").transform);
            Player.GetComponent<CharacterController>().enabled = false;
try{
 	    Player.transform.localPosition=UPDownMenu.instance.StoreLocation[storeid];
}catch{

 	    Player.transform.localPosition= UPDownMenu.instance.StoreLocation[0];
}

            Player.GetComponent<CharacterController>().enabled = true;

             StartCoroutine(ExampleCoroutine());

           
        }


    IEnumerator ExampleCoroutine()
    {
        

  Player.GetComponent<CharacterController>().enabled = false;

try{
 	    Player.transform.localPosition= UPDownMenu.instance.StoreLocation[storeid];
if(Player.transform.localPosition.x==19)

{

Player.transform.localPosition+=new  Vector3(-1, 0, 0);


}
if(Player.transform.localPosition.x==-19f)

{
Player.transform.localPosition+=new  Vector3(1, 0, 0);
}
}catch{

 	    Player.transform.localPosition= UPDownMenu.instance.StoreLocation[0];
}

        //yield on a new YieldInstruction that waits for 5 seconds.
yield return new WaitForSeconds(3);
            /*while (MallLoader.Isload){
            yield return new WaitForSeconds(1);
            }
             */
            Destroy(g);


 Player.GetComponent<CharacterController>().enabled = true;
            UPDownMenu.instance.ShowHideMap();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}}
