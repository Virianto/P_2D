 using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TMP_Text textoPuntos, textoVidas;
    public GameObject prefabBola;
    public Transform puntoInicio;
    public Transform zonaVerde;
    public GameObject zonaRoja;

    public int puntos = 0;
    public int vidas = 3;
    public bool juegoTerminado = false;

    int siguienteEfector;
    int siguienteBola = 50;
    int bolasActivas = 0;

    void Awake() { Instance = this; }

    void Start()
    {
        siguienteEfector = Random.Range(20, 31);
        CrearBola(puntoInicio.position);
        ActualizarUI();
    }

    public void SumarPuntos(int cantidad)
    {
        if (juegoTerminado) return;
        puntos += cantidad;

        if (puntos >= siguienteEfector)
        {
            zonaRoja.SetActive(true);
            siguienteEfector = puntos + Random.Range(20, 31);
            Invoke(nameof(OcultarEfector), 5f);
        }
        if (puntos >= siguienteBola)
        {
            CrearBola(zonaVerde.position);
            siguienteBola += 50;
        }
        ActualizarUI();
    }

    void OcultarEfector() { zonaRoja.SetActive(false); }

    void CrearBola(Vector3 pos)
    {
        Instantiate(prefabBola, pos, Quaternion.identity);
        bolasActivas++;
    }

    public void BolaPerdida(GameObject bola)
    {
        Destroy(bola);
        bolasActivas--;
        vidas--;
        ActualizarUI();

        if (vidas <= 0)
        {
            juegoTerminado = true;
            Time.timeScale = 0f;
            textoVidas.text = "GAME OVER";
        }
        else if (bolasActivas <= 0)
        {
            CrearBola(puntoInicio.position);
        }
    }

    void ActualizarUI()
    {
        textoPuntos.text = "Puntos: " + puntos;
        if (!juegoTerminado) textoVidas.text = "Vidas: " + vidas;
    }
}