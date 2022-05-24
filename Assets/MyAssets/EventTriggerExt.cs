using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class EventTriggerExt
{
    public static void AddListenner(this EventTrigger eventTrigger, EventTriggerType eventTriggerType, System.Action callback)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = eventTriggerType;
        entry.callback.AddListener((eventDate) => { callback.Invoke(); });
        eventTrigger.triggers.Add(entry);
    }
}