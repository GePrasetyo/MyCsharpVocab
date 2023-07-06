using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Majingari.Pool {
    public class PoolPrefabRef : MonoBehaviour {
        private readonly Dictionary<object, object> poolbyRefCollection = new Dictionary<object, object>();

        private void Awake() {
            DontDestroyOnLoad(gameObject);
        }

        /// <summary>
        /// Initialize Pool by prefab reference
        /// </summary>
        /// <typeparam name="T">Unity component</typeparam>
        /// <param name="key">prefab reference</param>
        /// <param name="capacity">capacity to instantiate</param>
        public void InitializePoolRef<T>(object key, int capacity = 1) where T : Component {
            if ((T)key == null) {
                return;
            }

            poolbyRefCollection[key] = new ObjectPool<T>(() => CreatePooledItem((T)key), OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, true, capacity);
        }

        /// <summary>
        /// Get Pool by Reference
        /// </summary>
        /// <typeparam name="T">Unity component</typeparam>
        /// <param name="go">output pool</param>
        /// <param name="key">prefab as a key</param>
        /// <returns></returns>
        public bool GetPoolRef<T>(out T output, object key) where T : Component {
            if ((T)key == null) {
                output = null;
                return false;
            }

            if (!poolbyRefCollection.ContainsKey(key)) {
                InitializePoolRef<T>(key);
            }

            var op = poolbyRefCollection[key] as ObjectPool<T>;
            output = op.Get() as T;
            return true;
        }

        /// <summary>
        /// Release object to pool
        /// </summary>
        /// <typeparam name="T">Unity Component</typeparam>
        /// <param name="key">prefab reference</param>
        /// <param name="item">item to release to pool</param>
        public void Release<T>(object key, object item) where T : Component {
            if ((T)key == null || (T)item == null) {
                return;
            }

            if (poolbyRefCollection.TryGetValue(key, out var op)) {
                (op as ObjectPool<T>).Release((T)item);
            }
        }

        private T CreatePooledItem<T>(T item) where T : Component {
            return Instantiate(item, this.transform) as T;
        }

        private void OnReturnedToPool<T>(T obj) where T : Component {
            obj.transform.SetParent(this.transform);
        }

        private void OnTakeFromPool<T>(T obj) where T : Component {
            obj.transform.SetParent(null);
        }

        private void OnDestroyPoolObject<T>(T obj) where T : Component {
            Destroy(obj.gameObject);
        }
    }
}