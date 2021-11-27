namespace Majin.Main
{
    public class BaseComponent : BaseClass
    {
        private Actor _owner;        

        public BaseComponent(string name, Actor owner, bool networkReplication) : base (name, networkReplication)
        {
            _owner = owner;
        }

        public Actor GetOwner()
        {
            return _owner;
        }
    }

}