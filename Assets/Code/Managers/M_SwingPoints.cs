

using UnityEngine;

/// <summary>
/// Aqui va el enunciado del proposito de esta clase
/// </summary>

public class M_SwingPoints : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    B_CapsulePlayer player;

    [SerializeField]
    List<SpringJoint2D> allJoinsList = new();

    [SerializeField]
    [Range(0, 20)]
    float minDistanceToSwing = 6;

    SpringJoint2D currentClosesJoint;

    #endregion
    #region METHODS

    private void Update()
    {
        float closeCurrentDistance = Mathf.Infinity;

        for (int i = 0; i < allJoinsList.Count; i++)
        {
            float distanceBetweenPlayerAndJoint = Vector3.Distance(player.transform.position, allJoinsList[i].transform.position);


            if ()
            {
                
            }

        }


    }

    #endregion
}

