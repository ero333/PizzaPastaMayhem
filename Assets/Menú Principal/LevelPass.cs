using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("0"))
        {
            Menu();
        }
        if (Input.GetKeyDown("1"))
        {
            Lvl1();
        }
        if (Input.GetKeyDown("2"))
        {

        }
        if (Input.GetKeyDown("3"))
        {

        }
        if (Input.GetKeyDown("4"))
        {

        }
        if (Input.GetKeyDown("5"))
        {

        }
        if (Input.GetKeyDown("6"))
        {

        }
        if (Input.GetKeyDown("7"))
        {

        }
        if (Input.GetKeyDown("8"))
        {

        }
        if (Input.GetKeyDown("9"))
        {

        }
        if (Input.GetKeyDown("0"))
        {

        }
    }


    public void Menu()
    {
        SceneManager.LoadScene(0);

    }

    public void Lvl1()
    {
        SceneManager.LoadScene(1);
    }
}
