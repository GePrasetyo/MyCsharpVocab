using UnityEngine;

namespace Majingari.Pool {
    public class CubeShape : MonoBehaviour {
        private PoolGeneric pm;
        private float timer = 0;

        void Update() {
            timer += Time.deltaTime;

            if (timer >= 1.5f) {
                pm.Release(this);
                timer = 0;
            }
        }

        public void Success(PoolGeneric _pm) {
            pm = _pm;
            //gameObject.name = $"Cube {Random.Range(1, 9999)}";
        }
    }
}