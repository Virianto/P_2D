using UnityEngine;

/// <summary>
/// Aqui va el enunciado del proposito de esta clase
/// </summary>
public class M_KeyControlPinball : MonoBehaviour
{
    #region ATTRIBUTES
    [SerializeField]
    KeyCode leftKey = KeyCode.A;
    [SerializeField]
    KeyCode rightKey = KeyCode.D;
    [SerializeField]
    KeyCode startKey = KeyCode.Space;

    [SerializeField]
    HingeJoint2D leftHinge;
    [SerializeField]
    HingeJoint2D rightHinge;
    [SerializeField]
    SliderJoint2D startMotor;
    #endregion


    #region METHODS
    private void Update()
    {
        leftHinge.useMotor = Input.GetKey(leftKey);
        rightHinge.useMotor = Input.GetKey(rightKey);
        startMotor.useMotor = Input.GetKey(startKey);
    }
    #endregion
}
