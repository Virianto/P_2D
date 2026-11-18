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

    public void UpdateLifesImage(int lifes)
    {
        if (lifes == 2)
        {
            life3.gameObject.SetActive(false);
        }
        if (lifes == 1)
        {
            life2.gameObject.SetActive(false);
        }
        if (lifes == 0)
        {
            life1.gameObject.SetActive(false);
        }
    }

    #endregion
}
