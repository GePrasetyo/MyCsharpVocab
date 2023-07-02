using UnityEngine;

namespace Majingari.Pool {
    public class PoolTesting : MonoBehaviour {
        public PoolGeneric poolManager;

        public SphereShape spherePrefab;
        public CubeShape cubePrefab;

        private float timerSpawnSphere = 0;
        private float timerSpawnCube = 0;

        void Update() {
            if (Input.GetKeyDown(KeyCode.A)) {
                SpawnSphere();
            }
            if (Input.GetKeyDown(KeyCode.B)) {
                SpawnCube();
            }

            timerSpawnSphere += Time.deltaTime;
            timerSpawnCube += Time.deltaTime;

            if (timerSpawnSphere >= 0.012f) {
                SpawnSphere();
                timerSpawnSphere = 0;
            }

            if (timerSpawnCube >= 0.004f) {
                SpawnCube();
                timerSpawnCube = 0;
            }
        }

        void SpawnSphere() {
            poolManager.GetPoolMono(out var sphere, spherePrefab);
            sphere.Success(poolManager);
        }

        void SpawnCube() {
            poolManager.GetPoolMono(out var cube, cubePrefab);
            cube.Success(poolManager);
        }
    }
}