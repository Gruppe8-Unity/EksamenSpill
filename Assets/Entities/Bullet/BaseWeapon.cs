using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BaseWeapon : Weapon
{
    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            InstantiateBullet();
        }
    }

    private void InstantiateBullet()
    {
        GameObject newBullet = Instantiate(bulletPrefab, firePosition.position, Quaternion.identity);
    }
}
