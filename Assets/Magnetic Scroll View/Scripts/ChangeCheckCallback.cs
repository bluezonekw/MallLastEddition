using UnityEngine;
using System.Reflection;

namespace MagneticScrollView
{
    /// <summary>
    /// MonoBehaviour class used to check whether the object dimensions has been changed.
    /// </summary>
#if UNITY_2018_3_OR_NEWER
    [ExecuteAlways]
#else
    [ExecuteInEditMode]
#endif

    [DisallowMultipleComponent]
    internal class ChangeCheckCallback : MonoBehaviour
    {
        //[HideInInspector]
        private MagneticScrollRect magneticScrollView;
        private MethodInfo AssignElements;
        private Transform viewport;

        void OnEnable ()
        {
            magneticScrollView = GetComponentInParent<MagneticScrollRect> ();
            AssignElements = typeof (MagneticScrollRect).GetMethod ("AssignElements",
                BindingFlags.NonPublic |
                BindingFlags.Instance);
            if (magneticScrollView != null)
                viewport = magneticScrollView.viewport;
            //hideFlags = HideFlags.HideInInspector;
            //hideFlags = HideFlags.None;
        }


        //private void Update ()
        //{
        //    if (transform.hasChanged)
        //        Debug.Log ("Transform Changed");
        //}


        private void OnRectTransformDimensionsChange ()
        {

            if (gameObject.activeInHierarchy && enabled && magneticScrollView != null)
            {
                //Debug.Log ("Dimension Changed", gameObject);
                bool resize = magneticScrollView.ResizeModeEnum != ResizeMode.Free;
                magneticScrollView.ArrangeElements (resize);
            }
        }

        //private void OnTransformChildrenChanged ()
        //{
        //    //Debug.Log (transform.hasChanged);

        //    if (gameObject.activeInHierarchy && enabled && magneticScrollView != null && viewport != null && gameObject == viewport.gameObject)
        //    {
        //        magneticScrollView.AssignElements ();
        //        if (!Application.isPlaying || (Application.isPlaying && magneticScrollView.AutoArranging))
        //            magneticScrollView.ArrangeElements ();
        //    }
        //}
    }
}
