using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class PinballManager : MonoBehaviour
{
    public TMP_Text pointsText;
    public GameObject redEffectorGO;
    public GameObject newBall;
    public Transform ballSpawnOrigin;
    public GameObject normalHUD;
    public GameObject gameOverHUD;
    public int points;
    public int redInnerPoints;
    public int ballInnerPoints;

    void Awake()
    {
        pointsText.text = "000";
    }
    void Update()
    {
        if(points >= 500)
        {
            normalHUD.SetActive(false);
            gameOverHUD.SetActive(true);
        }
    }

    public void UpdatePoints(int nuevosPuntos)
    {
        points += nuevosPuntos;
        pointsText.text = points.ToString();

        //Red Effector
        redInnerPoints += nuevosPuntos;
        if(redInnerPoints >= 20)
        {
            StartCoroutine(RedEffector());
            
        }

        //Ball Spawner
        ballInnerPoints += nuevosPuntos;
        if (ballInnerPoints >= 50)
        {
            SpawnBall(ballSpawnOrigin.position);
            ballInnerPoints = 0;
        }
    }

    IEnumerator RedEffector()
    {
        redEffectorGO.SetActive(true);
        yield return new WaitForSeconds(10);
        redEffectorGO.SetActive(false);
        redInnerPoints = 0;
    }

    void SpawnBall(Vector3 newPosition)
    {
        GameObject ball = Instantiate(newBall);
        ball.transform.position = newPosition;
        
    }

}
