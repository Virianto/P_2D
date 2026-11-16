using UnityEngine;


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

    int currentLifes;

    #endregion





    #region METHODS
    private void Start()
    {
        currentLifes = lifesCounter;
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
    }

    public void BlueZumperPoints()
    {
        totalPoints += 10;
        pinballCanvas.UpdatePointsText(totalPoints);
    }

    public void LifeDown()
    {
        lifesCounter -= 1;
        pinballCanvas.UpdateLifesImage(currentLifes);
    }

    #endregion
}