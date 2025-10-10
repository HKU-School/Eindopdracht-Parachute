using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> parachuts = new List<GameObject>();
    [SerializeField] private float _coolDown = 5;
    private float _unitlSpawn = 0;



    // Update is called once per frame
    void Update()
    {
        _unitlSpawn -= Time.deltaTime;
        if (_unitlSpawn <= 0)
        {
            for (int i = 0; i < parachuts.Count; i++)
            {
                SpawnParachuts();   
            }

            //reset cooldown
            _unitlSpawn = _coolDown;
        }
        
    }

    private void SpawnParachuts()
    {
        GameObject pSpawn = parachuts[Random.Range(0, parachuts.Count)];
        Vector2 newPost = new Vector2(Random.Range(-7, 7), 6);
        Instantiate(pSpawn, newPost, Quaternion.identity);
    }
}
