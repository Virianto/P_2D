using UnityEngine;


/// <summary>
/// Si la bola cae a la zona de abajo restamos una vida
/// </summary>
public class B_Life : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    M_PinballGameManager myManager;

    #endregion





    #region METHODS

    private void OnTriggerEnter2D(Collider2D other)
    {
        myManager.LifeDown();
    }

    #endregion
}