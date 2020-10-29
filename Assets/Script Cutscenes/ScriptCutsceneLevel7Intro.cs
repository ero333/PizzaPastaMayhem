using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScriptCutsceneLevel7Intro : MonoBehaviour
{
    public GameObject LvlManager;

    public GameObject BotonSiguiente;
    public EventSystem EventSys;

    public int Numero;

    string[] Dialogo = new string[4];

    public Text Texto;


    [Header("Sprites")]

    public GameObject Sprite1;
    public GameObject Sprite2;
    public GameObject Sprite3;
    public GameObject Sprite4;


    // Start is called before the first frame update
    void Start()
    {
        Numero = 0;

        LvlManager = GameObject.FindGameObjectWithTag("LVLMANAGER");

        PlayerPrefs.SetInt("DesbloqueasteNivel_7", 1);
    }

    // Update is called once per frame
    void Update()
    {
        CadaDialogo();

        SpriteChange();



        if (Input.GetKeyDown("j"))
        {
            Numero++;
        }

        if (Numero == 4)
        {
            LvlManager.SendMessage("Lvl7");
        }



        if (EventSys.currentSelectedGameObject == null)
        {
            EventSys.SetSelectedGameObject(BotonSiguiente);

        }
    }

    public void Siguiente()
    {
        Numero++;
    }

    public void CadaDialogo()
    {
        if (Numero < 4)
        {
            Texto.text = Dialogo[Numero];

            Dialogo[0] = "¡Que porrazo se dió el bicho!";
            Dialogo[1] = "Pero... ¿Qué es ese ruido? Suena a un río.";
            Dialogo[2] = "Ehhhh.....";
            Dialogo[3] = "¡Dios, no! ¡Debo salir de aqui rápido!";

        }

    }

    public void SpriteChange()
    {
        if (Numero == 0)
        {
            Sprite1.SetActive(true);
        }

        if (Numero == 1)
        {
            Sprite1.SetActive(false);
            Sprite2.SetActive(true);
        }


        if (Numero == 2)
        {
            Sprite2.SetActive(false);
            Sprite3.SetActive(true);
        }

        if (Numero == 3)
        {
            Sprite3.SetActive(false);
            Sprite4.SetActive(true);
        }
    }
}
