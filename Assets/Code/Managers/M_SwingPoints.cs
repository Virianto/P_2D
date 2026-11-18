using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// X Distancia mínima para activar los springJoints
/// X Lista con todos los springJoints de la escena
/// X Calculo constante de cuál es el springJoint más cercano al jugador
/// X Referencia a mi jugador
/// * Capacidad de des/conectar jugador al springJoint más cercano si cumple requisitos
/// </summary>
public class M_SwingPoints : MonoBehaviour
{
    #region ATTRIBUTES

    [Header("EXTERNAL REFERENCES")]

    [SerializeField]
    B_CapsulePlayer player;

    [SerializeField]
    List<SpringJoint2D> allJointsList = new();

    [Header("EDITABLE VALUES")]

    [SerializeField]
    [Range(0, 20)]
    float minDistanceToSwing = 6;

    SpringJoint2D currentClosestJoint;

    #endregion

    #region METHODS

    void Update()
    {
        // chivato para quedarme con el joint más cercano
        float closestCurrentDistance = Mathf.Infinity;

        // Recorrer la lista de TODOS los joints y buscar el más próximo al jugador
        for(int i = 0;  i < allJointsList.Count; ++i)
        {
            float distanceBetweenPlayerAndJoint = 
                Vector3.Distance(
                    player.transform.position, 
                    allJointsList[i].transform.position);

            // Si el joint está a una distancia válida para balancearme...
            if(distanceBetweenPlayerAndJoint <= minDistanceToSwing)
            {
                // Si la distancia de este joint es la menor que llevo calculada hasta ahora...
                if (distanceBetweenPlayerAndJoint < closestCurrentDistance)
                {
                    // Me quedo con este valor para las futuras comparaciones
                    closestCurrentDistance = distanceBetweenPlayerAndJoint;
                    // Me quedo con el elemento de la lista para conectar al jugador
                    currentClosestJoint = allJointsList[i];
                }
            }                       
        }
    }

    #endregion
}
