﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Tomate_Mov : MonoBehaviour
{
    public enum GameState { Patrullando, Muerto, Atacando, quieto }

    public GameState estado = GameState.Patrullando;



    public Transform APoint; // Traer gameobject del punto A

    public Transform BPoint; // Traer gameobject del punto B

    public bool izquierda = true; // Dirección inicial donde va a empezar el enemigo

    public float speed = 4f; // Velocidad a la que se moverá el enemigo

    public float AttackSpeed = 8f; // velocidad de movimiento de cuando ataca

    public float TimeDeath = 2.5f; // tiempo de muerte para eliminar el gameobject del enemigo

    public bool PlayerInRange;

    public bool IsDeath;

    public Transform PlayerPosition; // objeto para detectar la posicion del jugador




    public GameObject TomateAll; // traer GameObject que contiene el body de la salchicha
    public GameObject TomateBody; //traer GameObject donde está el sprite de la salchicha
    private Animator TomateAnim;










    public GameObject ItemDrop; // traer objeto que dropea la salchicha

    public Transform DropPosition; // traer gameobject donde va a dropearse el objeto





    #region Start

    // Start is called before the first frame update
    void Start()
    {

        IsDeath = false;

        estado = GameState.Patrullando; // Enemigo comienza estando vivo, puede moverse

        PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform; // busca la posicion del jugador por su tag


        if (izquierda) // Si el personaje está mirando hacia la izquierda, comienza desde el punto A
        {
            transform.position = APoint.position;
        }

        else // Si el personaje está mirando hacia la derecha, comienza desde el punto B
        {
            transform.position = BPoint.position;
        }



        PlayerInRange = false;


        TomateAnim = TomateBody.GetComponent<Animator>();

        TomateAnim.SetBool("TomateMuere", false); // Seteamos que el bool, que triggea la animación de muerte, empiece en false
    }

    #endregion

    #region Update

    // Update is called once per frame
    void Update()
    {
        if(estado != GameState.Muerto)
        {

            if(estado==GameState.Patrullando) // Si su estado es "Patrulla", camina del punto A al punto B
            {
                Patrulla();

                AnimacionMovimiento();
            }

            if (estado == GameState.Atacando) // Si su estado es "Patrulla", camina del punto A al punto B
            {
                Ataque();

                AnimacionAtaque();
            }

        }


        if (IsDeath == true)
        {

            estado = GameState.Muerto;

        }


        if (estado == GameState.Muerto)
        {

                APoint.position = transform.position;
                BPoint.position = transform.position;

        }



    }

    #endregion

    #region patrulla
    public void Patrulla()
    {
        if (izquierda)
        {
            transform.position = Vector3.MoveTowards(transform.position, BPoint.position, speed * Time.deltaTime); // Si está mirando hacia la izquierda, se mueve desde su posición actual hacia el punto B, eso por la cantidad de velocidad 

            if (transform.position == BPoint.position) // Si su posición actual es el punto B, izquierda deja de ser verdadero y flipea el sprite
            {
                izquierda = false;
                //GetComponent<SpriteRenderer>().flipX = true; //--------------> esto flipea el sprite. NO RECOMENDABLE si el enemigo tiene hitbox que encesita moverse

                transform.rotation = Quaternion.Euler(0, 180, 0); // gira el enemigo a 180 grados
            }
        }

        else
        {
            transform.position = Vector3.MoveTowards(transform.position, APoint.position, speed * Time.deltaTime); // Si está mirando hacia la derecha, se mueve desde su posición actual hacia el punto A, eso por la cantidad de velocidad 

            if (transform.position == APoint.position) // Si su posición actual es el punto A, izquierda es verdadero y flipea el sprite
            {
                izquierda = true;
                //GetComponent<SpriteRenderer>().flipX = false; //--------------> esto flipea el sprite. NO RECOMENDABLE si el enemigo tiene hitbox que encesita moverse

                transform.rotation = Quaternion.Euler(0, 0, 0); // gira el enemigo a 0 grados
            }
        }
    }

    #endregion

    #region ataque
    public void Ataque()
    {
            if (izquierda)
            {
                transform.position = Vector3.MoveTowards(transform.position, BPoint.position, AttackSpeed * Time.deltaTime); // Si está mirando hacia la izquierda, se mueve desde su posición actual hacia el punto B, eso por la cantidad de velocidad 

                if (transform.position == BPoint.position) // Si su posición actual es el punto B, izquierda deja de ser verdadero y flipea el sprite
                {
                    izquierda = false;
                    //GetComponent<SpriteRenderer>().flipX = true; //--------------> esto flipea el sprite. NO RECOMENDABLE si el enemigo tiene hitbox que encesita moverse

                    transform.rotation = Quaternion.Euler(0, 180, 0); // gira el enemigo a 180 grados
                }

            }

            else
            {
                transform.position = Vector3.MoveTowards(transform.position, APoint.position, AttackSpeed * Time.deltaTime); // Si está mirando hacia la derecha, se mueve desde su posición actual hacia el punto A, eso por la cantidad de velocidad 

                if (transform.position == APoint.position) // Si su posición actual es el punto A, izquierda es verdadero y flipea el sprite
                {
                    izquierda = true;
                    //GetComponent<SpriteRenderer>().flipX = false; //--------------> esto flipea el sprite. NO RECOMENDABLE si el enemigo tiene hitbox que encesita moverse

                    transform.rotation = Quaternion.Euler(0, 0, 0); // gira el enemigo a 0 grados
                }


            }
    }

    #endregion

    #region RecibiendoGolpe

    public void Golpeado()
    {
        if(estado != GameState.Atacando)
        {

            EstadoQuieto();

            AnimacionGolpe();

        }

    }

    #endregion

    #region muerte

    public void TomateDeath() // Método para que muera
    {
        if (estado == GameState.Atacando)
        {

            EstadoMuerte(); // Cambia el estado a muerto

            AnimacionMuerte();

            TomateAnim.SetBool("TomateMuere", true);

        }

        if (estado != GameState.Atacando)
        {
            EstadoMuerte(); // Cambia el estado a muerto

            AnimacionMuerte();

            TomateAnim.SetBool("TomateMuere", true);
        }

        IsDeath = true;

        EstadoMuerte(); // Cambia el estado a muerto

        Destroy(TomateAll, TimeDeath); // Destruye el objeto mencionado en X tiempo





    }

    #endregion

    #region estados

    public void EstadoMuerte()
    {
        estado = GameState.Muerto;
    }

    public void EstadoPatrullando()
    {
        estado = GameState.Patrullando;
    }

    public void EstadoAtacando()
    {
        estado = GameState.Atacando;
    }

    public void EstadoQuieto()
    {
        estado = GameState.quieto;
    }

    #endregion

    #region Animaciones

    public void AnimacionIdle()
    {
        TomateAnim.Play("Tomate_Idle");
    }

    public void AnimacionAtaque()
    {
        TomateAnim.Play("Tomate_Atacando");
    }

    public void AnimacionMuerte()
    {
        TomateAnim.Play("Tomate_Muerte");
    }

    public void AnimacionGolpe()
    {
        TomateAnim.Play("Tomate_Golpe");
    }

    public void AnimacionMovimiento()
    {
        TomateAnim.Play("Tomate_Movimiento");
    }


    #endregion

    #region drops

    public void DropearItem() //metodo para que dropee items
    {
        Instantiate(ItemDrop, DropPosition.position, Quaternion.identity);    //Crea objeto. Orden de parentesis: qué objeto, dónde (o sobre qué objeto) y la rotación
    }

    #endregion

}