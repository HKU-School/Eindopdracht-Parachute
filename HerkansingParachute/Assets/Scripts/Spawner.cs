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

        private List<GameObject> _spawnedParachutes = new List<GameObject>();
        private Coroutine _spawnCoroutine;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            GameManager.instance.OnGameOver += StopAndClear;
            _spawnCoroutine = StartCoroutine(SpawnLoop());
        }

        // Spawn parachutes with cooldown
        private IEnumerator SpawnLoop()
        {
            yield return new WaitForSeconds(3f);

            while (true)
            {
                SpawnParachuts();
                yield return new WaitForSeconds(coolDown);
            }
        }

        // Spawns the parachuts in random postions.
        private void SpawnParachuts()
        {
            GameObject randomParachute = parachutes[Random.Range(0, parachutes.Count)];
            Vector2 spawnPosition = new Vector2(Random.Range(minX, maxX), spawnY);
            GameObject instance = Instantiate(randomParachute, spawnPosition, Quaternion.identity);
            _spawnedParachutes.Add(instance);
        }

        // Stops spawning parachutes and remove all active
        private void StopAndClear()
        {
            if (_spawnCoroutine != null)
            {
                StopCoroutine(_spawnCoroutine);
            }

            foreach (var p in _spawnedParachutes)
            {
                if (p != null)
                {
                    Destroy(p);
                }
            }
            _spawnedParachutes.Clear();
        }

        private void OnDestroy()
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.OnGameOver -= StopAndClear;
            }
        }
    }
}