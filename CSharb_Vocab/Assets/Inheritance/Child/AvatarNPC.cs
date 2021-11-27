using Majin.Main;

public class AvatarNPC : Character
{
    public AvatarNPC(string name, Transform transform, bool networkReplication) : base(name, transform, networkReplication)
    {

    }

    protected override void Spawn()
    {
        base.Spawn();
    }

    protected override void Dead()
    {
        base.Spawn();
    }
}
