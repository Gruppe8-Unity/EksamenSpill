using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BaseWeapon : Weapon
{
    public override void Fire()
    {
        SpawnBullet(firePosition.position, firePosition.rotation);
    }
}
