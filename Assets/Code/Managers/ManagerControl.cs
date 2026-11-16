using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

/// <summary>
/// Aqui va el enunciado del proposito de esta clase
/// </summary>

public class ManagerControl : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    HingeJoint2D pala1;

    [SerializeField]
    HingeJoint2D pala2;

    [SerializeField]
    SliderJoint2D jumper;

    [SerializeField]
    Rigidbody2D plataforma;

    [SerializeField]
    GameObject cierre;

    #endregion
    #region METHODS

    private void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            pala1.useMotor = true;
        }
        else
        {
            pala1.useMotor = false;
        }

        if (Input.GetKey(KeyCode.X))
        {
            pala2.useMotor = true;
        }
        else
        {
            pala2.useMotor = false;
        }

        if (Input.GetKey(KeyCode.C))
        {
            jumper.useMotor = true;
            plataforma.gravityScale = 0;
            cierre.SetActive(false);
        }
        else
        {
            jumper.useMotor= false;
            plataforma.gravityScale = 1;
            cierre.SetActive(true);
        }
    }

    #endregion
}

