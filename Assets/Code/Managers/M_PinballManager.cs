using UnityEngine;

/// <summary>
/// Manager de todas las funcionalidades del pinball
/// </summary>
public class M_PinballManager : MonoBehaviour
{

    #region ATTRIBUTES


    [Header("EDITABLE VALUES")]
    [SerializeField]
    KeyCode rightShovelActivation = KeyCode.M;

    [SerializeField]
    KeyCode leftShovelActivation = KeyCode.Z;

    [SerializeField]
    KeyCode sliderActivation = KeyCode.Space;


    [Header("EXTERNAL REFERENCES")]
    public B_ShovelMotor rightMotor;
    public B_ShovelMotor leftMotor;
    public B_SliderJoint slider;
    #endregion


    #region METHODS

    void Update()
    {

        if (Input.GetKey(rightShovelActivation))
        { 
            rightMotor.ActivateHingeMotor();
        }
        if (Input.GetKey(leftShovelActivation))
        {
            leftMotor.ActivateHingeMotor();
        }
        if (Input.GetKeyDown(sliderActivation))
        {
            slider.ActivateSlider();
        }
    }

    #endregion
}
