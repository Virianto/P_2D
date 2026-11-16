using UnityEngine;

/// <summary>
/// Aquí va el enunciado del propósito 
/// </summary>
public class M_PinballBallsManager : MonoBehaviour
{

    #region ATTRIBUTES


    [SerializeField]
    GameObject ballPrefab;

    public M_PinballManager manager;

    public int spawnNewBallPoints = 50;

    int currentPoints = 0;


    #endregion


    #region METHODS

    private void Start()
    {
        M_PinballManager.Instance.OnScoredPoint += UpdateScore;
    }
    void UpdateScore(int score)
    {
        currentPoints =( currentPoints + score) % spawnNewBallPoints;
        if (currentPoints %1 == 0)
        {
            Instantiate(ballPrefab);
        }
    }


    #endregion
}
