using System;
using UnityEngine;

public class EnemyBoss : Enemy
{
    public GameObject bulletPrefab;
    public Transform crossfire;
    public float positionLimit = 20f;
    public float cooldown;

    private float timer;
    private bool movingRight;

    void Start()
    {
        crossfire.rotation = Quaternion.Euler(0f, 0f, 180f);
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            Fire();
            timer = cooldown;
        }

        if (movingRight)
        {
            transform.Translate(-Vector2.right * moveSpeed * Time.deltaTime);
            if (transform.position.x >= positionLimit)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            if (transform.position.x <= -positionLimit)
            {
                movingRight = true;
            }
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, crossfire.position, crossfire.rotation);
        Bullet bulletComponent = bullet.GetComponent<Bullet>();

        if (bulletComponent != null)
        {
            bulletComponent.ownerTag = "Enemy";
        }
    }
}
