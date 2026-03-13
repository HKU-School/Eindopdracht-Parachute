using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ParachutSpawner
{
    public class Spawner : MonoBehaviour
    {
        [Header("Spawner Values")]
        [SerializeField] private List<GameObject> parachutes = new List<GameObject>();
        [SerializeField] private float coolDown;

        [Header("Spawner Area")]
        [SerializeField] private float minX;
        [SerializeField] private float maxX;
        [SerializeField] private float spawnY;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            StartCoroutine(SpawnLoop());
        }

        // Coroutine that spawns parachuts after delay 
        private IEnumerator SpawnLoop()
        {
            yield return new WaitForSeconds(3f);

            while (true)
            {
                SpawnParachuts();
                yield return new WaitForSeconds(coolDown);
            }
        }

        // Spawns the parachuts in ranom postions.
        private void SpawnParachuts()
        {
            GameObject randomParachute = parachutes[Random.Range(0, parachutes.Count)];
            Vector2 spawnPosition = new Vector2(Random.Range(minX, maxX), spawnY);
            Instantiate(randomParachute, spawnPosition, Quaternion.identity);
        }
    }
}