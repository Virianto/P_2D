using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


public class SimplePlayer2D : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2D;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] M_EthanSwingPoint swingPointManager;
    [SerializeField][Range(1, 5)] float jumpForce;
    [SerializeField][Range(1, 5)] float dashForce;
    [SerializeField][Range(1, 5)] float moveSpeed;
    float movementValue;
    float facingDirection = 1;
    bool isDashing = false;
    bool isGrounded = false;
    bool isCrouche = false;
    bool isDoubleJumping = false;

    void OnMove(InputValue value)
    {
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
            rb2D.linearVelocityX = movementValue * moveSpeed;
        }
    }

    void OnJump()
    {
        if (isGrounded)
        {
            rb2D.linearVelocityY = jumpForce;
        }
        else if (!isDoubleJumping)
        {
            rb2D.linearVelocityY = jumpForce;
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

    IEnumerator DashRoutine()
    {
        rb2D.linearVelocityX = dashForce * facingDirection;
        isDashing = true;
        yield return new WaitForSeconds(0.5f);
        isDashing = false;
    }
    void OnCrouch(InputValue value)
    {
        isCrouche = value.isPressed;
        Vector3 newLocalSacle = new Vector3(transform.localScale.x, isCrouche ? (transform.localScale.y / 2) : (transform.localScale.y * 2), transform.localScale.z);
        transform.localScale = newLocalSacle;
    }
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
            isDoubleJumping = false;
        }
    }
    void OnTriggerExit2D (Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void OnSwing(InputValue value)
    {
        if (value.isPressed)
        {
            swingPointManager.ConnectPlayerToJoint();
        }
        else
        {
            swingPointManager.DisconnectPlayerToJoint();
        }
        
    }

}
