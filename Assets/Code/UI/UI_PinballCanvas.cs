using TMPro;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Aquí va el enunciado del propósito de esta clase
/// </summary>
public class UI_PinballCanvas : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    M_PinballGameManager myManager;

    [SerializeField]
    TMP_Text pointsCounterText;

    [SerializeField]
    Image life1;
    [SerializeField]
    Image life2;
    [SerializeField]
    Image life3;

    #endregion





    #region METHODS

    public void UpdatePointsText(int totalPoints)
    {
        pointsCounterText.text = string.Format("{00}", totalPoints);
    }

    public void UpdateLifesImage(int lifesCounter)
    {
        if (lifesCounter == 2)
        {
            life3.gameObject.SetActive(false);
        }
        if (lifesCounter == 1)
        {
            life2.gameObject.SetActive(false);
        }
        if (lifesCounter == 0)
        {
            life1.gameObject.SetActive(false);
        }
    }

    #endregion
}