using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// * Conectar esta clase con el componente PlayerInput
/// * Crear métodos específicos para las acciones del ActionsMap
/// * Rellenar estoos métodos con la funcionalidad correspondiente
/// </summary>
public class B_CapsulePlayer : MonoBehaviour
{

    #region ATTRIBUTES

    [Header ("EXTERNAL REFERENCES")]

    [SerializeField]
    Rigidbody2D playerRigidbody;

    [Header("EDITABLE VALUES")]
    [SerializeField]
    [Range(1, 15)]
    float jumpForce = 2;

    [SerializeField]
    [Range(1, 5)]
    float dashForce = 3;

    [SerializeField]
    [Range(1, 20)]
    float moveSpeed = 3;


    float movementValue;

    #endregion


    #region METHODS


    void OnJump()
    {
        playerRigidbody.linearVelocityY = jumpForce;
    }

    void OnDash()
    {
        playerRigidbody.linearVelocityX = dashForce; 
    }

    void OnMove(InputValue value)
    {
        movementValue = value.Get<float>();
    }

    void FixedUpdate()
    {
        //playerRigidbody.MovePosition(playerRigidbody.position + (playerRigidbody.position * movementValue *  moveSpeed * Time.fixedDeltaTime));    
    }
    #endregion
}
