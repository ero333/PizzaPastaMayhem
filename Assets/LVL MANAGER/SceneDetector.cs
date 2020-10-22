using System.Collections;
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

        if (NivelActual.buildIndex == 4) // Detecta si la escena activa es 4
        {
            PlayerPrefs.SetInt("UltimoJugado", NivelActual.buildIndex); // setea el INT del Player Pref al numero de la escena actual (4)
        }

        if (NivelActual.buildIndex == 5) // Detecta si la escena activa es 5
        {
            PlayerPrefs.SetInt("UltimoJugado", NivelActual.buildIndex); // setea el INT del Player Pref al numero de la escena actual (5)
        }

        if (NivelActual.buildIndex == 6) // Detecta si la escena activa es 6
        {
            PlayerPrefs.SetInt("UltimoJugado", NivelActual.buildIndex); // setea el INT del Player Pref al numero de la escena actual (6)
        }

        if (NivelActual.buildIndex == 7) // Detecta si la escena activa es 7
        {
            PlayerPrefs.SetInt("UltimoJugado", NivelActual.buildIndex); // setea el INT del Player Pref al numero de la escena actual (7)
        }

        if (NivelActual.buildIndex == 8) // Detecta si la escena activa es 8
        {
            PlayerPrefs.SetInt("UltimoJugado", NivelActual.buildIndex); // setea el INT del Player Pref al numero de la escena actual (8)
        }

        if (NivelActual.buildIndex == 9) // Detecta si la escena activa es 9
        {
            PlayerPrefs.SetInt("UltimoJugado", NivelActual.buildIndex); // setea el INT del Player Pref al numero de la escena actual (9)
        }

        if (NivelActual.buildIndex == 10) // Detecta si la escena activa es 10
        {
            PlayerPrefs.SetInt("UltimoJugado", NivelActual.buildIndex); // setea el INT del Player Pref al numero de la escena actual (10)
        }

        if (NivelActual.buildIndex == 11) // Detecta si la escena activa es 11
        {
            PlayerPrefs.SetInt("UltimoJugado", NivelActual.buildIndex); // setea el INT del Player Pref al numero de la escena actual (11)
        }

        if (NivelActual.buildIndex == 12) // Detecta si la escena activa es 12
        {
            PlayerPrefs.SetInt("UltimoJugado", NivelActual.buildIndex); // setea el INT del Player Pref al numero de la escena actual (12)
        }

        if (NivelActual.buildIndex == 13) // Detecta si la escena activa es 13
        {
            PlayerPrefs.SetInt("UltimoJugado", NivelActual.buildIndex); // setea el INT del Player Pref al numero de la escena actual (13)
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

        if (LastScene == 4) // Si el Numero de la escena anterior fue 4
        {
            SceneManager.LoadScene(4);
        }

        if (LastScene == 5) // Si el Numero de la escena anterior fue 5
        {
            SceneManager.LoadScene(5);
        }

        if (LastScene == 6) // Si el Numero de la escena anterior fue 6
        {
            SceneManager.LoadScene(6);
        }

        if (LastScene == 7) // Si el Numero de la escena anterior fue 7
        {
            SceneManager.LoadScene(7);
        }

        if (LastScene == 8) // Si el Numero de la escena anterior fue 8
        {
            SceneManager.LoadScene(8);
        }

        if (LastScene == 9) // Si el Numero de la escena anterior fue 9
        {
            SceneManager.LoadScene(9);
        }

        if (LastScene == 10) // Si el Numero de la escena anterior fue 10
        {
            SceneManager.LoadScene(10);
        }

        if (LastScene == 11) // Si el Numero de la escena anterior fue 11
        {
            SceneManager.LoadScene(11);
        }

        if (LastScene == 12) // Si el Numero de la escena anterior fue 12
        {
            SceneManager.LoadScene(12);
        }

        if (LastScene == 13) // Si el Numero de la escena anterior fue 13
        {
            SceneManager.LoadScene(13);
        }
    }
}
