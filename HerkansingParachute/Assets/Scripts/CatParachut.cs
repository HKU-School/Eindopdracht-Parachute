using Enemy;
using UnityEngine;

public class CatParachut : MonoBehaviour
{
    // Amount of cats needed to get extra lives. 
    [SerializeField] private int catchAmountNeeded;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.CatCaught(catchAmountNeeded);
            }
            Destroy(gameObject);
        }
        if (other.CompareTag("Ground"))
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.GameOver();
            }
        }
    }
}
