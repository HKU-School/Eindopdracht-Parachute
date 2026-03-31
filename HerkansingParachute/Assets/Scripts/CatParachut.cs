using Enemy;
using UnityEngine;

public class CatParachut : MonoBehaviour
{
    [SerializeField] private int plusPoints;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.AddPoint(plusPoints);
        }
        if (other.CompareTag("Ground"))
        {
            // Make an link to death screen that is managed with the game manager. 
            // When Cat hits ground Just instance game ove cause how dare you let a cat fall
        }
    }
}
