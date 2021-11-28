using Majin.Main;

public class AvatarPlayer : Character
{
    public AvatarPlayer(string name, Transform transform, bool networkReplication) : base(name, transform, networkReplication)
    {

    }

    public AvatarPlayer(string name, bool networkReplication) : this(name, new Transform(), networkReplication)
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
