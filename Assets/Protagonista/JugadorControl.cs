﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class JugadorControl : MonoBehaviour
{

    public enum GameState { vivo, muerto} // estados que puede tener el jugador

    public GameState estado = GameState.vivo; // el jugador empieza vivo

    private Rigidbody2D RBPlayer;

    public GameObject Body; // traer gameobject del jugador con los sprites (body)

    public float speed = 4f; // Velocidad de movimiento

    public float speedjump = 5f; // Fuerza de salto

    public GameObject bala; // traer prefab de la bala


    public GameObject MeleeHit; // traer prefab del golpe cuerpo a cuerpo




    public Transform balaGenR; // traer generador de balas. Lado Derecho.

    public Transform balaGenL; // traer generador de balas. Lado Izquierdo.

    private Animator anim;

    private bool Disparando = false; // checkea si está disparando o no


    private bool grounded = true; // checkea si está en el suelo o no





    public Transform MeleeR; // traer generador Daño Melee. Lado Derecho

    public Transform MeleeL; // traer generador Daño Melee. Lado Izquierdo




    #region VariablesVida


    public float vidaMaxima = 10;

    private float vidaActual;

    public GameObject barraHP; // traer gameobject de la barra de vida






    public GameObject LifeContainer1; // traer gameobject del contenedor 1

    public GameObject LifeContainer2; // traer gameobject del contenedor 2

    public int vida = 2; // cantidad de vidas del jugador

    public GameObject Reintentomsg;

    public GameObject GameOvermsg;



    public GameObject MarcoHP;


    #endregion


    public Transform Checkpoint; // traer game object donde se teletransportará el jugador al morir

    public GameObject LevelManager; // traer game object que permite cambiar de escenas









    // Start is called before the first frame update
    void Start()
    {
        vidaActual = vidaMaxima;



        RBPlayer = GetComponent<Rigidbody2D>();




        anim = Body.GetComponent<Animator>();


        anim.SetBool("PJMOV", false);
        anim.SetBool("PJJUMP", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (estado == GameState.vivo)
        {

            Movimiento();
            Salto();
            Disparo();
            Melee();



            if (vidaActual <= 0) // si la barra de vida es menor o igual a 0
            {
                estado = GameState.muerto; // cambia a estado "muerto"

                anim.Play("PJ_Muerte"); // trigea animacion

                vida--; // resta la cantidad de vidas que tiene el jugador

                ContenedoresVida(); // los contenedores de vida se actualizan

            }

            if (vida == 0) // muerte definitiva cuando el jugador se queda sin vidas
            {
                estado = GameState.muerto; // estado cambia a "muerto"

                anim.Play("PJ_Muerte"); // triggea animacion

                GameOvermsg.SetActive(true); // actviva mensaje de que te quedaste sin vidas

            }

        }


        if( (estado== GameState.muerto) && (vida >= 1)) // Si el jugador muere pero todavia le quedan vidas
        {
            Reintentomsg.SetActive(true); // activa mensaje para reiniciar

            if (Input.GetKeyDown("r")) // al presioanr la "R"
            {

                transform.position = Checkpoint.position; // jugador se teletransporta al checkpoint

                Reintentomsg.SetActive(false); // desactiva mensaje de muerte y reinicio

                estado = GameState.vivo; // el jugador vuelve a estar vivo

                anim.Play("PJ_Idle"); // Triggea animacion Idle





                if (vidaActual < vidaMaxima) // Detecta que la barra de vida del jugador sea menor a su total
                {
                    vidaActual += vidaMaxima; // Su vida actual es la misma que la vida que tiene al máximo

                    float LargoBarraHP = vidaActual / vidaMaxima; // calculo necesario

                    RecuperarFullHP(LargoBarraHP); // hace que se recupere la barra de vida visualmente
                }

            }


        }

        if ((estado == GameState.muerto) && (vida == 0) && (Input.GetKeyDown("r")))
        {
            LevelManager.SendMessage("GameOverScreen");
        }

    }





    #region Movimiento

    void Movimiento() // movimiento del jugador
    {
        if (Disparando == false)
        {
            if (Input.GetAxis("Horizontal") > 0) // al presionar la tecla mencionada. VERSION ALTERNATIVA - (Input.GetKey(KeyCode.RightArrow))
            {
                RBPlayer.velocity = new Vector2(speed, RBPlayer.velocity.y); // el jugador se mueve hacia la derecha

                Body.GetComponent<SpriteRenderer>().flipX = false; // flipear o no el sprite


                anim.SetBool("PJMOV", true); // animacion del personaje




            }

            if (Input.GetAxis("Horizontal") < 0) // al presionar la tecla mencionada. VERSION ALTERNATIVA - (Input.GetKey(KeyCode.LeftArrow))
            {
                RBPlayer.velocity = new Vector2(-speed, RBPlayer.velocity.y); // el jugador se mueve hacia la izquierda

                Body.GetComponent<SpriteRenderer>().flipX = true; // flipear o no el sprite

                anim.SetBool("PJMOV", true); // animacion del personaje



            }

            if (Input.GetAxis("Horizontal") == 0) // Si no funciona bien, probar ((Input.GetAxis("Horizontal") == 0) && (((Input.GetAxis("Horizontal") < 0) == false) || ((Input.GetAxis("Horizontal") > 0) == false)))
            {
                RBPlayer.velocity = new Vector2(0, RBPlayer.velocity.y);

                anim.SetBool("PJMOV", false); // detiene animacion del personaje
            }
        }

    }
    #endregion


    #region Salto


    void Salto()
    {
        if((Input.GetKeyDown(KeyCode.UpArrow) && grounded))
        {
            RBPlayer.velocity = new Vector2(RBPlayer.velocity.x, speedjump);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)  //si colisiona con plataforma
    {
        if ((collision.gameObject.tag == "Piso"))
        {


            Debug.Log("piso");


            grounded = true;
            anim.SetBool("PJJUMP", false);
        }



    }


    private void OnCollisionExit2D(Collision2D collision)   //si deja de colisionar con plataforma con plataforma
    {
        if (collision.gameObject.tag == "Piso")
        {
            grounded = false;
            anim.SetBool("PJJUMP", true);
        }
    }




    #endregion


    #region Disparo
    void Disparo()
    {


        if (Input.GetKeyDown("d"))
        {
            if (Body.GetComponent<SpriteRenderer>().flipX == false)
            {
                Instantiate(bala, balaGenR.position, Quaternion.identity);    //Crea objeto. Orden de parentesis: qué objeto, dónde (o sobre qué objeto) y la rotación

                anim.Play("PJ_Dispara");

                Disparando = true;

            }

            if (Body.GetComponent<SpriteRenderer>().flipX == true)
            {
                Instantiate(bala, balaGenL.position, Quaternion.identity);    //Crea objeto. Orden de parentesis: qué objeto, dónde (o sobre qué objeto) y la rotación

                anim.Play("PJ_Dispara");

                Disparando = true;

            }

        }

        if (Input.GetKey("d") == false)
        {
            Disparando = false;
        }

    }


    #endregion

    #region Melee
    void Melee()
    {


        if (Input.GetKeyDown("s"))
        {
            if (Body.GetComponent<SpriteRenderer>().flipX == false)
            {
                Instantiate(MeleeHit, MeleeR.position, Quaternion.identity);    //Crea objeto. Orden de parentesis: qué objeto, dónde (o sobre qué objeto) y la rotación

                anim.Play("PJ_Melee");

            }

            if (Body.GetComponent<SpriteRenderer>().flipX == true)
            {
                Instantiate(MeleeHit, MeleeL.position, Quaternion.identity);    //Crea objeto. Orden de parentesis: qué objeto, dónde (o sobre qué objeto) y la rotación

                anim.Play("PJ_Melee");



            }




        }



    }


    #endregion

    #region vida


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (estado == GameState.vivo)
        {
            if (collision.tag == "Salchicha") // si colisiona con un objeto con el tag mensionado
            {

                vidaActual--;

                float LargoBarraHP = vidaActual / vidaMaxima; // calcula el largo de la barra de vida del jugador

                PerderHP(LargoBarraHP);

                anim.Play("PJ_Herido"); // triggea la animación de que es herido

                MarcoHP.SendMessage("HPHit");

            }

            else if (collision.tag == "Caida") // si colisiona con un objeto con el tag mensionado
            {
                vidaActual = 0;



                float LargoBarraHP = vidaActual / vidaMaxima; // calcula el largo de la barra de vida del jugador

                PerderHP(LargoBarraHP);


                MarcoHP.SendMessage("HPHit");


            }
        }
    }


    public void PerderHP(float LargoBarraHP) // metodo para hacer que la barra de vida "baje" (visualmente hablando) de cierta manera. EJ: De derecha a izquierda, izquierda es 0 y derecha es su vida
    {
        barraHP.transform.localScale = new Vector3(LargoBarraHP, barraHP.transform.localScale.y, barraHP.transform.localScale.z); // Para que al barra de vida vaya bajando
    }

    public void RecuperarFullHP(float LargoBarraHP)
    {
        barraHP.transform.localScale = new Vector3(LargoBarraHP, barraHP.transform.localScale.y, barraHP.transform.localScale.z);
    }




    public void ContenedoresVida()
    {
        if (vida == 1)
        {
            LifeContainer2.SetActive(false);
        }

        if (vida == 0)
        {
            LifeContainer1.SetActive(false);
        }
    }

    #endregion







}




