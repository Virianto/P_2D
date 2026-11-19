using UnityEngine;

public class B_ClosedDoor : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    InventoryItems requiredKeysToPass;

    #endregion





    #region METHODS

    private void OnTriggerEnter2D(Collider2D other)
    {
        B_CapsulePlayer player = other.GetComponent<B_CapsulePlayer>();

        // Si el que intenta pasar es el jugador...
        if (player != null)
        {
            // Comprobar que tenga la llave correspondiente
            // Si la tiene...
            if (M_InventoryManager.Instance.playerInventory.HasFlag(requiredKeysToPass))
            {
                Vector3 targetPosition = new Vector3(-11, 27, 0);
                player.transform.position = targetPosition;
            }
        }
    }

    #endregion
}
