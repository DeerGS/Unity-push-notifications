using UnityEngine;
using System.Collections;

#if UNITY_ANDROID
public class AndroidNotifications : INotificationWrapper
{
    PushNotificationsAndroid manager = new PushNotificationsAndroid();
    public void SetLocalNotification(string title, string body, double secondsFromNow)
    {
        manager.ScheduleLocalNotification(title, (int)secondsFromNow, body);
    }

    public void RemoveLocalNotifications()
    {
        manager.ClearLocalNotifications();
    }

    public void Initialize()
    {
        
    }
}
#endif
