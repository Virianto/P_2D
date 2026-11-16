using UnityEngine;

public enum zumperType
{
    Yellow,
    Blue
}

/// <summary>
/// Aquí va el enunciado del propósito de esta clase
/// </summary>
public class B_Zumper : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    M_PinballGameManager myManager;

    public zumperType ztype;

    #endregion





    #region METHODS

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ztype == zumperType.Yellow)
        {
            myManager.YellowZumperPoints();
        }
        else if (ztype == zumperType.Blue)
        {
            myManager.BlueZumperPoints();
        }
    }

    #endregion
}