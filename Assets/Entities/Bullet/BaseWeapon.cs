using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BaseWeapon : Weapon
{
    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Fire();
        }
    }
}
