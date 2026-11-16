using UnityEngine;

/// <summary>
/// Aqui va el enunciado del proposito de esta clase
/// </summary>
public class B_LoseLifeCollider : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    M_Game gameManager;
    #endregion


    #region METHODS
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.OnFallBall();
    }
    #endregion
}
