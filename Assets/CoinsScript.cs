using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsScript : MonoBehaviour
{
public Text CoinNumber;
public GameObject Full,Empty;
public GameObject AddCoins;
    // Start is called before the first frame update
    void Start()
    {
if(UPDownMenu.coinsnumber==0){
Full.SetActive(false);
Empty.SetActive(true);

}else{
Full.SetActive(true);
Empty.SetActive(false);
var foundCanvasObjects = FindObjectsOfType<UPDownMenu>();
foundCanvasObjects[0].UpdateCoinsNumber();
     CoinNumber.text=UPDownMenu.coinsnumber.ToString();   
}
    }
public void OpenPackage (){

GameObject.Instantiate(AddCoins, GameObject.FindGameObjectWithTag("MainCanvas").transform);

}
public void ClosMenu(){
Destroy(gameObject);

}
    // Update is called once per frame
    void Update()
    {
if(UPDownMenu.coinsnumber!=0){
         CoinNumber.text=UPDownMenu.coinsnumber.ToString();   
}
    }

}
