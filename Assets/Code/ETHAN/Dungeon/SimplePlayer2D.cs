using UnityEngine;
using UnityEngine.InputSystem;


public class SimplePlayer2D : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2D;
    [SerializeField] [Range(1, 5)] float jumpForce;
    [SerializeField] [Range(1, 5)] float dashForce;
    [SerializeField] [Range(1, 5)] float moveSpeed;
    float movementValue;

    void ObMove(InputValue value)
    {
        movementValue = value.Get<float>();
    }

    void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + (rb2D.position * movementValue * moveSpeed * Time.fixedDeltaTime));
    }

    void OnJump()
    {
        rb2D.linearVelocityY = jumpForce;
    }
    
    void OnDash()
    {
        rb2D.linearVelocityX = dashForce;
    }

}
