using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePosition;
    public float bulletSpeed = 10f;
    public float damage = 1f;

    public virtual void Fire()
    {
        SpawnBullet(firePosition.position, firePosition.rotation);
    }

    protected void SpawnBullet(Vector3 position, Quaternion rotation)
    {
        GameObject newBullet = Instantiate(bulletPrefab, position, rotation);
        Bullet bullet = newBullet.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.speed = bulletSpeed;
            bullet.damage = damage;
            bullet.ownerTag = "Player";
        }
    }
}
