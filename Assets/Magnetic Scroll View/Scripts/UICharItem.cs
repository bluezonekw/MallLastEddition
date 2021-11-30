using UnityEngine;
using UnityEngine.UI;
using MagneticScrollView;

public class UICharItem : MonoBehaviour
{
    private int index = 0;
    public MagneticScrollRect scrollView;

    void Awake ()
    {
        scrollView = GetComponentInParent<MagneticScrollRect> ();
        //GetComponentInChildren<Text> ().text = transform.name;
    }

    public void OnItemClick ()
    {
        //scrollView.ResetScroll ();
        int randIndex = 0;
        while (randIndex == index)
            randIndex = Random.Range (0, 6);
        index = randIndex;
        scrollView.ScrollTo (index);
        //scrollView.ArrangeElements(true);
        //scrollView.AlignElements();
    }
}
