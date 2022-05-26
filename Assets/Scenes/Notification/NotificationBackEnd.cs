using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NotificationBackEnd : MonoBehaviour
{
    public NotificationItem notificationItem;

    // Start is called before the first frame update
    void Start()
    {
       

        //   NotificationItem example = ScriptableObject.CreateInstance<NotificationItem>();
        notificationItem= Resources.Load<NotificationItem>("Test");
        notificationItem.Artitle = "sasa";

    }
     public static NotificationItem CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<NotificationItem>(jsonString);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    
    



}
