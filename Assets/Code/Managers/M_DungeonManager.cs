using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class M_DungeonManager : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    B_CapsulePlayer player;

    [SerializeField]
    UI_DungeonCanvas dungeonCanvas;

    [SerializeField]
    Animator animController;

    [SerializeField]
    [Range(0, 3)]
    int lifesCounter = 3;

    bool isDead = false;

    #endregion





    #region METHODS

    public void LifeDown()
    {
        player.lifes -= 1;
        lifesCounter -= 1;
        player.damage.Play();
        dungeonCanvas.UpdateLifesImageDown(lifesCounter);
        animController.SetTrigger("Damage");

        // Si el jugador se queda sin vidas...
        if (player.lifes < 1)
        {
            // Desactivamos el script del jugador para que no pueda realizar ninguna acción
            player.enabled = false;

            // Ponemos el booleano a true para el AnimatorController
            isDead = true;

            // Lanzo la animación de muerte
            animController.SetBool("IsDead", isDead);

            // Lanzo sonido de muerte
            player.dead.Play();

            // Accedo a SceneManager y solicito que cargue la escena de GameOver por su índice
            StartCoroutine(SwitchToGameOverScene());
        }
    }

    public void LifeUp()
    {
        player.lifes += 1;
        lifesCounter += 1;
        player.heart.Play();
        dungeonCanvas.UpdateLifesImageUp(lifesCounter);
    }

    IEnumerator SwitchToGameOverScene()
    {
        // Espero un tiempo antes de cargar la escena de GameOver
        yield return new WaitForSeconds(2.5f);

        // Accedo a SceneManager y solicito que cargue la escena de GameOver por su índice
        SceneManager.LoadScene(2);
    }

    #endregion
}
