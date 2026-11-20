using UnityEngine;
using Code.Utils;
using UnityEngine.SceneManagement;

/// <summary>
/// Aplica los cambios de configuración seleccionados en el menú y
/// permite navegar hacia la escena de juego
/// </summary>
public class M_Start : Singleton<M_Start>
{
    #region ATTRIBUTES

    #endregion

    #region METHODS

    /// <summary>
    /// Accedo a SceneManager y solicito que cargue la escena de juego por indice
    /// </summary>
    public void SwitchToGameScene()
    {
        SceneManager.LoadScene(1);
    }

    #endregion
}
