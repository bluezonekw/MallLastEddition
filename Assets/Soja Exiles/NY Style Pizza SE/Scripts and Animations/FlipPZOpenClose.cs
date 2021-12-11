using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipPZOpenClose : MonoBehaviour {

	public Animator FlipPZ;
	public bool open;
	public Transform Player;

	void Start (){
		open = false;
	}

	void OnMouseOver (){
		{
			if (Player) {
				float dist = Vector3.Distance (Player.position, transform.position);
				if (dist < 15) {
					if (open == false) {
						if (Input.GetMouseButtonDown (0)) {
							StartCoroutine (opening ());
						}
					} else {
						if (open == true) {
							if (Input.GetMouseButtonDown (0)) {
								StartCoroutine (closing ());
							}
						}

					}

				}
			}

		}

	}

	IEnumerator opening(){
		print ("you are flipping open");
		FlipPZ.Play ("FlipOpenPZ");
		open = true;
		yield return new WaitForSeconds (.5f);
	}

	IEnumerator closing(){
		print ("you are flipping close");
		FlipPZ.Play ("FlipClosePZ");
		open = false;
		yield return new WaitForSeconds (.5f);
	}


}

