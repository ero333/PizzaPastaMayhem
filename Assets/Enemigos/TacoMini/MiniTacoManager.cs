using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniTacoManager : MonoBehaviour
{



    public enum GameState { Quieto, Patrulla, Muerto }

    public GameState estado = GameState.Patrulla;



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

        ObjectAnim.SetBool("MiniTacoMuere", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (estado == GameState.Muerto)
        {
            ObjectAnim.SetBool("MiniTacoMuere", true);
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



    public void Death()
    {
        EstadoMuerto();
    }

    public void Destruir()
    {
        Destroy(ObjectAll);
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
        ObjectAnim.Play("TacoMini_Idle");
    }

    public void AnimacionMelee()
    {
        ObjectAnim.Play("TacoMini_Melee");
    }

    public void AnimacionMovimiento()
    {
        ObjectAnim.Play("TacoMini_Movimiento");
    }

    public void AnimacionMuerte()
    {
        ObjectAnim.Play("TacoMini_Muerte");
    }

    #endregion


}
