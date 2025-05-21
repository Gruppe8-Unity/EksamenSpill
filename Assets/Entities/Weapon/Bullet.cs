using UnityEngine;

public class Bullet : MonoBehaviour
{
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
}
