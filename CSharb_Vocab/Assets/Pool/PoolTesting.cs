using UnityEngine;

namespace Majingari.Pool {
    public class PoolTesting : MonoBehaviour {
        public PoolGeneric poolManager;
        public PoolPrefabRef poolManagerRef;

        public SphereShape spherePrefab;
        public CubeShape cubePrefab;

        public ParticleSystem vfxOne;
        public ParticleSystem vfxTwo;

        private float timerSpawnSphere = 0;
        private float timerSpawnCube = 0;

        private float vfxOneTime = 0;
        private float vfxTwoTime = 0;

        public bool UpdateSpawn;

        void Update() {
            if (Input.GetKeyDown(KeyCode.A)) {
                SpawnSphere();
            }
            if (Input.GetKeyDown(KeyCode.B)) {
                SpawnCube();
            }

            if (!UpdateSpawn)
                return;

            timerSpawnSphere += Time.deltaTime;
            timerSpawnCube += Time.deltaTime;
            vfxOneTime += Time.deltaTime;
            vfxTwoTime += Time.deltaTime;

            if (timerSpawnSphere >= 0.012f) {
                SpawnSphere();
                timerSpawnSphere = 0;
            }

            if (timerSpawnCube >= 0.004f) {
                SpawnCube();
                timerSpawnCube = 0;
            }

            if (vfxOneTime >= 0.02f) {
                SpawnVFX1();
                vfxOneTime = 0;
            }

            if (vfxTwoTime >= 0.04f) {
                SpawnVFX2();
                vfxTwoTime = 0;
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

        void SpawnVFX1() {
            poolManagerRef.GetPoolRef<ParticleSystem>(out var vOne, vfxOne);
            vOne.Emit(1);
            poolManagerRef.Release<ParticleSystem>(vfxOne, vOne);
        }

        void SpawnVFX2() {
            poolManagerRef.GetPoolRef<ParticleSystem>(out var vTwo, vfxTwo);
            vTwo.Emit(1);
            poolManagerRef.Release<ParticleSystem>(vfxTwo, vTwo);
        }
    }
}