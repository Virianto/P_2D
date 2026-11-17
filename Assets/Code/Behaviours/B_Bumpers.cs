using UnityEngine;

public class Bumper : MonoBehaviour
{
    public int puntos = 5;
    public float fuerzaRebote = 20f;

    void Start()
    {
        // Crea el material de rebote por código (no hace falta el menú)
        PhysicsMaterial2D mat = new PhysicsMaterial2D("Rebote");
        mat.bounciness = 1f;
        mat.friction = 0f;
        GetComponent<Collider2D>().sharedMaterial = mat;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Choca con: " + col.gameObject.name);

        if (col.rigidbody != null)
        {
            Vector2 dir = (col.transform.position - transform.position).normalized;
            col.rigidbody.AddForce(dir * fuerzaRebote, ForceMode2D.Impulse);
        }

        if (GameManager.Instance != null)
            GameManager.Instance.SumarPuntos(puntos);
    }
}