using UnityEngine;
using System.Collections;

/// <summary>
/// Métodos de mi juego
/// </summary>
public class M_Game : MonoBehaviour
{
    #region ATTRIBUTES
    [SerializeField]
    UI_PinballCanvas myCanvas;

    [SerializeField]
    M_KeyControlPinball keyControl;

    [SerializeField]
    GameObject effectorUp;

    public int currentPoints;
    public int nextActivationPoints = 20;
    public int lifes = 3;
    public int currentLifes;

    #endregion

    #region METHODS
    public void Start()
    {
        currentLifes = lifes;
    }
    public void OnZumperHit(B_Zumper.ZumperType type)
    {
        if (type == B_Zumper.ZumperType.Triangle)
        {
            currentPoints += 5;
            myCanvas.UpdateCounter(currentPoints);
        }
        else if (type == B_Zumper.ZumperType.Circle)
        {
            currentPoints += 2;
            myCanvas.UpdateCounter(currentPoints);
        }
        else if (type == B_Zumper.ZumperType.Special)
        {
            // Se desactiva cuando la bola lo toca
            effectorUp.SetActive(false);
        }

        if (currentPoints >= nextActivationPoints)
        {
            effectorUp.SetActive(true);
            nextActivationPoints += 20;
            StartCoroutine(AutoTurnOffCoroutine());
        }
    }
    private IEnumerator AutoTurnOffCoroutine()
    {
        // O se desactiva en 2 segundos
        yield return new WaitForSeconds(2f);
        effectorUp.SetActive(false);
    }

    public void OnFallBall()
    {
        currentLifes -= 1;
        myCanvas.LoseLife(currentLifes);
    }

    public void KeyControl()
    {
        keyControl.enabled = false;
    }


    #endregion
}