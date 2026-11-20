using UnityEngine;

using  UnityEngine;

public class MovimientoLateral : MonoBehaviour
{
    public float velocidad = 5f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal"); // A/D o flechas
        rb.linearVelocity = new Vector2(x * velocidad, rb.linearVelocity.y);
    }
}
