using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using Code.Utils;

/// <summary>
/// Mantiene referencias a todos los elementos de interfaz interactivos
/// y permite navefar por el menú de la escena inicial
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
        M_Start.Instance.SwitchToGameScene();
    }

    #endregion
}
