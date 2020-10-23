using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomateVision : MonoBehaviour
{
    public GameObject TomateBody;   // traer objeto con script

    public GameObject TomateAll;    // traer objeto que contiene a toda la torreta

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
            TomateBody.SendMessage("EstadoAtacando"); //manda mensaje al script del enemigo

            // print("en rango");

        }
    }


}
