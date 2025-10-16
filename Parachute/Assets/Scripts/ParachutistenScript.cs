using Unity.VisualScripting;
using UnityEngine;

public class ParachutistenScript : MonoBehaviour
{
    private float pSpeed;
    private Vector2 dir;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        pSpeed = Random.Range(3f, 6f);
        dir = new Vector2(Random.Range(-1f, 1f), -1f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = dir * pSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Ground"))
        {
            Debug.Log("Playere detectid or Ground");
            Destroy(gameObject);
        }

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
