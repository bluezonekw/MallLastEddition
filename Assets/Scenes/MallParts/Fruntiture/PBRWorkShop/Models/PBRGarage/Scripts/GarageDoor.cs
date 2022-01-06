using UnityEngine;
using System.Collections;

public class GarageDoor : MonoBehaviour {
	 Transform	MessageUI;

	Animation doorAnim;
	bool opened=false; 
	bool allowOpen;

	// Use this for initialization
	void Start () {
		doorAnim=GetComponent<Animation>();
		MessageUI.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (!opened) {
			if (true) {
				opened=true;
				MessageUI.gameObject.SetActive(false);
				doorAnim.Play("Open");
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		allowOpen=true;
		if (!opened) {
			MessageUI.gameObject.SetActive(true);
		}
	}

	void OnTriggerExit(Collider other) {
		allowOpen=false;
		if (!opened) {
			MessageUI.gameObject.SetActive(false);
		}
	}
}
