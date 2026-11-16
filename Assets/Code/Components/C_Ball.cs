using System.Collections;
using UnityEngine;

using System.Collections;

using UnityEngine.Rendering;


/// <summary>
/// X Va a conservar una referencia al manager que la creó
/// X Va a modificar sus propios atributos al nacer
/// X Va a comunicar a su manager cuándo debe desaparecer
/// </summary>
public class C_Ball : MonoBehaviour
{
    #region ATTRIBUTES

    M_Spawner spawner;

    float lifeTime = 1;



    #endregion

    #region METHODS

    public void InitializeBall(M_Spawner manager, Vector3 newPosition, float lifeTime)
    {
        transform.position = newPosition;


        GetComponent<Renderer>().material.color = Color.magenta;
        gameObject.name = "Bola " + Random.value.ToString();

        gameObject.name = "Bola" + Random.value.ToString();

        

        this.lifeTime = lifeTime;
    }

    #endregion
}
