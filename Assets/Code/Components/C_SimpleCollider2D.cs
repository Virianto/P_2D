using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Detecta colisiones en escena y lanza un evento fácil de conectar con cualquier Manager
/// (Si lo quieres mejorar, añádele el CollisionStay y más tipos de eventos, no solo Unity,
/// para capturarlos también desde código además de la escena)
/// </summary>
public class C_SimpleCollider2D : MonoBehaviour
{
    #region ATTRIBUTES

    public UnityEvent collisionEnter2DEvent;
    public UnityEvent collisionExit2DEvent;

    #endregion

    #region METHODS

    void OnCollisionEnter2D(Collision2D collision)
    {
        collisionEnter2DEvent?.Invoke();
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        collisionExit2DEvent?.Invoke();
    }

    #endregion
}
