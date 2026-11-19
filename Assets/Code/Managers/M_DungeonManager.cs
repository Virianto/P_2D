using UnityEngine;
using System;

public class M_DungeonManager : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    B_CapsulePlayer player;

    [SerializeField]
    UI_DungeonCanvas dungeonCanvas;

    [SerializeField]
    [Range(0, 3)]
    int lifesCounter = 3;

    #endregion





    #region METHODS

    public void LifeDown()
    {
        player.damage.Play();
        player.lifes -= 1;
        lifesCounter -= 1;
        dungeonCanvas.UpdateLifesImage(lifesCounter);
    }

    #endregion
}
