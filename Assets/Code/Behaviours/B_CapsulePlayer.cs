using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Conectar esta clase con el componente PlayerInput
/// Crear métodos especificos para las acciones del ActionMap
/// Rellenar esos métodos con la funcionalidad correspondiente
/// </summary>
public class B_Player : MonoBehaviour
{
    #region ATTRIBUTES
    [Header("External References")]
    [SerializeField] Rigidbody2D rigidBody2D;

    [Header("Editable Attributes")]
    [SerializeField]
    [Range(1, 15)]
    float jumpForce = 5f;

    [SerializeField]
    [Range(1, 5)]
    float dashForce = 5f;
    [SerializeField]
    [Range(1, 20)]
    float moveSpeed = 3f;

    Vector2 movementValue;

    #endregion

    #region METHODS
    void OnMove(InputValue value)
    {
        //introducir información de Input en la variable movementValue
        movementValue = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        //acceder al componente Rigidbody2D y modificar su velocidad horizontal
        rigidBody2D.MovePosition(rigidBody2D.position + movementValue * moveSpeed * Time.fixedDeltaTime);
    }

    void OnJump()
    {
        //acceder al componente Rigidbody2D y modificar su velocidad vertical
        rigidBody2D.linearVelocityY = jumpForce;
    }

    void OnDash()
    {
        //acceder al componente Rigidbody2D y modificar su velocidad horizontal
        rigidBody2D.linearVelocityX= dashForce;
    }

    #endregion
}
