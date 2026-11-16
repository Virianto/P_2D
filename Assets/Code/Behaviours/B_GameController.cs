using UnityEngine;

/// <summary>
/// Controlar las palas con teclado
/// </summary>
public class B_GameController : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    KeyCode teclaPalaI = KeyCode.LeftArrow;
    [SerializeField]
    KeyCode teclaPalaD = KeyCode.RightArrow;
    [SerializeField]
    KeyCode teclaMuelle = KeyCode.Space;

    [SerializeField]
    GameObject componente;
    [SerializeField]
    GameObject bola;
    SliderJoint2D fuerzaMuelle, newSlider;

    #endregion

    #region METHODS

    private void Awake()
    {
        if (gameObject.name.Equals("Boost"))
        {
            fuerzaMuelle = componente.GetComponent<SliderJoint2D>();

            //SliderJoint2D newSlider = componente.AddComponent<SliderJoint2D>();
            //newSlider.enabled = false;
            //newSlider.connectedBody = bola.GetComponent<Rigidbody2D>();
            //JointMotor2D sliderMotor = newSlider.motor;
            ////sliderMotor.motorSpeed = -50;
            ////newSlider.breakForce = 10;
            //this.newSlider = newSlider;
        }
    }

    private void Update()
    {
        if ((Input.GetKey(teclaPalaD) && tag.Equals("Flipper2"))
            || (Input.GetKey(teclaPalaI) && tag.Equals("Flipper1")))
            componente.GetComponent<HingeJoint2D>().useMotor = true;
        else if (Input.GetKeyDown(teclaMuelle) && !tag.Contains("Flipper"))
        {
            if (fuerzaMuelle.isActiveAndEnabled)
            {
                fuerzaMuelle.useMotor = true;
            }
            else
                fuerzaMuelle.enabled = true;

            //if (fuerzaMuelle.motor.motorSpeed == 0)
            //{
            //    JointMotor2D motor = fuerzaMuelle.motor;
            //    motor.motorSpeed = -50;
            //}
            //if (fuerzaMuelle is null)
            //    newSlider.enabled = true;
        }
        else if (tag.Contains("Flipper"))
            componente.GetComponent<HingeJoint2D>().useMotor = false;

        //if (Input.GetKey(teclaPalaI) && !name.Contains("1"))
        //    motorPala.GetComponent<HingeJoint2D>().useMotor = true;
        //else
        //    motorPala.GetComponent<HingeJoint2D>().useMotor = false;
    }

    #endregion
}
