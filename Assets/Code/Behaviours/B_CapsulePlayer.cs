using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// * Conectar esta clase con el componente PlayerInput
/// * Crear métodos específicos para las acciones del ActionsMap
/// * Rellenar estos métodos con la funcionalidad correspondiente
/// 
/// </summary>
public class B_CapsulePlayer : MonoBehaviour
{

    #region ATTRIBUTES

    [Header ("EXTERNAL REFERENCES")]

    [SerializeField]
    Rigidbody2D playerRigidbody;

    [SerializeField]
    M_SwingPoints swingPointsManager;

    [Header("EDITABLE VALUES")]
    [SerializeField]
    [Range(1, 30)]
    float jumpForce = 2;

    [SerializeField]
    [Range(1, 30)]
    float dashForce = 3;

    [SerializeField]
    [Range(1, 20)]
    float moveSpeed = 3;
    [SerializeField]
    [Range(0, 1)]
    float crouch = 0.5f;


    float movementValue;

    float facingDirection = 1;

    bool isDashing = false;

    bool isGrounded = false;

    bool isDoubleJumping = false;

    bool isCrouching = false;

    bool isSwinging = false;

    GameObject player;

    #endregion


    #region METHODS

    void FixedUpdate()
    {
        if (facingDirection == 1)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (facingDirection == -1)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (!isDashing)
        {
            playerRigidbody.linearVelocityX = movementValue * moveSpeed;        
        }
        if (!isSwinging)
        {
            playerRigidbody.linearVelocityX = movementValue * moveSpeed;
        }
        if (isCrouching)
        {
            if (facingDirection == 1)
            {
                transform.localScale = new Vector3(1f, crouch, 1f);
            }
            if (facingDirection == -1)
            {
                transform.localScale = new Vector3(-1f, crouch, 1f);
            }
        }
    }

    void OnJump()
    {
        if (isGrounded)
        {
            playerRigidbody.linearVelocityY = jumpForce;
        }
        else if (!isDoubleJumping)
        {
            playerRigidbody.linearVelocityY = jumpForce;
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

    void OnMove(InputValue value)
    {
        movementValue = value.Get<float>();
        facingDirection = movementValue >= 0 ? 1 : -1;    
    }

    void OnCrouch(InputValue value)
    {
        isCrouching = value.isPressed;
        Vector3 newPlayerScale = new Vector3(transform.localScale.x, isCrouching ? crouch : 1f, transform.localScale.z);

        transform.localScale = newPlayerScale;
    }


    void OnSwing(InputValue value)
    {
        if(value.isPressed)        
        {
            isSwinging = true;
         swingPointsManager.ConnectPlayerToJoint();
        }
        else
        {
            isSwinging = false;
         swingPointsManager.DisconnectPlayerFromJoint();
        }
    }
    IEnumerator DashRoutine()
    {
        playerRigidbody.linearVelocityX = dashForce * facingDirection;
        isDashing = true;
        yield return new WaitForSeconds(0.5f);
        isDashing = false;

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
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

    #endregion
}
