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
    
    [SerializeField]
    TMP_Text lifeText;

    [SerializeField]
    GameObject gameOverPanel;

    public M_PinballManager manager;

    #endregion

    #region METHODS


    void Start()
    { 
        scoreText.text = (manager.score.ToString());
        lifeText.text = manager.totalLifePoints.ToString();
        M_PinballManager.Instance.OnScoredPoint += UpdateScoreText;
        M_PinballManager.Instance.OnUpdatedLife += UpdateLifeText;
        
    }

    void UpdateScoreText (int score)
    {
        scoreText.text = score.ToString();
    }

    void UpdateLifeText (int life)
    {
        lifeText.text = life.ToString();
    }

    public void SetGameOverText()
    {
        gameOverPanel.SetActive(true);
    }
    #endregion
	
}
