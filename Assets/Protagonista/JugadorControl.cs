using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;
//using Debug = UnityEngine.Debug;
using UnityEngine.UI;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class JugadorControl : MonoBehaviour
{

    public enum GameState { vivo, muerto, revive, pausa }               // estados que puede tener el jugador

    public GameState estado = GameState.vivo;                           // el jugador empieza vivo

    private Rigidbody2D RBPlayer;

    public GameObject Body;                                             // traer gameobject del jugador con los sprites (body). busqueda por tag activada en el start

    private Animator anim;

    public Transform Checkpoint;                                        // traer game object donde se teletransportará el jugador al morir. busqueda por tag activada en el start

    public float ejeX;
    public float ejeY;
    int EnteroX;
    int EnteroY;

    public string EnemigoAsesino;
    public bool Asesinado;

    int R1 = 1;
    int R2 = 2;
    int R3 = 3;

    string RecetaObtenida;

    int RecetaUsada;






    [Header("Manejo de Niveles")]

    public bool NivelCompletado;

    public Button Felicidades;                                          // Traer botón que te permite pasar de nivel

    public GameObject LevelManager;                                     // traer game object que permite cambiar de escenas. busqueda por tag activada en el start

    public bool LvlRunner = false;

    Scene NivelActual;

    string MorirLvl;


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

    private float BalaPowerCooldownTime = 45f;                          // tiempo que dura el CD del power attack

    public float BalaPowerTimer;

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

    private float vidaMaxima;                                            // Cantidad de Vida total que va a tener el jugador. Modificable

    public float vidaActual;                                            // Cantidad de vida que tiene el jugador actualmente. No modificable

    public GameObject barraHP;                                          // traer gameobject de la barra de vida

    public GameObject MarcoHP;                                          // traer gameobject de la barra de vida

    public Text VidaContador;                                           // traer gameobject del texto del contador de vidas

    public int vida;                                                    // cantidad de vidas del jugador

    private float Curarse = 10f;                                        // cantidad de vida que me curo








    #endregion

    #region Variables Municion

    [Header("Municion")]

    private float municionMáxima = 20;

    public float municionActual;

    public GameObject barraAmmo;                                        // traer gameobject de la barra de vida

    public Text municionContador;                                       // traer objeto de texto con contador de municion

    private int RecargaAmmo = 5;                                         // numero que dice cuanto va a recargar el jugador al colisionar con X item



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



    private float PowerT = 10f;

    public float PowerTimeStart;

    public GameObject PowerShield;                                      // traer game object del escudo

    public bool Power2Activo = false;

    private float ShieldTime = 10f;

    public float ShieldTimeStart;

    #endregion

    #region Variables Vida que me quitan cada enemigo
    [Header("Daño Recibido")]

    private float PancitoHit = 10f;

    private float PatyHit = 15f;

    private float QuesoHit = 15f;

    private float SalchichaHit = 2f;

    private float AlbondigaHit = 20f;

    private float BalaAlbondigaHit = 15f;

    private float JamonHit = 20f;

    private float ShockwaveHit = 30f;



    private float PolloHit = 15f;

    private float TomateHit = 10f;

    private float LechugaHit = 2f;




    private float BalaMorrónHit = 10f;


    private float PepinoHit = 25f;

    private float PepinoBossContact = 40f;


    private float BossTacoHit = 25f;

    private float BossTacoPunchHit = 100f;

    private float BossTacoSierraHit = 40f;

    private float MiniTacoHit = 20f;

    private float MiniTacoPunchHit = 40f;


    private float CarniceroHit = 10;

    private float CarniceroBulletHit = 25;

    #endregion


    void Awake()
    {
        //NivelActual = SceneManager.GetActiveScene();


        vida = PlayerPrefs.GetInt("vidas");                             // Recupera valores de estas variables 
        vidaActual = PlayerPrefs.GetFloat("VidaActual");                // Recupera valores de estas variables
        if (vida <= 0)                                                  // Corrige Issue de que las vidas quedan en negativo
        {
            LevelManager.SendMessage("Reinicio");

            //SceneManager.LoadScene(NivelActual.buildIndex);
        }




    }







    #region Start
    // Start is called before the first frame update
    void Start()
    {
        Asesinado = false;

        vida = PlayerPrefs.GetInt("vidas");                             // Recupera valores de estas variables 
        vidaMaxima = PlayerPrefs.GetFloat("VidaTotal");                 // Recupera valores de estas variables
        vidaActual = PlayerPrefs.GetFloat("VidaActual");                // Recupera valores de estas variables
        //municionMáxima = PlayerPrefs.GetFloat("MunicionMaxima");        // Recupera valores de estas variables
        //municionActual = PlayerPrefs.GetFloat("MunicionActual");        // Recupera valores de estas variables
        municionActual = municionMáxima;



        if (vidaActual <= 0)                                            // NO SE POR QUÉ, PERO ESTE CÓDIGO ARREGLA EL ERROR INFERNAL DE MORIR+SALIR = VIDAACTUAL: 0
        {
            vidaActual = vidaMaxima;

            //Debug.Log("funciona");
            //SceneManager.LoadScene(NivelActual.buildIndex);
        }




        Body = GameObject.FindGameObjectWithTag("Player");              // busqueda del objeto por Tag

        LevelManager = GameObject.FindGameObjectWithTag("LVLMANAGER");  // busqueda del objeto por Tag


        RBPlayer = GetComponent<Rigidbody2D>();




        anim = Body.GetComponent<Animator>();


        anim.SetBool("PJMOV", false);
        anim.SetBool("PJJUMP", false);





        NivelCompletado = false;



        BalaPowerReady = true;




        NivelActual = SceneManager.GetActiveScene();

        Analytics.CustomEvent("level_start", new Dictionary<string, object>
            {
                {"level_index", NivelActual.buildIndex },
                {"lifes", vida },
                {"ammo", municionActual }


            });
        
        //Debug.Log("Número de vidas = " + vida);
        //Debug.Log("Municion Actual = " + municionActual);







    }

    // Update is called once per frame
    #endregion

    #region update


    void Update()
    {



        PlayerPrefs.SetInt("vidas", vida);                              // Todo cambio que el jugador reciba con esta variable, va a actualizar el player pref
        PlayerPrefs.SetFloat("VidaTotal", vidaMaxima);
        PlayerPrefs.SetFloat("VidaActual", vidaActual);
        //PlayerPrefs.SetFloat("MunicionMaxima", municionMáxima);
        //PlayerPrefs.SetFloat("MunicionActual", municionActual);


        Checkpoint = GameObject.FindGameObjectWithTag("Checkpoint").transform;  


        if (vidaActual > vidaMaxima)
        {
            vidaActual = vidaMaxima;
        }

        if (municionActual > municionMáxima)
        {
            municionActual = municionMáxima;
        }



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


    private void OnCollisionStay2D(Collision2D collision)                              // si colisiona con plataforma
    {
        if ((collision.gameObject.tag == "Piso"))
        {


            //Debug.Log("piso");


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

                AnalyticsDisparo();

                MunicionJugador();
            }

        }

    }

    public void JugadorNoAtaca()
    {
        Disparando = false;

    }


    public void AnalyticsDisparo()
    {
        Coordenadas();
        
        print(EnteroX);
        print(EnteroY);
        print("Disparaste en nivel "+ NivelActual.buildIndex);

        



        Analytics.CustomEvent("disparar", new Dictionary<string, object>
            {
                {"level_index", NivelActual.buildIndex },

                {"x", EnteroX },
                {"y", EnteroY },



            });

        
    }

    #endregion

    #region Melee
    void Melee()
    {


        if (Input.GetKeyDown("s"))
        {
            if (Body.GetComponent<SpriteRenderer>().flipX == false)
            {
                //Instantiate(MeleeHit, MeleeR.position, Quaternion.identity);            // Crea objeto. Orden de parentesis: qué objeto, dónde (o sobre qué objeto) y la rotación

                anim.Play("PJ_Melee");

                Disparando = true;

                RBPlayer.velocity = new Vector2(0, RBPlayer.velocity.y);                // jugador se queda quieto al atacar

            }

            if (Body.GetComponent<SpriteRenderer>().flipX == true)
            {
                //Instantiate(MeleeHit, MeleeL.position, Quaternion.identity);            // Crea objeto. Orden de parentesis: qué objeto, dónde (o sobre qué objeto) y la rotación

                anim.Play("PJ_Melee");

                Disparando = true;

                RBPlayer.velocity = new Vector2(0, RBPlayer.velocity.y);                // jugador se queda quieto al atacar
            }




        }



    }

    public void CrearGolpe()
    {
        if (Body.GetComponent<SpriteRenderer>().flipX == false)
        {
            Instantiate(MeleeHit, MeleeR.position, Quaternion.identity);            // Crea objeto. Orden de parentesis: qué objeto, dónde (o sobre qué objeto) y la rotación

        }

        if (Body.GetComponent<SpriteRenderer>().flipX == true)
        {
            Instantiate(MeleeHit, MeleeL.position, Quaternion.identity);            // Crea objeto. Orden de parentesis: qué objeto, dónde (o sobre qué objeto) y la rotación

        }
    }


    #endregion

    #region PowerShot

    public void DisparoPower()
    {
        if ((Input.GetKeyDown("a")) && (BalaPowerReady == true))
        {

            AnalyticsPowerHit();


            if (Body.GetComponent<SpriteRenderer>().flipX == false)
            {

                anim.Play("PJ_Power");

                Disparando = true;

                RBPlayer.velocity = new Vector2(0, RBPlayer.velocity.y);                // jugador se queda quieto al atacar


            }

            if (Body.GetComponent<SpriteRenderer>().flipX == true)
            {

                anim.Play("PJ_Power");

                Disparando = true;

                RBPlayer.velocity = new Vector2(0, RBPlayer.velocity.y);                // jugador se queda quieto al atacar

            }

        }
    }

    public void PowerProyectil()
    {
        if (Body.GetComponent<SpriteRenderer>().flipX == true)
        {
            Instantiate(BalaPower, balaGenL.position, Quaternion.identity);             // Crea objeto. Orden de parentesis: qué objeto, dónde (o sobre qué objeto) y la rotación

            BalaPowerReady = false;
        }

        if (Body.GetComponent<SpriteRenderer>().flipX == false)
        {
            Instantiate(BalaPower, balaGenR.position, Quaternion.identity);             // Crea objeto. Orden de parentesis: qué objeto, dónde (o sobre qué objeto) y la rotación

            BalaPowerReady = false;
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

    public void AnalyticsPowerHit()
    {
        Coordenadas();
        /*
        print(EnteroX);
        print(EnteroY);
        print("lanzaste PH en nivel "+ NivelActual.buildIndex);

        */



        Analytics.CustomEvent("usar_powerhit", new Dictionary<string, object>
            {
                {"level_index", NivelActual.buildIndex },

                {"x", EnteroX },
                {"y", EnteroY },



            });
    }


    #endregion

    #region vida

    void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.tag == "1UP")                             // si colisiona con un objeto con el tag mensionado
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


                    EnemigoAsesino = collision.tag;


                }

                if (collision.tag == "BalaMorron")              // si colisiona con un objeto con el tag mensionado
                {

                    vidaActual -= BalaMorrónHit;

                    anim.Play("PJ_Herido");                     // triggea la animación de que es herido

                    MarcoHP.SendMessage("HPHit");

                    EnemigoAsesino = collision.tag;

                }

                if (collision.tag == "BalaAlbondiga")           // si colisiona con un objeto con el tag mensionado
                {

                    vidaActual -= BalaAlbondigaHit;

                    anim.Play("PJ_Herido");                     // triggea la animación de que es herido

                    MarcoHP.SendMessage("HPHit");

                    EnemigoAsesino = collision.tag;

                }

                if (collision.tag == "Tomate")                  // si colisiona con un objeto con el tag mensionado
                {

                    vidaActual -= TomateHit;

                    anim.Play("PJ_Herido");                     // triggea la animación de que es herido

                    MarcoHP.SendMessage("HPHit");

                    EnemigoAsesino = collision.tag;

                }

                if (collision.tag == "Jamón")                   // si colisiona con un objeto con el tag mensionado
                {
                    vidaActual -= JamonHit;

                    anim.Play("PJ_Herido");                     // triggea la animación de que es herido

                    MarcoHP.SendMessage("HPHit");

                    EnemigoAsesino = collision.tag;
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

                    EnemigoAsesino = collision.tag;

                }




                if (collision.tag == "Pollo")                                                           // si colisiona con un objeto con el tag mensionado
                {
                    vidaActual -= PolloHit;

                    anim.Play("PJ_Herido");                                                             // triggea la animación de que es herido

                    MarcoHP.SendMessage("HPHit");

                    EnemigoAsesino = collision.tag;

                }

                if (collision.tag == "Lechuga")                                                         // si colisiona con un objeto con el tag mensionado
                {
                    vidaActual -= LechugaHit;

                    anim.Play("PJ_Herido");                                                             // triggea la animación de que es herido

                    MarcoHP.SendMessage("HPHit");

                    EnemigoAsesino = collision.tag;
                }

                if (collision.tag == "Pepino")                                                         // si colisiona con un objeto con el tag mensionado
                {
                    vidaActual -= PepinoHit;

                    anim.Play("PJ_Herido");                                                             // triggea la animación de que es herido

                    MarcoHP.SendMessage("HPHit");

                    EnemigoAsesino = collision.tag;

                }

                if (collision.tag == "Paty")                                                         // si colisiona con un objeto con el tag mensionado
                {
                    vidaActual -= PatyHit;

                    anim.Play("PJ_Herido");                                                             // triggea la animación de que es herido

                    MarcoHP.SendMessage("HPHit");

                    EnemigoAsesino = collision.tag;

                }

                if (collision.tag == "Queso")                                                         // si colisiona con un objeto con el tag mensionado
                {
                    vidaActual -= QuesoHit;

                    anim.Play("PJ_Herido");                                                             // triggea la animación de que es herido

                    MarcoHP.SendMessage("HPHit");

                    EnemigoAsesino = collision.tag;

                }

                if (collision.tag == "BossTaco")                                                         // si colisiona con un objeto con el tag mensionado
                {
                    vidaActual -= BossTacoHit;

                    anim.Play("PJ_Herido");                                                             // triggea la animación de que es herido

                    MarcoHP.SendMessage("HPHit");

                    EnemigoAsesino = collision.tag;

                }

                if (collision.tag == "BossTacoPunch")                                                         // si colisiona con un objeto con el tag mensionado
                {
                    vidaActual -= BossTacoPunchHit;

                    anim.Play("PJ_Herido");                                                             // triggea la animación de que es herido

                    MarcoHP.SendMessage("HPHit");

                    EnemigoAsesino = collision.tag;

                }

                if (collision.tag == "BossTacoSierra")                                                         // si colisiona con un objeto con el tag mensionado
                {
                    vidaActual -= BossTacoSierraHit;

                    anim.Play("PJ_Herido");                                                             // triggea la animación de que es herido

                    MarcoHP.SendMessage("HPHit");

                    EnemigoAsesino = collision.tag;

                }



                if (collision.tag == "MiniTaco")                                                         // si colisiona con un objeto con el tag mensionado
                {
                    vidaActual -= MiniTacoHit;

                    anim.Play("PJ_Herido");                                                             // triggea la animación de que es herido

                    MarcoHP.SendMessage("HPHit");

                    EnemigoAsesino = collision.tag;

                }

                if (collision.tag == "MiniTacoPunch")                                                         // si colisiona con un objeto con el tag mensionado
                {
                    vidaActual -= MiniTacoPunchHit;

                    anim.Play("PJ_Herido");                                                             // triggea la animación de que es herido

                    MarcoHP.SendMessage("HPHit");

                    EnemigoAsesino = collision.tag;

                }

                if (collision.tag == "Carnicero")                                                         // si colisiona con un objeto con el tag mensionado
                {
                    vidaActual -= CarniceroHit;

                    anim.Play("PJ_Herido");                                                             // triggea la animación de que es herido

                    MarcoHP.SendMessage("HPHit");

                    EnemigoAsesino = collision.tag;

                }

                if (collision.tag == "CarniceroBullet")                                                         // si colisiona con un objeto con el tag mensionado
                {
                    vidaActual -= CarniceroBulletHit;

                    anim.Play("PJ_Herido");                                                             // triggea la animación de que es herido

                    MarcoHP.SendMessage("HPHit");

                    EnemigoAsesino = collision.tag;

                }

                if (collision.tag == "Pancito")                                                       // si colisiona con un objeto con el tag mensionado
                {

                    EnemigoAsesino = collision.tag;
                }

                if (collision.tag == "Albondiga")                                                       // si colisiona con un objeto con el tag mensionado
                {
                    EnemigoAsesino = collision.tag;

                }

            }


            if (collision.tag == "Caida")                                                               // si colisiona con un objeto con el tag mensionado
            {
                vidaActual = 0;

                MarcoHP.SendMessage("HPHit");

                EnemigoAsesino = collision.tag;
            }

            if (collision.tag == "PanMonstruo")                                                         // si colisiona con un objeto con el tag mensionado
            {
                vidaActual = 0;

                MarcoHP.SendMessage("HPHit");

                EnemigoAsesino = collision.tag;


            }

            if (collision.tag == "PowerBomb")                                                         // si colisiona con un objeto con el tag mensionado
            {
                vidaActual = 0;

                MarcoHP.SendMessage("HPHit");

                EnemigoAsesino = collision.tag;


            }

            if (collision.tag == "SalsaHazard")                                                         // si colisiona con un objeto con el tag mensionado
            {
                vidaActual = 0;

                MarcoHP.SendMessage("HPHit");

                EnemigoAsesino = collision.tag;


            }

            if (collision.tag == "BossPepino")                                                         // si colisiona con un objeto con el tag mensionado
            {
                vidaActual -= PepinoBossContact;

                MarcoHP.SendMessage("HPHit");

                EnemigoAsesino = collision.tag;


            }

            if (collision.tag == "CarniceroTornado")                                                         // si colisiona con un objeto con el tag mensionado
            {
                vidaActual = 0;

                MarcoHP.SendMessage("HPHit");

                EnemigoAsesino = collision.tag;


            }

            if (collision.tag == "CarniceroHammer")                                                         // si colisiona con un objeto con el tag mensionado
            {
                vidaActual = 0;

                MarcoHP.SendMessage("HPHit");

                EnemigoAsesino = collision.tag;


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
        Coordenadas();


        vida++;

        
        print(NivelActual.buildIndex);
        print(EnteroX);
        print(EnteroY);
        

/*
        print("vida extra X = " + EnteroX);
        print("vida extra Y = " + EnteroY);
*/
        Analytics.CustomEvent("recoger_vidas", new Dictionary<string, object>
            {
                {"level_index", NivelActual.buildIndex },

                {"x", EnteroX },
                {"y", EnteroY },

            });
    }

    #endregion

    void OnTriggerStay2D(Collider2D collision)                                                          // Al permanecer dentro de la Hitbox de X objeto
    {
        #region colision con enemigos (POR SEGUNDO)

        if ((estado == GameState.vivo) && (NivelCompletado == false))
        {
            if (Power2Activo == false)
            {

                if (collision.tag == "Pancito")                                                         // si colisiona con un objeto con el tag mensionado
                {
                    vidaActual -= PancitoHit*Time.deltaTime;

                    anim.Play("PJ_Herido");                                                             // triggea la animación de que es herido

                    MarcoHP.SendMessage("HPHit");

                }

                if (collision.tag == "Albondiga")                                                         // si colisiona con un objeto con el tag mensionado
                {
                    vidaActual -= AlbondigaHit * Time.deltaTime;

                    anim.Play("PJ_Herido");                                                             // triggea la animación de que es herido

                    MarcoHP.SendMessage("HPHit");


                }
            }
        }

        #endregion

        if (collision.tag == "AmmoStation")                                                             // si colisiona con un objeto con el tag mensionado
        {
            RefillAmmo();

        }

    }

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

    #region recargar

    void RefillAmmo()
    {
        Time.timeScale = 1f;
        if(municionActual<municionMáxima)
        {
            municionActual += Time.timeScale;
        }
    }

    void MasMunicion()
    {
            municionActual += RecargaAmmo;



        Coordenadas();


        /*
        print(NivelActual.buildIndex);
        print(ejeX);
        print(ejeY);
        */



        Analytics.CustomEvent("recoger_ammo", new Dictionary<string, object>
            {
                {"level_index", NivelActual.buildIndex },

                {"x", EnteroX },
                {"y", EnteroY },

            });

    }

    void MasVida()
    {


        if(vidaActual <= vidaMaxima)
        {
            Coordenadas();

            /*
            print(NivelActual.buildIndex);
            print(ejeX);
            print(ejeY);

            */


            Analytics.CustomEvent("recoger_hppack", new Dictionary<string, object>
            {
                {"level_index", NivelActual.buildIndex },

                {"x", EnteroX },
                {"y", EnteroY },

            });



            vidaActual += Curarse;
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
            //print("Power1 activado");

            SendMessage("Receta1Usada");


            RecetaUsada = R1;

            PowerAnalytic();







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
            //print("Power2 activado");

            SendMessage("Receta2Usada");




            RecetaUsada = R2;

            PowerAnalytic();





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
            //print("Power3 activado");

            SendMessage("Receta3Usada");






            RecetaUsada = R3;

            PowerAnalytic();





            Receta3 = false;

            MarcoHP.SendMessage("HPHeal");


            // El siguiente código hace que te recuperes la vida

            vidaActual += 60;                            // Su vida actual es la misma que la vida que tiene al máximo


        }
    }





    #endregion

    #region Power Up Usados Analytics

    public void PowerAnalytic()
    {

        //print(RecetaUsada);
        //print("nivel actual= "+NivelActual.buildIndex);


        Analytics.CustomEvent("usar_powerup", new Dictionary<string, object>
            {
                {"cual", RecetaUsada },
                {"level_index", NivelActual.buildIndex }

            });



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

        if ((estado == GameState.muerto) && (vida <= 0))        // Si el jugador muere pero se queda sin vidas, aparece pantalla de Game Over
        {

            /*
            Debug.Log("Perdiste en X = " + ejeX);
            Debug.Log("Perdiste en Y = " + ejeY);
            Debug.Log("Perdiste con " + municionActual + " munición");
            */


            print(EnteroX);
            print(EnteroY);


            Analytics.CustomEvent("game_over", new Dictionary<string, object>
            {
                {"level_index", NivelActual.buildIndex },
                
                {"x", EnteroX },
                {"y", EnteroY },
                {"ammo", municionActual }

                



            }


            );

            /*Debug.Log("GAME OVER");
            Debug.Log("Moriste en el nivel: "+NivelActual.buildIndex);*/
            LevelManager.SendMessage("GameOverScreen");
        }












        if (vida < 0)                                                     // Corrige Issue de que las vidas quedan en negativo
        {
            // LevelManager.SendMessage("GameOverScreen");

            LevelManager.SendMessage("Reinicio");
        }



        if(estado == GameState.muerto)
        {

            /*
            print("Moriste en el nivel " + NivelActual.buildIndex);
            print("Moriste en las coordenadas X=" + ejeX + ", Y=" + ejeY);
            print("Moriste y te quedan " + vida + " vidas");
            print("Moriste teniendo " + municionActual + " de munición");
            print("Moriste por " + EnemigoAsesino);

            */

          //  SwitchMorirAnalytics();





            /*
            Analytics.CustomEvent("morir", new Dictionary<string, object>
            {
                {"level_index", NivelActual.buildIndex },
                {"enemy", EnemigoAsesino},
                {"x", EnteroX },
                {"y", EnteroY },
                {"lifes", vida },
                {"ammo", municionActual }





            }
            

            );

            */
        }




        if ((estado == GameState.muerto) && (vida >= 1))        // Si el jugador muere pero todavia le quedan vidas, aparece en el checkpoint
        {


            if((NivelActual.buildIndex==6)|| (NivelActual.buildIndex == 7)|| (NivelActual.buildIndex == 13))
            {
                SceneManager.LoadScene(NivelActual.buildIndex);
            }




            //  SISTEMA DE CHECKPOINT

            transform.position = Checkpoint.position;           // jugador se teletransporta al checkpoint

            estado = GameState.revive;                          // el jugador vuelve a estar vivo

            anim.Play("PJ_Revive");                             // Triggea animacion Idle


            


                /*Debug.Log("Moriste en el nivel " + NivelActual.buildIndex);
                Debug.Log("Moriste en las coordenadas X=" + ejeX + ", Y=" + ejeY);
                Debug.Log("Moriste y te quedan " + vida + " vidas");
                Debug.Log("Moriste teniendo " + municionActual + " de munición");
                Debug.Log("Moriste por " + EnemigoAsesino);*/




            PlayerPrefs.SetFloat("VidaActual", vidaActual);

            if (vidaActual < vidaMaxima)                        // Detecta que la barra de vida del jugador sea menor a su total
            {
                 vidaActual = vidaMaxima;                        // Su vida actual es la misma que la vida que tiene al máximo

                 float LargoBarraHP = vidaActual / vidaMaxima;   // cálculo necesario

                 PerderHP(LargoBarraHP);                         // hace que se recupere la barra de vida visualmente


                /*if (vidaActual == vidaMaxima)
                {
                    LevelManager.SendMessage("ReiniciarNivelActual");
                }*/
            }




        }
    }

    public void Coordenadas()
    {


        ejeX = Body.transform.position.x;
        ejeY = Body.transform.position.y;

        EnteroX = (int)ejeX;
        EnteroY = (int)ejeY;

        //Debug.Log("X = "+ejeX);
        //Debug.Log("Y = " + ejeY);


    }


    // RESET DE LEVEL

    public void ReiniciarScene()
    {
        LevelManager.SendMessage("ReiniciarNivelActual");
    }







    public void SwitchMorirAnalytics()
    {
        int Nivel = NivelActual.buildIndex;
        switch(Nivel)
        {
            case 1:



                /*
                print("Moriste en el nivel " + NivelActual.buildIndex);
                print("Moriste en las coordenadas X=" + EnteroX + ", Y=" + EnteroY);
                print("Moriste y te quedan " + vida + " vidas");
                print("Moriste teniendo " + municionActual + " de munición");
                print("Moriste por " + EnemigoAsesino);


                */



                Analytics.CustomEvent("morir1", new Dictionary<string, object>
            {
                {"level_index", NivelActual.buildIndex },
                {"enemy", EnemigoAsesino},
                {"x", EnteroX },
                {"y", EnteroY },
                {"lifes", vida },
                {"ammo", municionActual }





            }


);






                break;
            case 2:
                Analytics.CustomEvent("morir2", new Dictionary<string, object>
            {
                {"level_index", NivelActual.buildIndex },
                {"enemy", EnemigoAsesino},
                {"x", EnteroX },
                {"y", EnteroY },
                {"lifes", vida },
                {"ammo", municionActual }





            }


);
                break;
            case 3:
                Analytics.CustomEvent("morir3", new Dictionary<string, object>
            {
                {"level_index", NivelActual.buildIndex },
                {"enemy", EnemigoAsesino},
                {"x", EnteroX },
                {"y", EnteroY },
                {"lifes", vida },
                {"ammo", municionActual }





            }


);
                break;
            case 4:
                Analytics.CustomEvent("morir4", new Dictionary<string, object>
            {
                {"level_index", NivelActual.buildIndex },
                {"enemy", EnemigoAsesino},
                {"x", EnteroX },
                {"y", EnteroY },
                {"lifes", vida },
                {"ammo", municionActual }





            }


            );
                break;
            case 5:
                Analytics.CustomEvent("morir5", new Dictionary<string, object>
            {
                {"level_index", NivelActual.buildIndex },
                {"enemy", EnemigoAsesino},
                {"x", EnteroX },
                {"y", EnteroY },
                {"lifes", vida },
                {"ammo", municionActual }





            }


);
                break;
            case 6:
                Analytics.CustomEvent("morir6", new Dictionary<string, object>
            {
                {"level_index", NivelActual.buildIndex },
                {"enemy", EnemigoAsesino},
                {"x", EnteroX },
                {"y", EnteroY },
                {"lifes", vida },
                {"ammo", municionActual }





            }


);
                break;
            case 7:
                Analytics.CustomEvent("morir7", new Dictionary<string, object>
            {
                {"level_index", NivelActual.buildIndex },
                {"enemy", EnemigoAsesino},
                {"x", EnteroX },
                {"y", EnteroY },
                {"lifes", vida },
                {"ammo", municionActual }





            }


);
                break;
            case 8:
                Analytics.CustomEvent("morir8", new Dictionary<string, object>
            {
                {"level_index", NivelActual.buildIndex },
                {"enemy", EnemigoAsesino},
                {"x", EnteroX },
                {"y", EnteroY },
                {"lifes", vida },
                {"ammo", municionActual }





            }


);
                break;
            case 9:

                Analytics.CustomEvent("morir9", new Dictionary<string, object>
            {
                {"level_index", NivelActual.buildIndex },
                {"enemy", EnemigoAsesino},
                {"x", EnteroX },
                {"y", EnteroY },
                {"lifes", vida },
                {"ammo", municionActual }





            }


);
                break;
            case 10:
                Analytics.CustomEvent("morir10", new Dictionary<string, object>
            {
                {"level_index", NivelActual.buildIndex },
                {"enemy", EnemigoAsesino},
                {"x", EnteroX },
                {"y", EnteroY },
                {"lifes", vida },
                {"ammo", municionActual }





            }


);
                break;
            case 11:
                Analytics.CustomEvent("morir11", new Dictionary<string, object>
            {
                //{"level_index", NivelActual.buildIndex },
                {"enemy", EnemigoAsesino},
                {"x", EnteroX },
                {"y", EnteroY },
                {"lifes", vida },
                {"ammo", municionActual }





            }


);
                break;
            case 12:
                Analytics.CustomEvent("morir12", new Dictionary<string, object>
            {
                //{"level_index", NivelActual.buildIndex },
                {"enemy", EnemigoAsesino},
                {"x", EnteroX },
                {"y", EnteroY },
                {"lifes", vida },
                {"ammo", municionActual }





            }


);
                break;
            case 13:
                Analytics.CustomEvent("morir13", new Dictionary<string, object>
            {
                //{"level_index", NivelActual.buildIndex },
                {"enemy", EnemigoAsesino},
                {"x", EnteroX },
                {"y", EnteroY },
                {"lifes", vida },
                {"ammo", municionActual }





            }


);
                break;
        }
    }



    #endregion

    #region Nivel Completado
    public void NivelCompleto()                                 // Método que activa el bool "nivel completado", llamado desde el objeto "lvl manager"
    {
        NivelCompletado = true;

        //print("level completed");
        SwitchNiveles();

        Analytics.CustomEvent("level_complete", new Dictionary<string, object>
            {
                {"level_index", NivelActual.buildIndex },

                {"lifes", vida },
                {"ammo", municionActual }

            });




        if(vida ==1)
        {
            vida++;
        }

    }

    public void NextLevel()
    {
        if(NivelCompletado && Input.GetKeyDown("n"))            // Si el bool es "nivel completado" y activo la tecla "N"
        {
            Felicidades.onClick.Invoke();                       // Activa el botón que permite pasar al siguiente nivel
        }
    }

    public void SwitchNiveles()
    {
        int Nivel = NivelActual.buildIndex;
        switch (Nivel)
        {
            case 1:
                PlayerPrefs.SetInt("DesbloqueasteNivel_2", 1);
                //print("Desbloqueaste nivel + " + (NivelActual.buildIndex + 1));
                break;

            case 2:
                PlayerPrefs.SetInt("DesbloqueasteNivel_3", 1);
                //print("Desbloqueaste nivel + " + (NivelActual.buildIndex + 1));
                break;

            case 3:
                PlayerPrefs.SetInt("DesbloqueasteNivel_4", 1);
                //print("Desbloqueaste nivel + " + (NivelActual.buildIndex + 1));
                break;

            case 4:
                PlayerPrefs.SetInt("DesbloqueasteNivel_5", 1);
                //print("Desbloqueaste nivel + " + (NivelActual.buildIndex + 1));
                break;

            case 5:
                PlayerPrefs.SetInt("DesbloqueasteNivel_6", 1);
                //print("Desbloqueaste nivel + " + (NivelActual.buildIndex + 1));
                break;

            case 6:
                PlayerPrefs.SetInt("DesbloqueasteNivel_7", 1);
                //print("Desbloqueaste nivel + " + (NivelActual.buildIndex + 1));
                break;

            case 7:
                PlayerPrefs.SetInt("DesbloqueasteNivel_8", 1);
                //print("Desbloqueaste nivel + " + (NivelActual.buildIndex + 1));
                break;

            case 8:
                PlayerPrefs.SetInt("DesbloqueasteNivel_9", 1);
                //print("Desbloqueaste nivel + " + (NivelActual.buildIndex + 1));
                break;

            case 9:
                PlayerPrefs.SetInt("DesbloqueasteNivel_10", 1);
                //print("Desbloqueaste nivel + " + (NivelActual.buildIndex + 1));
                break;

            case 10:
                PlayerPrefs.SetInt("DesbloqueasteNivel_11", 1);
                //print("Desbloqueaste nivel + " + (NivelActual.buildIndex + 1));
                break;

            case 11:
                PlayerPrefs.SetInt("DesbloqueasteNivel_12", 1);
                //print("Desbloqueaste nivel + " + (NivelActual.buildIndex + 1));
                break;

            case 12:
                PlayerPrefs.SetInt("DesbloqueasteNivel_13", 1);
                //print("Desbloqueaste nivel + " + (NivelActual.buildIndex + 1));
                break;


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

        Object[] AmenazaPowerBomb = GameObject.FindGameObjectsWithTag("PowerBomb");      // llamar a todos los objetos con esta TAG

        foreach (GameObject PanMonstruo in AmenazaPan)                                  // Por cada objeto que haya, los destruye
        {
            Destroy(PanMonstruo);                                                       // Destruye Dicho Objeto
        }

        foreach (GameObject Hazard in AmenazaHazard)                                    // Por cada objeto que haya, los destruye
        {
            Destroy(Hazard);                                                            // Destruye Dicho Objeto
        }

        foreach (GameObject Bomb in AmenazaPowerBomb)                                  // Por cada objeto que haya, los destruye
        {
            Destroy(Bomb);                                                       // Destruye Dicho Objeto
        }
    }





    #endregion

}




