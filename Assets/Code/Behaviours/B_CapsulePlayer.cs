using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Conectar esta clase con el componente PlayerInput
/// Crear métodos específicos para las acciones del ActionsMap
/// Rellenar esos métodos con la funcionalidad correspondiente
/// </summary>
public class B_CapsulePlayer : MonoBehaviour
{
    #region ATTRIBUTES
    [Header("External references")]
    [SerializeField]
    Rigidbody2D rb_2D;

    [Header("Editable Values")]
    [SerializeField]
    [Range(1, 10)]
    float playerSpeed = 3;

    float movementValue;

    [SerializeField]
    [Range (1, 15)]
    float playerJumpForce = 2;

    [SerializeField]
    [Range(1, 15)]
    float playerDashForce = 3;

    #endregion


    #region METHODS
    void OnMove(InputValue value)
    {
        // Introducir info del Input en la variable movementValue
        movementValue = value.Get<float>();
    }

    void FixedUpdate()
    {
        rb_2D.MovePosition(rb_2D.position + (rb_2D.position * movementValue * playerSpeed * Time.fixedDeltaTime));
    }

    void OnJump()
    {
        // Acceder al componente RigitBody2D a través de la variable y modificar su velocidad vertical
        rb_2D.linearVelocityY = playerJumpForce;
    }

    void OnDash()
    {
        // Acceder al componente RigitBody2D a través de la variable y modificar su velocidad horizontal
        rb_2D.linearVelocityX = playerDashForce;

    }
    #endregion
}
