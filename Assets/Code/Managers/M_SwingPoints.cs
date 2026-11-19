using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Distancia mínima para activar springJoints
/// Lista con todos los joints de la escena (spring)
/// Calculo constante de cual es el spring más cercano
/// Referencia jugador
/// Capacidad de con/desconectar jugador
/// </summary>
public class M_SwingPoints : MonoBehaviour
{
    #region ATTRIBUTES

    [Header("EXTERNAL REFERENCES")]

    [SerializeField]
    List<SpringJoint2D> allJointsList = new();
    [SerializeField]
    B_CapsulePlayer player;

    [Header("EDITABLE VALUES")]

    [Range(0, 20)]
    float minDistanceToSwing = 6;

    SpringJoint2D currentClosesJoint;

    Vector3 playerPos;

    #endregion

    #region METHODS

    private void Update()
    {
        playerPos = player.transform.position;

        float closestCurrentDistance = Mathf.Infinity;

        for (int i = 0; i < allJointsList.Count; i++)
        {
            float distanceBetwPlayerJoint = Vector3.Distance(playerPos, allJointsList[i].transform.position);

            //Si la distancia de este joint es meno que 
            if (distanceBetwPlayerJoint <= minDistanceToSwing)
            {
                //Si la distancia de este joint es la menor que llevo calculada...
                if (distanceBetwPlayerJoint < closestCurrentDistance)
                {
                    //Me quedo con este valor para futuras comparaciones
                    closestCurrentDistance = distanceBetwPlayerJoint;
                    //Me quedo con el elemento a conectar al player
                    currentClosesJoint = allJointsList[i];
                }
            }
        }
    }

    public void ConnectPlayerToJoint()
    {
        //Si no hay conexión válida, no hacemos nada
        if (currentClosesJoint != null)
        {
            currentClosesJoint.connectedBody = player.GetComponent<Rigidbody2D>();
        }
    }

    public void DisconnectPlayerJoint()
    {
        if(currentClosesJoint != null)
        {
            currentClosesJoint.connectedBody = null;
        }
    }

    #endregion
}
