using Enemy;
using System.Collections;
using UnityEngine;

public class GoodParachut : MonoBehaviour
{
    [SerializeField] private int plusPoints;
    [SerializeField] private int minPoints;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.AddPoint(plusPoints);
        }
        if (other.CompareTag("Ground"))
        {
            GameManager.instance.RemovePoint(minPoints);
            GameManager.instance.ParachutMissed();
        }
    }

   
}

