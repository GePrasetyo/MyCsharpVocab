using UnityEngine;

namespace Majingari.Pool {
    public class SphereShape : MonoBehaviour {
        private PoolGeneric pm;
        private float timer = 0;

        void Update() {
            timer += Time.deltaTime;

            if (timer >= 1.2f) {
                pm.Release(this);
                timer = 0;
                gameObject.SetActive(false);
            }
        }

        public void Success(PoolGeneric _pm) {
            pm = _pm;
            //gameObject.name = $"Sphere {Random.Range(1, 9999)}";
        }
    }
}