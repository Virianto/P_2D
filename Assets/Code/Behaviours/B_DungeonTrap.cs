using System.Collections;
using UnityEngine;

public class B_DungeonTrap : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    M_DungeonManager dungeonManager;

    bool playerIsInsideArea = false;

    bool canDamage = true;

    #endregion





    #region METHODS

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<B_CapsulePlayer>() != null && canDamage)
        {
            // Detectar cuándo ha entrado el jugador en su área de efecto
            playerIsInsideArea = true;

            dungeonManager.LifeDown();

            StartCoroutine(DamageCooldownRoutine());
        }
    }

    IEnumerator DamageCooldownRoutine()
    {
        canDamage = false;

        yield return new WaitForSeconds(0.5f);

        canDamage = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<B_CapsulePlayer>() != null)
        {
            // Detectar cuándo ha salido el jugador de su área de efecto
            playerIsInsideArea = false;
        }
    }

    #endregion
}
