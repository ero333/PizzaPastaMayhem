using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OpcionesControl : MonoBehaviour
{
    public GameObject Opciones;             // traer gameobject del objeto con las opciones (botones y demás)

    public GameObject BotonOpciones;        // traer gameobject del -> BOTON <- que abre el menu de opciones

    public GameObject BotonFelicidades;     // traer gameobject del -> BOTON <- del cartel de felicitaciones

    public GameObject BotonCerrarCONTROLES; // traer gameobject del -> BOTON <- que cierra la interfaz de los controles

    public GameObject controles;            // traer gameobject del objeto que muestra los controles

    public GameObject LvlManager;

    public GameObject AudioSource;          // objeto de AudioSource

    public GameObject MuteButton1;

    public GameObject MuteButton2;

    public GameObject MuteButton3;

    public GameObject MuteButton4;

    public EventSystem EventSys;            // variable del EventSystem. BUSQUEDA POR TAG


    // Start is called before the first frame update
    void Start()
    {
        LvlManager = GameObject.FindGameObjectWithTag("LVLMANAGER");




        AudioSource = GameObject.FindGameObjectWithTag("AudioSource");                              // busca objetos por tags





        EventSys = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<EventSystem>();     // busca objetos por tags

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("p"))
        {
            OPENCLOSEMENU();

        }

        if (AudioSource.GetComponent<AudioSource>().mute == true)
        {
            MuteButton1.SetActive(false);
            MuteButton2.SetActive(true);
            MuteButton3.SetActive(false);
            MuteButton4.SetActive(true);
        }

        if (AudioSource.GetComponent<AudioSource>().mute == false)
        {
            MuteButton1.SetActive(true);
            MuteButton2.SetActive(false);
            MuteButton3.SetActive(true);
            MuteButton4.SetActive(false);
        }

        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2) || Input.GetKeyDown("p"))
        {
            if (controles.activeInHierarchy == false)
            {
                EventSys.SetSelectedGameObject(BotonOpciones);
            }
            else
            {
                EventSys.SetSelectedGameObject(BotonCerrarCONTROLES);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //Debug.Log("click click click");

            EventSys.SetSelectedGameObject(BotonFelicidades);
        }

    }

    #region Abrir o Cerrar Menu
    public void OPENCLOSEMENU()
    {
        if (Opciones.activeInHierarchy == false)
        {
            Opciones.SetActive(true);
        }
        else
        {
            Opciones.SetActive(false);
            controles.SetActive(false);
        }
    }
    #endregion

    #region Controles
    public void OPENCLOSECONTROLES()
    {
        if (controles.activeInHierarchy == false)
        {
            controles.SetActive(true);
        }
        else
        {
            controles.SetActive(false);
        }
    }


    #endregion

    #region LVL Manager
    public void LVLMENU()
    {
        LvlManager.SendMessage("Menu");
    }

    public void LVLSELECTOR()
    {
        LvlManager.SendMessage("LvlSelector");
    }
    #endregion

}
