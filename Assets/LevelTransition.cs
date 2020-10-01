using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    [Header("Variables que se mantienen")]
    public int NumeroVidas = 2;
    public float VidaTotal = 10f;
    public float MunicioTotal = 50f;


    // Start is called before the first frame update
    void Start()
    {

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

        PlayerPrefs.SetFloat("MunicionMaxima", MunicioTotal);
        PlayerPrefs.SetFloat("MunicionActual", MunicioTotal);

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








}
