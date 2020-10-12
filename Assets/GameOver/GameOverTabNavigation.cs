using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameOverTabNavigation : MonoBehaviour
{



    public GameObject Reintentar;           // traer gameobject del -> BOTON <-

    public GameObject VolverMenu;           // traer gameobject del -> BOTON <-

    public EventSystem EventSys;            // variable del EventSystem. BUSQUEDA POR TAG


    public bool ReintentarSeleccionado;

    public bool VolverMenuSeleccionado;


    public bool BotonSeleccionado;



    // Start is called before the first frame update
    void Start()
    {
        EventSys = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<EventSystem>();     // busca objetos por tags

        ReintentarSeleccionado = Reintentar.GetComponent<Button>();
        VolverMenuSeleccionado = VolverMenu.GetComponent<Button>();

        BotonSeleccionado = true;
    }

    // Update is called once per frame
    void Update()
    {
        //SiempreSelecccionando();
        //TabNavi();

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(BotonSeleccionado)
            {
                BotonSeleccionado = false;
                Debug.Log("Reintentar");
            }

            else
            {
                BotonSeleccionado = true;
                Debug.Log("Volver al menu");
            }
        }


        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            BotonSeleccionado = false;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            BotonSeleccionado = true;
        }



        if (BotonSeleccionado)
        {
            EventSys.SetSelectedGameObject(Reintentar);
        }


        else
        {
            EventSys.SetSelectedGameObject(VolverMenu);
        }

        CualSeleccionado();


    }


    public void SiempreSelecccionando()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
        {
            EventSys.SetSelectedGameObject(Reintentar);
        }
    }

    public void CualSeleccionado()
    {
        if(EventSys.currentSelectedGameObject == VolverMenu)
        {
            BotonSeleccionado = false;
        }

        else
        {
            BotonSeleccionado = true;
        }

    }
}
