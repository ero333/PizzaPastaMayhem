using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneNivel4 : MonoBehaviour
{


    public GameObject LvlManager;

    public int Numero;

    string[] Dialogo = new string[10];

    public Text Texto;


    [Header("Sprites Viejo")]

    public GameObject Sprite1;
    public GameObject Sprite2;
    public GameObject Sprite3;
    public GameObject Sprite4;
    public GameObject Sprite5;
    public GameObject Sprite6;
    public GameObject Sprite7;
    public GameObject Sprite8;
    public GameObject Sprite9;
    public GameObject Sprite10;

    // Start is called before the first frame update
    void Start()
    {
        Numero = 0;

        LvlManager = GameObject.FindGameObjectWithTag("LVLMANAGER");
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

        if (Numero == 10)
        {
            LvlManager.SendMessage("Lvl5");
        }
    }

    public void Siguiente()
    {
        Numero++;
    }

    public void CadaDialogo()
    {
        if (Numero < 10)
        {
            Texto.text = Dialogo[Numero];

            Dialogo[0] = "...";
            Dialogo[1] = "¡Uy!¡Creo que me perdí!";
            Dialogo[2] = "Mmmmh, tal vez en esta casa haya alguien.";
            Dialogo[3] = "¡¿Hola?!¡¿Hay alguien ahí?!";
            Dialogo[4] = "¿...?";
            Dialogo[5] = "¡¿Quién interrumpe mi siestaaaa?!";
            Dialogo[6] = "¡Yo te maldigooooo!";
            Dialogo[7] = "Hola señor, ¿podría decirme qué dirección debo tomar para salir de aqui?";
            Dialogo[8] = "¿¡Un HUMANO!?¡hace decenas de meses que no veía a otro humano!";
            Dialogo[9] = "Si logras traerme un poco de la gelatina que producen las criaturas, te dire por donde debes ir.";
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

        if (Numero == 4)
        {
            Sprite4.SetActive(false);
            Sprite5.SetActive(true);
        }

        if (Numero == 5)
        {
            Sprite5.SetActive(false);
            Sprite6.SetActive(true);
        }

        if (Numero == 6)
        {
            Sprite6.SetActive(false);
            Sprite7.SetActive(true);
        }

        if (Numero == 7)
        {
            Sprite7.SetActive(false);
            Sprite8.SetActive(true);
        }

        if (Numero == 8)
        {
            Sprite8.SetActive(false);
            Sprite9.SetActive(true);
        }

        if (Numero == 9)
        {
            Sprite9.SetActive(false);
            Sprite10.SetActive(true);
        }
    }
}
