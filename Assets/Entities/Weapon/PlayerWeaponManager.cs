using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    public Weapon[] weaponLevels;
    private int currentLevel = 0;

    void Start()
    {
        ActivateWeapon(currentLevel);
    }

    public void Fire()
    {
        weaponLevels[currentLevel].Fire();
    }

    public void UpgradeWeapon()
    {
        if (currentLevel < weaponLevels.Length - 1)
        {
            if (weaponLevels[currentLevel] != null)
            {
                weaponLevels[currentLevel].gameObject.SetActive(false);
            }
            currentLevel++;
            ActivateWeapon(currentLevel);
            Debug.Log("Weapon upgraded to level " + currentLevel);
        }
    }

    void ActivateWeapon(int index)
    {
        for (int i = 0; i < weaponLevels.Length; i++)
        {
            weaponLevels[i].gameObject.SetActive(i == index);
        }
    }
}
