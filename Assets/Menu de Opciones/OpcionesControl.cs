using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OpcionesControl : MonoBehaviour
{
    public GameObject Opciones; // traer gameobject del objeto con las opciones (botones y demás)

    public GameObject controles; // traer gameobject del objeto que muestra los controles

    public GameObject LvlManager;

    // Start is called before the first frame update
    void Start()
    {
        LvlManager = GameObject.FindGameObjectWithTag("LVLMANAGER");
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown("p"))
        {
            OPENCLOSEMENU();

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
    public void LVLControl()
    {
        LvlManager.SendMessage("Menu");
    }
    #endregion
}
