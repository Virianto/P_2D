using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

/// <summary>
/// Este método se encarga de crear una luz 2D parpadeante
/// </summary>
public class C_DistrubingLight : MonoBehaviour
{

    #region ATTRIBUTES

    public Light2D light;
    
    [SerializeField]
    [Range(0f, 1f)]
    float timeOnOff = 0.5f;

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
            light.intensity = isOn ? 2f : 0f;
            yield return new WaitForSeconds(timeOnOff);
        }

    }
    #endregion
}
