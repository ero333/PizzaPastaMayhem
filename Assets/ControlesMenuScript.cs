using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ControlesMenuScript : MonoBehaviour
{
    public GameObject controles; // traer gameobject del objeto que muestra los controles

    public GameObject BotonEmpezar;          // traer gameobject del -> BOTON <-

    public EventSystem EventSys;                // variable del EventSystem.

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (EventSys.currentSelectedGameObject == null)
        {
            EventSys.SetSelectedGameObject(BotonEmpezar);

            if (controles.activeInHierarchy == true)
            {
                OPENCLOSECONTROLES();
            }
        }
    }
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


}
