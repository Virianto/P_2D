using UnityEngine;

/// <summary>
/// Propósito de esta clase
/// </summary>
public class B_Palas : MonoBehaviour
{
    #region ATTRIBUTES
    [SerializeField] KeyCode rightKey=KeyCode.L;
    #endregion

    #region METHODS
    void Update() {
        if (Input.GetKeyDown(rightKey))
        {
            gameObject.GetComponent<HingeJoint2D>().enabled = true;
        }
        if (!Input.GetKeyDown(rightKey))
        {
            gameObject.GetComponent<HingeJoint2D>().enabled = false;
        }
    }

    #endregion
}
