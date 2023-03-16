using UnityEngine;
using UnityEngine.Events;

public class CheckCollider : MonoBehaviour
{
    public event UnityAction InflictDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.TakeDamage(1);
            InflictDamage?.Invoke();
        }
    }
}