using UnityEngine;


/// <summary>
/// Detectar al jugador cuando toque el objeto
/// * Añadir a inventario de juego un elemento específico
/// * Desaparecer
/// </summary>
public class C_Items : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    B_CapsulePlayer player;

    [SerializeField]
    InventoryItems thisItem;

    #endregion





    #region METHODS

    private void OnTriggerEnter2D(Collider2D other)
    {
        B_CapsulePlayer player = other.GetComponent<B_CapsulePlayer>();

        if (player != null)
        {
            // Busco al Manager y le añado este objeto a su inventario
            M_InventoryManager.Instance.playerInventory |= thisItem;

            UI_InventoryCanvas2D.Instance.AddNewInventoryItem(thisItem);

            player.keyCollected.Play();

            // Desaparezco
            gameObject.SetActive(false);
        }
    }

    #endregion
}