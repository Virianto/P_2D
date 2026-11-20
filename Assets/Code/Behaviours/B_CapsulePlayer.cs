using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// * Conectar esta clase con el componente PlayerInput
/// * Crear métodos específicos para las acciones del ActionMap
/// * Rellenar esos métodos con la funcionalidad correspondiente
/// * Referenciar al Manager de puntos de balanceo
/// * Referenciar al AnimatorController
/// * Vincular variables de movimiento
/// </summary>
public class B_CapsulePlayer : MonoBehaviour
{
    #region ATTRIBUTES

    [Header("External references")]

    M_DungeonManager dungeonManager;

    [SerializeField]
    Rigidbody2D rb_2D;

    [SerializeField]
    Animator animController;

    [SerializeField]
    M_SwingPoints swingsPointsManager;

    [Header("Editable values")]

    public int lifes = 3;

    [SerializeField]
    [Range(1, 15)]
    float jumpForce = 10;

    [SerializeField]
    [Range(1, 15)]
    float dashForce = 10;

    [SerializeField]
    [Range(1, 15)]
    float moveSpeed = 5;

    public AudioSource jump;

    public AudioSource damage;

    public AudioSource keyCollected;

    public AudioSource heart;

    public AudioSource sword;

    float movementValue;

    float originalXScale;

    // Variable para controlar hacia dónde enfocamos acciones y conectores
    float facingDirection = 1;

    bool isDashing = false;

    bool isGrounded = false;

    bool isDoubleJumping = false;

    bool isCrouching = false;

    bool isSwinging = false;

    #endregion





    #region METHODS

    private void Awake()
    {
        originalXScale = transform.localScale.x;
    }

    void OnJump()
    {
        // Acceder al componente Rigidbody2D a través de la variable y modificar su velocidad vertical
        if (isGrounded && !isCrouching)
        {
            rb_2D.linearVelocityY = jumpForce;
            jump.Play();
        }
        else if (!isDoubleJumping && !isCrouching)
        {
            rb_2D.linearVelocityY = jumpForce;
            jump.Play();

            isDoubleJumping = true;
        }
    }

    void OnDash()
    {
        if (!isDashing && !isCrouching)
        {
            StartCoroutine(DashRoutine());
        }
    }

    void OnAttack(InputValue value)
    {
        if (!isDashing && !isCrouching)
        {
            animController.SetTrigger("IsAttacking");

            sword.Play();
        }
    }

    IEnumerator DashRoutine()
    {
        // Empujar al jugador con la fuerza indicada
        rb_2D.linearVelocityX = dashForce * facingDirection;

        // Modificar el boolenao de estado
        isDashing = true;

        // Esperar un tiempo
        yield return new WaitForSeconds(1);

        // Modificar el booleano de estado
        isDashing = false;
    }

    void OnMove(InputValue value)
    {
        // Introducir información de Input en la variable movementValue
        movementValue = value.Get<float>();

        if (movementValue != 0)
        {
            facingDirection = movementValue > 0 ? 1 : -1;

            transform.localScale = new Vector3(facingDirection, transform.localScale.y, transform.localScale.z);
        }
    }

    void OnCrouch(InputValue value)
    {
        isCrouching = value.isPressed;

        Vector3 newLocalScale = new Vector3(transform.localScale.x, isCrouching ? (transform.localScale.y / 2) : (transform.localScale.y * 2), transform.localScale.z);
        transform.localScale = newLocalScale; 

        animController.SetBool("IsCrouching", isCrouching);
    }

    void OnSwing(InputValue value)
    {
        if (value.isPressed)
        {
            isSwinging = true;
            swingsPointsManager.ConnectPlayerToJoint();
        }
        else
        {
            isSwinging = false;
            swingsPointsManager.DisconnectPlayerFromJoint();
        }
    }

    private void FixedUpdate()
    {
        if (!isDashing && !isSwinging)
        // !isDashing && !isSwinging -> True cuando los dos booleanos son False
        // !isDashing || !isSwinging -> True cuando uno o los dos booleanos son False

        {
            rb_2D.linearVelocityX = movementValue * moveSpeed;

            animController.SetFloat("HorizontalSpeed", Mathf.Abs(rb_2D.linearVelocityX));
        }

        animController.SetFloat("VerticalSpeed", rb_2D.linearVelocityY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            // Modificar un booleano que permita saltar
            isGrounded = true;

            // Modificar un booleano que no permita saltar más
            isDoubleJumping = false;

            // Comunicar al AnimatorController que estamos en el suelo
            animController.SetBool("IsGrounded", isGrounded);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            // Modificar un booleano que no permita saltar
            isGrounded = false;

            // Comunicar al AnimatorController que estamos en el suelo
            animController.SetBool("IsGrounded", isGrounded);
        }    
    }

    #endregion
}