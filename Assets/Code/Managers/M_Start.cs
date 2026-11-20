using Code.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Aplica los cambios de configuración seleccionados en el menú
/// Permite navegar hacia la escena de juego
/// </summary>
public class M_Start : Singleton<M_Start>
{

    #region ATTRIBUTES



    #endregion



    #region METHODS

    public void SwitchToGameScene()
    {

        SceneManager.LoadScene(1);

    }

    #endregion
}