using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAniquilacion : MonoBehaviour
{


    public GameObject UI_Pasaste; // traer gameobject con el mensaje de que pasaste el nivel

    public bool completado; // bool para detectar si el nivel está completado

    public GameObject LvlManager; // traer gameobject del lvl manager

    // Start is called before the first frame update
    void Start()
    {
        completado = false;
    }

    // Update is called once per frame
    void Update()
    {


        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0) // detecta si hay enemigos en la escena actual
        {
            UI_Pasaste.SetActive(true);

            completado = true;
        }

        if (completado && Input.GetKeyDown("n"))
        {
            LvlManager.SendMessage("Lvl2");
        }
    }
}
