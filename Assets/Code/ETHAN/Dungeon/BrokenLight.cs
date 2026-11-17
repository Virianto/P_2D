using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BrokenLight : MonoBehaviour
{

    Light2D lightComponent;


    void Awake()
    {
        lightComponent = GetComponent<Light2D>();
        StartCoroutine(FlikeringLight());
    }

    IEnumerator FlikeringLight()
    {
        while (true)
        {
            lightComponent.enabled = false;
            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));

            lightComponent.enabled = true;
            yield return new WaitForSeconds(Random.Range(0.5f, 2f));
        }
    }
}
