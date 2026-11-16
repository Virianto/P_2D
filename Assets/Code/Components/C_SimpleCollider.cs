using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Detecta colisiones en escena y lanza un evento fácil de conectar con cualquier Manager
/// (Si lo quieres mejorar, añádele el CollisionStay y más tipos de eventos, no solo Unity,
/// para capturarlos también desde código además de la escena)
/// </summary>
public class C_SimpleCollider : MonoBehaviour
{
    #region ATTRIBUTES

    public UnityEvent collisionEnterEvent;
    public UnityEvent collisionExitEvent;

    #endregion

    #region METHODS

    void OnCollisionEnter(Collision collision)
    {
        collisionEnterEvent?.Invoke();
    }

    void OnCollisionExit(Collision collision)
    {
        collisionExitEvent?.Invoke();
    }

    #endregion
}
