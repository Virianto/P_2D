using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UI_DungeonCanvas : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    M_DungeonManager dungeonManager;

    [SerializeField]
    Image life1;
    [SerializeField]
    Image life2;
    [SerializeField]
    Image life3;

    #endregion





    #region METHODS

    public void UpdateLifesImageDown(int lifes)
    {
        if (lifes == 2)
        {
            StartCoroutine(LifeDownEffect(life3));
        }
        else if (lifes == 1)
        {
            StartCoroutine(LifeDownEffect(life2));
        }
        else if (lifes == 0)
        {
            StartCoroutine(LifeDownEffect(life1));
        }
    }

    IEnumerator LifeDownEffect(Image heart)
    {
        // Cambiamos el tamaño de la imagen
        Vector3 originalScale = heart.transform.localScale;
        heart.transform.localScale = originalScale * 1.5f;

        // Cambiamos el color de la imagen
        Color originalColor = heart.color;
        heart.color = Color.black;

        // Esperamos un tiempo
        yield return new WaitForSeconds(1.5f);

        // Desactivamos la imagen
        heart.gameObject.SetActive(false);

        // Volvemos a cambiarlo a su estado original
        heart.color = originalColor;
        heart.transform.localScale = originalScale;
    }

    public void UpdateLifesImageUp(int lifes)
    {
        if (lifes == 3)
        {
            StartCoroutine(LifeUpEffect(life3));
        }
        if (lifes == 2)
        {
            StartCoroutine(LifeUpEffect(life2));
        }
    }

    IEnumerator LifeUpEffect(Image heart)
    {
        // Activamos la imagen
        heart.gameObject.SetActive(true);

        // Cambiamos el tamaño de la imagen
        Vector3 originalScale = heart.transform.localScale;
        heart.transform.localScale = originalScale * 1.5f;

        // Cambiamos el color de la imagen
        Color originalColor = heart.color;
        heart.color = Color.green;

        // Esperamos un tiempo
        yield return new WaitForSeconds(0.25f);

        // Cambiamos el tamaño de la imagen
        heart.transform.localScale = originalScale;

        // Esperamos un tiempo
        yield return new WaitForSeconds(0.25f);

        heart.transform.localScale = originalScale * 1.5f;

        // Esperamos un tiempo
        yield return new WaitForSeconds(0.25f);

        // Cambiamos el tamaño de la imagen
        heart.transform.localScale = originalScale;

        // Esperamos un tiempo
        yield return new WaitForSeconds(0.25f);

        heart.transform.localScale = originalScale * 1.5f;

        // Esperamos un tiempo
        yield return new WaitForSeconds(0.25f);

        // Volvemos a cambiarlo a su estado original
        heart.color = originalColor;
        heart.transform.localScale = originalScale;
    }

    #endregion
}
