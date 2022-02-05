using UnityEngine;
using System.Collections;

public class BrowserOpener : MonoBehaviour {

	public string pageToOpen = "";

public InAppBrowser.DisplayOptions options;
	

	
	// check readme file to find out how to change title, colors etc.
	public void OnButtonClicked() {
		 options = new InAppBrowser.DisplayOptions();
		options.displayURLAsPageTitle = true;
		

		InAppBrowser.OpenURL(pageToOpen, options);


	}




	public void OnClearCacheClicked() {
		InAppBrowser.ClearCache();
	}
}
