
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// * Distancia mínima para activar los SpringJoints
/// * Lista con todos los SpringJoints de la escena
/// * Calculo constante de cuál es el SpringJoint más cercano al jugador
/// * Referencia al jugador
/// * Capacidad de conectar y desconectar el jugador al SpringJoint más cercano si se cumplen ciertos requisitos
/// </summary>
public class M_SwingPoints : MonoBehaviour
{
    #region ATTRIBUTES

    [Header("External references")]

    [SerializeField]
    B_CapsulePlayer player;

    [SerializeField]
    List<SpringJoint2D> allJointsList = new();

    [Header("Editable values")]

    [SerializeField]
    [Range(0, 20)]
    float minDistanceToSwing = 5;

    SpringJoint2D currentClosestJoint;

    #endregion





    #region METHODS

    private void Update()
    {
        // Información para quedarnos con el SpringJoint más cercano
        float closestCurrentDistance = Mathf.Infinity;

        // Recorrer la lista de todos los SpringJoints y buscar el más próximo al jugador
        for (int i = 0; i < allJointsList.Count; ++i)
        {
            float distanceBetweenPlayerAndJoint = Vector3.Distance(player.transform.position, allJointsList[i].transform.position);

            // Si el SpringJoint está a una distancia válida para balancearse...
            if (distanceBetweenPlayerAndJoint <= minDistanceToSwing)
            {
                // Si la distancia de este SpringJoint es la menor que llevamos calculada hasta ahora...
                if (distanceBetweenPlayerAndJoint < closestCurrentDistance)
                {
                    // Nos quedamos con este valor para futuras comparaciones
                    closestCurrentDistance = distanceBetweenPlayerAndJoint;
                    // Nos quedamos con el elemento de la lista para conectar al jugador
                    currentClosestJoint = allJointsList[i];
                }
            }
        }

    }

    public void ConnectPlayerToJoint()
    {
        // Si no hay conexión válida posible no hacemos nada
        if (currentClosestJoint != null)
        {
            currentClosestJoint.connectedBody = player.GetComponent<Rigidbody2D>();
        }
    }

    public void DisconnectPlayerFromJoint()
    {
        if (currentClosestJoint != null)
        {
            currentClosestJoint.connectedBody = null;
        }
    }

    #endregion
}