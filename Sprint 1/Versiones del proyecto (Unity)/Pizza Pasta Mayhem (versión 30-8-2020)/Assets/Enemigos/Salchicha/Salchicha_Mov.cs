using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salchicha_Mov : MonoBehaviour
{
    public Transform APoint; // Traer gameobject del punto A

    public Transform BPoint; // Traer gameobject del punto B

    public bool izquierda = true; // Dirección inicial donde está viendo el enemigo

    public float speed = 4f; // Velocidad a la que se moverá el enemigo



    public GameObject SalchichaSprite; //traer GameObject donde está el sprite de la salchicha
    private Animator SalchichaAnim;









    // Start is called before the first frame update
    void Start()
    {
        if (izquierda) // Si el personaje está mirando hacia la izquierda, comienza desde el punto A
        {
            transform.position = APoint.position;
        }

        else // Si el personaje está mirando hacia la derecha, comienza desde el punto B
        {
            transform.position = BPoint.position;
        }

    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }


    void Movimiento() // Movimiento del personaje
    {
        if (izquierda)
        {
            transform.position = Vector3.MoveTowards(transform.position, BPoint.position, speed * Time.deltaTime); // Si está mirando hacia la izquierda, se mueve desde su posición actual hacia el punto B, eso por la cantidad de velocidad 

            if (transform.position == BPoint.position) // Si su posición actual es el punto B, izquierda deja de ser verdadero y flipea el sprite
            {
                izquierda = false;
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }

        else
        {
            transform.position = Vector3.MoveTowards(transform.position, APoint.position, speed * Time.deltaTime); // Si está mirando hacia la derecha, se mueve desde su posición actual hacia el punto A, eso por la cantidad de velocidad 

            if (transform.position == APoint.position) // Si su posición actual es el punto A, izquierda es verdadero y flipea el sprite
            {
                izquierda = true;
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }





}
