using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectImage : MonoBehaviour {

	public void OnSelectImage() {
		/// to throw the argument of the select slide.
		UISlideShow.SP.OnClickImage(this.gameObject);
	}
}
