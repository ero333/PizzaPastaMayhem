﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class JugadorControl : MonoBehaviour
{

    public enum GameState { vivo, muerto, revive, pausa } // estados que puede tener el jugador

    public GameState estado = GameState.vivo; // el jugador empieza vivo

    private Rigidbody2D RBPlayer;

    public GameObject Body; // traer gameobject del jugador con los sprites (body)

    private Animator anim;

    public Transform Checkpoint; // traer game object donde se teletransportará el jugador al morir

    public GameObject LevelManager; // traer game object que permite cambiar de escenas



    #region Variables Movimiento

    public float speed = 4f; // Velocidad de movimiento

    public float speedjump = 5f; // Fuerza de salto

    private bool grounded = true; // checkea si está en el suelo o no

    #endregion

    #region ataques

    private bool Disparando = false; // checkea si está disparando o no



    public GameObject bala; // traer prefab de la bala


    public GameObject MeleeHit; // traer prefab del golpe cuerpo a cuerpo


    public Transform balaGenR; // traer generador de balas. Lado Derecho.

    public Transform balaGenL; // traer generador de balas. Lado Izquierdo.


    public Transform MeleeR; // traer generador Daño Melee. Lado Derecho

    public Transform MeleeL; // traer generador Daño Melee. Lado Izquierdo

    #endregion

    #region Variables Vida


    public float vidaMaxima = 10f;

    private float vidaActual;

    public GameObject barraHP; // traer gameobject de la barra de vida






    public GameObject LifeContainer1; // traer gameobject del contenedor 1

    public GameObject LifeContainer2; // traer gameobject del contenedor 2

    public int vida = 2; // cantidad de vidas del jugador




    public GameObject MarcoHP;



    public float Curarse = 2.5f; // cantidad de vida que me curo


    #endregion

    #region Variables Recetas y Power Ups

    public bool Receta1 = false;

    public bool Receta2 = false;

    public bool Receta3 = false;


    public bool Power1Activo = false;

    public float PowerSpeed = 8f;

    public float PowerSpeedJump = 10f;

    public float PowerT = 5f;

    private float PowerTimeStart;

    public GameObject PowerShield; // traer game object del escudo

    public bool Power2Activo = false;

    public float ShieldTime = 5f;

    private float ShieldTimeStart;

    #endregion




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


    #region update


    void Update()
    {
        if (estado == GameState.vivo)
        {
            Movimiento();
            Salto();
            Disparo();
            Melee();
            Limbo();
            Power1();
            Power1Time();
            Power2();
            Power3();



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

            }

        }


        if (estado == GameState.muerto)
        {
            RBPlayer.velocity = new Vector2(0, RBPlayer.velocity.y); // personaje se queda quieto al morir
        }

    }


    #endregion

    #region Movimiento

    void Movimiento() // movimiento del jugador
    {
        if (Disparando == false)
        {
            if (Power1Activo == false) // detecta si el power up 1 está desactivado
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


            if (Power1Activo == true) // detecta si el power up 1 está activado
            {
                if (Input.GetAxis("Horizontal") > 0) // al presionar la tecla mencionada. VERSION ALTERNATIVA - (Input.GetKey(KeyCode.RightArrow))
                {
                    RBPlayer.velocity = new Vector2(PowerSpeed, RBPlayer.velocity.y); // el jugador se mueve hacia la derecha

                    Body.GetComponent<SpriteRenderer>().flipX = false; // flipear o no el sprite


                    anim.SetBool("PJMOV", true); // animacion del personaje




                }

                if (Input.GetAxis("Horizontal") < 0) // al presionar la tecla mencionada. VERSION ALTERNATIVA - (Input.GetKey(KeyCode.LeftArrow))
                {
                    RBPlayer.velocity = new Vector2(-PowerSpeed, RBPlayer.velocity.y); // el jugador se mueve hacia la izquierda

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

    }
    #endregion

    #region Salto


    void Salto()
    {

        if (Power1Activo == false) // detecta si el power up 1 está desactivado
        {
            if ((Input.GetKeyDown(KeyCode.UpArrow) && grounded))
            {
                RBPlayer.velocity = new Vector2(RBPlayer.velocity.x, speedjump);

                anim.Play("PJJUMP");
            }
        }

        if (Power1Activo == true) // detecta si el power up 1 está activado
        {
            if ((Input.GetKeyDown(KeyCode.UpArrow) && grounded))
            {
                RBPlayer.velocity = new Vector2(RBPlayer.velocity.x, PowerSpeedJump);

                anim.Play("PJJUMP");
            }
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
        if ((estado == GameState.vivo) && (Power2Activo == false))
        {
            if (collision.tag == "Salchicha") // si colisiona con un objeto con el tag mensionado
            {

                vidaActual--;

                float LargoBarraHP = vidaActual / vidaMaxima; // calcula el largo de la barra de vida del jugador

                PerderHP(LargoBarraHP);

                anim.Play("PJ_Herido"); // triggea la animación de que es herido

                MarcoHP.SendMessage("HPHit");

            }

            if (collision.tag == "BalaMorron") // si colisiona con un objeto con el tag mensionado
            {

                vidaActual--;

                float LargoBarraHP = vidaActual / vidaMaxima; // calcula el largo de la barra de vida del jugador

                PerderHP(LargoBarraHP);

                anim.Play("PJ_Herido"); // triggea la animación de que es herido

                MarcoHP.SendMessage("HPHit");

            }

            if (collision.tag == "BalaAlbondiga") // si colisiona con un objeto con el tag mensionado
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

    #region Recetas






    public void TengoReceta1()
    {
        Receta1 = true;
    }

    public void TengoReceta2()
    {
        Receta2 = true;
    }

    public void TengoReceta3()
    {
        Receta3 = true;
    }






    #endregion

    #region Power-Ups

    public void Power1()
    {
        if ((Receta1 == true) && Input.GetKeyDown(KeyCode.Alpha1))
        {
            print("Power1 activado");

            SendMessage("Receta1Usada");

            Receta1 = false;

            Power1Activo = true;
        }
    }

    public void Power2()
    {
        if ((Receta2 == true) && Input.GetKeyDown(KeyCode.Alpha2))
        {
            print("Power2 activado");

            SendMessage("Receta2Usada");

            Receta2 = false;

            Power2Activo = true;

            if (Power2Activo == true)
            {
                PowerShield.SetActive(true);
            }
        }
    }

    public void Power3()
    {
        if ((Receta3 == true) && Input.GetKeyDown(KeyCode.Alpha3))
        {
            print("Power3 activado");

            SendMessage("Receta3Usada");

            Receta3 = false;




            // El siguiente código hace que te recuperes la vida

            vidaActual = vidaMaxima; // Su vida actual es la misma que la vida que tiene al máximo

            float LargoBarraHP = vidaActual / vidaMaxima; // cálculo necesario

            RecuperarFullHP(LargoBarraHP); // hace que se recupere la barra de vida visualmente

        }
    }

    public void Power1Time()
    {
        if (Power1Activo == true)
        {

            if (PowerTimeStart > 0)
            {
                PowerTimeStart -= Time.deltaTime;
            }
            else if (PowerTimeStart <= 0)
            {
                Power1Activo = false;
            }
        }

        if (Power1Activo == false) // Reinicia Timer
        {
            PowerTimeStart = PowerT;
        }

        if (Power2Activo == true)
        {

            if (ShieldTimeStart > 0)
            {
                ShieldTimeStart -= Time.deltaTime;
            }
            else if (ShieldTimeStart <= 0)
            {
                Power2Activo = false;
            }
        }

        if (Power2Activo == false) // Reinicia Timer
        {
            ShieldTimeStart = ShieldTime;

            PowerShield.SetActive(false);
        }





    }


    #endregion

    #region Revivir
    public void Limbo()
    {
        if ((estado == GameState.muerto) && (vida == 0)) // Si el jugador muere pero se queda sin vidas, aparece pantalla de Game Over
        {
            LevelManager.SendMessage("GameOverScreen");
        }

        if ((estado == GameState.muerto) && (vida >= 1)) // Si el jugador muere pero todavia le quedan vidas, aparece en el checkpoint
        {
            transform.position = Checkpoint.position; // jugador se teletransporta al checkpoint

            estado = GameState.revive; // el jugador vuelve a estar vivo

            anim.Play("PJ_Revive"); // Triggea animacion Idle





            if (vidaActual < vidaMaxima) // Detecta que la barra de vida del jugador sea menor a su total
            {
                vidaActual += vidaMaxima; // Su vida actual es la misma que la vida que tiene al máximo

                float LargoBarraHP = vidaActual / vidaMaxima; // cálculo necesario

                RecuperarFullHP(LargoBarraHP); // hace que se recupere la barra de vida visualmente
            }

        }
    }

    #endregion

    #region Estados especificos
    public void ItsAlive()
    {
        estado = GameState.vivo;
    }
    public void Fiambre()
    {
        estado = GameState.muerto;
    }
    public void Revivision()
    {
        estado = GameState.revive;
    }
    public void ItsTimeToStop()
    {
        estado = GameState.pausa;

        RBPlayer.velocity = new Vector2(0, RBPlayer.velocity.y);

        AnimacionIdle();

        anim.SetBool("PJMOV", false);

    }
    #endregion

    #region Animaciones especificas

    public void AnimacionIdle()
    {
        anim.Play("PJ_Idle");
    }
    public void AnimacionMovimiento()
    {
        anim.Play("PJ_Movimiento");
    }

    public void AnimacionSalto()
    {
        anim.Play("PJ_Salto");
    }
    public void AnimacionDisparo()
    {
        anim.Play("PJ_Dispara");
    }
    public void AnimacionPowerAttack()
    {
        anim.Play("PJ_Power");
    }
    public void AnimacionHerido()
    {
        anim.Play("PJ_Herido");
    }
    public void AnimacionMuerte()
    {
        anim.Play("PJ_Muerte");
    }
    public void AnimacionRevive()
    {
        anim.Play("PJ_Revive");
    }
    #endregion

}




