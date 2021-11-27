using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonInstantiatorManager : MonoBehaviour
{
    private const BindingFlags BindingAttribute = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

    protected virtual void Awake()
    {
        CreateButtons();
    }

    private void CreateButtons()
    {
        foreach (var field in GetType().GetFields(BindingAttribute))
        {
            var button = field.GetValue(this) as Button;
            if (button != null)
            {
                CreateButton(button, field);
            }
        }
    }

    private void CreateButton(Button button, FieldInfo field)
    {
        var ownerType = GetType();

        var buttonHaveCallback = TryGetMethod(ownerType, field.Name + "Callback", out MethodInfo callbackInfo);
        if (!buttonHaveCallback)
        {
            var buttonHaveEventDown = TryGetMethod(ownerType, field.Name + "Down", out MethodInfo eventDownInfo);
            var buttonHaveEventUp = TryGetMethod(ownerType, field.Name + "Up", out MethodInfo eventUpInfo);

            if (!buttonHaveEventDown && !buttonHaveEventUp)
            {
                Debug.LogWarning(
                    string.Format("Failed to find method for {0}.\nButton is: {1}.",
                    field.Name,
                    button.gameObject.name));
            }
            else
            {
                var eventDown = CreateDelegate(eventDownInfo);
                var eventUp = CreateDelegate(eventUpInfo);
                new EventButtonController(button, eventDown, eventUp, "");
            }
        }
        else
        {
            var callback = CreateDelegate(callbackInfo);
            new ButtonController(button, callback, "");
        }
    }

    private bool TryGetMethod(Type ownerType, string methodName, out MethodInfo methodInfo)
    {
        methodInfo = ownerType.GetMethod(methodName, BindingAttribute);
        return methodInfo != null;
    }

    private Action CreateDelegate(MethodInfo callbackInfo)
    {
        var callback = (Action)Delegate.CreateDelegate(typeof(Action), this, callbackInfo);
        return callback;
    }
}
