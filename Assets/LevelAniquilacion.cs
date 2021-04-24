using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAniquilacion : MonoBehaviour
{


    public GameObject UI_Pasaste; // traer gameobject con el mensaje de que pasaste el nivel

    public bool completado = false; // bool para detectar si el nivel está completado

    public int ejemplo;

    public GameObject Player;

    public bool MsgEnviado;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("PlayerAll");

        MsgEnviado = false;

    }

    // Update is called once per frame
    void Update()
    {





        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0) // detecta si hay enemigos en la escena actual
        {

            completado = true;


            if(completado)
            {
                UI_Pasaste.SetActive(true);
            }
        }


        if(completado && !MsgEnviado)
        {
            Player.SendMessage("NivelCompleto");
            MsgEnviado = true;
        }

    }


}
