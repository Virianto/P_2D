
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// * Conectar esta clase con el componente PlayerInput
/// * Crear métodos específicos para las acciones del ActionMap
/// * Rellenar esos métodos con la funcionalidad correspondiente
/// </summary>
public class B_CapsulePlayer : MonoBehaviour
{
    #region ATTRIBUTES

    [Header("External references")]

    [SerializeField]
    Rigidbody2D rb_2D;

    [Header("Editable values")]

    [SerializeField]
    [Range(1, 15)]
    float jumpForce = 10;

    [SerializeField]
    [Range(1, 15)]
    float dashForce = 5;

    [SerializeField]
    [Range(1, 15)]
    float moveSpeed = 5;

    float movementValue;

    #endregion





    #region METHODS

    void OnJump()
    {
        // Acceder al componente Rigidbody2D a través de la variable y modificar su velocidad vertical
        rb_2D.linearVelocity = new Vector2(rb_2D.linearVelocity.x, jumpForce);
    }

    void OnDash()
    {
        // Acceder al componente Rigidbody2D a través de la variable y modificar su velocidad horizontal
        rb_2D.linearVelocity = new Vector2(dashForce, rb_2D.linearVelocity.y);
    }

    void OnMove(InputValue value)
    {
        // Introducir información de Input en la variable movementValue
        movementValue = value.Get<float>();
    }

    //private void FixedUpdate()
    //{
    //    rb_2D.MovePosition(rb_2D.position + (Vector2.right * movementValue * moveSpeed * Time.fixedDeltaTime));
    //}

    #endregion
}