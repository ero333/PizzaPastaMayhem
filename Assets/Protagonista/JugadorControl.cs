using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;
using Debug = UnityEngine.Debug;
using UnityEngine.UI;

public class JugadorControl : MonoBehaviour
{

    public enum GameState { vivo, muerto, revive, pausa }               // estados que puede tener el jugador

    public GameState estado = GameState.vivo;                           // el jugador empieza vivo

    private Rigidbody2D RBPlayer;

    public GameObject Body;                                             // traer gameobject del jugador con los sprites (body). busqueda por tag activada en el start

    private Animator anim;

    public Transform Checkpoint;                                        // traer game object donde se teletransportará el jugador al morir. busqueda por tag activada en el start








    [Header("Manejo de Niveles")]

    public bool NivelCompletado;

    public Button Felicidades;                                          // Traer botón que te permite pasar de nivel

    public GameObject LevelManager;                                     // traer game object que permite cambiar de escenas. busqueda por tag activada en el start

    public bool LvlRunner = false;


    #region Variables Movimiento
    [Header("Movimiento")]

    public float speed = 4f;                                            // Velocidad de movimiento

    public float speedjump = 5f;                                        // Fuerza de salto

    private bool grounded = true;                                       // checkea si está en el suelo o no

    #endregion

    #region ataques

    [Header("Ataque")]

    public bool Disparando = false;                                     // checkea si está disparando o no



    public GameObject bala;                                             // traer prefab de la bala

    public GameObject MeleeHit;                                         // traer prefab del golpe cuerpo a cuerpo

    public GameObject BalaPower;                                        // traer prefab del ataque especial

    public float BalaPowerCooldownTime = 5f;                            // tiempo que dura el CD del power attack

    private float BalaPowerTimer;

    public bool BalaPowerReady;                                         // bool que te permite activar o no el Power Attack

    public GameObject MedidorBalaPower;


    [Header("Posición de Generacion de ataques")]

    public Transform balaGenR;                                          // traer generador de balas. Lado Derecho.

    public Transform balaGenL;                                          // traer generador de balas. Lado Izquierdo.


    public Transform MeleeR;                                            // traer generador Daño Melee. Lado Derecho

    public Transform MeleeL;                                            // traer generador Daño Melee. Lado Izquierdo

    #endregion

    #region Variables Vida

    [Header("Vida")]

    public float vidaMaxima;                                      // Cantidad de Vida total que va a tener el jugador. Modificable

    public float vidaActual;                                            // Cantidad de vida que tiene el jugador actualmente. No modificable

    public GameObject barraHP;                                          // traer gameobject de la barra de vida

    public GameObject MarcoHP;                                          // traer gameobject de la barra de vida

    public Text VidaContador;                                           // traer gameobject del texto del contador de vidas

    public int vida;                                                    // cantidad de vidas del jugador

    public float Curarse = 2.5f;                                        // cantidad de vida que me curo









    #endregion

    #region Variables Vida que me quitan cada enemigo
    [Header("Daño Recibido")]

    public float SalchichaHit = 1f;

    public float TomateHit = 1f;

    public float JamonHit = 1f;

    public float ShockwaveHit = 1f;

    public float BalaAlbondigaHit = 1f;

    public float BalaMorrónHit = 1f;

    public float PolloHit = 1f;

    public float LechugaHit = 1f;

    #endregion

    #region Variables Municion

    [Header("Municion")]

    public float municionMáxima;

    public float municionActual;

    public GameObject barraAmmo;                                        // traer gameobject de la barra de vida

    public Text municionContador;                                       // traer objeto de texto con contador de municion

    #endregion

    #region Variables Recetas y Power Ups

    [Header("Recetas y Power Ups")]

    public bool Receta1 = false;

    public bool Receta2 = false;

    public bool Receta3 = false;


    public bool Power1Activo = false;

    public float PowerSpeed = 8f;

    public float PowerSpeedJump = 10f;

    public GameObject SpeedTornado;                                     // traer gameobject del tornado



    public float PowerT = 5f;

    private float PowerTimeStart;

    public GameObject PowerShield;                                      // traer game object del escudo

    public bool Power2Activo = false;

    public float ShieldTime = 5f;

    private float ShieldTimeStart;

    #endregion

    #region Start
    // Start is called before the first frame update
    void Start()
    {
        vida = PlayerPrefs.GetInt("vidas");                             // Recupera valores de estas variables 
        vidaMaxima = PlayerPrefs.GetFloat("VidaTotal");                 // Recupera valores de estas variables
        vidaActual = PlayerPrefs.GetFloat("VidaActual");                // Recupera valores de estas variables
        municionMáxima = PlayerPrefs.GetFloat("MunicionMaxima");        // Recupera valores de estas variables
        municionActual = PlayerPrefs.GetFloat("MunicionActual");        // Recupera valores de estas variables








        Body = GameObject.FindGameObjectWithTag("Player");              // busqueda del objeto por Tag

        LevelManager = GameObject.FindGameObjectWithTag("LVLMANAGER");  // busqueda del objeto por Tag


        RBPlayer = GetComponent<Rigidbody2D>();




        anim = Body.GetComponent<Animator>();


        anim.SetBool("PJMOV", false);
        anim.SetBool("PJJUMP", false);





        NivelCompletado = false;



        BalaPowerReady = true;

    }

    // Update is called once per frame
    #endregion

    #region update


    void Update()
    {


        PlayerPrefs.SetInt("vidas", vida);                              // Todo cambio que el jugador reciba con esta variable, va a actualizar el player pref
        PlayerPrefs.SetFloat("VidaTotal", vidaMaxima);
        PlayerPrefs.SetFloat("VidaActual", vidaActual);
        PlayerPrefs.SetFloat("MunicionMaxima", municionMáxima);
        PlayerPrefs.SetFloat("MunicionActual", municionActual);









        VidaContador.text = vida.ToString("0");                         // muestra el numero de la cantidad de vida como texto

        if (estado == GameState.vivo)
        {
            Movimiento();
            Salto();
            Disparo();
            Melee();
            DisparoPower();
            MedidorPowerHit();
            Limbo();
            Power1();
            PowersTime();
            Power2();
            Power3();
            NextLevel();

            municionContador.text = municionActual.ToString("0");       // muestra el número de la municion como texto

            float LargoBarraHP = vidaActual / vidaMaxima;               // calcula el largo de la barra de vida del jugador

            float LargoBarraAmmo = municionActual / municionMáxima;     // calcula el largo de la barra de municion del jugador

            PerderHP(LargoBarraHP);

            AmmoBarFunction(LargoBarraAmmo);




            if (vidaActual <= 0)                                        // si la barra de vida es menor o igual a 0
            {
                estado = GameState.muerto;                              // cambia a estado "muerto"

                anim.Play("PJ_Muerte");                                 // trigea animacion

                vida--;                                                 // resta la cantidad de vidas que tiene el jugador

            }

            if (vida == 0)                                              // muerte definitiva cuando el jugador se queda sin vidas
            {
                estado = GameState.muerto;                              // estado cambia a "muerto"

                anim.Play("PJ_Muerte");                                 // triggea animacion

            }

        }


        if (estado == GameState.muerto)
        {
            RBPlayer.velocity = new Vector2(0, RBPlayer.velocity.y);    // personaje se queda quieto al morir

            Power1Activo = false;                                       // Power Up 1 se desactiva al morir

            Power2Activo = false;                                       // Power Up 2 se desactiva al morir

            PowerShield.SetActive(false);                               // Desactiva el escudo
        }

    }


    #endregion

    #region Movimiento

    void Movimiento()                                                                   // movimiento del jugador
    {
        if (Disparando == false)
        {
            if (Power1Activo == false)                                                  // detecta si el power up 1 está desactivado
            {
                if (Input.GetAxis("Horizontal") > 0)                                    // al presionar la tecla mencionada. VERSION ALTERNATIVA - (Input.GetKey(KeyCode.RightArrow))
                {
                    RBPlayer.velocity = new Vector2(speed, RBPlayer.velocity.y);        // el jugador se mueve hacia la derecha

                    Body.GetComponent<SpriteRenderer>().flipX = false;                  // flipear o no el sprite


                    anim.SetBool("PJMOV", true);                                        // animacion del personaje




                }

                if (Input.GetAxis("Horizontal") < 0)                                    // al presionar la tecla mencionada. VERSION ALTERNATIVA - (Input.GetKey(KeyCode.LeftArrow))
                {
                    RBPlayer.velocity = new Vector2(-speed, RBPlayer.velocity.y);       // el jugador se mueve hacia la izquierda

                    Body.GetComponent<SpriteRenderer>().flipX = true;                   // flipear o no el sprite

                    anim.SetBool("PJMOV", true);                                        // animacion del personaje



                }

                if (Input.GetAxis("Horizontal") == 0)
                {
                    RBPlayer.velocity = new Vector2(0, RBPlayer.velocity.y);

                    anim.SetBool("PJMOV", false);                                       // detiene animacion del personaje
                }
            }


            if (Power1Activo == true)                                                   // detecta si el power up 1 está activado
            {
                if (Input.GetAxis("Horizontal") > 0)                                    // al presionar la tecla mencionada. VERSION ALTERNATIVA - (Input.GetKey(KeyCode.RightArrow))
                {
                    RBPlayer.velocity = new Vector2(PowerSpeed, RBPlayer.velocity.y);   // el jugador se mueve hacia la derecha

                    Body.GetComponent<SpriteRenderer>().flipX = false;                  // flipear o no el sprite


                    anim.SetBool("PJMOV", true);                                        // animacion del personaje




                }

                if (Input.GetAxis("Horizontal") < 0)                                    // al presionar la tecla mencionada. VERSION ALTERNATIVA - (Input.GetKey(KeyCode.LeftArrow))
                {
                    RBPlayer.velocity = new Vector2(-PowerSpeed, RBPlayer.velocity.y);  // el jugador se mueve hacia la izquierda

                    Body.GetComponent<SpriteRenderer>().flipX = true;                   // flipear o no el sprite

                    anim.SetBool("PJMOV", true);                                        // animacion del personaje



                }

                if (Input.GetAxis("Horizontal") == 0)                               
                {
                    RBPlayer.velocity = new Vector2(0, RBPlayer.velocity.y);

                    anim.SetBool("PJMOV", false);                                       // detiene animacion del personaje
                }
            }
        }

    }
    #endregion

    #region Salto


    void Salto()
    {

        if (Power1Activo == false)                                                      // detecta si el power up 1 está desactivado
        {
            if ((Input.GetKeyDown(KeyCode.UpArrow) && grounded))
            {
                RBPlayer.velocity = new Vector2(RBPlayer.velocity.x, speedjump);

                anim.Play("PJJUMP");
            }
        }

        if (Power1Activo == true)                                                       // detecta si el power up 1 está activado
        {
            if ((Input.GetKeyDown(KeyCode.UpArrow) && grounded))
            {
                RBPlayer.velocity = new Vector2(RBPlayer.velocity.x, PowerSpeedJump);

                anim.Play("PJJUMP");
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)                              // si colisiona con plataforma
    {
        if ((collision.gameObject.tag == "Piso"))
        {


            Debug.Log("piso");


            grounded = true;
            anim.SetBool("PJJUMP", false);
        }



    }


    private void OnCollisionExit2D(Collision2D collision)                               // si deja de colisionar con plataforma con plataforma
    {
        if (collision.gameObject.tag == "Piso")
        {
            grounded = false;
            anim.SetBool("PJJUMP", true);
        }
    }




    #endregion

    #region Disparo
    public void Disparo()
    {


        if (Input.GetKeyDown("d"))
        {
            if (municionActual > 0)
            {
                if (Body.GetComponent<SpriteRenderer>().flipX == false)
                {
                    Instantiate(bala, balaGenR.position, Quaternion.identity);          // Crea objeto. Orden de parentesis: qué objeto, dónde (o sobre qué objeto) y la rotación

                    anim.Play("PJ_Dispara");

                    Disparando = true;

                    RBPlayer.velocity = new Vector2(0, RBPlayer.velocity.y);            // jugador se queda quieto al atacar

                }

                if (Body.GetComponent<SpriteRenderer>().flipX == true)
                {
                    Instantiate(bala, balaGenL.position, Quaternion.identity);          //Crea objeto. Orden de parentesis: qué objeto, dónde (o sobre qué objeto) y la rotación

                    anim.Play("PJ_Dispara");

                    Disparando = true;

                    RBPlayer.velocity = new Vector2(0, RBPlayer.velocity.y);            // jugador se queda quieto al atacar
                }

                MunicionJugador();
            }

        }

    }

    public void JugadorNoAtaca()
    {
        Disparando = false;

    }


    #endregion

    #region Melee
    void Melee()
    {


        if (Input.GetKeyDown("s"))
        {
            if (Body.GetComponent<SpriteRenderer>().flipX == false)
            {
                Instantiate(MeleeHit, MeleeR.position, Quaternion.identity);            // Crea objeto. Orden de parentesis: qué objeto, dónde (o sobre qué objeto) y la rotación

                anim.Play("PJ_Melee");

                Disparando = true;

                RBPlayer.velocity = new Vector2(0, RBPlayer.velocity.y);                // jugador se queda quieto al atacar

            }

            if (Body.GetComponent<SpriteRenderer>().flipX == true)
            {
                Instantiate(MeleeHit, MeleeL.position, Quaternion.identity);            // Crea objeto. Orden de parentesis: qué objeto, dónde (o sobre qué objeto) y la rotación

                anim.Play("PJ_Melee");

                Disparando = true;

                RBPlayer.velocity = new Vector2(0, RBPlayer.velocity.y);                // jugador se queda quieto al atacar
            }




        }



    }


    #endregion

    #region PowerShot

    public void DisparoPower()
    {
        if ((Input.GetKeyDown("a")) && (BalaPowerReady == true))
        {
            if (Body.GetComponent<SpriteRenderer>().flipX == false)
            {

                anim.Play("PJ_Power");

                Disparando = true;

                RBPlayer.velocity = new Vector2(0, RBPlayer.velocity.y);                // jugador se queda quieto al atacar

                BalaPowerReady = false;

            }

            if (Body.GetComponent<SpriteRenderer>().flipX == true)
            {

                anim.Play("PJ_Power");

                Disparando = true;

                RBPlayer.velocity = new Vector2(0, RBPlayer.velocity.y);                // jugador se queda quieto al atacar

                BalaPowerReady = false;
            }

        }
    }

    public void PowerProyectil()
    {
        if (Body.GetComponent<SpriteRenderer>().flipX == true)
        {
            Instantiate(BalaPower, balaGenL.position, Quaternion.identity);             // Crea objeto. Orden de parentesis: qué objeto, dónde (o sobre qué objeto) y la rotación
        }

        if (Body.GetComponent<SpriteRenderer>().flipX == false)
        {
            Instantiate(BalaPower, balaGenR.position, Quaternion.identity);             // Crea objeto. Orden de parentesis: qué objeto, dónde (o sobre qué objeto) y la rotación
        }

    }

    public void MedidorPowerHit()
    {
        float LargoBarraPowerHit = BalaPowerTimer / BalaPowerCooldownTime;

        MedidorPowerHitFunction(LargoBarraPowerHit);
    }


    public void MedidorPowerHitFunction(float LargoBarraPowerHit)
    {

        MedidorBalaPower.transform.localScale = new Vector3(MedidorBalaPower.transform.localScale.x, LargoBarraPowerHit, MedidorBalaPower.transform.localScale.z);

    }




    #endregion

    #region vida

    void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.tag == "1UP")               // si colisiona con un objeto con el tag mensionado
        {
            Destroy(collision.gameObject);
            VidaExtra();

        }

        #region Colisiones enemigas

        if ((estado == GameState.vivo) && (NivelCompletado == false))
        {
            if(Power2Activo == false)
            {
                if (collision.tag == "Salchicha")               // si colisiona con un objeto con el tag mensionado
                {

                    vidaActual -= SalchichaHit;

                    anim.Play("PJ_Herido");                     // triggea la animación de que es herido

                    MarcoHP.SendMessage("HPHit");

                }

                if (collision.tag == "BalaMorron")              // si colisiona con un objeto con el tag mensionado
                {

                    vidaActual -= BalaMorrónHit;

                    anim.Play("PJ_Herido");                     // triggea la animación de que es herido

                    MarcoHP.SendMessage("HPHit");

                }

                if (collision.tag == "BalaAlbondiga")           // si colisiona con un objeto con el tag mensionado
                {

                    vidaActual -= BalaAlbondigaHit;

                    anim.Play("PJ_Herido");                     // triggea la animación de que es herido

                    MarcoHP.SendMessage("HPHit");

                }

                if (collision.tag == "Tomate")                  // si colisiona con un objeto con el tag mensionado
                {

                    vidaActual -= TomateHit;

                    anim.Play("PJ_Herido");                     // triggea la animación de que es herido

                    MarcoHP.SendMessage("HPHit");

                }

                if (collision.tag == "Jamón")                   // si colisiona con un objeto con el tag mensionado
                {
                    vidaActual -= JamonHit;

                    anim.Play("PJ_Herido");                     // triggea la animación de que es herido

                    MarcoHP.SendMessage("HPHit");

                }

                if (collision.tag == "Shockwave")               // si colisiona con un objeto con el tag mensionado
                {
                    vidaActual -= ShockwaveHit;

                    anim.Play("PJ_Herido");                     // triggea la animación de que es herido

                    MarcoHP.SendMessage("HPHit");

                    float dir;

                    GameObject EnemigoJamon = GameObject.FindGameObjectWithTag("Shockwave");

                    if (transform.position.x < EnemigoJamon.transform.position.x)
                    {
                        dir = 1;
                        KnockBack(dir);

                    }
                    if (transform.position.x > EnemigoJamon.transform.position.x)
                    {
                        dir = -1;
                        KnockBack(dir);
                    }



                }




                if (collision.tag == "Pollo")                   // si colisiona con un objeto con el tag mensionado
                {
                    vidaActual -= PolloHit;

                    anim.Play("PJ_Herido");                     // triggea la animación de que es herido

                    MarcoHP.SendMessage("HPHit");

                }

                if (collision.tag == "Lechuga")                 // si colisiona con un objeto con el tag mensionado
                {
                    vidaActual -= LechugaHit;

                    anim.Play("PJ_Herido");                     // triggea la animación de que es herido

                    MarcoHP.SendMessage("HPHit");

                }

            }


            if (collision.tag == "Caida")                   // si colisiona con un objeto con el tag mensionado
            {
                vidaActual = 0;

                MarcoHP.SendMessage("HPHit");


            }

            if (collision.tag == "PanMonstruo")             // si colisiona con un objeto con el tag mensionado
            {
                vidaActual = 0;

                MarcoHP.SendMessage("HPHit");


            }

            if (collision.tag == "SalsaHazard")             // si colisiona con un objeto con el tag mensionado
            {
                vidaActual = 0;

                MarcoHP.SendMessage("HPHit");


            }
        }
        #endregion
    }

    public void KnockBack(float dir)
    {

        RBPlayer.velocity = new Vector2(0f, 0f);
        RBPlayer.AddForce(new Vector2(dir*500, 300f));

    }



    public void PerderHP(float LargoBarraHP)                // metodo para hacer que la barra de vida "baje" (visualmente hablando) de cierta manera. EJ: De derecha a izquierda, izquierda es 0 y derecha es su vida
    {
        barraHP.transform.localScale = new Vector3(LargoBarraHP, barraHP.transform.localScale.y, barraHP.transform.localScale.z); // Para que al barra de vida vaya bajando
    }


    public void VidaExtra()
    {
        vida++;
    }

    #endregion

    #region Municion

    public void MunicionJugador()
    {
        float LargoBarraAmmo = municionActual / municionMáxima;

        municionActual--;

        AmmoBarFunction(LargoBarraAmmo);
    }


    public void AmmoBarFunction(float LargoBarraAmmo)
    {

        barraAmmo.transform.localScale = new Vector3(barraAmmo.transform.localScale.x, LargoBarraAmmo, barraAmmo.transform.localScale.z);

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

            if (Power1Activo == true)
            {
                SpeedTornado.SetActive(true);
            }
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

            MarcoHP.SendMessage("HPHeal");


            // El siguiente código hace que te recuperes la vida

            vidaActual = vidaMaxima;                            // Su vida actual es la misma que la vida que tiene al máximo


        }
    }

    #endregion

    #region Timer de habilidades especiales

    public void PowersTime()
    {
        if (Power1Activo == true)                               // Activa Timer del Power up 1
        {

            if (PowerTimeStart > 0)
            {
                PowerTimeStart -= Time.deltaTime;
            }
            else if (PowerTimeStart <= 0)
            {
                Power1Activo = false;
            }


            if (vidaActual <= 0)
            {
                Power1Activo = false;
            }



        }

        if (Power1Activo == false)                              // Reinicia Timer del Power Up 1
        {
            PowerTimeStart = PowerT;

            SpeedTornado.SetActive(false);
        }





        if (Power2Activo == true)                               // Activa Timer del Power up 2
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

        if (Power2Activo == false)                              // Reinicia Timer del Power Up 2
        {
            ShieldTimeStart = ShieldTime;

            PowerShield.SetActive(false);
        }






        if (BalaPowerReady == true)                             // reinicia Timer del Power Attack
        {
            BalaPowerTimer = BalaPowerCooldownTime;

            float LargoBarraPowerHit = 0;

            MedidorPowerHitFunction(LargoBarraPowerHit);
        }

        if(BalaPowerReady==false)                               // Activa Timer del Power Attack
        {
            if (BalaPowerTimer > 0)
            {
                BalaPowerTimer -= Time.deltaTime;

            }
            else if (BalaPowerTimer <= 0)
            {
                BalaPowerReady = true;
            }
        }



    }


    #endregion

    #region Revivir
    public void Limbo()
    {
        if ((estado == GameState.muerto) && (vida == 0))        // Si el jugador muere pero se queda sin vidas, aparece pantalla de Game Over
        {
            LevelManager.SendMessage("GameOverScreen");
        }

        if ((estado == GameState.muerto) && (vida >= 1))        // Si el jugador muere pero todavia le quedan vidas, aparece en el checkpoint
        {
            transform.position = Checkpoint.position;           // jugador se teletransporta al checkpoint

            estado = GameState.revive;                          // el jugador vuelve a estar vivo

            anim.Play("PJ_Revive");                             // Triggea animacion Idle





            if (vidaActual < vidaMaxima)                        // Detecta que la barra de vida del jugador sea menor a su total
            {
                vidaActual = vidaMaxima;                        // Su vida actual es la misma que la vida que tiene al máximo

                float LargoBarraHP = vidaActual / vidaMaxima;   // cálculo necesario

                PerderHP(LargoBarraHP);                         // hace que se recupere la barra de vida visualmente
            }

        }
    }

    #endregion

    #region Nivel Completado
    public void NivelCompleto()                                 // Método que activa el bool "nivel completado", llamado desde el objeto "lvl manager"
    {
        NivelCompletado = true;
    }

    public void NextLevel()
    {
        if(NivelCompletado && Input.GetKeyDown("n"))            // Si el bool es "nivel completado" y activo la tecla "N"
        {
            Felicidades.onClick.Invoke();                       // Activa el botón que permite pasar al siguiente nivel
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

    #region LevelRunner
    public void ThreatGenerator()
    {
        if(LvlRunner == true)
        {
            SendMessage("AmenazaGen");
        }
    }

    public void DestroyThreat()
    {
        Object[] AmenazaPan = GameObject.FindGameObjectsWithTag("PanMonstruo");         // llamar a todos los objetos con esta TAG

        Object[] AmenazaHazard = GameObject.FindGameObjectsWithTag("SalsaHazard");      // llamar a todos los objetos con esta TAG

        foreach (GameObject PanMonstruo in AmenazaPan)                                  // Por cada objeto que haya, los destruye
        {
            Destroy(PanMonstruo);                                                       // Destruye Dicho Objeto
        }

        foreach (GameObject Hazard in AmenazaHazard)                                    // Por cada objeto que haya, los destruye
        {
            Destroy(Hazard);                                                            // Destruye Dicho Objeto
        }
    }

    #endregion


}




