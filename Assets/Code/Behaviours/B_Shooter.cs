using UnityEngine;

/// <summary>
/// Propósito de esta clase
/// </summary>
public class B_Shooter : MonoBehaviour
{
    #region ATTRIBUTES
    [SerializeField] SliderJoint2D sliderJoint;
    [SerializeField] KeyCode key=KeyCode.Space;
    #endregion

    #region METHODS

    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            sliderJoint.useMotor = true;
        }
        if (Input.GetKeyUp(key))
        {
            sliderJoint.useMotor = false;
        }
    }
    #endregion
}
