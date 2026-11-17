using UnityEngine;

public class Flipper : MonoBehaviour
{
    public KeyCode tecla = KeyCode.LeftArrow;
    public float velocidad = 800f;      // negativo en la otra pala
    public float fuerza = 10000f;
    HingeJoint2D bisagra;

    void Start()
    {
        bisagra = GetComponent<HingeJoint2D>();
        JointMotor2D m = bisagra.motor;
        m.motorSpeed = velocidad;
        m.maxMotorTorque = fuerza;
        bisagra.motor = m;
    }

    void Update()
    {
        bisagra.useMotor = Input.GetKey(tecla);   // activa/desactiva el motor
    }
}