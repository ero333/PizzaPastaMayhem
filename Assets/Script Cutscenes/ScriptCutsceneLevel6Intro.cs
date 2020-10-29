using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScriptCutsceneLevel6Intro : MonoBehaviour
{
    public GameObject LvlManager;

    public GameObject BotonSiguiente;
    public EventSystem EventSys;

    public int Numero;

    string[] Dialogo = new string[4];

    public Text Texto;

    public GameObject NombreProta;

    public GameObject NombreViejo;


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

        PlayerPrefs.SetInt("DesbloqueasteNivel_6", 1);
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
            LvlManager.SendMessage("Lvl6");
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

            Dialogo[0] = "¡Maravilloso! ¡Me has traido todas las gelatinas! ¡Ahora me podré bañar muy bien con ellas!";
            Dialogo[1] = "¡El carnicero pasó por esa caverna de ahi! Pero cuidado, escuché ruidos muy raros viniendo de allí";
            Dialogo[2] = "Esta cueva se ve asquerosa y muy oscura, pero... ¿Por qué tiene tan rico olor a facturas?";
            Dialogo[3] = "Oof";

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
            NombreProta.SetActive(true);
            NombreViejo.SetActive(false);


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
