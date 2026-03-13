using Enemy;
using UnityEngine;

public class NormalParachut : Parachutist
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.AddPoint();
        }
        if (other.CompareTag("Ground"))
        {
            GameManager.instance.RemovePoint();
        }
        else
        {
            base.OnTriggerEnter2D(other);
        }
    }
}
