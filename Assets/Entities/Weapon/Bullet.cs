using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject[] hitEffect;
    public string ownerTag;
    public float speed = 0f;
    public float damage = 0f;

    void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime, Space.World);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        int randomEffect = Random.Range(0, hitEffect.Length);
        Instantiate(hitEffect[randomEffect], transform.position, Quaternion.identity);
    }
}
