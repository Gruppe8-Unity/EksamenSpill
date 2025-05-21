using UnityEngine;

public class AdvancedUpgradedWeapon : Weapon
{
    public float offset = 0.2f;
    public float moreOffset = 1.5f;
        //Lyd
    public AudioSource sfxSource;
    public AudioClip fireSound;


    public override void Fire()
    {
        Vector3 left = firePosition.position + firePosition.right * -offset;
        Vector3 middle_left = firePosition.position + firePosition.right * (-offset - moreOffset);
        Vector3 middle_right = firePosition.position + firePosition.right * (offset + moreOffset);
        Vector3 right = firePosition.position + firePosition.right * offset;

        SpawnBullet(left, firePosition.rotation);
        SpawnBullet(middle_left, firePosition.rotation);
        SpawnBullet(middle_right, firePosition.rotation);
        SpawnBullet(right, firePosition.rotation);
        //Lyd
        if (sfxSource != null && fireSound != null)
        {
            sfxSource.PlayOneShot(fireSound); 
        }
    }
}
