using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;
using System;
public class phoneNotification : MonoBehaviour
{/*
private GameNotificationsManager manager;
    //2
    public const string ChannelId = "game_channel0";
    //3
    public const string ReminderChannelId = "reminder_channel1";
    //4
    public const string NewsChannelId = "news_channel2";
    #region UI buttons

    private string smallIconName = "icon_0";
    private string largeIconName = "icon_1";

    #endregion
    // Start is called before the first frame update
    void Awake()
    {
        manager = GetComponent<GameNotificationsManager>();
    }

    void Start()
    {
        //1
        var c1 = new GameNotificationChannel(ChannelId, "Game Alerts", "Game notifications");
        //2
        var c2 = new GameNotificationChannel(NewsChannelId, "News", "News and Events");
        //3
        var c3 = new GameNotificationChannel(ReminderChannelId,
            "Reminders", "Reminders");
        //4
        manager.Initialize(c1, c2, c3);
    }


    //1
    public void SendNotification(string title, string body, DateTime deliveryTime,
        int? badgeNumber = null, bool reschedule = false, string channelId = null,
        string smallIcon = null, string largeIcon = null)
    {
        //2
        IGameNotification notification = manager.CreateNotification();
        //3
        if (notification == null)
        {
            return;
        }

        //4
        notification.Title = title;
        //5
        notification.Body = body;
        //6
        notification.Group =
            !string.IsNullOrEmpty(channelId) ? channelId : ChannelId;
        //7
        notification.DeliveryTime = deliveryTime;
        //8
        notification.SmallIcon = smallIcon;
        //9
        notification.LargeIcon = largeIcon;

        //10   
        if (badgeNumber != null)
        {
            notification.BadgeNumber = badgeNumber;
        }

        //11
        PendingNotification notificationToDisplay =
            manager.ScheduleNotification(notification);
        //12
        notificationToDisplay.Reschedule = reschedule;
    }*/
}
