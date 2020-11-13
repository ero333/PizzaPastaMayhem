using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScriptCutsceneOutro : MonoBehaviour
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

        //PlayerPrefs.SetInt("DesbloqueasteNivel_13", 1);
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
            LvlManager.SendMessage("Creditos");
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

            Dialogo[0] = "Giuseppe corrió y corrió, Escapando de explosión mágica que consumió al carnicero.";
            Dialogo[1] = "Giuseppe cumplió su mision, vengó a sus colegas chef mages y evitó la destrución de su pueblo, y posiblemente el mundo. Su mente solo se sentraba en volver a su pueblo y comenzar a enseñar magia culinaria a sus habitantes, ya que ahore es el último Chef Mage.";
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
