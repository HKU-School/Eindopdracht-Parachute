using UnityEngine;

public class Bomb : MonoBehaviour
{
    [Header("Speed and -points")]
    [SerializeField] private float fallSpeed;
    private Rigidbody2D _rb;

    [SerializeField] private int minPoints;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.linearVelocity = Vector2.down * fallSpeed;
    }

    // Handles collision with player or ground.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.RemovePoint(minPoints);
            GameManager.instance.TakeDamage();
            Destroy(gameObject);
        }
        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
