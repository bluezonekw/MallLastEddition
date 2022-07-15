using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LoadLevel : MonoBehaviour
{
 public   AssetBundle bundle;
    public string MainPath;

    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            MainPath= @"AssetBundles\Android\";

        }
        else
        if (Application.platform == RuntimePlatform.IPhonePlayer) { 

            MainPath = @"AssetBundles\iOS\";

        }
        else
        {
            MainPath = @"AssetBundles\StandaloneWindows\";
        }
        print(MainPath);
        bundle = Resources.Load<AssetBundle>(MainPath+"1");
        print(bundle.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
