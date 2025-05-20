using UnityEngine;

public class EnemyBasic : Enemy
{

    void FixedUpdate()
    {
        transform.Translate(-Vector2.down * moveSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TakeDamage(1);
            Debug.Log("ATTACKING PLAYER");
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
        Debug.Log("Enemy gone!");
    }
}
