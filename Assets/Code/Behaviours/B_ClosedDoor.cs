using UnityEngine;

public class B_ClosedDoor : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    InventoryItems requiredKeysToPass;

    [SerializeField]
    Transform entryDoor;

    [SerializeField]
    Transform exitDoor;

    #endregion





    #region METHODS

    private void OnTriggerEnter2D(Collider2D other)
    {
        B_CapsulePlayer player = other.GetComponent<B_CapsulePlayer>();

        Vector3 entryDoorPosition = entryDoor.position;
        Vector3 exitDoorPosition = exitDoor.position;

        // Si el que intenta pasar es el jugador...
        if (player != null)
        {
            // Comprobar que tenga la llave correspondiente
            // Si la tiene...
            if (M_InventoryManager.Instance.playerInventory.HasFlag(requiredKeysToPass))
            {
                player.transform.position = exitDoorPosition;
            }
        }
    }

    #endregion
}
