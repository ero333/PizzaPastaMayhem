using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerPlatWin : MonoBehaviour
{

    public GameObject PanRunnerlvl; // traer gameobject que contiene todo el objeto

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
        if ((collision.tag == "Player")|| (collision.tag == "PlayerAll")) // si colisiona con un objeto con el tag mensionado
        {

            PanRunnerlvl.SendMessage("LevelCompletado");

        }
    }
}
