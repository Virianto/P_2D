using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Canvas con puntos y vida
/// </summary>
public class UI_PinballCanvas : MonoBehaviour
{
    #region ATTRIBUTES
    [SerializeField]
    TMP_Text pointsText;

    [SerializeField]
    M_Game myManager;

    [SerializeField]
    public Image life1;
    [SerializeField]
    public Image life2;
    [SerializeField]
    public Image life3;
    #endregion

    #region METHODS
    private void Start()
    {
        pointsText.text = "0";
    }

    public void UpdateCounter(int points)
    {
        pointsText.text = points.ToString();
    }

    public void LoseLife(int lifes)
    {
        if (lifes == 2)
        {
            life3.gameObject.SetActive(false);
        }
        else if (lifes == 1)
        {
            life2.gameObject.SetActive(false);
        }
        else if (lifes == 0)
        {
            life1.gameObject.SetActive(false);
        }
        else
        {
            myManager.KeyControl();
        }
    }
    #endregion
}
