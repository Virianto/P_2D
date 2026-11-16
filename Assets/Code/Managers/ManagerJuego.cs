using System;
using UnityEngine;
using UnityEngine.Video;

/// <summary>
/// Aqui va el enunciado del proposito de esta clase
/// </summary>

public class ManagerJuego : MonoBehaviour
{
    #region ATTRIBUTES

    int vida = 3;

    int puntos = 0;

   #endregion
   #region METHODS

    public void Puntos(int añadirPuntos)
    {
        puntos += añadirPuntos;
        Debug.Log(puntos);
    }

    public void Vida(int eliminarVida)
    {
        vida -= eliminarVida;
    }

   #endregion    
}

