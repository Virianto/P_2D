using System.Collections;
using UnityEngine;

/// <summary>
/// Aquí va el enunciado del propósito 
/// </summary>
public class B_Ball : MonoBehaviour
{

    #region ATTRIBUTES


    float lifeCycle = 20;

    M_PinballBallsManager manager;
    #endregion


    #region METHODS

    public void InitializeBall(M_PinballBallsManager myManager)
    {
        manager = myManager;
        StartCoroutine(FinishBallLifeCycle());
    }

    IEnumerator FinishBallLifeCycle()
    {
        yield return new WaitForSeconds(lifeCycle);
        manager.FinishBall(this);
    }
    #endregion
}
