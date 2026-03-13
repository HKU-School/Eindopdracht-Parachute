using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ParachutSpawner
{
    public class Spawner : MonoBehaviour
    {
        [Header("Spawner Values")]
        //[Range(1, 10)][SerializeField] private float spawnPoint;
        [SerializeField] private List<GameObject> parachuts = new List<GameObject>();
        [SerializeField] private float coolDown;

        private float _spawnTime = 0;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            StartCoroutine(SpawnLoop());
        }

        // Coroutine that spawns parachuts after delay 
        private IEnumerator SpawnLoop()
        {
            yield return new WaitForSeconds(5f);

            while (true)
            {
                yield return new WaitForEndOfFrame();
                _spawnTime -= Time.deltaTime;

                if (_spawnTime <= 0)
                {
                    for (int i = 0; i < parachuts.Count; i++)
                    {
                        SpawnParachuts();
                        yield return new WaitForSeconds(1f);
                    }

                    // Reset cooldown
                    _spawnTime = coolDown;
                }
            }
        }

        // Spawns the parachuts in ranom postions.
        private void SpawnParachuts()
        {
            GameObject pSpawn = parachuts[Random.Range(0, parachuts.Count)];
            Vector2 newPost = new Vector2(Random.Range(-5, 7), 6);
            Instantiate(pSpawn, newPost, Quaternion.identity);
        }
    }

}
