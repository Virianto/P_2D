using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// Aqui va el enunciado del proposito de esta clase
/// </summary>

public class B_CapsulePlayer : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    Rigidbody2D rb_2D;

    [SerializeField]
    [Range(1, 15)]
    float jumpForce = 30;

    [SerializeField]
    [Range(1, 15)]
    float dashForce = 3;

    [SerializeField]
    [Range(1, 20)]
    float moveSpeed = 3;

    float movementValue;

    #endregion
    #region METHODS

    void OnJump()
    {
        rb_2D.linearVelocityY = jumpForce;
        Debug.Log("He saltado");
    }
    void OnDash()
    {
        rb_2D.linearVelocityX = dashForce;
        Debug.Log("He echo DASH");
    }

    void OnMove(InputValue value)
    {
        movementValue = value.Get<float>();
    }

    private void FixedUpdate()
    {
        //rb_2D.MovePosition(rb_2D.position + movementValue * moveSpeed * Time.fixedDeltaTime);
    }
    #endregion
}

