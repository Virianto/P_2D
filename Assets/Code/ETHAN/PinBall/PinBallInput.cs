using System.Collections;
using UnityEngine;

public class PinBallInput : MonoBehaviour
{
    public HingeJoint2D FangR;
    public HingeJoint2D FangL;
    public SliderJoint2D laucherJoint;

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            FangR.useMotor = true;
        }
        else
        {
            FangR.useMotor = false;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            FangL.useMotor = true;
        }
        else
        {
            FangL.useMotor = false;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            StartCoroutine(Launcher());
        }
        IEnumerator Launcher()
        {
            laucherJoint.useMotor = true;
            yield return new WaitForSeconds(0.5f);
            laucherJoint.useMotor = false;
        }
    }
}
