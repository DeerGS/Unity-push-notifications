# Unity-push-notifications
Small system that manages notifications in both iOS and Android.

# What does it do?
Uses Pushwoosh https://www.pushwoosh.com/ (for Android) and Unity (for iOS) functionality to make local notifications appear when you want them to. 

# How do I turn it on?
Unity build-in method OnApplicationPause(bool) governs setting them up and removing if player returns to your game, so nothing is needed to enable them. Just plug, define your notifications, add them to dispatcher, and play:)

# How do I define my notifications?
You inherit from Notification class. Just overrride Condition to enable notification, and define your behavior in getter. Set SecondsToNotification to how much seconds should you wait till notification appearing, header to what should be the header of notification (typicaly you app name), and body - message that will go along with it.
Condition should return true when notification is set up, false if otherwise. 

You can also define custom actions that should be done when notification is executed, you do this by overriding InvokeAction method and doing what you want. You then add InvokeAction to NotificationDispatcher event called NotificationReward. InvokeAction should also check time that enough time has passed for this thing to run this code.

# How do I add them to dispatcher?
Add them to Notifications List in NotificationDispatcher. Either during gameplay, or in list declaration section. Either way is okay.

# What do other things in dispatcher do?
This is basic structure made for Pushwoosh remote notifications. You can read more here http://docs.pushwoosh.com/docs/unity-plugin on that matter. 

# Q&A
Why does my notifications don't file from 9PM to 9AM?
Not to disturb users in the night.

Where do I get pushwoosh plugin?
Here: http://docs.pushwoosh.com/docs/unity-plugin

Where do I insert my credit card?
It is free, so put that thing away. Okay?:)
