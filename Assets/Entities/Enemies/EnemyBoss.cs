using System;
using UnityEngine;

public class EnemyBoss : Enemy
{
    public float positionLimit = 20;

    private bool movingRight = true;

    void Update()
    {
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
}
