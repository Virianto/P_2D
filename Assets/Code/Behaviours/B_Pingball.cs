using UnityEngine;

/// <summary>
/// Aqui va el enunciado del proposito de esta clase
/// </summary>
public class B_Pinpon : MonoBehaviour
{
    #region ATTRIBUTES
    [SerializeField]
    KeyCode leftKey = KeyCode.A;
    [SerializeField]
    HingeJoint2D leftHinge;

    [SerializeField]
    KeyCode rightTiltKey = KeyCode.D;
    [SerializeField]
    HingeJoint2D rightHinge;


    [SerializeField]
    KeyCode startKey = KeyCode.Space;
    [SerializeField]
    SliderJoint2D startMotor;
    #endregion


    #region METHODS
    private void Update()
    {
        // Detectar input de usuario para girar y rotar el objeto
        if (Input.GetKey(leftKey))
        {
            leftHinge.useMotor = true;
        }
        else
        {
            leftHinge.useMotor = false;
        }
        if (Input.GetKey(rightTiltKey))
        {
            rightHinge.useMotor = true;
        }
        else
        {
            rightHinge.useMotor = false;
        }
        if (Input.GetKey(startKey))
        {
            startMotor.useMotor = true;
        }
    }

    #endregion
}
