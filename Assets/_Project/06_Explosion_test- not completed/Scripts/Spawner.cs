using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Krzychu
{

    public class Spawner : MonoBehaviour
    {
        public GameObject Glass;
        public Transform spawnBucket;
        public float spawnSpeed;

        private void OnEnable()
        {
            SpawnEnemies();
        }
        public void OnDisable()
        {
            CancelInvoke();
        }

        public void SpawnEnemies()
        {
            Instantiate(Glass, transform.position, transform.rotation);

            Invoke(nameof(SpawnEnemies), UnityEngine.Random.Range(1f / spawnSpeed, 1f / spawnSpeed));
        }

    }

}