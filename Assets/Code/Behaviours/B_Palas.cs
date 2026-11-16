using UnityEngine;

public class B_Palas : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField] KeyCode key;
    [SerializeField] HingeJoint2D anchorHingeJoint;

    #endregion

    #region METHODS

    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            anchorHingeJoint.useMotor = true;
            Debug.Log("MOTOR ON: " + anchorHingeJoint.useMotor);
        }

        if (Input.GetKeyUp(key))
        {
            anchorHingeJoint.useMotor = false;
            Debug.Log("MOTOR OFF: " + anchorHingeJoint.useMotor);
        }
    }

    #endregion
}