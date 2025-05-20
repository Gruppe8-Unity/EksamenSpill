using UnityEngine;

public class EnemyBasic : Enemy
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TakeDamage(1);
            Debug.Log("ATTACKING PLAYER");
        }
    }
}
