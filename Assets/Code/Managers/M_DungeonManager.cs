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
        player.lifes -= 1;
        lifesCounter -= 1;
        player.damage.Play();
        dungeonCanvas.UpdateLifesImageDown(lifesCounter);
    }

    public void LifeUp()
    {
        player.lifes += 1;
        lifesCounter += 1;
        player.heart.Play();
        dungeonCanvas.UpdateLifesImageUp(lifesCounter);
    }

    #endregion
}
