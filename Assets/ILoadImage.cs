using System.Collections;
using UnityEngine;
using UnityEngine.UI;

internal interface ILoadImage
{
    IEnumerator DownloadRawImage();
    IEnumerator DownloadMatrial();


    }