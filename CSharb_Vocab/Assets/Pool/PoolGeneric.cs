using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using System;

namespace Majingari.Pool {
    public class PoolGeneric : MonoBehaviour {
        private readonly Dictionary<Type, object> poolbyMonoCollection = new Dictionary<Type, object>();

        /// <summary>
        /// Initialize pool by monobehaviour as key and prefab to reference
        /// </summary>
        /// <typeparam name="T">Monobehaviour</typeparam>
        /// <param name="item">prefab as monobehaviour</param>
        /// <param name="capacity">capacity to instantiate</param>
        public void InitializePoolMono<T>(T item, int capacity = 1) where T : MonoBehaviour {
            poolbyMonoCollection[typeof(T)] = new ObjectPool<T>(() => CreatePooledMono(item), OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, true, capacity);
        }

        /// <summary>
        /// Get Pool by Monobehaviour
        /// </summary>
        /// <typeparam name="T">Monobehaviour</typeparam>
        /// <param name="output">output pool</param>
        /// <param name="item">monobehaviour prefab as a key</param>
        /// <returns></returns>
        public bool GetPoolMono<T>(out T output, T item) where T : MonoBehaviour {
            if (!poolbyMonoCollection.ContainsKey(typeof(T))) {
                InitializePoolMono(item);
            }

            var op = poolbyMonoCollection[typeof(T)] as ObjectPool<T>;
            output = op.Get() as T;
            return true;
        }

        /// <summary>
        /// Release object to pool
        /// </summary>
        /// <typeparam name="T">Monobehaviour</typeparam>
        /// <param name="item">item to release to pool</param>
        public void Release<T>(T item) where T : MonoBehaviour {
            var op = poolbyMonoCollection[typeof(T)] as ObjectPool<T>;
            op.Release(item);
        }

        private T CreatePooledMono<T>(T item) where T : MonoBehaviour {
            return Instantiate(item) as T;
        }

        private void OnReturnedToPool<T>(T obj) where T : MonoBehaviour {
            //obj.gameObject.SetActive(false);
        }

        private void OnTakeFromPool<T>(T obj) where T : MonoBehaviour {
            //obj.gameObject.SetActive(true);
        }

        private void OnDestroyPoolObject<T>(T obj) where T : MonoBehaviour {
            Destroy(obj.gameObject);
        }
    }
}