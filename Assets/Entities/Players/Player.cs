using UnityEngine;

public class Player : MonoBehaviour
{
    const float CREDIT = 10f;

    public float health = 0f;
    public float moveSpeed = 0f;

    void Awake()
    {
        health = CREDIT;
    }

    void Start()
    {
        UIScript.Instance.UpdateHealth(health);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage();
            Debug.Log("PLAYER HEALTH: " + health);

            if (collision.gameObject.CompareTag("Bullet"))
            {
                Destroy(collision.gameObject);
            }

            if (collision.gameObject.CompareTag("Enemy"))
            {
                Destroy(collision.gameObject);
            }
        }
    }

    public void TakeDamage()
    {
        health -= 1;
        UIScript.Instance.UpdateHealth(health);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void RestrictPosition(Rigidbody2D body)
    {
        Vector2 pos = body.position;
        pos.x = Mathf.Clamp(pos.x, 0, Screen.width);
        pos.y = Mathf.Clamp(pos.y, 0, Screen.height);
        body.MovePosition(pos);   
    }
}
