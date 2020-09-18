using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{


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

    public void GameOverScreen()
    {
        SceneManager.LoadScene("Pantalla Game Over");
    }



}
