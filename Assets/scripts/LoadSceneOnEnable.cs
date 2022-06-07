using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnEnable : MonoBehaviour
{
   
    private void OnEnable()
    {

        SceneManager.LoadSceneAsync(gameObject.name, LoadSceneMode.Additive);
    }

    private void OnDisable()
    {
        AsyncOperation asyncLoad = SceneManager.UnloadSceneAsync(gameObject.name);
    }

}
