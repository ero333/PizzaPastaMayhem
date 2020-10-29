using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScriptCutsceneLevel10Intro : MonoBehaviour
{
    public GameObject LvlManager;

    public GameObject BotonSiguiente;
    public EventSystem EventSys;

    public int Numero;

    string[] Dialogo = new string[2];

    public Text Texto;


    [Header("Sprites")]

    public GameObject Sprite1;
    public GameObject Sprite2;

    // Start is called before the first frame update
    void Start()
    {
        Numero = 0;

        LvlManager = GameObject.FindGameObjectWithTag("LVLMANAGER");

        PlayerPrefs.SetInt("DesbloqueasteNivel_10", 1);
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
            LvlManager.SendMessage("Lvl10");
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

            Dialogo[0] = "¡Tonto! ¿Crees que puedes contra mi? Pues déjame decirte, compadre...";
            Dialogo[1] = "¡Qué te debes enfrentar a mi! ¡¡¡El EsparTaco!!!";
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

    }
}
