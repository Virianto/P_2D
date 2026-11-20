using UnityEngine;

public class B_Heart : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    M_DungeonManager dungeonManager;

    [SerializeField]
    B_CapsulePlayer player;

    #endregion





    #region METHODS

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<B_CapsulePlayer>() != null && player.lifes != 3)
        {
            dungeonManager.LifeUp();

            Destroy(gameObject);
        }
    }

    #endregion
}
