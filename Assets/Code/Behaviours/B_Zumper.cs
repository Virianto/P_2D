using UnityEngine;

/// <summary>
/// Las palas de mi pinball
/// </summary>
public class B_Zumper : MonoBehaviour
{
    public enum ZumperType
    {
        Triangle,
        Circle,
        Special
    }

    #region ATTRIBUTES
    [SerializeField]
    ZumperType zumperType;

    [SerializeField]
    M_Game gameManager;
    #endregion

    #region METHODS
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.OnZumperHit(zumperType);
    }
    #endregion
}