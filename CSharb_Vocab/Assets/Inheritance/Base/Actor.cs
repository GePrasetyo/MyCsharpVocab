using System;
using System.Collections.Generic;

namespace Majin.Main
{
    public class Actor : BaseClass
    {
        private Lazy<Dictionary<string, BaseComponent>> _myComponent = new Lazy<Dictionary<string, BaseComponent>>();

        public Transform MyTransform;        

        public Actor(string name, Transform transform, bool networkReplication) : base (name, networkReplication)
        {
            MyTransform = transform;
        }

        public void AddComponent(BaseComponent newComponent)
        {
            _myComponent.Value.Add(newComponent.GetType() + "", newComponent);
        }

        public T GetComponenta<T>() where T : BaseComponent
        {
            var type = typeof(T) + "";

            try
            {
                return (T)Convert.ChangeType(_myComponent.Value[type], typeof(T));
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }
    }
}
