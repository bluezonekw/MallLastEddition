using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionResizer : MonoBehaviour
{
    public MagneticScrollView.MagneticScrollRect scrollView;
    public float itemWidth;
    public float itemHeight;
    private int curCenterIndex;
    private int exCenterIndex;

    public void Init (GameObject item)
    {
        CenterCatch ();
    }

    private void CenterCatch ()
    {
        curCenterIndex = scrollView.CurrentSelectedIndex;
        if (exCenterIndex != curCenterIndex && curCenterIndex < scrollView.Elements.Length)
        {
            ChangeCenterItem ();
        }

    }

    private void ChangeCenterItem ()
    {
        try
        {
            scrollView.Elements [exCenterIndex].sizeDelta = new Vector2 (itemWidth, itemHeight);
            scrollView.Elements [curCenterIndex].sizeDelta = new Vector2 (itemWidth * 2, itemHeight * 2);
            exCenterIndex = curCenterIndex;
        }
        catch (System.IndexOutOfRangeException e)
        {
            Debug.Log (e.Message + "Maybe No SnapTarget - Error Index" + curCenterIndex);
        }
        finally
        {
            scrollView.ArrangeElements (true);
        }
    }
}
