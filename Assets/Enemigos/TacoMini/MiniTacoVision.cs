using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniTacoVision : MonoBehaviour
{
    [Header("Body y All")]
    public GameObject ObjectAll;                        // traer GameObject que contiene al body
    public GameObject ObjectBody;                       // traer GameObject donde está el sprite


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
            ObjectBody.SendMessage("AnimacionMelee"); //manda mensaje al script del enemigo


        }
    }
}
