using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Distancia mínima para activar los springJoints
/// Lista con todos los springJoint de la escena
/// Cálculo constante de cuál es el springJoint más cercano al jugador
/// Referencia a mi jugador
/// Capacidad de des/conectar jugador al springJoint más cercano si cumple requisitos
/// </summary>
public class M_SwingPoints : MonoBehaviour
{
    #region ATTRIBUTES
    [Header("EXTERNAL VALUES")]

    [SerializeField] List<SpringJoint2D> allJointList = new();
    [SerializeField] B_CapsulePlayer player;

    [Header("EDITABLE VALUES")]

    [SerializeField]
    [Range(0, 20)]
    float minDistanceToSwing =6;

    SpringJoint2D currentClosestJoint;

#endregion

    #region METHODS
    void Update()
    {
        //chivato para quedarme con el joint más cercano
        float closestCurrentDistance = Mathf.Infinity;

        //recorrer la lista de todos los joints y buscar el más próximo al jugador
        for(int i=0; i<allJointList.Count; i++)
        {
            float distanceBetweenPlayerAndJoint = 
                Vector3.Distance(
                    player.transform.position, 
                    allJointList[i].transform.position);

            //si el joint esta a una distancia válida para balancearme
            if(distanceBetweenPlayerAndJoint <= minDistanceToSwing)
            {
                //si la distancia de este joint es la menor que llevo calcuada hasta ahora
                if (distanceBetweenPlayerAndJoint < closestCurrentDistance)
                {
                    //me quedo con este valor para futuras comparaciones
                    closestCurrentDistance = distanceBetweenPlayerAndJoint;

                    //me quedo con el elemento de la lista para conectar al jugador
                    currentClosestJoint = allJointList[i];
                }
            }
        }
    }

    public void ConnectPlayerToJoint()
    {
        //si no hay conexión válida posible, no hago nada
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
