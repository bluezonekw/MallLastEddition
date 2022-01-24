using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;
public class loadassetbundle : MonoBehaviour
{
public AssetReference scene;
    public string scene1,scene2,scene3;
   

    // Start is called before the first frame update
    void Start()
    {
Addressables.LoadSceneAsync(scene,UnityEngine.SceneManagement.LoadSceneMode.Additive).Completed  += SceneLoadComplete;
/*Addressables.LoadSceneAsync(scene1,UnityEngine.SceneManagement.LoadSceneMode.Additive).Completed  += SceneLoadComplete;
Addressables.LoadSceneAsync(scene2,UnityEngine.SceneManagement.LoadSceneMode.Additive).Completed  += SceneLoadComplete;
Addressables.LoadSceneAsync(scene3,UnityEngine.SceneManagement.LoadSceneMode.Additive).Completed  += SceneLoadComplete;*/
print(Time.deltaTime);
      

     

    }
private void SceneLoadComplete(AsyncOperationHandle<UnityEngine.ResourceManagement.ResourceProviders.SceneInstance> obj)     {  
       if (obj.Status == AsyncOperationStatus.Succeeded) 
{
print(Time.deltaTime);

}
        }        

    // Update is called once per frame
    void Update()
    {
        
    }
}
