using UnityEngine;

public class B_SpawnNewBall : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    M_PinballGameManager myManager;

    #endregion

    #region METHODS

    private void OnTriggerEnter2D(Collider2D other)
    {
        myManager.GenerateNewBall();
    }

    #endregion
}
