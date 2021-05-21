using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class OpcionesControl : MonoBehaviour
{
    [Header("Otros objetos")]

    public GameObject FelicitacionesAll;

    public GameObject LvlManager;

    public GameObject AudioSource;          // objeto de AudioSource

    public EventSystem EventSys;            // variable del EventSystem. BUSQUEDA POR TAG

    [Header("Menu de Opciones")]

    public GameObject Opciones;             // traer gameobject del objeto con las opciones (botones y demás)

    public GameObject controles;            // traer gameobject del objeto que muestra los controles


    [Header("Botones")]

    public GameObject BotonOpciones;        // traer gameobject del -> BOTON <- que abre el menu de opciones

    public GameObject BotonFelicidades;     // traer gameobject del -> BOTON <- del cartel de felicitaciones

    public GameObject MuteButton1;

    public GameObject MuteButton2;

    public GameObject MuteButton3;

    public GameObject MuteButton4;

    public GameObject BotonCerrarCONTROLES; // traer gameobject del -> BOTON <- que cierra la interfaz de los controles

    Scene NivelActual;


    // Start is called before the first frame update
    void Start()
    {

        NivelActual = SceneManager.GetActiveScene();


        LvlManager = GameObject.FindGameObjectWithTag("LVLMANAGER");




        AudioSource = GameObject.FindGameObjectWithTag("AudioSource");                              // busca objetos por tags





        EventSys = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<EventSystem>();     // busca objetos por tags


    }

    // Update is called once per frame
    void Update()
    {
        FelicitacionesAll = GameObject.FindGameObjectWithTag("UIFelicitaciones");

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

            if (FelicitacionesAll.activeInHierarchy == true)
            {
                CualSeleccionado();
            }
            //Debug.Log("click click click");
        }

        if (EventSys.currentSelectedGameObject == null)
        {
            EventSys.SetSelectedGameObject(BotonOpciones);
        }


    }

    #region Abrir o Cerrar Menu
    public void OPENCLOSEMENU()
    {
        if (Opciones.activeInHierarchy == false)
        {
            Opciones.SetActive(true);

            Time.timeScale = 0f;
        }
        else
        {
            Opciones.SetActive(false);
            controles.SetActive(false);

            Time.timeScale = 1f;
        }
    }
    #endregion

    #region Controles
    public void OPENCLOSECONTROLES()
    {
        if (controles.activeInHierarchy == false)
        {
            controles.SetActive(true);

            print("Evento ver_controles: Nivel " + NivelActual.buildIndex);




            Analytics.CustomEvent("ver_controles", new Dictionary<string, object>
            {
                {"level_index", NivelActual.buildIndex },


            });

            
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


    public void ReinicarLvLActual()
    {


        print("Evento reiniciar_nivel: Nivel " + NivelActual.buildIndex);



        Analytics.CustomEvent("reiniciar_nivel", new Dictionary<string, object>
            {
                {"level_index", NivelActual.buildIndex },


            });
        

        LvlManager.SendMessage("ReiniciarNivelActual");
    }


    #endregion


    public void CualSeleccionado()
    {
        if (EventSys.currentSelectedGameObject == BotonFelicidades)
        {
            EventSys.SetSelectedGameObject(null);
        }

        if (EventSys.currentSelectedGameObject == BotonOpciones)
        {
            EventSys.SetSelectedGameObject(BotonFelicidades);
        }

    }



}
