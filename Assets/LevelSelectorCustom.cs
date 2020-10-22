using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelSelectorCustom : MonoBehaviour
{
    public GameObject BotonVolverMenu;          // traer gameobject del -> BOTON <-

    public EventSystem EventSys;                // variable del EventSystem.

    // Start is called before the first frame update
    void Start()
    {
        //EventSys = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<EventSystem>();     // busca objetos por tags
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSys.currentSelectedGameObject == null)
        {
            EventSys.SetSelectedGameObject(BotonVolverMenu);
        }
    }
}
