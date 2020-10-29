using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScriptCutsceneLevel4Intro : MonoBehaviour
{
    public GameObject LvlManager;

    public GameObject BotonSiguiente;
    public EventSystem EventSys;

    public int Numero;

    string[] Dialogo = new string[10];

    public Text Texto;

    public GameObject NombreMisterioso;

    public GameObject NombrePepino;


    [Header("Sprites")]

    public GameObject Sprite1;
    public GameObject Sprite2;

    // Start is called before the first frame update
    void Start()
    {
        Numero = 0;

        LvlManager = GameObject.FindGameObjectWithTag("LVLMANAGER");

        PlayerPrefs.SetInt("DesbloqueasteNivel_4", 1);
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

        if (Numero == 2)
        {
            LvlManager.SendMessage("Lvl4");
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
        if (Numero < 2)
        {
            Texto.text = Dialogo[Numero];

            Dialogo[0] = "Al fin llegas, Chef mago. Ahora debes de enfrentarte a mi:";
            Dialogo[1] = "¡El Vijia Pepino!";
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
            NombreMisterioso.SetActive(false);
            NombrePepino.SetActive(true);

            Sprite1.SetActive(false);
            Sprite2.SetActive(true);
        }

    }
}
