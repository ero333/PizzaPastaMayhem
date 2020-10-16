using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTacoManager : MonoBehaviour
{

    public enum GameState { Quieto, Patrulla, Muerto }

    public GameState estado = GameState.Patrulla;

    private float NumeroAzar1;                      // variable para el numero al azar
    private float NumeroAzar2;                      // variable para el numero al azar









    [Header("Ataques")]

    public GameObject Proyectil;

    public Transform ABot;
    public Transform BBot;
    public Transform ATop;
    public Transform BTop;



    [Header("Body y All")]
    public GameObject ObjectAll;                    // traer GameObject que contiene al body
    public GameObject ObjectBody;                   // traer GameObject donde está el sprite
    private Animator ObjectAnim;









    [Header("Movimiento")]
    public Transform APoint;                        // Traer gameobject del punto A
    public Transform BPoint;                        // Traer gameobject del punto B

    public bool izquierda = true;                   // Dirección inicial donde va a empezar el enemigo

    public float speed = 4f;                        // Velocidad a la que se moverá el enemigo



    // Start is called before the first frame update
    void Start()
    {
        ObjectAnim = GetComponent<Animator>();

        ObjectAnim.SetBool("BossTacoMuere", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(estado == GameState.Muerto)
        {
            ObjectAnim.SetBool("BossTacoMuere", true);
        }

        if (estado == GameState.Patrulla)
        {
            Patrulla();
        }

    }

    public void Patrulla()
    {
        if (izquierda)
        {
            transform.position = Vector3.MoveTowards(transform.position, BPoint.position, speed * Time.deltaTime);  // Si está mirando hacia la izquierda, se mueve desde su posición actual hacia el punto B, eso por la cantidad de velocidad 

            if (transform.position == BPoint.position)                                                              // Si su posición actual es el punto B, izquierda deja de ser verdadero y flipea el sprite
            {
                izquierda = false;

                transform.rotation = Quaternion.Euler(0, 180, 0);                                                   // gira el enemigo a 180 grados
            }
        }

        else
        {
            transform.position = Vector3.MoveTowards(transform.position, APoint.position, speed * Time.deltaTime);  // Si está mirando hacia la derecha, se mueve desde su posición actual hacia el punto A, eso por la cantidad de velocidad 

            if (transform.position == APoint.position)                                                              // Si su posición actual es el punto A, izquierda es verdadero y flipea el sprite
            {
                izquierda = true;

                transform.rotation = Quaternion.Euler(0, 0, 0);                                                     // gira el enemigo a 0 grados
            }
        }
    }

    public void AtaqueAzar()                                                       // metodo para que dropee items
    {
        NumeroAzar1 = Random.Range(0, 2);                                           // numero al azar

        if (NumeroAzar1 == 0)
        {
            ObjectAnim.Play("TacoBoss_AtaqueBot");

        }

        if (NumeroAzar1 == 1)
        {
            ObjectAnim.Play("TacoBoss_AtaqueTop");
        }

    }

    public void GenerarSierra()
    {
        if (NumeroAzar1 == 0)
        {
            NumeroAzar2 = Random.Range(0, 2);

            if (NumeroAzar2 == 0)
            {
                Instantiate(Proyectil, ABot.transform.position, Quaternion.identity);    //Crea objeto. Orden de parentesis: qué objeto, dónde (o sobre qué objeto) y la rotación
            }

            if (NumeroAzar2 == 1)
            {
                Instantiate(Proyectil, BBot.transform.position, Quaternion.identity);    //Crea objeto. Orden de parentesis: qué objeto, dónde (o sobre qué objeto) y la rotación
            }

        }

        if (NumeroAzar1 == 1)
        {
            NumeroAzar2 = Random.Range(0, 2);

            if (NumeroAzar2 == 0)
            {
                Instantiate(Proyectil, ATop.transform.position, Quaternion.identity);    //Crea objeto. Orden de parentesis: qué objeto, dónde (o sobre qué objeto) y la rotación
            }

            if (NumeroAzar2 == 1)
            {
                Instantiate(Proyectil, BTop.transform.position, Quaternion.identity);    //Crea objeto. Orden de parentesis: qué objeto, dónde (o sobre qué objeto) y la rotación
            }
        }
    }

    public void Death()
    {
        EstadoMuerto();
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

    public void EstadoMuerto()
    {
        estado = GameState.Muerto;
    }

    #endregion

    #region Animaciones Especificas

    public void AnimacionIdle()
    {
        ObjectAnim.Play("TacoBoss_Idle");
    }

    public void AnimacionMelee()
    {
        ObjectAnim.Play("TacoBoss_Melee");
    }

    public void AnimacionMovimiento()
    {
        ObjectAnim.Play("TacoBoss_Movimiento");
    }

    public void AnimacionMuerte()
    {
        ObjectAnim.Play("TacoBoss_Muerte");
    }

    #endregion
}
