using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController
{
    //private const string DefaultButtonAudio = EffectList.ButtonNeutral2;
    protected Button Component;

    protected EffectModel _audio;
    private Action _callback;

    public ButtonController(Button button, Action callback, string audio = null) : this(button, callback, CreateAudio(button.gameObject, audio))
    {

    }

    public ButtonController(Button button, Action callback, EffectModel audio)
    {
        Component = button;
        _callback = callback;
        _audio = audio;
        Component.onClick.AddListener(InvokeButton);
    }

    public void SetActive(bool value)
    {
        Component.gameObject.SetActive(value);
    }

    protected static EffectModel CreateAudio(GameObject button, string name)
    {
        //if (EffectManager.Instance == null)
        //{
        //    Debug.LogWarning("Waiting until EffectManager is automatically reloaded on Splashscreen Scene");
        //    return null;
        //}

        if (name != null)
        {
            //var audio = EffectManager.Instance.CommonEffects.GetEffectByName(name);
            //if (audio.Sound != null)
            //{
            //    return audio;
            //}
        }

        Debug.LogWarning(button.name + ": effect name or effect Sound is null");

        return null;//EffectManager.Instance.CommonEffects.GetEffectByName(DefaultButtonAudio);
    }

    protected virtual void InvokeButton()
    {
        //EffectManager.Create(_audio).Start();
        _callback?.Invoke();
    }
}

public class EffectModel
{ 

}

public class EffectManager
{
    
}