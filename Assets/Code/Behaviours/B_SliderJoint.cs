using System.Collections;
using UnityEngine;


/// <summary>
/// Activar el motor del slider
/// </summary>
public class B_SliderJoint : MonoBehaviour
{
    #region ATTRIBUTRES

    public SliderJoint2D slider;
    
    #endregion

    #region METHODS
    
    public void ActivateSlider()
    {
        StartCoroutine(SliderActivation());
    }

    IEnumerator SliderActivation()
    {
        slider = GetComponent<SliderJoint2D>();
        slider.useMotor = true;
        yield return new WaitForSeconds(0.1f);
        slider.useMotor = false;
    }
    #endregion
	
}
