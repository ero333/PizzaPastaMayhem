using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    [Header("Variables que se mantienen")]
    private int NumeroVidas = 2;
    private float VidaTotal = 100f;
    private float MunicioTotal = 20f;

    float vidaActual;

    Scene NivelActual;


    // Start is called before the first frame update
    void Start()
    {
        vidaActual = PlayerPrefs.GetFloat("VidaActual");

        NivelActual = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LvlSelector()
    {
        SceneManager.LoadScene("SelectorDeNiveles");
    }

    public void Lvl1()
    {
        SceneManager.LoadScene(1);
    }

    public void Lvl2()
    {
        SceneManager.LoadScene(2);
    }

    public void Lvl3()
    {
        SceneManager.LoadScene(3);
    }

    public void Lvl4()
    {
        SceneManager.LoadScene(4);
    }

    public void Lvl5()
    {
        SceneManager.LoadScene(5);
    }

    public void Lvl6()
    {
        SceneManager.LoadScene(6);
    }

    public void Lvl7()
    {
        SceneManager.LoadScene(7);
    }

    public void Lvl8()
    {
        SceneManager.LoadScene(8);
    }

    public void Lvl9()
    {
        SceneManager.LoadScene(9);
    }

    public void BossFight1()
    {
        SceneManager.LoadScene("Boss-Fight1");
    }
    public void BossFight2()
    {
        SceneManager.LoadScene("Boss-Fight2");
    }
    public void BossFight3()
    {
        SceneManager.LoadScene("Boss-Fight3");
    }


    public void CUTSCENE1()
    {
        SceneManager.LoadScene("CUTSCENEPRUEBA1");
    }

    public void GameOverScreen()
    {
        SceneManager.LoadScene("Pantalla Game Over");
    }

    public void Reinicio()
    {
        PlayerPrefs.SetInt("vidas", NumeroVidas);
        PlayerPrefs.SetFloat("VidaTotal", VidaTotal);
        PlayerPrefs.SetFloat("VidaActual", VidaTotal);

        RecetasReinicio();
    }

    public void RecetasReinicio()
    {
        PlayerPrefs.SetInt("DropPan", 0);
        PlayerPrefs.SetInt("DropQueso", 0);
        PlayerPrefs.SetInt("DropPaty", 0);

        PlayerPrefs.SetInt("DropJamon", 0);
        PlayerPrefs.SetInt("DropSalchicha", 0);
        PlayerPrefs.SetInt("DropAlbondiga", 0);

        PlayerPrefs.SetInt("DropPollo", 0);
        PlayerPrefs.SetInt("DropLechuga", 0);
        PlayerPrefs.SetInt("DropTomate", 0);

    }

    public void VidaReinicio()
    {
        if(vidaActual <= 0)
        {
            PlayerPrefs.SetFloat("VidaActual", VidaTotal);
        }

    }

    public void MunicionReinicio()
    {
        PlayerPrefs.SetFloat("MunicionMaxima", MunicioTotal);
        PlayerPrefs.SetFloat("MunicionActual", MunicioTotal);

    }

    public void EmpezarJuego()
    {
        Reinicio();
        MunicionReinicio();
    }


    public void PasarNivel()
    {
        SceneManager.LoadScene(NivelActual.buildIndex + 1);
    }





}
