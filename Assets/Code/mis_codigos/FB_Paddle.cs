using UnityEngine;

/// <summary>
/// Controla las palas del pinball activando el motor de su HingeJoint2D
/// mientras se mantiene pulsada la tecla correspondiente.
/// </summary>
public class FB_Paddle : MonoBehaviour
{
    #region ATTRIBUTES

    [Range(-3000, 0)]
    public float rightPaddleForce = -1500; //velocidad 

    [Range(0, 3000)]
    public float leftPaddleForce = 1500;

    [SerializeField]
    KeyCode leftPaddle = KeyCode.Q;

    [SerializeField]
    KeyCode rightPaddle = KeyCode.W;

    [SerializeField]
    HingeJoint2D leftJoint; //REFERENCIA A LOS JOINS PRA TOCARLE LOS VALORES

    [SerializeField]
    HingeJoint2D rightJoint;

    [SerializeField]
    float maxMotorTorque = 10000f; //fuerza para ambas

    #endregion

    #region METHODS

    void Update()
    {
        // Mientras se mantiene la tecla, el motor está activo
        MovePaddle(leftJoint, Input.GetKey(leftPaddle), leftPaddleForce);
        MovePaddle(rightJoint, Input.GetKey(rightPaddle), rightPaddleForce);
    }

    void MovePaddle(HingeJoint2D joint, bool pressed, float speed) 
    {
        joint.useMotor = pressed;

        if (pressed)
        {
            JointMotor2D motor = joint.motor;   // es un struct: copia, modifica, reasigna
            motor.motorSpeed = speed;
            motor.maxMotorTorque = maxMotorTorque;
            joint.motor = motor; //aqui seteamos el valor qu ehemos ocado al motor real 
        }
    }

    #endregion
}