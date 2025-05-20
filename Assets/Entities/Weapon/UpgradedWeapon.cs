
using UnityEngine;
using UnityEngine.InputSystem;

public class UpgradedWeapon : Weapon
{
    public float offset = 0.4f;

    public override void Fire()
    {
        Vector3 left = firePosition.position + firePosition.right * -offset;
        Vector3 right = firePosition.position + firePosition.right * offset;

        SpawnBullet(left, firePosition.rotation);
        SpawnBullet(right, firePosition.rotation);
    }
}