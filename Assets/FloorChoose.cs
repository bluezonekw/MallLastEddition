using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorChoose : MonoBehaviour
{
public GameObject Floor1_1,Floor1_2,Floor2_1,Floor2_2,Floor3_1,Floor3_2;


public GameObject EmptyShops1,EmptyShops2,EmptyShops3,EmptyShops4,EmptyShops5,EmptyShops6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(loadHalls.NumberOfFloor==1){

Floor1_1.SetActive(true);
Floor1_2.SetActive(true);
Floor2_1.SetActive(false);
Floor2_2.SetActive(false);
Floor3_1.SetActive(false);
Floor3_2.SetActive(false);


EmptyShops1.SetActive(false);
EmptyShops4.SetActive(false);
EmptyShops2.SetActive(true);
EmptyShops3.SetActive(true);
EmptyShops5.SetActive(true);
EmptyShops6.SetActive(true);





}else
if(loadHalls.NumberOfFloor==2){

Floor1_1.SetActive(false);
Floor1_2.SetActive(false);
Floor2_1.SetActive(true);
Floor2_2.SetActive(true);
Floor3_1.SetActive(false);
Floor3_2.SetActive(false);


EmptyShops1.SetActive(true);
EmptyShops4.SetActive(true);
EmptyShops2.SetActive(false);
EmptyShops3.SetActive(true);
EmptyShops5.SetActive(false);
EmptyShops6.SetActive(true);



}
else
if(loadHalls.NumberOfFloor==3){

Floor1_1.SetActive(false);
Floor1_2.SetActive(false);
Floor2_1.SetActive(false);
Floor2_2.SetActive(false);
Floor3_1.SetActive(true);
Floor3_2.SetActive(true);




EmptyShops1.SetActive(true);
EmptyShops4.SetActive(true);
EmptyShops2.SetActive(true);
EmptyShops3.SetActive(false);
EmptyShops5.SetActive(true);
EmptyShops6.SetActive(false);


}


    }
}
