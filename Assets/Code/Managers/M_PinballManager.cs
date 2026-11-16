using UnityEngine;
using Code.Utils;
using System;
using System.Collections;

/// <summary>
/// Manager de todas las funcionalidades del pinball
/// </summary>
public class M_PinballManager : Singleton<M_PinballManager>
{

    #region ATTRIBUTES


    public event Action <int> OnScoredPoint;
    public event Action <int> OnUpdatedLife;

    [Header("EDITABLE VALUES")]

    public int score = 0;

    public int totalLifePoints = 3;

    


    [Header("EXTERNAL REFERENCES")]
   
    [SerializeField]
    UI_GameplayCanvas gameplayCanvas;

    [SerializeField]
    GameObject inputManagerGameObject;



    #endregion


    #region METHODS


    private void Update()
    {
        if(totalLifePoints == 0)
        {
            inputManagerGameObject.SetActive(false);
            Debug.Log("Has perdido el juego");
        }
    }
    public void UpdateLifePoints(int amount)
    {
        totalLifePoints += amount;
        OnUpdatedLife?.Invoke(totalLifePoints);

    }

    public void UpdateCounter(int amount)
    {
        score += amount;
        OnScoredPoint?.Invoke(score);
    }


 
    #endregion
}

