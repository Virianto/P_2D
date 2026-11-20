using Code.Utils;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Mantiene referencias a todos los elementos de interfaz interactivos
/// Permite navegar por el menú de la escena inicial
/// </summary>
public class UI_Start : Singleton<UI_Start>
{

    #region ATTRIBUTES

    [SerializeField]
    Button playButton;

    #endregion



    #region METHODS

    public void StartGame()
    {

        // Accedo a SceneManager y solicito que cargue la escena de juego por índice

        M_Start.Instance.SwitchToGameScene();

    }

    #endregion
}