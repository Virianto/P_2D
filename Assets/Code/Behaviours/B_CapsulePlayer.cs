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

    [Header("EXTERNAL REFERENCES")]
    

    [SerializeField]
    Rigidbody2D rb_2D;

    [Header("EDITABLE VALUES")]

    [SerializeField]
    [Range(1, 15)]
    float jumpForce = 8;
    [SerializeField]
    [Range(1, 5)]
    float dashForce = 5;
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
        //rb_2D.MovePosition(rb_2D.position + (rb_2D.position * movementValue * moveSpeed * Time.fixedDeltaTime));

    }

    void OnJump()
    {
        //Debug.Log("He saltado");

        // Acceder al componente rigibody2D a través de la varible y modificar su velocidad vertical
        rb_2D.linearVelocityY = jumpForce;

    }
    void OnDash()
    {
        //Debug.Log("He hecho un dash");
        // Acceder al componente rigibody2D a través de la varible y modificar su velocidad horizontal
        rb_2D.linearVelocityX = dashForce;  
    }

    #endregion
}