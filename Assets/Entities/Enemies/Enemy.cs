using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float moveSpeed = 0f;
    public float health = 0f;

    public virtual void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            if (bullet != null)
            {
                TakeDamage(bullet.damage);
                if (UIScript.Instance != null)
                {
                    UIScript.Instance.UpdateScore(100);
                }
                Debug.Log("Health left: " + health);
            }
        }
    }
}
