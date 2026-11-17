using UnityEngine;
using System.Collections;
using UnityEngine.Rendering.Universal;

/// <summary>
/// Aqui va el enunciado del proposito de esta clase
/// </summary>
public class C_BlinkLight : MonoBehaviour
{
    #region ATTRIBUTES
    public float time = 0.5f;

    private Light2D blinkLight;

    #endregion


    #region METHODS
    void Start()
    {
        blinkLight = GetComponent<Light2D>();
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        if (blinkLight.enabled == false)
        {
            blinkLight.enabled = true;
        }
        else
        {
            blinkLight.enabled = false;
        }
        yield return new WaitForSeconds(time);
        
        StartCoroutine(Blink());
    }
    #endregion
}
