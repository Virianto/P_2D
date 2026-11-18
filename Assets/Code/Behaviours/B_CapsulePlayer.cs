using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// * Conectar esta clase con el componente PlayerInput
/// * Crear métodos específicos para las acciones del ActionsMap
/// * Rellear esos métodos con la funcnionalidad correspondiente
/// </summary>
public class B_CapsulePlayer : MonoBehaviour
{

    #region ATTRIBUTES

    [SerializeField]
    M_SwingPoints swingPointsManager;

    [Header("EXTERNAL REFERENCES")]
    

    [SerializeField]
    Rigidbody2D rb_2D;

    [Header("EDITABLE VALUES")]

    [SerializeField]
    [Range(1, 20)]
    float jumpForce = 8;
    [SerializeField]
    [Range(1, 20)]
    float dashForce = 5;
    [SerializeField]
    [Range(1, 20)]
    float moveSpeed = 3;

    float movementValue;

    // Variable para controlar hacia dónde enfoco acciones y conectores
    float facingDirection = 1;
    float lastFacingDirection = 1;

    bool isDashing = false;
    bool isGrounded = false;
    bool isDoubleJumping = false;
    bool isCrouching = false;
    bool isSwinging = false;

    #endregion



    #region METHODS
    void OnMove(InputValue value)
    {
        // Introducir información de Input en la variable movementValue
        movementValue = value.Get<float>();

        // movementValue >= 0 --> es un if
        // 1 --> resultado si es true
        // -1 --> resultado si es false
        if(movementValue != 0)
        {
            facingDirection = movementValue >= 0 ? 1 : -1;
        }
    }

    void FixedUpdate()
    {
        if (!isDashing)
        {
            //rb_2D.MovePosition(rb_2D.position + (rb_2D.position * movementValue * moveSpeed * Time.fixedDeltaTime));
            rb_2D.linearVelocityX = movementValue * moveSpeed;
        }
    }

    void OnJump()
    {
        //Debug.Log("He saltado");

        // Acceder al componente rigibody2D a través de la varible y modificar su velocidad vertical
        if (isGrounded)
        {
            rb_2D.linearVelocityY = jumpForce;

        }
        else if (!isDoubleJumping)
        {
            rb_2D.linearVelocityY = jumpForce;
            isDoubleJumping= true;
        }
        // rb_2D.linearVelocityY = jumpForce;
        // rb_2D.linearVelocityY = isGrounded ? jumpForce : rb_2D.linearVelocityY;
    }
    void OnDash()
    {
        //Debug.Log("He hecho un dash");
        // Acceder al componente rigibody2D a través de la varible y modificar su velocidad horizontal
        //rb_2D.linearVelocityX = dashForce;  
        if(!isDashing)
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

        // Esperar un tiempo x
        yield return new WaitForSeconds(0.5f);

        // Modificar el booleano de estado
        isDashing = false;

    }

    void OnCrouch(InputValue value)
    {
        // Debug.Log("Me estoy agachando");
        isCrouching = value.isPressed;

        // Vector3 newLocalScale = new Vector3(transform.localScale.x, isCrouching ? (transform.localScale.y / 2) : transform.localScale.y, transform.localScale.z);

        Vector3 newLocalScale = new Vector3(
                    transform.localScale.x,
                    isCrouching ? 0.4f : 0.8f,
                    transform.localScale.z);

        // transform.localScale.y = isCrouching ? 0.4f : 0.8f;
        transform.localScale = newLocalScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("He detectado algo a los pies");
        if (collision.CompareTag("Ground"))
        {
            isGrounded = true;
            isDoubleJumping = false;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGrounded = false;
        }

    }

    void OnSwing(InputValue value)
    {
   
        if (value.isPressed)
        {
            isSwinging = true;
            swingPointsManager.ConnectPlayerToJoint();
        }
        else
        {
            isSwinging = false;
            swingPointsManager.DisconectPlayerFromJoint();
        }
    
    }
    #endregion
}