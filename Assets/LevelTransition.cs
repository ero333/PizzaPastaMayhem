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

    int JuegoNoComenzado;

    // Start is called before the first frame update
    void Start()
    {
        vidaActual = PlayerPrefs.GetFloat("VidaActual");

        NivelActual = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("n"))
        {
            //Lvl5();
        }
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

    public void Lvl10()
    {
        SceneManager.LoadScene(10);
    }
    public void Lvl11()
    {
        SceneManager.LoadScene(11);
    }

    public void Lvl12()
    {
        SceneManager.LoadScene(12);
    }

    public void Lvl13()
    {
        SceneManager.LoadScene(13);
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




    public void CUTSCENE1(bool selector = false)
    {
        SceneManager.LoadScene("Cutscene LVL 1");
    }

    public void CUTSCENE2()
    {
        SceneManager.LoadScene("Cutscene LVL 2");
    }

    public void CUTSCENE3()
    {
        SceneManager.LoadScene("Cutscene LVL 3");
    }

    public void CUTSCENE4()
    {
        SceneManager.LoadScene("Cutscene LVL 4");
    }

    public void CUTSCENE5()
    {
        SceneManager.LoadScene("Cutscene LVL 5");
    }

    public void CUTSCENE6()
    {
        SceneManager.LoadScene("Cutscene LVL 6");
    }

    public void CUTSCENE7()
    {
        SceneManager.LoadScene("Cutscene LVL 7");
    }

    public void CUTSCENE8()
    {
        SceneManager.LoadScene("Cutscene LVL 8");
    }

    public void CUTSCENE9()
    {
        SceneManager.LoadScene("Cutscene LVL 9");
    }

    public void CUTSCENE10()
    {
        SceneManager.LoadScene("Cutscene LVL 10");
    }

    public void CUTSCENE11()
    {
        SceneManager.LoadScene("Cutscene LVL 11");
    }

    public void CUTSCENE12()
    {
        SceneManager.LoadScene("Cutscene LVL 12");
    }

    public void CUTSCENE13()
    {
        SceneManager.LoadScene("Cutscene LVL 13");
    }

    public void CUTSCENE14()
    {
        SceneManager.LoadScene("Cutscene LVL 14");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Créditos");
    }

    public void Calificar()
    {

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

    public void ReiniciarNivelActual()
    {
        SceneManager.LoadScene(NivelActual.buildIndex);
    }

}
