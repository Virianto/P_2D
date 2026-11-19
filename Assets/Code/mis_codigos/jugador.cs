using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// X IMPLEMENTAR DIRECCIÓN 
/// X ARREGLAR EL DASH
/// * IMPLEMENTAR DETECCIÓN DE SUELO
/// * IMPLEMENTAR DOBLE SALTO
/// * IMPLEMENTAR BALANCEO
/// </summary>
public class jugador : MonoBehaviour
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

    // Variable para controlar hacia dónde enfoco acciones y conectores
    float facingDirection = 1;

    bool isDashing = false;

    #endregion

    #region METHODS

    void OnMove(InputValue value)
    {
        // Introducir información de Input en la variable movementValue
        movementValue = value.Get<float>();

        facingDirection = movementValue >= 0 ? 1 : -1;
    }

    void FixedUpdate()
    {
        if (!isDashing)
        {
            rb_2D.linearVelocityX = movementValue * moveSpeed;
        }
    }

    void OnJump()
    {
        // Acceder al componente RigidBody2D a través de la variable y modificar su velocidad vertical
        rb_2D.linearVelocityY = jumpForce;
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
        // Empujar al jugador con la fuerza indicada
        rb_2D.linearVelocityX = dashForce * facingDirection;
        // Modificar el booleano de estado
        isDashing = true;
        // Esperar un tiempo X
        yield return new WaitForSeconds(0.5f);
        // Modificar el booleano de estado
        isDashing = false;
    }

    #endregion
}
