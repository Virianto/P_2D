using System.Collections;
using UnityEngine;

/// <summary>
/// Aquí va el enunciado del propósito 
/// </summary>
public class M_EffectorManager : MonoBehaviour
{

    #region ATTRIBUTES

    [Header("EDITABLE VALUES")]


    [SerializeField]
    float effectorTimeSpawn = 30;

    public float currentTime = 0;

    [Header("EXTERNAL REFERENCES")]

    [SerializeField]
    GameObject effector;
    #endregion


    #region METHODS

    private void Start()
    {
        currentTime = effectorTimeSpawn;
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            StartCoroutine(ActivateEffector());
            currentTime = effectorTimeSpawn;
        }
    }


    IEnumerator ActivateEffector()
    {
        effector.SetActive(true);
        yield return new WaitForSeconds(5);
        effector.SetActive(false);

    }

    #endregion
}
