using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretVarianteVision : MonoBehaviour
{
    public GameObject TurretBody;   // traer objeto con script

    public GameObject TurretAll; // traer objeto que contiene a toda la torreta


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") // si el jugador entra en el campo de vision
        {
            TurretBody.SendMessage("Vision"); //manda mensaje al script del enemigo

            //print("en rango");




            TurretBody.SendMessage("EstaDisparando"); // comienza a hacer animacion de ataque

        }
    }





    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") // si el jugador entra en el campo de vision
        {

            TurretBody.SendMessage("Vision"); // manda mensaje al script del enemigo



            //Debug.Log("fuera de rango");




            TurretBody.SendMessage("NoEstaDisparando"); // vuelve a hacer su animación Idle





        }
    }

}
