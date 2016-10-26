using UnityEngine;
using System.Collections;

public interface INotificationWrapper 
{
    void SetLocalNotification(string title, string body, double secondsFromNow);
    void RemoveLocalNotifications();
    void Initialize();
}
