using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BaseWeapon : Weapon
{
        //Lyd
    public AudioSource sfxSource;
    public AudioClip fireSound;
    public override void Fire()
    {
        SpawnBullet(firePosition.position, firePosition.rotation);
        //Lyd
        if (sfxSource != null && fireSound != null)
        {
            sfxSource.PlayOneShot(fireSound);
        }
    }
}
