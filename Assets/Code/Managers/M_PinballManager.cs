using UnityEngine;

/// <summary>
/// Aquí va el enunciado del propósito 
/// </summary>
public class M_PinballManager : MonoBehaviour
{

    #region ATTRIBUTES


    [SerializeField]
    GameObject rightShovelMotor;

    [SerializeField]

    KeyCode rightShovelActivation = KeyCode.M;

    [SerializeField]

    KeyCode leftShovelActivation = KeyCode.Z;


    #endregion


    #region METHODS

    void Update()
    {

        if (Input.GetKeyDown(rightShovelActivation))
        {
            
        }

        if (Input.GetKeyDown(leftShovelActivation))
        {
            //El motor izquierdo se activa
        }
    }

    #endregion
}
