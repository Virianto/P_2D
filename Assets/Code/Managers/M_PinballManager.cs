using UnityEngine;
using Code.Utils;
using System;

/// <summary>
/// Manager de todas las funcionalidades del pinball
/// </summary>
public class M_PinballManager : Singleton<M_PinballManager>
{

    #region ATTRIBUTES


    public event Action<int> OnScoredPoint;

    [Header("EDITABLE VALUES")]
    [SerializeField]
    KeyCode rightShovelActivation = KeyCode.M;

    [SerializeField]
    KeyCode leftShovelActivation = KeyCode.Z;

    [SerializeField]
    KeyCode sliderActivation = KeyCode.Space;

    public int score = 0;


    [Header("EXTERNAL REFERENCES")]
    public B_ShovelMotor rightMotor;
    public B_ShovelMotor leftMotor;
    public B_SliderJoint slider;

    [SerializeField]
    UI_GameplayCanvas gameplayCanvas;


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


    public void UpdateCounter(int amount)
    {
        score += amount;
        OnScoredPoint?.Invoke(score);
    }
    #endregion
}

