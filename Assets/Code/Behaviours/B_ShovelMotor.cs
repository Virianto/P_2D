using UnityEngine;
using System.Collections;

/// <summary>
/// Activar el motor de la bisagra
/// </summary>
public class B_ShovelMotor : MonoBehaviour
{

    #region ATTRIBUTES
    public HingeJoint2D hinge;

    #endregion


    #region METHODS

    public void ActivateHingeMotor()
    {
        StartCoroutine(ActivateMotor());
    }

    IEnumerator ActivateMotor()
    {       
        hinge = GetComponent<HingeJoint2D>();
        hinge.useMotor = true;
        yield return new WaitForSeconds(0.1f);
        hinge.useMotor = false;
    }
    #endregion
}
