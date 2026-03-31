using UnityEngine;

public class BombDropper : MonoBehaviour
{
    [Header("Bombs setting")]
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private float dropTime;

    private int _BombsDrop = 1;
    private float _timer;

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= dropTime)
        {
            DropBomb();
            _timer = 0;
        }
    }

    private void DropBomb()
    {
        Instantiate(bombPrefab, transform.position, Quaternion.identity);
    }
}
