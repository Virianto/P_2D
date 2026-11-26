using UnityEngine;

public class B_Bat : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    M_DungeonManager dungeonManager;

    [SerializeField]
    Animator animController;

    [SerializeField]
    B_CapsulePlayer player;

    [SerializeField]
    B_Attack2D attack;

    [SerializeField]
    [Range(1, 10)]
    float moveSpeed = 5;

    float movementValue;

    float facingDirection = 1;

    float originalXScale = 3;

    #endregion





    #region METHODS

    private void Update()
    {
        movementValue = player.transform.position.x - transform.position.x;

        if (player.transform.position.x != transform.position.x)
        {
            facingDirection = movementValue > 0 ? 1 : -1;

            transform.localScale = new Vector3(facingDirection * originalXScale, transform.localScale.y, transform.localScale.z);
        }
    }



    #endregion
}
