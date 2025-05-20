using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.UI;

public abstract class Enemy : MonoBehaviour
{
    public float moveSpeed = 0;
    public float health = 0;

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
