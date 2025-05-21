using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerOne : Player
{
    public Rigidbody2D body;
    public PlayerWeaponManager weaponManager;

    Vector2 moveDirection = Vector2.zero;

    void FixedUpdate()
    {
        //RestrictPosition(body);
        body.linearVelocity = moveDirection * moveSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();

    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            weaponManager.Fire();
        }
    }

}
