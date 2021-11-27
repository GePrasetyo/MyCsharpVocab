namespace Majin.Main
{
    public class BaseClass
    {
        public string Name;
        private bool _networkReplication;

        public BaseClass(string name, bool replicate)
        {
            Name = name;
            _networkReplication = replicate;
        }

        public bool IsReplicated()
        {
            return _networkReplication;
        }
    }
}