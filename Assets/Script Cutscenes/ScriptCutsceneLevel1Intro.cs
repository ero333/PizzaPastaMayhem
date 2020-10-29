using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScriptCutsceneLevel1Intro : MonoBehaviour
{
    public GameObject LvlManager;

    public GameObject BotonSiguiente;
    public EventSystem EventSys;

    public int Numero;

    string[] Dialogo = new string[5];

    public Text Texto;


    [Header("Sprites")]

    public GameObject Sprite1;
    public GameObject Sprite2;
    public GameObject Sprite3;
    public GameObject Sprite4;
    public GameObject Sprite5;

    // Start is called before the first frame update
    void Start()
    {
        Numero = 0;

        LvlManager = GameObject.FindGameObjectWithTag("LVLMANAGER");

        PlayerPrefs.SetInt("DesbloqueasteNivel_1", 1);
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

        if (Numero == 5)
        {
            LvlManager.SendMessage("Lvl1");
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
        if (Numero < 5)
        {
            Texto.text = Dialogo[Numero];

            Dialogo[0] = "Hace muchos años, existían grandes reinos dispersos por el mundo...";
            Dialogo[1] = "...y cada uno de estos reinos tenían  magos especializados en las artes mágicas culinarias: los Chef Mages.";
            Dialogo[2] = "Pero un día, un mago carnicero logro contactar a un poderoso demonio de la comida, el cual le dio un enorme poder al a cambio de que este eliminara a todos los otros Chef Mages.";
            Dialogo[3] = "El Carnicero conjuró un enorme ejercito, convirtiendo la comida de todo el mundo en sus soldados. Con su ejército, conquistó a todos los reinos y eliminó a todos los Chef Mages.";
            Dialogo[4] = "Todos excepto a uno: Giuseppe Napoletani... Quien deberá proteger a su pueblo, detener al carnicero y vengar a los Chef Mages caidos.";
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
    }
}
