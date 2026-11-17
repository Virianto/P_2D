using UnityEngine;
using System;


/// <summary>
/// Controlar el HingeJoint de las palas y el SliderJoint del lanzador de inicio
/// </summary>
public class M_PinballGameManager : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    HingeJoint2D leftHingeJoint;
    [SerializeField]
    HingeJoint2D rightHingeJoint;
    [SerializeField]
    SliderJoint2D sliderJoint;

    [SerializeField]
    KeyCode leftController = KeyCode.A;
    [SerializeField]
    KeyCode rightController = KeyCode.D;
    [SerializeField]
    KeyCode sliderController = KeyCode.Space;

    [SerializeField]
    UI_PinballCanvas pinballCanvas;

    [SerializeField]
    [Range(0, 1000)]
    int totalPoints;

    [SerializeField]
    [Range(0, 3)]
    int lifesCounter = 3;

    [SerializeField]
    GameObject ballPrefab;

    int activeBalls = 0;

    int pointsForNewBall = 100;

    Vector2 ballPosition = new Vector2(8.85f, -4);

    #endregion





    #region METHODS

    private void Start()
    {
        GenerateNewBall();
    }

    private void Update()
    {
        if (Input.GetKey(leftController))
        {
            leftHingeJoint.useMotor = true;
        }
        else
        {
            leftHingeJoint.useMotor = false;
        }

        if (Input.GetKey(rightController))
        {
            rightHingeJoint.useMotor = true;
        }
        else
        {
            rightHingeJoint.useMotor = false;
        }

        if (Input.GetKey(sliderController))
        {
            sliderJoint.useMotor = true;
        }
        else
        {
            sliderJoint.useMotor = false;
        }
    }

    public void YellowZumperPoints()
    {
        totalPoints += 5;
        pinballCanvas.UpdatePointsText(totalPoints);
        HundredPoints();
    }

    public void BlueZumperPoints()
    {
        totalPoints += 10;
        pinballCanvas.UpdatePointsText(totalPoints);
        HundredPoints();
    }

    public void LifeDown()
    {
        lifesCounter -= 1;
        pinballCanvas.UpdateLifesImage(lifesCounter);
    }

    public void GenerateNewBall()
    {
            Instantiate(ballPrefab, ballPosition, Quaternion.identity);
        activeBalls ++;
    }

    public void HundredPoints()
    {
        if (totalPoints >= pointsForNewBall)
        {
            if (activeBalls < 3)
            {
                GenerateNewBall();
            }

            pointsForNewBall += 100;
        }
    }

    #endregion
}