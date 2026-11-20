using UnityEngine;

public class Patrulla : MonoBehaviour
{
    public float velocidad = 2f;
    public float distancia = 3f;
    Vector3 inicio;

    void Start()
    {
        inicio = transform.position;
    }

    void Update()
    {
        float x = Mathf.PingPong(Time.time * velocidad, distancia * 2) - distancia;
        transform.position = new Vector3(inicio.x + x, inicio.y, inicio.z);
    }
}