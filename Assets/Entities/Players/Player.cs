using UnityEngine;

public class Player : MonoBehaviour
{
    const float CREDIT = 10f;

    public float health = 0f;
    public float moveSpeed = 0f;

    private float screenWidth;
    private float screenHeight;

    void Awake()
    {
        health = CREDIT;
        float verticalSize = Camera.main.orthographicSize * 2f;
        screenHeight = verticalSize;
        screenWidth = verticalSize * Camera.main.aspect;
    }

    void Start()
    {
        UIScript.Instance.UpdateHealth(health);
    }

    void Update()
    {
        WrapPlayerAroundScreen();
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

    public float GetHealth()
    {
        return health;
    }

    public void WrapPlayerAroundScreen()
    {
        Vector3 position = transform.position;

        float halfWidth = screenWidth / 2f;
        float halfHeight = screenHeight / 2f;

        if (position.x < -halfWidth)
            position.x = halfWidth;
        else if (position.x > halfWidth)
            position.x = -halfWidth;

        if (position.y < -halfHeight)
            position.y = halfHeight;
        else if (position.y > halfHeight)
            position.y = -halfHeight;

        transform.position = position;

    }
}
