using UnityEngine;

public class Pulsador : MonoBehaviour
{
    public KeyCode tecla = KeyCode.Space;
    public float velocidadBajada = -3f;
    public float velocidadSubida = 30f;
    public float fuerza = 100000f;

    SliderJoint2D slider;

    void Start()
    {
        slider = GetComponent<SliderJoint2D>();
        slider.useMotor = true;
    }

    void Update()
    {
        JointMotor2D m = slider.motor;
        m.maxMotorTorque = fuerza;

        if (GameManager.Instance != null && GameManager.Instance.juegoTerminado)
            m.motorSpeed = 0f;
        else
            m.motorSpeed = Input.GetKey(tecla) ? velocidadBajada : velocidadSubida;

        slider.motor = m;
    }
}