using Unity.VisualScripting;
using UnityEngine;

public class ParachutistenScript : MonoBehaviour
{
    [SerializeField] GameObject _SpawnPost;
    [SerializeField] private float _pSpeed = 3f;
    private Rigidbody _rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Playere detectid");
            Destroy(gameObject);
        }
    }
}
