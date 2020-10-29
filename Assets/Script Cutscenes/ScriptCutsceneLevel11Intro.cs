using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScriptCutsceneLevel11Intro : MonoBehaviour
{
    public GameObject LvlManager;

    public GameObject BotonSiguiente;
    public EventSystem EventSys;

    public int Numero;

    string[] Dialogo = new string[1];

    public Text Texto;


    [Header("Sprites")]

    public GameObject Sprite1;

    // Start is called before the first frame update
    void Start()
    {
        Numero = 0;

        LvlManager = GameObject.FindGameObjectWithTag("LVLMANAGER");

        PlayerPrefs.SetInt("DesbloqueasteNivel_11", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Numero == 1)
        {
            LvlManager.SendMessage("Lvl11");
        }

        CadaDialogo();
    }

    public void Siguiente()
    {
        Numero++;
    }

    public void CadaDialogo()
    {
        if (Numero < 1)
        {
            Texto.text = Dialogo[Numero];

            Dialogo[0] = "¡El carnicero esta aqui! ¡Debo detenerlo a toda costa!";
        }

    }
}
