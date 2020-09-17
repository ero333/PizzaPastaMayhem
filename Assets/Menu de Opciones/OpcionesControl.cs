using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OpcionesControl : MonoBehaviour
{
    public GameObject Opciones; // traer gameobject del objeto con las opciones (botones y demás)

    public GameObject controles; // traer gameobject del objeto que muestra los controles

    public GameObject LvlManager;

    public GameObject AudioSource; // objeto de AudioSource

    public GameObject MuteButton1;

    public GameObject MuteButton2;

    // Start is called before the first frame update
    void Start()
    {
        LvlManager = GameObject.FindGameObjectWithTag("LVLMANAGER");




        AudioSource = GameObject.FindGameObjectWithTag("AudioSource"); // busca objetos con audio por tags
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
        }

        if (AudioSource.GetComponent<AudioSource>().mute == false)
        {
            MuteButton1.SetActive(true);
            MuteButton2.SetActive(false);
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

    public void AudioManagerDetector()
    {

    }
}
