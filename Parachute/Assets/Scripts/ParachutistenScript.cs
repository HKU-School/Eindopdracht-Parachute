using Unity.VisualScripting;
using UnityEngine;

public class ParachutistenScript : MonoBehaviour
{
    private float _pSpeed;
    private Vector2 _dir;
    private Rigidbody2D _rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _pSpeed = Random.Range(3f, 6f);
        _dir = new Vector2(Random.Range(-1f, 1f), -1f);
    }

    // Update is called once per frame
    void Update()
    {
        _rb.linearVelocity = _dir * _pSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Playere detectid");
            Destroy(gameObject);
        }

        if(other.CompareTag("Wall"))
        {
            Debug.Log("touch wall");
            if(_dir.x < 0f)
            {
                _dir.x = 1f;
            }
            else if (_dir.x > 0f)
            {
                _dir.x = -1f;
            }
        }
    }
}
