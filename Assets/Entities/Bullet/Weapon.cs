using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePosition;

    public void Fire()
    {
        GameObject newBullet = Instantiate(bulletPrefab, firePosition.position, Quaternion.identity);
    }
}
