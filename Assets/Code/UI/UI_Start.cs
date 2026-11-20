using Code.Utils;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Mantiene referencias a todos los elementos de interfaz interactivos y permite navegar por el menú de la escena inicial
/// </summary>
public class UI_Start : Singleton<UI_Start>
{
    #region ATTRIBUTES

    #endregion

    [SerializeField]
    Button playButton;




    #region METHODS

    public void StartGame()
    {
        // Acceder al Manager de la escena para que cambie a escena de juego
        M_Start.Instance.SwitchToGameScene();
    }

    #endregion
}