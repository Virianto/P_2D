using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// *Distancia mínima para activar los springJoints
/// *Lista con todos los springJoints de la escena
/// *Cálculo constante de cuál es el springJoint más cercano al jugador
/// *Referencia a mi jugador
/// *Capacidad de concentar al jugador al springJoint más cercano si cumple requisitos
/// *Capacidad de DESconcentar al jugador al springJoint más cercano si cumple requisitos
/// </summary>
public class M_SwingPoints : MonoBehaviour
{

    #region ATTRIBUTES

    [Header("EDITABLE VALUES")]

    [SerializeField]
    [Range(0f, 20f)]
    float minDistanceToSwing = 6;

    SpringJoint2D currentClosestJoint;

    [Header("EXTERNAL REFERENCES")]

    [SerializeField]
    List<SpringJoint2D> allJointsList = new();

    [SerializeField]
    B_CapsulePlayer player;

    #endregion


    #region METHODS


    private void Update()
    {
        float closestCurrentDistance = Mathf.Infinity;

        for (int i = 0; i < allJointsList.Count; i++)
        {
            float distanceBetweenPlayerAndJoint = Vector3.Distance(player.transform.position, allJointsList[i].transform.position);

            if (distanceBetweenPlayerAndJoint <= minDistanceToSwing) 
            {
                if (distanceBetweenPlayerAndJoint < closestCurrentDistance)
                {
                    closestCurrentDistance = distanceBetweenPlayerAndJoint;
                    currentClosestJoint = allJointsList[i];
                }
            }                
        }

    }


    public void ConnectPlayerToJoint()
    {
        if (currentClosestJoint != null)
        {
            currentClosestJoint.connectedBody = player.GetComponent<Rigidbody2D>();
        }
    }

    public void DisconnectPlayerFromJoint()
    {
        if(currentClosestJoint != null)
        {
            currentClosestJoint.connectedBody = null;
        }
    }
    #endregion
}
