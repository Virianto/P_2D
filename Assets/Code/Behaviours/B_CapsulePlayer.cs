using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Vamos a conectar esta clase con PlayerInput
/// Crear métodos para acciones del ActionMap
/// Rellenar métodos con funcionalidad
/// </summary>
public class B_CapsulePlayer : MonoBehaviour
{
    #region ATTRIBUTES

    [Header("EXTERNAL REFERENCES")]
    
    [SerializeField]
    Rigidbody2D rb;

    [Header("EDITABLE REFERENCES")]
    
    [SerializeField]
    [Range(1, 15)]
    float jumpForce = 2;

    [SerializeField]
    [Range(1, 5)]
    float dashForce = 3;

    [SerializeField]
    [Range(1, 20)]
    float moveSpeed = 3;

    float movementValue;

    #endregion

    #region METHODS

    void OnJump()
    {
        rb.linearVelocityY = jumpForce;
    }

    void OnDash()
    {
        rb.linearVelocityX = dashForce;
    }

    void OnMove(InputValue input)
    {
        movementValue = input.Get<float>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position +
            (rb.position * movementValue * moveSpeed * Time.fixedDeltaTime));        
    }

    #endregion
}
