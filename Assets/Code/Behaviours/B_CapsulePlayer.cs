using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// X IMPLEMENTAR DIRECCIÓN 
/// X ARREGLAR EL DASH
/// * IMPLEMENTAR DETECCIÓN DE SUELO
/// * IMPLEMENTAR DOBLE SALTO
/// * IMPLEMENTAR BALANCEO
/// </summary>
public class B_CapsulePlayer : MonoBehaviour
{
    #region ATTRIBUTES

    [Header("EXTERNAL REFERENCES")]

    [SerializeField]
    Rigidbody2D rb_2D;
    [SerializeField]
    M_SwingPoints swingPointsManager;

    [Header("EDITABLE VALUES")]

    [SerializeField]
    [Range(1, 15)]
    float jumpForce = 2;

    [SerializeField]
    [Range(1, 15)]
    float dashForce = 3;

    [SerializeField]
    [Range(1, 20)]
    float moveSpeed = 3;

    float movementValue;

    // Variable para controlar hacia dónde enfoco acciones y conectores
    float facingDirection = 1;

    bool isDashing = false;
    bool isGrounded = false;
    bool isDoubleJumping = false;
    bool isCrouching = false;
    bool isSwinging = false;
    Vector3 playerScale;

    #endregion

    #region METHODS

    private void Awake()
    {
        playerScale = transform.localScale;
    }

    void OnMove(InputValue value)
    {
        // Introducir información de Input en la variable movementValue

        movementValue = value.Get<float>();

        if (movementValue != 0)
            facingDirection = movementValue >= 0 ? 1 : -1;
    }

    void FixedUpdate()
    {
        if (!isDashing || !isSwinging)
            rb_2D.linearVelocityX = movementValue * moveSpeed;
    }

    void OnJump()
    {
        if (isGrounded)
        {
            // Acceder al componente RigidBody2D a través de la variable y modificar su velocidad vertical
            rb_2D.linearVelocityY = jumpForce;
        }
        else if (!isDoubleJumping)
        {
            rb_2D.linearVelocityY = jumpForce;
            isDoubleJumping = true;
        }
    }

    void OnDash()
    {
        if (!isDashing)
        {
            StartCoroutine(DashRoutine());
        }         
    }

    void OnCrouch(InputValue input)
    {
        isCrouching = input.isPressed;
        Debug.Log("Me estoy agachando");

        Vector3 newPlayerScale = playerScale;

        newPlayerScale.y = isCrouching ? playerScale.y / 1.5f : playerScale.y;
        transform.localScale = newPlayerScale;
    }

    void OnSwing(InputValue input)
    {
        if (input.isPressed)
        {
            Debug.Log("Conectado");
            isSwinging = true;
            swingPointsManager.ConnectPlayerToJoint();
        }
        else
        {
            isSwinging = false;
            swingPointsManager.DisconnectPlayerJoint();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Debug.Log("Detectado suelo");
            isGrounded = true;
            isDoubleJumping = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
            isGrounded = false;
    }

    #endregion
}
