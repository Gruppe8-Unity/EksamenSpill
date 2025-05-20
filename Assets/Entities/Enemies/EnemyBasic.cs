using UnityEngine;

public class EnemyBasic : Enemy
{

    void FixedUpdate()
    {
        transform.Translate(-Vector2.down * moveSpeed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
        Debug.Log("Enemy gone!");
    }
}
