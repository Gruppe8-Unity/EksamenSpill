using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float moveSpeed = 0f;
    public float health = 0f;
    //Lyd
    public AudioClip hitSound;
    public virtual void TakeDamage(float amount)
    {
        //Lyd
        GameObject sfxPlayer = GameObject.Find("SFXPlayer");
        if (sfxPlayer != null && hitSound != null)
        {
            AudioSource sfx = sfxPlayer.GetComponent<AudioSource>();
            if (sfx != null)
            {
                sfx.PlayOneShot(hitSound);
            }

            health -= amount;

            if (health <= 0)
            {
                Destroy(gameObject);
            }
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

