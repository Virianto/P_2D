using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


/// <summary>
/// Canvas que va a llevar la cuenta de los puntos
/// </summary>
public class UI_GameplayCanvas : MonoBehaviour
{
    #region ATTRIBUTRES

    [SerializeField]
    TMP_Text scoreText;

    public M_PinballManager manager;

    int newScore;
    #endregion

    #region METHODS


    void Start()
    { 
        scoreText.text = (manager.score.ToString());
    }

    void Update()
    {
        manager.score = newScore;
        M_PinballManager.Instance.UpdateCounter(newScore);
        scoreText.text = newScore.ToString();
    }
   
    #endregion
	
}
