using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Aquí va el enunciado del propósito 
/// </summary>
public class C_SimpleColliison : MonoBehaviour
{

    #region ATTRIBUTES

    public UnityEvent collisionEnterEvent;
    public UnityEvent collisionExitEvent;

    #endregion


    #region METHODS
    void OnCollisionEnter2D(Collision2D collision)
    {
        collisionEnterEvent?.Invoke();
    }

   
    #endregion
}
