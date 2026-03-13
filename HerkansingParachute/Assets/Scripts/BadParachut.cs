using Enemy;
using UnityEngine;

public class BadParachut : Parachutist
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.RemovePoint(minPoints);
        }
        else
        {
            base.OnTriggerEnter2D(other);
        }
    }
}
