using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneBar : MonoBehaviour
{
public string levelName="AllInOneScen";
float progress;
    // Start is called before the first frame update
    void Start()
    {
          StartCoroutine(LoadSceneAsync(levelName));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  IEnumerator LoadSceneAsync ( string levelName )
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(levelName);

        while ( !op.isDone )
        {
            progress = Mathf.Clamp01(op.progress / .9f);
GetComponent<Renderer>().material.SetFloat("_Progress", progress);
            Debug.Log(op.progress);

            yield return null;
        }
    }
}
