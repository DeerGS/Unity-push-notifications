using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class NotificationDispatcher : MonoBehaviour
{
    private INotificationWrapper wrapper;
    public event Action NotificationReward;
    private bool isInit = false;
    public List<Notification> Notifications = new List<Notification>() 
    {

    };

    void OnApplicationPause(bool pauseState)
    {
        if(isInit)
        {
            if(pauseState)
            {
                foreach(Notification notif in Notifications)
                {
                    if(notif.Condition)
                    {
#if DEBUG
                        wrapper.SetLocalNotification(notif.header, notif.body, 30f);
#else
                        wrapper.SetLocalNotification(notif.header, notif.body, notif.SecondsToNotification);
#endif
                    }
                }
            } else
            {
                if(NotificationReward != null)
                {
                    var tmpRew = NotificationReward;
                    NotificationReward = null;
                    tmpRew();
                }

               // if(wrapper!=null)
                wrapper.RemoveLocalNotifications();
            }
        }
    }

    public void Initialize()
    {
        isInit = true;
#if UNITY_IOS || UNITY_EDITOR
        wrapper = new iOSNotifications();
        wrapper.Initialize();
#elif UNITY_ANDROID
        wrapper = new AndroidNotifications();
#endif

        Pushwoosh.ApplicationCode = "";
        Pushwoosh.GcmProjectNumber = "";
        Pushwoosh.Instance.OnRegisteredForPushNotifications += OnRegisteredForPushNotifications;
        Pushwoosh.Instance.OnFailedToRegisteredForPushNotifications += OnFailedToRegisteredForPushNotifications;
        Pushwoosh.Instance.OnPushNotificationsReceived += OnPushNotificationsReceived;
        Pushwoosh.Instance.RegisterForPushNotifications ();
    }

    void OnRegisteredForPushNotifications(string token)
    {
        // TODO: handling here
        Debug.Log("NotificationDispatcher OnRegisteredForPushNotifications: Received token: " + token);
    }

    void OnFailedToRegisteredForPushNotifications(string error)
    {
        // TODO: handling here
        Debug.Log("NotificationDispatcher OnFailedToRegisteredForPushNotifications: Error ocurred while registering to push notifications: " + error);
    }

    void OnPushNotificationsReceived(string payload)
    {
        // TODO: handling here
        Debug.Log("NotificationDispatcher OnPushNotificationsReceived: Received push notificaiton: " + payload);
    }
}
