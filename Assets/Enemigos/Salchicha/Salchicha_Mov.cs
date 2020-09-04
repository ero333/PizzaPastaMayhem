using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Salchicha_Mov : MonoBehaviour
{
    public enum GameState { Vivo, Muerto}

    public GameState estado = GameState.Vivo;



    public Transform APoint; // Traer gameobject del punto A

    public Transform BPoint; // Traer gameobject del punto B

    public bool izquierda = true; // Dirección inicial donde va a empezar el enemigo

    public float speed = 4f; // Velocidad a la que se moverá el enemigo





    public GameObject SalchichaAll; // traer GameObject que contiene el body de la salchicha
    public GameObject SalchichaBody; //traer GameObject donde está el sprite de la salchicha
    private Animator SalchichaAnim;








    public float TimeDeath = 2.5f; // tiempo de muerte para eliminar el gameobject del enemigo






    // Start is called before the first frame update
    void Start()
    {


        estado = GameState.Vivo; // Enemigo comienza estando vivo, puede moverse


        if (izquierda) // Si el personaje está mirando hacia la izquierda, comienza desde el punto A
        {
            transform.position = APoint.position;
        }

        else // Si el personaje está mirando hacia la derecha, comienza desde el punto B
        {
            transform.position = BPoint.position;
        }







        SalchichaAnim = SalchichaBody.GetComponent<Animator>();

        SalchichaAnim.SetBool("SalchichaMuere", false); // Seteamos que el bool, que triggea la animación de muerte, empiece en false










    }

    // Update is called once per frame
    void Update()
    {
        if(estado == GameState.Vivo)
        {
            Movimiento();
        }

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








    public void SalchichaDeath()
    {

        SalchichaAnim.SetBool("SalchichaMuere", true); // triggea la animación de muerte


        estado = GameState.Muerto; // Cambia el estado a muerto

        Destroy(SalchichaAll, TimeDeath); // Destruye el objeto mencionado en X tiempo



    }



    public void SalchichaGolpeada()
    {
        SalchichaAnim.Play("Salchicha_Golpe");
    }
}
