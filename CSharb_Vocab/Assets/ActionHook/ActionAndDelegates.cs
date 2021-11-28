using System;
using System.Collections.Generic;
using Majin.Main;

public class ActionAndDelegates
{
    public Action CallOutside;
    public event Action CallInside;

    public Action<Locomotion> HookWithParam;
    public Func<BaseComponent, Actor> HookFunc;

    void TriggerActionLocal()
    {
        CallOutside?.Invoke();

        HookWithParam += GenericActionListener<Locomotion>;
        HookFunc += GenericFuncListener<AvatarNPC>;
    }

    public void GenericActionListener<T>(T component) where T : BaseComponent
    {
        var actor = component.GetOwner() as Character;

        actor.Interacted();
    }

    public T GenericFuncListener<T>(BaseComponent component) where T : Actor
    {
        try
        {
            return (T)Convert.ChangeType(component.GetOwner(), typeof(T));
        }
        catch (KeyNotFoundException)
        {
            return null;
        }
    }
}

public class OutsideAction
{
    void TriggerActionFromOutside()
    {
        var action = new ActionAndDelegates();

        var actorName = "MyActor";
        var actor = new AvatarPlayer(actorName, true);

        var locomotion = new Locomotion(actor, true);
        action.HookWithParam?.Invoke(locomotion);

        action.CallOutside?.Invoke();

        ReceiveFuncToProcess((x,y) => { return x + y; });
        ReceiveFuncToProcess(locomotion, action.GenericFuncListener<AvatarPlayer>);
    }

    void ReceiveFuncToProcess(Func<int, int, int> getResult)
    {
        var result = getResult?.Invoke(5, 5);
    }

    void ReceiveFuncToProcess(BaseComponent baseComponent, Func<BaseComponent, Actor> getActor)
    {
        var actor = getActor?.Invoke(baseComponent);
    }    
}
