using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMov : MonoBehaviour
{
    public Transform Player; // traer posicion del gameobject

    public bool MovimientoHorizontal = true;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("PlayerAll").transform;

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 temp = transform.position;

        if (MovimientoHorizontal)
        {
            temp.x = Player.transform.position.x;
        }
        if (!MovimientoHorizontal)
        {
            temp.y = Player.transform.position.y;
        }

        transform.position = temp;
    }
}
