using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
	
	/// option of slide show patern 
public enum SlideShowEffects
{
	Horizontal = 0,
	Vertical = 1,
	Radial90 = 2,
	Radial180 = 3,
	Radial360 = 4,
	Random = 5

}
[HideInInspector]
[System.Serializable]
public class UISlideShow : MonoBehaviour {
    #region PUBLIC_MEMBERS 
	[SerializeField]
	public GameObject slideSource;	/// parent gameobject of the slide image objects.
	[Header("The Slide Show Properties")]
	[Space(10)]
	[SerializeField]
	public SlideShowEffects slideShowMethod;	/// option to show the slide.
	public bool autoSlideOn;	/// auto slide show is active or not.
	public bool LoadingImagesAtRuntime;	/// image load at runtime check true.
	public float slideShowTime = 4f;	/// auto sliding time between slides.
	[Range(0.1f,1)]
	public float slideAnimationSpeed;
	public static UISlideShow SP;	/// static instance of the class.

	#endregion END_PUBLIC REGION


	#region  PRIVATE_MEMBERS
	private float waitForNextClick;	///  hold the click between two slides.
	private Transform currentObj; /// current slide image.
	private bool onHoldNextClick,onHoldPreviousClick;		/// hold the button continues click.

	#endregion END_PRIVATE REGION

	/// <.summary>
	/// the initial state to prepare the scene .
	/// <.!--summary>
	void Awake () {
		SP = this;
	}
	void Start() {
		/// the slideshow auto starting when autoslide show is on mode.
		if(!slideSource){
			Debug.Log("Please assign the parentObj component value!");
			return;
		}
		if(!LoadingImagesAtRuntime){
			InitialStartSlide();
		}
	}

	public void InitialStartSlide() {
		try {
			slideSource.transform.GetChild(slideSource.transform.childCount-1).GetComponent<Animator>().SetTrigger("open");
			StartAutoSlide();
		} catch(System.Exception ex) {
			Debug.Log(ex);
		}
	}

	void Update() {
		/// close the application .
		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}
	}
	/// <.summary>
	/// on next slide image show.
	/// <.!--summary>
	public void OnNextImage() {
		if(currentObj == null){
             currentObj = slideSource.transform.GetChild(slideSource.transform.childCount-1);
		}
		if(!onHoldNextClick && currentObj.GetComponent<Animator>()) {			
			if(SlideShowEffects.Random == slideShowMethod){
				/// the slide show method is random.
				int currentMethodValue = Random.Range(0,5);		/// get the random integer value and set to the Image fillmethod.
				currentObj.GetComponent<Image>().fillMethod = (Image.FillMethod)currentMethodValue;
				slideSource.transform.GetChild(0).GetComponent<Image>().fillMethod = (Image.FillMethod)currentMethodValue;
				SetImageFillOrigin(currentObj,slideSource.transform.GetChild(0),(SlideShowEffects)currentMethodValue,0,1,true);
			} else {
				/// the slide show method is not random.
				currentObj.GetComponent<Image>().fillMethod = (Image.FillMethod)slideShowMethod;
				slideSource.transform.GetChild(0).GetComponent<Image>().fillMethod = (Image.FillMethod)slideShowMethod;
				SetImageFillOrigin(currentObj,slideSource.transform.GetChild(0),slideShowMethod,0,1,true);
			}
			slideSource.transform.GetChild(0).SetAsLastSibling();				/// the current slide image set to last sibiling of parent.
			onHoldNextClick = true;
			StartCoroutine(HoldNextImageShow());
			StartAutoSlide();
		}
	}
	/// <.summary>
	/// set the image fillorigin value.
	/// <.!--summary>
	void SetImageFillOrigin(Transform currentSlide,Transform childSlide,SlideShowEffects currentMethod,int originValue1,int originValue2,bool nextSlide) {
		currentObj.GetComponent<Animator>().speed = slideAnimationSpeed;
		childSlide.GetComponent<Animator>().speed = slideAnimationSpeed;
		waitForNextClick = currentObj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
		if(SlideShowEffects.Horizontal == currentMethod || SlideShowEffects.Vertical == currentMethod){
					/// slide show method is horizontal/vertical set to the following origin set.
					currentSlide.GetComponent<Image>().fillOrigin = originValue1;
					childSlide.GetComponent<Image>().fillOrigin = originValue2;
				} else {
					/// slide show method is ratial 90 / 180 / 360 set to the following origin set.
					if(nextSlide) {
						currentSlide.GetComponent<Image>().fillOrigin = originValue1;
						currentSlide.GetComponent<Image>().fillClockwise = false;
						childSlide.GetComponent<Image>().fillOrigin = originValue1;
						childSlide.GetComponent<Image>().fillClockwise = true;
					} else {
						currentSlide.GetComponent<Image>().fillOrigin = originValue2;
						currentSlide.GetComponent<Image>().fillClockwise = true;
						childSlide.GetComponent<Image>().fillOrigin = originValue2;
						childSlide.GetComponent<Image>().fillClockwise = false;
					}
		}
			currentObj.GetComponent<Animator>().SetTrigger("hide");        ///  trigger to animator and run the image hide animation.
			childSlide.GetComponent<Animator>().SetTrigger("show");        ///  trigger to animator and run the image show animation.
			currentObj = childSlide;		
	}
	/// <.summary>
	/// Start the auto slide show calling method.
	/// <.!--summary>
	void StartAutoSlide() {
		if(!autoSlideOn)
			return;
		CancelInvoke();							/// cancel the previous invoke call.
		float temp = slideShowTime + waitForNextClick;
		Invoke("OnNextImage",temp); 		/// invoke call for auto slide.
	}
	/// <.summary>
	/// on previous slide image show.
	/// <.!--summary>
	public void OnPreviousImage() {
		if(currentObj == null){
             currentObj = slideSource.transform.GetChild(slideSource.transform.childCount-1);
		}
		if(!onHoldPreviousClick) {					
			currentObj.transform.SetAsFirstSibling();		/// the current slide image set to first sibiling of parent.
			int index = slideSource.transform.childCount; /// get the childs count of the parent.
			if(SlideShowEffects.Random == slideShowMethod){
				int currentMethodValue = Random.Range(0,5);
				currentObj.GetComponent<Image>().fillMethod = (Image.FillMethod)currentMethodValue;
				slideSource.transform.GetChild(index-1).GetComponent<Image>().fillMethod = (Image.FillMethod)currentMethodValue;
				SetImageFillOrigin(currentObj,slideSource.transform.GetChild(index-1),(SlideShowEffects)currentMethodValue,1,0,false);
			} else {
				currentObj.GetComponent<Image>().fillMethod = (Image.FillMethod)slideShowMethod;
				slideSource.transform.GetChild(index-1).GetComponent<Image>().fillMethod = (Image.FillMethod)slideShowMethod;
				SetImageFillOrigin(currentObj,slideSource.transform.GetChild(index-1),slideShowMethod,1,0,false);
			}
			onHoldPreviousClick = true;
			StartCoroutine(HoldPreviousImageShow());
			StartAutoSlide();			
		}
	}
	/// <.summary>
	/// hold the next image select button click.
	/// <.!--summary>
	IEnumerator HoldNextImageShow() {
		yield return new WaitForSeconds(waitForNextClick);
		onHoldNextClick = false;
	}
	/// <.summary>
	/// hold the previous image select button click.
	/// <.!--summary>
	IEnumerator HoldPreviousImageShow() {
		yield return new WaitForSeconds(waitForNextClick);
		onHoldPreviousClick = false;
	}
	/// <.summary>
	/// select the slide image object name debug.
	/// <.!--summary>
	public void OnClickImage(GameObject obj) {
		if(!onHoldPreviousClick && !onHoldNextClick){
			Debug.Log("You are clicked on the "+obj.GetComponent<Image>().sprite.name);
		}
	}
}
