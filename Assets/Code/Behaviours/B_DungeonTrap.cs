using System.Collections;
using UnityEngine;

public class B_DungeonTrap : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    M_DungeonManager dungeonManager;

    [SerializeField]
    ParticleSystem smoke;

    [SerializeField]
    AudioSource fireOff;

    bool playerIsInsideArea = false;

    bool canDamage = true;

    float damageTime = 0.5f;

    float destroyDelay = 0.25f;



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

        if (other.GetComponent<B_Attack2D>() != null)
        {
            StartCoroutine(SmokeParticlesRoutine());
            StartCoroutine(DestroyEnemyRoutine());
        }
    }

    IEnumerator DamageCooldownRoutine()
    {
        canDamage = false;

        yield return new WaitForSeconds(damageTime);

        canDamage = true;
    }

    IEnumerator DestroyEnemyRoutine()
    {
        canDamage = false;
        yield return new WaitForSeconds(destroyDelay);
        fireOff.transform.SetParent(null);
        smoke.transform.SetParent(null);
        gameObject.SetActive(false);
    }

    IEnumerator SmokeParticlesRoutine()
    {
        fireOff.Play();
        smoke.Play();
        yield return new WaitForSeconds(1);
        Destroy(fireOff.gameObject);
        Destroy(smoke.gameObject);
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
