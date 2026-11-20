using System.Collections;
using UnityEngine;

public class GeneradorPrefabs : MonoBehaviour
{
    [Header("Configuración")]
    public GameObject prefabAGenerar; // Arrastra tu prefab aquí desde el Inspector
    public float intervalo = 3f;      // Tiempo en segundos entre cada aparición

    void Start()
    {
        // Iniciamos la corrutina al empezar el juego
        StartCoroutine(GenerarCadaTiempo());
    }

    IEnumerator GenerarCadaTiempo()
    {
        // Bucle infinito mientras el objeto esté activo
        while (true)
        {
            // Espera 3 segundos
            yield return new WaitForSeconds(intervalo);

            // Crea el prefab en la posición y rotación de este objeto generador
            if (prefabAGenerar != null)
            {
                Instantiate(prefabAGenerar, transform.position, transform.rotation);
            }
        }
    }
}