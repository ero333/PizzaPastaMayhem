using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlesMenu : MonoBehaviour
{

    public GameObject controles; // traer gameobject del objeto que muestra los controles

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
