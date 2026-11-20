using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// X IMPLEMENTAR DIRECCIÓN 
/// X ARREGLAR EL DASH
/// * IMPLEMENTAR DETECCIÓN DE SUELO
/// * IMPLEMENTAR DOBLE SALTO
/// * IMPLEMENTAR BALANCEO
/// Referencia a AnimatorController
/// </summary>
public class B_CapsulePlayer : MonoBehaviour
{
    #region ATTRIBUTES

    [Header("EXTERNAL REFERENCES")]

    [SerializeField]
    Rigidbody2D rb_2D;
    [SerializeField]
    M_SwingPoints swingPointsManager;
    [SerializeField]
    Animator animator;

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
    float originalXScale;

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
        originalXScale = transform.localScale.x;
    }

    void OnMove(InputValue value)
    {
        animator.SetBool("IsCrouching", false);
        // Introducir información de Input en la variable movementValue

        movementValue = value.Get<float>();

        if (movementValue != 0)
        {
            facingDirection = movementValue >= 0 ? 1 : -1;
            playerScale = new Vector3(originalXScale * facingDirection, playerScale.y, playerScale.z);
            transform.localScale = playerScale;
        }
    }

    void FixedUpdate()
    {
        if (!isDashing && !isSwinging && !isCrouching) 
        {
            rb_2D.linearVelocityX = movementValue * moveSpeed;
            animator.SetFloat("HorizontalSpeed", Mathf.Abs(rb_2D.linearVelocityX));
        }

        //Control de velocidad vertical para controlar animaciones
        animator.SetFloat("VerticalSpeed", rb_2D.linearVelocityY);
    }

    void OnJump()
    {
        if (isGrounded)
        {
            // Acceder al componente RigidBody2D a través de la variable y modificar su velocidad vertical
            rb_2D.linearVelocityY = jumpForce;
            animator.SetBool("IsCrouching", false);
        }
        else if (!isDoubleJumping)
        {
            rb_2D.linearVelocityY = jumpForce;
            isDoubleJumping = true;
            animator.Play("Jump", 0, 0);
        }
    }

    void OnDash()
    {
        if (!isDashing)
        {
            animator.Play("Dash", 0, 0);
            StartCoroutine(DashRoutine());
            //animator.Play("MartialHero", 0, 0);
        }
    }

    void OnCrouch(InputValue input)
    {
        if (isCrouching = input.isPressed)
            animator.SetBool("IsCrouching", true);
        else
            animator.SetBool("IsCrouching", false);

        //Vector3 newPlayerScale = playerScale;

        //newPlayerScale.y = isCrouching ? playerScale.y / 1.5f : playerScale.y;
        //transform.localScale = newPlayerScale;
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
            animator.SetBool("IsGrounded", isGrounded);
            isDoubleJumping = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGrounded = false;
            animator.SetBool("IsGrounded", isGrounded);
        }
    }

    #endregion
}
