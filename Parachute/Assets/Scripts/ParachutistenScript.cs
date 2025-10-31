using Unity.VisualScripting;
using UnityEngine;

public class ParachutistenScript : MonoBehaviour
{
    private float pSpeed;
    [SerializeField] private float minSpeed = 3f;
    [SerializeField] private float maxSpeed = 6f;
    private Vector2 dir;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        pSpeed = Random.Range(minSpeed, maxSpeed);
        dir = new Vector2(Random.Range(-1f, 1f), -1f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = dir * pSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Destroy parachuts when touch ground or wall
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        if (CompareTag("Parachutisten") && other.CompareTag("Ground"))
        {
            // Remove point when good parachutisten touch ground
            GameManager.instance.RemovePoint(); 
            Destroy(gameObject);
        }
        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

        // Turn other diraction when hit wall
        if (other.CompareTag("Wall"))
        {
            Debug.Log("touch wall");
            if(dir.x < 0f)
            {
                dir.x = 1f;
            }
            else if (dir.x > 0f)
            {
                dir.x = -1f;
            }
        }
    }
}
