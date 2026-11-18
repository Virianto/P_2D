using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// Aqui va el enunciado del proposito de esta clase
/// </summary>

public class B_CapsulePlayer : MonoBehaviour
{
    #region ATTRIBUTES

    //[SerializeField]
    //HingeJoint2D Enganche;

    [SerializeField]
    Rigidbody2D rb_2D;

    [SerializeField]
    [Range(1, 30)]
    float jumpForce = 30;

    [SerializeField]
    [Range(1, 30)]
    float dashForce = 3;

    [SerializeField]
    [Range(1, 20)]
    float moveSpeed = 3;

    float movementValue;

    float facingDirection = 1;
    float lastFacingDirection = 1;

    bool isDashing = false;
    bool isGrounded = false;
    bool isDoubleJumping = false;
    bool isCrouching = false;

    #endregion
    #region METHODS

    void OnJump()
    {
        if (isGrounded)
        {
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

    void OnMove(InputValue value)
    {
        movementValue = value.Get<float>();

        if (movementValue != 0)
        {
            facingDirection = movementValue > 0 ? 1 : -1;
        }

    }

    private void FixedUpdate()
    {
        rb_2D.linearVelocityX = movementValue * moveSpeed;
    }

    void OnEnganche()
    {
        //Enganche.enabled = true;
        Debug.Log("Estoy colgando");
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
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

    IEnumerator DashRoutine()
    {
        rb_2D.linearVelocityX = dashForce * facingDirection;
        isDashing = true;
        yield return new WaitForSeconds(0.5f);
        isDashing = false;
    }

#endregion
}

