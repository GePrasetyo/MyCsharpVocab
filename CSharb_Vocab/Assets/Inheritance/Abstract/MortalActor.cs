namespace Majin.Main
{
    public abstract class MortalActor : Actor
    {
        protected abstract void Spawn();

        protected abstract void Dead();

        public MortalActor(string name, Transform transform, bool networkReplication) : base (name, transform, networkReplication)
        { 
            
        }
    }
}