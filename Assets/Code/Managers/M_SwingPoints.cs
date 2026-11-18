using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// * Distancia mínima para activar los springsJoints
/// * Lista con todos los SpringJoints de mi escena
/// * Cálculo constante de cuál es el springJoint más cercano a mi jugador
/// * Referencia a mi jugador
/// * Capacidad de des/conectar jugador al springJoint más cercano si cumple los requisitos
/// </summary>
public class M_SwingPoints : MonoBehaviour
{
    #region ATTRIBUTES
    [Header("Valores externos")]
    [SerializeField]
    List<SpringJoint2D> allJointList = new();

    [SerializeField]
    B_CapsulePlayer player;

    [Header("Valores editables")]

    [SerializeField]
    [Range(0, 20)]
    float minDistanceToSwing = 6;

    SpringJoint2D currentClosetJoint;
    #endregion


    #region METHODS
    void Update()
    {
        // Chivato para quedarme con el joint más cercano siempre
        float closetCurrentDistance = Mathf.Infinity;

        // Recorrer la lista de todos los joints y buscar el más próximo al jugador
        for(int i = 0; i < allJointList.Count; i++)
        {
            float distanceBetwewnPlayerAndJoint = 
                Vector3.Distance(
                    player.transform.position,
                    allJointList[i].transform.position
                );
            // Si el joint está a una distancia válida para balancearme...
            if(distanceBetwewnPlayerAndJoint <= minDistanceToSwing)
            {
                // Si la distancia de este joint es la menor q llevo calculando hasta ahora
                if(distanceBetwewnPlayerAndJoint < closetCurrentDistance)
                {
                    // Me quedo con este valor para las futuras comparaciones
                    closetCurrentDistance = distanceBetwewnPlayerAndJoint;
                    //Me quedo con el elemento de la lista para conectar al ugador
                    currentClosetJoint = allJointList[i];
                }

            }
        }
    }

    public void ConnectPlayerToJoint()
    {
        // Si no hay conexión válida posible no hago nada
        if(currentClosetJoint != null)
        {
            currentClosetJoint.connectedBody = player.GetComponent<Rigidbody2D>();
        }
    }
    public void DisconnectPlayerToJoint()
    {
        if (currentClosetJoint != null)
        {
            currentClosetJoint.connectedBody = null;
        }
    }

    #endregion
}
