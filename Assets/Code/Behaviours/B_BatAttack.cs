using Unity.Cinemachine;
using UnityEngine;

public class B_BatAttack : MonoBehaviour
{
    #region ATTRIBUTES

    bool playerIsInsideArea = false;


    #endregion





    #region METHODS

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<B_CapsulePlayer>() != null)
        {
            playerIsInsideArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<B_CapsulePlayer>() != null)
        {
            playerIsInsideArea = false;
        }
    }

    #endregion
}
