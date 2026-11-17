using UnityEngine;

using UnityEngine;

public class ZonaAmarilla : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bola"))
            GameManager.Instance.BolaPerdida(col.gameObject);
    }
}