using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Conectar esta clase con el componente PlayerInput
/// Crear métodos específicos para las acciones del ActionsMap
/// Rellenar esos métodos con la funcionalidad correspondiente
/// Añadir una referencia al manager de puntos de balanceo
/// 
/// Crear una referencia al AnimatorController
/// Vincular variablesde movimientos con parámetros
/// </summary>
public class B_CapsulePlayer : MonoBehaviour
{
    #region ATTRIBUTES
    [Header("External references")]
    [SerializeField]
    Rigidbody2D rb_2D;

    [SerializeField]
    M_SwingPoints swigPointsManager;

    [SerializeField]
    Animator animController;

    [Header("Editable Values")]
    [SerializeField]
    [Range(1, 10)]
    float playerSpeed = 3;

    [SerializeField]
    [Range (1, 15)]
    float playerJumpForce = 2;

    [SerializeField]
    [Range(1, 15)]
    float playerDashForce = 3;

    float movementValue;
    //Variable para controlar hacia donde enfoco acciones y conexiones
    float facingDirection = 1;

    bool isDashing = false;
    bool isGrounded = false;
    bool isDoubleJumping = false;
    bool isCrounching = false;
    bool isSwinging = false;
    float originalXScale;

    #endregion


    #region METHODS
    private void Awake()
    {
        originalXScale = transform.localScale.x;
    }
    void OnMove(InputValue value)
    {
        // Introducir info del Input en la variable movementValue
        movementValue = value.Get<float>();

        if (movementValue != 0)
        {
            facingDirection = movementValue >= 0 ? 1 : -1;

            transform.localScale = new Vector3(
                originalXScale * facingDirection, 
                transform.localScale.y,
                transform.localScale.z);
        }

        // La interrogración es un if, el 1 posterior indica q si es true haga lo q hay tras el :
        
    }

    void FixedUpdate()
    { // && -> es Y     || -> es O
        if(! isDashing && !isSwinging /*&& !isCrounching*/)
        {
            rb_2D.linearVelocityX = movementValue * playerSpeed;
            animController.SetFloat("horizontalSpeed",Mathf.Abs(rb_2D.linearVelocityX));
        }
        // Control de vel vertical para modificar animaciones
        animController.SetFloat("verticalSpeed", rb_2D.linearVelocityY);
    }

    void OnJump()
    {
        if (isGrounded && !isCrounching)
        {
            // Acceder al componente RigitBody2D a través de la variable y modificar su velocidad vertical
            rb_2D.linearVelocityY = playerJumpForce;
        }
        else if (!isDoubleJumping && !isCrounching)
        {
            rb_2D.linearVelocityY = playerJumpForce;
            isDoubleJumping = true;
        }
    }

    void OnDash()
    {
        if(! isDashing && !isCrounching)
        {
            StartCoroutine(DashRoutine());
        }

    }

    void OnCrouch(InputValue value)
    {
        isCrounching = value.isPressed;

        Vector3 newLocalScale = new Vector3(
            transform.localScale.x,
            isCrounching ? (transform.localScale.y / 2) : (transform.localScale.y * 2 ),
            transform.localScale.z);
        transform.localScale = newLocalScale;

        animController.SetBool("isCrounching", isCrounching);
    }

    void OnSwing(InputValue value)
    {
        if(value.isPressed)
        {
            isSwinging = true;
            swigPointsManager.ConnectPlayerToJoint();
        }
        else
        {
            isSwinging = false;
            swigPointsManager.DisconnectPlayerToJoint();
        }
    }

    IEnumerator DashRoutine()
    {
        // Empujar al jugador con la fuerza indicada
        rb_2D.linearVelocityX = playerDashForce * facingDirection;
        // Modificar el booleano de estado
        isDashing = true;
        // Esperar un tiempo X
        yield return new WaitForSeconds(0.5f);
        // Modificar el booleano de estado
        isDashing = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGrounded = true;
            isDoubleJumping = false;
            animController.SetBool("isGrounded", isGrounded);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Modificar un booleano q permita saltar
        if (collision.CompareTag("Ground"))
        {
            isGrounded = false;
            animController.SetBool("isGrounded", isGrounded);
        }
    }
    #endregion
}
