using Enemy;
using UnityEngine;

public class BadParachut : MonoBehaviour
{
    [SerializeField] private int minPoints;

    // Handles collision with player
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.RemovePoint(minPoints);
            GameManager.instance.TakeDamage();
        }
    }
}
