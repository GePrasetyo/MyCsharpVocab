using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EventButtonController : ButtonController
{
    public EventButtonController(Button button, Action eventDownCallback, Action eventUpCallback, string audio = null) : this(button, eventDownCallback, eventUpCallback, CreateAudio(button.gameObject, audio))
    {

    }

    public EventButtonController(Button button, Action eventDownCallback, Action eventUpCallback, EffectModel audio = null) : base(button, null, audio)
    {
        if (!button.TryGetComponent(out EventTrigger eventTrigger))
        {
            eventTrigger = button.gameObject.AddComponent<EventTrigger>();
        }

        eventTrigger.triggers.Add(CreateEntry(EventTriggerType.PointerDown, InvokeTrigger(eventDownCallback)));
        eventTrigger.triggers.Add(CreateEntry(EventTriggerType.PointerUp, InvokeTrigger(eventUpCallback)));
    }

    protected override void InvokeButton() { }

    private EventTrigger.Entry CreateEntry(EventTriggerType type, Action action)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = type;
        entry.callback.AddListener((_) => action());

        return entry;
    }

    private Action InvokeTrigger(Action callback)
    {
        return () =>
        {
            //EffectManager.Create(_audio).Start();
            callback?.Invoke();
        };
    }

}
