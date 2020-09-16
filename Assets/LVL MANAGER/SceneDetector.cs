﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDetector : MonoBehaviour
{

    Scene NivelActual;

    public int LastScene;

    void Start()
    {
        NivelActual = SceneManager.GetActiveScene(); // NivelActual detecta la escena activa

        LastScene = PlayerPrefs.GetInt("UltimoJugado"); // Last Scene va a tomar el resultado del Player Pref, que seria la ultima escena que se jugó
    }

    // Update is called once per frame
    void Update()
    {
        LastLVL();
    }

    public void LastLVL()
    {
        if (NivelActual.buildIndex == 1) // Detecta si la escena activa es 1
        {
            PlayerPrefs.SetInt("UltimoJugado", NivelActual.buildIndex); // setea el INT del Player Pref al numero de la escena actual (1)
        }

        if (NivelActual.buildIndex == 2) // Detecta si la escena activa es 2
        {
            PlayerPrefs.SetInt("UltimoJugado", NivelActual.buildIndex); // setea el INT del Player Pref al numero de la escena actual (2)
        }

        if (NivelActual.buildIndex == 3) // Detecta si la escena activa es 3
        {
            PlayerPrefs.SetInt("UltimoJugado", NivelActual.buildIndex); // setea el INT del Player Pref al numero de la escena actual (3)
        }

    }
    public void EscenaAnterior()
    {
        if (LastScene==1) // Si el Numero de la escena anterior fue 1
        {
            SceneManager.LoadScene(1);
        }
        if (LastScene == 2) // Si el Numero de la escena anterior fue 2
        {
            SceneManager.LoadScene(2);
        }
        if (LastScene == 3) // Si el Numero de la escena anterior fue 3
        {
            SceneManager.LoadScene(3);
        }
    }
}