using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
//using Sirenix.OdinInspector;
using MagneticScrollView;

public class UISelect : MonoBehaviour /*: UIPanel*/
{
    private MagneticScrollRect scrollView;
    private int exCenterIndex = 1;
    private int curCenterIndex = 0;
    public Text curSelectCharName;
    public const float itemWidth = 250;
    public const float itemHeith = 700;

    void Awake ()
    {
        scrollView = GetComponentInChildren<MagneticScrollRect> ();
    }

    void OnEnable ()
    {
        scrollView.StartAutoArranging ();
    }

    private void OnDisable ()
    {
        scrollView.StopAutoArranging ();
    }

    void Update ()
    {
        //if (scrollView.isScrolling)
        CenterCatch ();
    }

    private void CenterCatch ()
    {
        curCenterIndex = scrollView.CurrentSelectedIndex;
        if (exCenterIndex != curCenterIndex && curCenterIndex < scrollView.Elements.Length)
        {
            //print("curCenterIndex: " + curCenterIndex + "exCenterIndex: " + exCenterIndex);
            ChangeCenterItem ();
        }
    }

    private void ChangeCenterItem ()
    {
        try
        {
            scrollView.Elements [exCenterIndex].sizeDelta = new Vector2 (itemWidth, itemHeith);
            scrollView.Elements [curCenterIndex].sizeDelta = new Vector2 (itemWidth * 1.2f, itemHeith * 1.2f);
            scrollView.ArrangeElements (false);
            exCenterIndex = curCenterIndex;
        }
        catch (IndexOutOfRangeException e)
        {
            Debug.Log (e.Message + "Maybe No SnapTarget - Error Indedx: " + curCenterIndex);
        }
        finally
        {
            //scrollView.ArrangeElements(true);
        }
    }

    public void OnSelectionChanage ()
    {
        if (scrollView.CurrentSelectedObject != null)
        {
            curSelectCharName.text = scrollView.CurrentSelectedObject.name;
            ChangeCenterItem ();
            //scrollView.ArrangeElements ();
        }

    }

    //public void OnButtonGameStart ()
    //{
    //    uiManager.ClosePanel (E_UIPanel.Select);
    //    uiManager.OpenPanel (E_UIPanel.Match);
    //    GameManager.Instance.networkManager.StartMatchMaking ();
    //}

}
