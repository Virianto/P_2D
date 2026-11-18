using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

/// <summary>
/// Este método se encarga de crear una luz 2D parpadeante
/// </summary>
public class C_DistrubingLight : MonoBehaviour
{

    #region ATTRIBUTES

    public Light2D pLight;
    
    [SerializeField]
    [Range(0f, 1f)]
    float timeOnOff = 0.5f;

    [SerializeField]
    [Range(0f, 4f)]
    float lowIntensity = 0;

    [SerializeField]
    [Range(0f, 4f)]
    float highIntensity = 0;


    bool isOn = true;
    #endregion


    #region METHODS

    void Start()
    {
        StartCoroutine(ActivateDistrubingLight());
    }
    IEnumerator ActivateDistrubingLight()
    {
        while (true)
        {
            isOn = !isOn;
            pLight.intensity = isOn ? highIntensity : lowIntensity;
            yield return new WaitForSeconds(timeOnOff);
        }

    }
    #endregion
}
