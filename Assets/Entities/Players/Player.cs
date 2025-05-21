using System;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    const float CREDIT = 10f;

    public String playerName;
    public float health = 0f;
    public float moveSpeed = 0f;
    public TMP_Text healthText;

    private float screenWidth;
    private float screenHeight;

    void Awake()
    {
        health = CREDIT;
        float verticalSize = Camera.main.orthographicSize * 2f;
        screenHeight = verticalSize;
        screenWidth = verticalSize * Camera.main.aspect;
    }

    void Update()
    {
        WrapPlayerAroundScreen();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Bullet bullet = collision.GetComponent<Bullet>();
            if (bullet != null && bullet.ownerTag == "Player")
            {
                return;
            }

            TakeDamage();
            Destroy(collision.gameObject);
            Debug.Log("PLAYER HEALTH: " + health);
            return;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage();
            Destroy(collision.gameObject);
            Debug.Log("PLAYER HEALTH: " + health);
        }

        if (collision.gameObject.CompareTag("Boss"))
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        health -= 1;
        if (healthText != null)
        {
            healthText.text = playerName + health;
        }

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

        if (position.x <= -halfWidth)
            position.x = halfWidth;
        else if (position.x >= halfWidth)
            position.x = -halfWidth;

        if (position.y <= -halfHeight)
            position.y = halfHeight;
        else if (position.y >= halfHeight)
            position.y = -halfHeight;

        transform.position = position;

    }
}
