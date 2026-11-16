
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Aquí va el enunciado del propósito 
/// </summary>
public class M_PinballBallsManager : MonoBehaviour
{

    #region ATTRIBUTES

    public List<B_Ball> allBallsList = new();
    [SerializeField]
    GameObject ballPrefab;

    public M_PinballManager manager;

    public int spawnNewBallPoints = 50;

    int currentPoints = 0;
    int t = 0;


    #endregion


    #region METHODS

    private void Start()
    {
        M_PinballManager.Instance.OnScoredPoint += UpdateScore;
    }
    void UpdateScore(int score)
    {
        currentPoints = score - spawnNewBallPoints*t;
        if (currentPoints >= spawnNewBallPoints)
        {
            t++;
            GenerateNewBall();  
        }
    }


    void GenerateNewBall()
    {
        B_Ball newBall = Instantiate(ballPrefab).GetComponent<B_Ball>();
        allBallsList.Add(newBall);
        newBall.InitializeBall(this);

    }
    public void FinishBall(B_Ball ball)
    {
        allBallsList.Remove(ball);
        Destroy(ball.gameObject);
    }
    

    


    #endregion
}
