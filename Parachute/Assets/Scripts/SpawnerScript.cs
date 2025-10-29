using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> parachuts = new List<GameObject>();
    [SerializeField] private float coolDown = 5;
    private float unitlSpawn = 0;
     
    

    private void Start()
    {
       StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop ()
    {
        yield return new WaitForSeconds(5f);
        
        while (true)
        {
            yield return new WaitForEndOfFrame();
            unitlSpawn -= Time.deltaTime;

            if (unitlSpawn <= 0)
            {
                for (int i = 0; i < parachuts.Count; i++)
                {
                    SpawnParachuts();
                    yield return new WaitForSeconds(1f);
                }

                // Reset cooldown
                unitlSpawn = coolDown;
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
