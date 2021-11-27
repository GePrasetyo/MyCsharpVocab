using Majin.Main;

public class Character : MortalActor, IHit<Actor, float>, Iinteract
{
    public Character(string name, Transform transform, bool networkReplication) : base(name, transform, networkReplication)
    {

    }

    protected override void Spawn()
    {

    }

    protected override void Dead()
    {

    }

    public void GotHit(Actor attacker, float damageTaken)
    {

    }

    public void Interacted()
    {

    }
}
