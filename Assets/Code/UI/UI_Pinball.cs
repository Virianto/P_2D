using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Aquí va el enunciado del propósito de esta clase
/// </summary>
public class UI_Pinball : MonoBehaviour
{

    #region ATTRIBUTES


    [SerializeField]
    TMP_Text playerPointsText;

    [SerializeField]
    TMP_Text playerLifeText;

    [SerializeField]
    M_Game gameManager;
    #endregion



    #region METHODS
    private void Start()
    {
        gameManager.OnPointsChanged += UpdateCounter;
        gameManager.OnLifeChanged += UpdateLife;
    }

    public void UpdateCounter(float points)
    {

        playerPointsText.text = points.ToString();
    }
    public void UpdateLife(float life)
    {
        playerLifeText.text = life.ToString();

    }

    #endregion
}