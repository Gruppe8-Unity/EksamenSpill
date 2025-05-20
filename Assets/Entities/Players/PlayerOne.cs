using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerOne : MonoBehaviour
{
    public Rigidbody2D body;
    public float moveSpeed = 0;

    Vector2 moveDirection = Vector2.zero;

    void FixedUpdate()
    {
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
            Debug.Log("FIRED!");
        }
    }
}
