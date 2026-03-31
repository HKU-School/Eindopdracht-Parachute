using UnityEngine;

namespace Enemy
{
    public class Parachutist : MonoBehaviour
    {
        private Rigidbody2D _rb;
        private Vector2 _dir;

        [Header("Parachutist Values")]
        [SerializeField] protected float speed;
        [SerializeField] protected float fallAngle;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            float xDir = Random.value < 0.5f ? -1f : 1f;
            _dir = new Vector2(xDir * fallAngle, -1f).normalized;
        }

        // Update is called once per frame
        private void Update()
        {
            Move();
        }

        private void Move()
        {
            _rb.linearVelocity = _dir * speed;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // Destroy objects
            if (other.CompareTag("Player") || other.CompareTag("Ground"))
            {
                Destroy(gameObject);
            }
            // Turns other diraction
            if (other.CompareTag("Wall"))
            {
                _dir.x *= -1f;
            }
        }
    }
}

