using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Esta clase se ocupa de generar esferas en escena siguiendo algunas condiciones
///     X Ubicar la esfera en una posicion concreta (facilitada desde el Editor)
///     X Introducir aleatoriedad en posicion de origen y en cantidad de esferas
///     X añadir fisicas en el momento de generar cada esfera
///     X Condicionar la generacion a input o a parametros especificos
///     X Gestionar el ciclo de vida de las esferas generadas
/// </summary>

public class M_BallsSpawn : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    GameObject ballPrefab;

    [SerializeField]
    Transform spawnOrigin;

    #endregion

    #region METHODS
    void GenerateNewPrefab(Vector3 newPosition)
    {
        C_BouncingBall newBall = Instantiate(ballPrefab).GetComponent<C_BouncingBall>();
        newBall.InitializeBall(this,newPosition);
    }

    public void GenerateBall()
    {
        GenerateNewPrefab(spawnOrigin.position);
    }

    public void FinishBallLifeCycle(C_BouncingBall ball)
    {
        Destroy(ball.gameObject);
    }

    #endregion
}