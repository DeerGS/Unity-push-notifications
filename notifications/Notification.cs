using UnityEngine;
using System.Collections;
using System;

public abstract class Notification
{
    private bool _Condition;
    public virtual bool Condition { get { return _Condition; } protected set{ _Condition = value; } }

    public string header;
    public string body;
	private double secondsToNotification;
    public double SecondsToNotification
    {
        get{ return secondsToNotification; }
        set
        {
            var time = DateTime.Now.TimeOfDay.TotalSeconds + value;
            if(time < TimeSpan.FromHours(21).TotalSeconds && time > TimeSpan.FromHours(9).TotalSeconds)
            {
                secondsToNotification = value;

            }else
            {
                if(time > TimeSpan.FromHours(21).TotalSeconds)
                    secondsToNotification = TimeSpan.FromHours(24).TotalSeconds - DateTime.Now.TimeOfDay.TotalSeconds + TimeSpan.FromHours(9).TotalSeconds;
                if(time < TimeSpan.FromHours(9).TotalSeconds)
                    secondsToNotification = TimeSpan.FromHours(9).TotalSeconds - DateTime.Now.TimeOfDay.TotalSeconds;
            }
        }
    }

    public virtual void InvokeAction()
    {
        
    }
}
