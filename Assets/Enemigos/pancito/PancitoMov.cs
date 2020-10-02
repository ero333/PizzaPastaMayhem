using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PancitoMov : MonoBehaviour
{
    public enum GameState { Vivo, Muerto}

    public GameState estado = GameState.Vivo;

    [Header("Movimiento")]



    public Transform PlayerPoint;                       // Traer gameobject del punto B

    public bool izquierda = true;                       // Dirección inicial donde va a empezar el enemigo

    public bool PointStart = true;                      // Elegir si comienza desde el punto a o el B

    public float speed = 4f;                            // Velocidad a la que se moverá el enemigo

    private float NumeroAzar;                           // variable para el numero al azar


    [Header("Body y All")]
    public GameObject ObjectAll;                        // traer GameObject que contiene al body
    public GameObject ObjectBody;                       // traer GameObject donde está el sprite
    private Animator ObjectAnim;


    [Header("Drops")]

    public GameObject IngredienteDrop;                  // traer el ingrediente que dropea este enemigo

    public Transform DropPosition;                      // traer gameobject donde va a dropearse el objeto




    // Start is called before the first frame update
    void Start()
    {
        PlayerPoint = GameObject.FindGameObjectWithTag("Player").transform;

        estado = GameState.Vivo;                        // Enemigo comienza estando vivo, puede moverse


    }

    // Update is called once per frame
    void Update()
    {
        if (estado == GameState.Vivo)                   // si su gamestate es "vivo", entonces se mueve
        {
            Movimiento();
        }

    }




    #region Movimiento

    void Movimiento()                                   // Movimiento del personaje
    {

            transform.position = Vector3.MoveTowards(transform.position, PlayerPoint.position, speed * Time.deltaTime);  // Si está mirando hacia la izquierda, se mueve desde su posición actual hacia el punto B, eso por la cantidad de velocidad 

            if (transform.position.x > PlayerPoint.position.x)                                                              // Si su posición actual es el punto B, izquierda deja de ser verdadero y flipea el sprite
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);                                                   // gira el enemigo a 180 grados
            }

            if (transform.position.x < PlayerPoint.position.x)                                                              // Si su posición actual es el punto B, izquierda deja de ser verdadero y flipea el sprite
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);                                                   // gira el enemigo a 180 grados
            }

    }

    #endregion

    public void EstadoMuerto()                                                                                      // metodo para cuando está atacando. Se queda quieto
    {
        estado = GameState.Muerto;
    }

    public void Patrulla()                                                                                          // cambia el estado a "vivo" para que se siga moviendo
    {
        estado = GameState.Vivo;
    }

    public void DropearItem()                                                                                       // metodo para que dropee items
    {
        Instantiate(IngredienteDrop, DropPosition.position, Quaternion.identity);                                   // Crea objeto. Orden de parentesis: qué objeto, dónde (o sobre qué objeto) y la rotación
    }

}
