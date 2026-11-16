using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// * Lanzamiento de un UnityEvent en cada uno de los casos
/// </summary>
public class C_SimpleTrigger2D : MonoBehaviour
{
    #region ATTRIBUTES

    public UnityEvent triggerEnter2DEvent;
    public UnityEvent triggerExit2DEvent;

    #endregion

    #region METHODS

    void OnTriggerEnter2D(Collider2D other)
    {
        // Preguntar si hay ALGUIEN o ALGO suscrito al evento para que reaccione
        triggerEnter2DEvent?.Invoke();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Preguntar si hay ALGUIEN o ALGO suscrito al evento para que reaccione
        triggerExit2DEvent?.Invoke();
    }


    #endregion
}
