using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


public class SimplePlayer2D : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2D;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] M_EthanSwingPoint swingPointManager;
    [SerializeField] Animator animController;
    [SerializeField] [Range(1, 5)] float jumpForce;
    [SerializeField] [Range(1, 5)] float dashForce;
    [SerializeField] [Range(1, 5)] float moveSpeed;
    float movementValue;
    float facingDirection = 1;
    bool isDashing = false;
    bool isGrounded = false;
    bool isCrouche = false;
    bool isDoubleJumping = false;
    bool isSwinging = false;

    void OnMove(InputValue value)
    {
        movementValue = value.Get<float>();
        if (movementValue != 0)
        {
            facingDirection = movementValue > 0 ? 1 : -1;
            transform.localScale = new Vector3(facingDirection,transform.localScale.y,transform.localScale.z);
        }
    }

    void FixedUpdate()
    {
        if (!isDashing)
        {
            rb2D.linearVelocityX = movementValue * moveSpeed;
            animController.SetFloat("HorizontalSpeed", Mathf.Abs(rb2D.linearVelocityX));
        }
        animController.SetFloat("VerticalSpeed", rb2D.linearVelocityY);
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

        animController.SetBool("IsCrouching", isCrouche);
    }
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
            isDoubleJumping = false;
            animController.SetBool("IsGrounded", isGrounded);
        }
    }
    void OnTriggerExit2D (Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = false;
            animController.SetBool("IsGrounded", isGrounded);
        }
    }

    void OnSwing(InputValue value)
    {
        isSwinging = value.isPressed;
        if (isSwinging)
        {
            swingPointManager.ConnectPlayerToJoint();
        }
        else
        {
            swingPointManager.DisconnectPlayerFromJoint();
        }
        
    }

}
