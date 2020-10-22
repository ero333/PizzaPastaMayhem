using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatyMov : MonoBehaviour
{
    public enum GameState { Vivo, Muerto, Atacando, Quieto }

    public GameState estado = GameState.Vivo;

    [Header("Movimiento")]

    public Transform APoint;                            // Traer gameobject del punto A

    public Transform BPoint;                            // Traer gameobject del punto B

    public bool izquierda = true;                       // Dirección inicial donde va a empezar el enemigo

    public bool PointStart = true;                      // Elegir si comienza desde el punto a o el B

    public float speed = 4f;                            // Velocidad a la que se moverá el enemigo

    private float NumeroAzar;                           // variable para el numero al azar


    [Header("Body y All")]
    public GameObject ObjectAll;                        // traer GameObject que contiene al body
    public GameObject ObjectBody;                       // traer GameObject donde está el sprite
    private Animator ObjectAnim;


    [Header("Drops")]

    public GameObject HPDrop;                           //  traer Gameobject del paquete de vida

    public GameObject AmmoDrop;                         // traer Gameobject del paquete de municion

    public GameObject IngredienteDrop;                  // traer objeto que dropea la salchicha

    public Transform DropPosition;                      // traer gameobject donde va a dropearse el objeto

    private float AzarDrop;




    // Start is called before the first frame update
    void Start()
    {


        estado = GameState.Vivo;                        // Enemigo comienza estando vivo, puede moverse

        if (PointStart == true)
        {
            if (izquierda)                              // Si el personaje está mirando hacia la izquierda, comienza desde el punto A
            {
                transform.position = APoint.position;
            }

            else                                        // Si el personaje está mirando hacia la derecha, comienza desde el punto B
            {
                transform.position = BPoint.position;
            }
        }





        ObjectAnim = ObjectBody.GetComponent<Animator>();

        ObjectAnim.SetBool("PatyMuere", false);        // Seteamos que el bool, que triggea la animación de muerte, empiece en false
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
        if (izquierda)
        {
            transform.position = Vector3.MoveTowards(transform.position, BPoint.position, speed * Time.deltaTime); // Si está mirando hacia la izquierda, se mueve desde su posición actual hacia el punto B, eso por la cantidad de velocidad 

            if (transform.position == BPoint.position)                                                             // Si su posición actual es el punto B, izquierda deja de ser verdadero y flipea el sprite
            {
                izquierda = false;

                transform.rotation = Quaternion.Euler(0, 180, 0);                                                  // gira el enemigo a 180 grados
            }
        }

        else
        {
            transform.position = Vector3.MoveTowards(transform.position, APoint.position, speed * Time.deltaTime); // Si está mirando hacia la derecha, se mueve desde su posición actual hacia el punto A, eso por la cantidad de velocidad 

            if (transform.position == APoint.position)                                                             // Si su posición actual es el punto A, izquierda es verdadero y flipea el sprite
            {
                izquierda = true;

                transform.rotation = Quaternion.Euler(0, 0, 0);                                                    // gira el enemigo a 0 grados
            }
        }
    }

    #endregion








    public void RecibeGolpe()                           // metodo para triggear animacion de que recibe daño
    {
        ObjectAnim.Play("Paty_Golpe");
        EstadoQuieto();
    }

    public void Atacando()                              // metodo para cuando está atacando. Se queda quieto
    {
        estado = GameState.Atacando;
    }

    public void EstadoQuieto()                          // metodo para cuando está atacando. Se queda quieto
    {
        estado = GameState.Quieto;
    }

    public void Patrulla()                              // cambia el estado a "vivo" para que se siga moviendo
    {
        estado = GameState.Vivo;
    }

    public void AtaqueAzar()                            // agarra la variante mencionada y le da un valor al azar
    {

        NumeroAzar = Random.Range(1, 100);              // numero al azar, probabilidades de que ataque o no


        if (NumeroAzar < 51)                            // si el numero al azar da entre 1 y 50, entonces realiza un ataque
        {
            ObjectAnim.Play("Paty_Atacando");
            Atacando();

        }
    }


    #region Muerte
    public void Death()                                 // Método para que muera
    {

        ObjectAnim.SetBool("PatyMuere", true);         // triggea la animación de muerte


        estado = GameState.Muerto;                      // Cambia el estado a muerto



    }


    public void DestruirObjecto()                       //metodo para destruir el objeto (llamado desde la animacion)
    {
        Destroy(ObjectAll);
    }

    #endregion

    #region drops

    public void DropearItem()                                                       //metodo para que dropee items
    {
        AzarDrop = Random.Range(1, 100);                                            // numero al azar, probabilidades del drop de items

        if (AzarDrop >= 90)                                      // si el numero al azar da entre 50 y 75, dropea municion
        {
            Instantiate(AmmoDrop, DropPosition.position, Quaternion.identity);
        }
        else if (AzarDrop < 10)                                                          // si el numero al azar da entre 75 y 100, dropea vida
        {
            Instantiate(HPDrop, DropPosition.position, Quaternion.identity);
        }

        else                                                          // si el numero al azar da entre 0 y 50, dropea ingrediente
        {
            Instantiate(IngredienteDrop, DropPosition.position, Quaternion.identity);
        }
    }

    #endregion
}
