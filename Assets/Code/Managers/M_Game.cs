using System;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Aquí va el enunciado del propósito de esta clase
/// </summary>
public class M_Game : MonoBehaviour
{

    #region ATTRIBUTES

    public event Action<float> OnLifeChanged;
    public event Action<float> OnPointsChanged;

    [SerializeField]
    UI_Pinball pinball;
    [SerializeField]
    M_Spawner spawner;

    float points;
    float life;

    float lifeTime = 1;

    #endregion



    #region METHODS

    public void PlayerLifeChanged(float amount)
    {
        life += amount;

        OnLifeChanged?.Invoke(life);
    }
    //public void PointsCollected(M_Points playerPoints)
    //{

    //    pinball.UpdateCounter(playerPoints.totalPoints);
    //}

    //public void ModifyPoints(float amount)
    //{
    //    points += amount;

    //    OnPointsChanged?.Invoke(points);

    //    if(points == 50)
    //    {
    //        spawner.GenerateNewPrefab(Vector3.zero);
    //    }

    //}

    //public void InitializeBall(M_Spawner manager, Vector3 newPosition, float lifeTime)
    //{
 
    //    transform.position = newPosition;


    //    GetComponent<Renderer>().material.color = Color.magenta;
    //    gameObject.name = "Bola " + Random.value.ToString();

    //    //GetComponent<Renderer>().material.color = Random.ColorHSV;
    //    gameObject.name = "Bola" + Random.value.ToString();

    //    GetComponent<Rigidbody>().AddExplosionForce(600, Vector3.zero, 150);

    //    this.lifeTime = lifeTime;
    //}

    #endregion
}