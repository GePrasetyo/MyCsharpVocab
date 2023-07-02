using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using System;

namespace Majingari.Pool {
    public class PoolGeneric : MonoBehaviour {
        private struct PoolContainer {
            public object Pool;
        }

        private readonly Dictionary<Type, PoolContainer> poolMonoCollection = new Dictionary<Type, PoolContainer>();

        public void InitializePool<T>(T item, int capacity = 1) where T : MonoBehaviour {
            var _pc = new PoolContainer();
            _pc.Pool = new ObjectPool<T>(() => CreatePooledItem(item), OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, true, capacity);

            poolMonoCollection[typeof(T)] = _pc;
        }

        public bool GetPoolMono<T>(out T go, T item) where T : MonoBehaviour {
            if (!poolMonoCollection.ContainsKey(typeof(T))) {
                InitializePool(item);
            }

            var op = poolMonoCollection[typeof(T)].Pool as ObjectPool<T>;
            go = op.Get() as T;
            return true;
        }

        public void Release<T>(T item) where T : MonoBehaviour {
            var op = poolMonoCollection[typeof(T)].Pool as ObjectPool<T>;
            op.Release(item);
        }

        public T CreatePooledItem<T>(T item) where T : MonoBehaviour {
            return Instantiate(item) as T;
        }

        void OnReturnedToPool<T>(T obj) where T : MonoBehaviour {
            obj.gameObject.SetActive(false);
        }

        void OnTakeFromPool<T>(T obj) where T : MonoBehaviour {
            obj.gameObject.SetActive(true);
        }

        void OnDestroyPoolObject<T>(T obj) where T : MonoBehaviour {
            Destroy(obj.gameObject);
        }
    }
}