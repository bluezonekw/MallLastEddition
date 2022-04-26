using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour {

	public GameObject imagePrefab;
	public GameObject slideSource;

	public Sprite[] slideImageCollection;

	void Start () {
		StartCoroutine(CreateSlideShow());
	}

	IEnumerator CreateSlideShow() {
		yield return null;
		int i =0;
		while(i < slideImageCollection.Length) {
			GameObject obj = Instantiate(imagePrefab);
			obj.GetComponent<RectTransform>().localPosition = Vector3.zero;
			obj.GetComponent<Image>().sprite = slideImageCollection[i];
			obj.transform.SetParent(slideSource.transform,false);
			i++;
		}
		UISlideShow.SP.InitialStartSlide();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
