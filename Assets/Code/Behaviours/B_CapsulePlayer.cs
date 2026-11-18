using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

/// <summary>
/// X IMPLEMENTAR DIRECCIÓN 
/// X ARREGLAR EL DASH
/// X IMPLEMENTAR DETECCIÓN DE SUELO
/// X IMPLEMENTAR DOBLE SALTO
/// X IMPLEMENTAR AGACHARSE
/// * IMPLEMENTAR BALANCEO
/// </summary>
public class B_CapsulePlayer : MonoBehaviour
{
    #region ATTRIBUTES

    [Header("EXTERNAL REFERENCES")]

    [SerializeField]
    Rigidbody2D rb_2D;

    [Header("EDITABLE VALUES")]

    [SerializeField]
    [Range(1, 30)]
    float jumpForce = 2;

    [SerializeField]
    [Range(1, 30)]
    float dashForce = 3;

    [SerializeField]
    [Range(1, 15)]
    float moveSpeed = 3;

    float movementValue;

    // Variable para controlar hacia dónde enfoco acciones y conectores
    float facingDirection = 1;

    bool isDashing = false;
    bool isGrounded = false;
    bool isDoubleJumping = false;
    bool isCrouching = false;

    #endregion

    #region METHODS

    void OnMove(InputValue value)
    {
        // Introducir información de Input en la variable movementValue
        movementValue = value.Get<float>();

        if (movementValue != 0) 
        {
            facingDirection = movementValue > 0 ? 1 : -1;
        }
        
    }

    void FixedUpdate()
    {
        if (!isDashing)
        {
            rb_2D.linearVelocityX = movementValue * moveSpeed;
        }        
    }

    void OnJump(InputValue value)
    {
        // Acceder al componente RigidBody2D a través de la variable y modificar su velocidad vertical
        if (isGrounded)
        {
            rb_2D.linearVelocityY = jumpForce;
        }
        else if (!isDoubleJumping)
        {
            rb_2D.linearVelocityY = jumpForce;
            isDoubleJumping = true; 
        }

        Debug.Log(value.isPressed);
    }

    void OnDash()
    {
        if (!isDashing)
        {
            StartCoroutine(DashRoutine());
        }         
    }

    IEnumerator DashRoutine()
    {
        // Empujar al jugador con la fuerza indicada
        rb_2D.linearVelocityX = dashForce * facingDirection;
        // Modificar el booleano de estado
        isDashing = true;
        // Esperar un tiempo X
        yield return new WaitForSeconds(0.5f);
        // Modificar el booleano de estado
        isDashing = false;
    }

    void OnCrouch(InputValue value)
    {
        isCrouching = value.isPressed;

        Vector3 newLocalScale = new Vector3(
            transform.localScale.x,
            isCrouching ? (transform.localScale.y / 2) : (transform.localScale.y * 2),
            transform.localScale.z);

        transform.localScale = newLocalScale;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {     
        if (collision.CompareTag("Ground"))
        {
            isGrounded = true;
            isDoubleJumping = false;
        }        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGrounded = false;
        }        
    }

    #endregion
}
