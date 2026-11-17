using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// X Conectar esta clase con el componente PlayerInput
/// X Crear métodos específicos para las acciones del ActionsMap
/// * Rellenar esos métodos con la funcionalidad correspondiente
/// </summary>
public class B_CapsulePlayer : MonoBehaviour
{
    #region ATTRIBUTES

    [Header("EXTERNAL REFERENCES")]

    [SerializeField]
    Rigidbody2D rb_2D;

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

    void OnMove(InputValue value)
    {
        // Introducir información de Input en la variable movementValue
        movementValue = value.Get<float>();
    }

    void FixedUpdate()
    {
        //rb_2D.MovePosition(rb_2D.position + 
            //(rb_2D.position * movementValue * moveSpeed * Time.fixedDeltaTime));
    }

    void OnJump()
    {
        // Acceder al componente RigidBody2D a través de la variable y modificar su velocidad vertical
        rb_2D.linearVelocityY = jumpForce;
    }

    void OnDash()
    {
        // Acceder al componente RigidBody2D a través de la variable y modificar su velocidad horizontal
        rb_2D.linearVelocityX = dashForce;
    }

    #endregion
}
