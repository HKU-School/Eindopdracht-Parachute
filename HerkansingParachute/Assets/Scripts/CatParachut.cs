using Enemy;
using UnityEngine;

public class CatParachut : Parachutist
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.AddPoint(plusPoints);
        }
        if (other.CompareTag("Ground"))
        {
            GameManager.instance.RemovePoint(minPoints);

            // When Cat hits ground Just instance game ove cause how dare you let a cat fall
        }
 
        base.OnTriggerEnter2D(other);
    }
}
