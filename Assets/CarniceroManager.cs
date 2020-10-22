using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarniceroManager : MonoBehaviour
{
    public enum GameState { Quieto, Patrulla, Muerto, Tornado, Idle}

    public GameState estado;



    public float IdleTimeCD;                            // valor modificable                   
    public float IdleTimer;

    private float NumeroAzar;                           // variable para el numero al azar
    public bool muerto;

    [Header("Movimiento")]

    public bool izquierda = true;                       // Dirección inicial donde va a empezar el enemigo

    public float SpeedWalk = 4f;                        // Velocidad a la que se moverá el enemigo

    public float SpeedTornado = 6f;

    public float SpeedActual;





    [Header("GameObjects")]
    public GameObject ObjectAll;                        // traer GameObject que contiene al body
    public GameObject ObjectBody;                       // traer GameObject donde está el sprite
    private Animator ObjectAnim;


    public GameObject ColliderTornado;
    public GameObject ColliderMartillo;
    public Transform BalaGen;

    public Transform APoint;                            // Traer gameobject del punto A
    public Transform BPoint;                            // Traer gameobject del punto B

    public GameObject playerBody;

    public GameObject BalaPrefab;



    // Start is called before the first frame update
    void Start()
    {

        IdleTimer = IdleTimeCD;

        muerto = false;

        ObjectAnim = GetComponent<Animator>();

        ObjectAnim.SetBool("CarniceroMuere", false);








        playerBody = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if( estado == GameState.Patrulla)
        {
            PuntoAB();

            SpeedActual = SpeedWalk;
        }

        if (estado == GameState.Tornado)
        {
            PuntoAB();

            SpeedActual = SpeedTornado;
        }


        if (estado == GameState.Muerto)
        {
           // ObjectAnim.SetBool("CarniceroMuere", true);

        }


        if(muerto)
        {
            estado = GameState.Muerto;

            //  ObjectAnim.SetBool("CarniceroMuere", true);

            //AnimacionMuerte();
        }


        CoolDownIdle();
    }





    public void PuntoAB()
    {
        if (izquierda)
        {
            transform.position = Vector3.MoveTowards(transform.position, BPoint.position, SpeedActual * Time.deltaTime);  // Si está mirando hacia la izquierda, se mueve desde su posición actual hacia el punto B, eso por la cantidad de velocidad 

            if (transform.position == BPoint.position)                                                              // Si su posición actual es el punto B, izquierda deja de ser verdadero y flipea el sprite
            {
                izquierda = false;

                transform.rotation = Quaternion.Euler(0, 180, 0);                                                   // gira el enemigo a 180 grados
            }
        }

        else
        {
            transform.position = Vector3.MoveTowards(transform.position, APoint.position, SpeedActual * Time.deltaTime);  // Si está mirando hacia la derecha, se mueve desde su posición actual hacia el punto A, eso por la cantidad de velocidad 

            if (transform.position == APoint.position)                                                              // Si su posición actual es el punto A, izquierda es verdadero y flipea el sprite
            {
                izquierda = true;

                transform.rotation = Quaternion.Euler(0, 0, 0);                                                     // gira el enemigo a 0 grados
            }
        }
    }






    public void CoolDownIdle()
    {
        IdleTimer -= Time.deltaTime;

        if (IdleTimer <= 0)
        {
            Comportamiento();
        }
    }

    public void Comportamiento()                                                       // metodo para que dropee items
    {
        NumeroAzar = Random.Range(0, 15);                                           // numero al azar

        if (NumeroAzar >= 10)
        {

            IdleTimer = IdleTimeCD;

            AnimacionDisparo();

            Debug.Log("nro " + NumeroAzar);
        }

        if (NumeroAzar < 10 && NumeroAzar > 4)
        {

            IdleTimer = IdleTimeCD;

            AnimacionTornado();

            Debug.Log("nro " + NumeroAzar);
        }

        if (NumeroAzar <= 4)
        {
            IdleTimer = IdleTimeCD;

            AnimacionMovimiento();

            estado = GameState.Patrulla;
        }
    }

    public void Muriendo()
    {
        if(muerto)
        {

        }
    }

    public void Death()
    {
        EstadoMuerto();

        ObjectAnim.SetBool("CarniceroMuere", true);

        muerto = true;

    }

    public void Destruir()
    {
        Destroy(ObjectAll.gameObject);
    }


    #region Estados Especificos
    public void EstadoQuieto()
    {
        estado = GameState.Quieto;
    }

    public void EstadoPatrulla()
    {
        estado = GameState.Patrulla;
    }

    public void EstadoTornado()
    {
        estado = GameState.Tornado;
    }

    public void EstadoMuerto()
    {
        estado = GameState.Muerto;
    }

    #endregion

    #region Animaciones Especificas

    public void AnimacionIdle()
    {
        ObjectAnim.Play("Carnicero_Idle");
    }

    public void AnimacionMovimiento()
    {
        ObjectAnim.Play("Carnicero_Movimiento");
    }

    public void AnimacionMelee()
    {
        ObjectAnim.Play("Carnicero_Melee");
    }

    public void AnimacionDisparo()
    {
        ObjectAnim.Play("Carnicero_Distancia");
    }

    public void AnimacionTornado()
    {
        ObjectAnim.Play("Carnicero_Tornado");
    }

    public void AnimacionMuerte()
    {
        ObjectAnim.Play("Carnicero_Muerte");
    }

    #endregion

    #region Disparo
    public void DireccionAPlayer()
    {

        if (playerBody.transform.position.x > transform.position.x)      //checkea si el robot está de un lado o no
        {
            izquierda = false;

            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        else if (playerBody.transform.position.x < transform.position.x)     //checkea si el robot está de un lado o no
        {
            izquierda = true;

            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void DisparoBala()
    {
        Instantiate(BalaPrefab, BalaGen.transform.position, Quaternion.identity);    //Crea objeto. Orden de parentesis: qué objeto, dónde (o sobre qué objeto) y la rotación
    }


    #endregion
}
