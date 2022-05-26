using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NotificationItem", menuName = "Notification/Items", order = 1)]
public class NotificationItem : ScriptableObject
{

    public string Artitle,EnTitle,Time,URLIcon;
    public RawImage Icon;
    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }
    public void Load(string savedData)
    {
        JsonUtility.FromJsonOverwrite(savedData, this);
    }
}
