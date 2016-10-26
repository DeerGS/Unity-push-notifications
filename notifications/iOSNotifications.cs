using UnityEngine;
using System.Collections;
#if UNITY_IOS || UNITY_EDITOR
using UnityEngine.iOS;

public class iOSNotifications : INotificationWrapper
{
    public void SetLocalNotification(string title, string body, double secondsFromNow)
    {
        Debug.Log("iOSNotifications SetLocalNotification: Setting notification to fire in " + secondsFromNow.ToString() + " with title: " + title);
        var localNotification = new UnityEngine.iOS.LocalNotification();
        localNotification.alertAction = title;
        localNotification.alertBody = body;
        localNotification.fireDate = System.DateTime.Now.AddSeconds(secondsFromNow);
        UnityEngine.iOS.NotificationServices.ScheduleLocalNotification(localNotification);


        UnityEngine.iOS.NotificationServices.RegisterForNotifications(NotificationType.Alert | NotificationType.Badge);

    }

    public void RemoveLocalNotifications()
    {
        UnityEngine.iOS.NotificationServices.CancelAllLocalNotifications();
    }

    public void Initialize()
    {
    }
}
#endif