using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Aquí va el enunciado del propósito de esta clase
/// </summary>
public class M_Spawner : MonoBehaviour
{

    #region ATTRIBUTES

    [SerializeField]
    [Range(1, 300)]
    int totalSpheresToCreate = 1;

    [SerializeField]
    [Range(1, 15)]
    float horizontalXRange = 2;

    [SerializeField]
    [Range(1, 15)]
    float horizontalZRange = 2;

    [SerializeField]
    GameObject ballPrefab;
    [SerializeField]
    Transform spawnOrigin;

    [SerializeField]
    List<Transform> allSequencePointsList = new();

    List<M_Game> allInstantiatedBallsList = new();

    int currentSequenceIndex = 0;

    float points;
    #endregion



    #region METHODS

    //void Update()
    //{
    //    // Detectar una tecla para generar una esfera en el spawnOrigin
    //    if (points == 50)
    //    {
    //        GenerateNewPrefab(spawnOrigin.position);
    //    }

    //}


    public void GenerateNewPrefab(Vector3 newPosition)
    {
        C_Ball newBall = Instantiate(ballPrefab).GetComponent<C_Ball>();

        //allInstantiatedBallsList.Add(newBall);
        newBall.InitializeBall(this, newPosition, Random.value * 5);
    }


    public void FinishBallLifeCycle(M_Game ball)
    {

        allInstantiatedBallsList.Remove(ball);

        Destroy(ball.gameObject);

        currentSequenceIndex = (currentSequenceIndex + 1) % allSequencePointsList.Count;
    }

    void GeneratePrefabAtCustomOrigin()
    {
        //GameObject newBall = GenerateNewPrefab(spawnOrigin.position);            
    }

    #endregion
}