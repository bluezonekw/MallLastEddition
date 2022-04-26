using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
 
using System.IO;
using System.Collections.Generic;

public class InfoPlistManager : MonoBehaviour
{

#if UNITY_IOS
    [PostProcessBuild]
    static void OnPostprocessBuild(BuildTarget buildTarget, string path)
    {
        // Read plist
        var plistPath = Path.Combine(path, "Info.plist");
        var plist = new PlistDocument();
        plist.ReadFromFile(plistPath);

        // Update value
        PlistElementDict rootDict = plist.root;
        rootDict.SetString("NSPhotoLibraryUsageDescription", "Used for reading library content");
	rootDict.SetString("NSPhotoLibraryAddUsageDescription", "Used for adding content to library");

        // Write plist
        File.WriteAllText(plistPath, plist.WriteToString());
    }
#endif
}