using UnityEngine;

/// <summary>
/// Aqui va el enunciado del proposito de esta clase
/// </summary>

public class B_Puntos : MonoBehaviour
{
    #region ATTRIBUTES
    ManagerJuego manager = new ManagerJuego();

    #endregion
    #region METHODS

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.CompareTag("ZumperSuperior"))
        {
            manager.Puntos(2);
        }
        if (this.CompareTag("Zumper"))
        {
            manager.Puntos(5);
        }
    }

    #endregion
}

