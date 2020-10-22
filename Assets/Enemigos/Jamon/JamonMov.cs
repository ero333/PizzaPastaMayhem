using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JamonMov : MonoBehaviour
{

    public enum GameState { Patrullando, Muerto, Quieto }

    public GameState estado = GameState.Patrullando;


    [Header("Movimiento")]

    public Transform APoint; // Traer gameobject del punto A

    public Transform BPoint; // Traer gameobject del punto B

    public bool izquierda = true; // Dirección inicial donde va a empezar el enemigo

    public bool PointStart = true; // Elegir si comienza desde el punto a o el B

    public float speed = 4f; // Velocidad a la que se moverá el enemigo


    [Header("Ataque")]

    public GameObject Bala;         // traer pre-fab del proyectil de este enemigo

    public Transform BalaGenerator; // traer objeto donde apareceran los proyectiles

    public float CoolDown;
    public float CDTimer;

    public bool CdOn;




    [Header("Objetos")]

    public GameObject JamonAll; // traer GameObject que contiene al body
    public GameObject JamonBody; //traer GameObject donde está el sprite
    private Animator JamonAnim;









    [Header("Drops")]

    public GameObject HPDrop;                       //  traer Gameobject del paquete de vida

    public GameObject AmmoDrop;                     // traer Gameobject del paquete de municion

    public GameObject IngredienteDrop;              // traer objeto que dropea la salchicha

    public Transform DropPosition;                  // traer gameobject donde va a dropearse el objeto

    private float AzarDrop;

    // Start is called before the first frame update
    void Start()
    {
        estado = GameState.Patrullando;

        if (PointStart == true)
        {
            if (izquierda) // Si el personaje está mirando hacia la izquierda, comienza desde el punto A
            {
                transform.position = APoint.position;
            }

            else // Si el personaje está mirando hacia la derecha, comienza desde el punto B
            {
                transform.position = BPoint.position;
            }
        }

        CDTimer = CoolDown;
        CdOn = false;

        JamonAnim = JamonBody.GetComponent<Animator>();

        JamonAnim.SetBool("StartMov", true);

        JamonAnim.SetBool("IsDeath", false);

    }

    // Update is called once per frame
    void Update()
    {
        if(estado==GameState.Patrullando)
        {
            Movimiento();
        }

        if(CdOn==true)
        {
            CoolDownTime();
        }

        if (estado == GameState.Muerto)
        {
            JamonAnim.SetBool("IsDeath", true);
        }



    }

    #region Movimiento

    public void Movimiento()
    {
        if (izquierda)
        {
            transform.position = Vector3.MoveTowards(transform.position, BPoint.position, speed * Time.deltaTime); // Si está mirando hacia la izquierda, se mueve desde su posición actual hacia el punto B, eso por la cantidad de velocidad 

            if (transform.position == BPoint.position) // Si su posición actual es el punto B, izquierda deja de ser verdadero y flipea el sprite
            {
                izquierda = false;

                transform.rotation = Quaternion.Euler(0, 180, 0); // gira el enemigo a 180 grados
            }
        }

        else
        {
            transform.position = Vector3.MoveTowards(transform.position, APoint.position, speed * Time.deltaTime); // Si está mirando hacia la derecha, se mueve desde su posición actual hacia el punto A, eso por la cantidad de velocidad 

            if (transform.position == APoint.position) // Si su posición actual es el punto A, izquierda es verdadero y flipea el sprite
            {
                izquierda = true;

                transform.rotation = Quaternion.Euler(0, 0, 0); // gira el enemigo a 0 grados
            }
        }
    }

    #endregion

    #region Ataque

    public void Disparo()
    {
        Instantiate(Bala, BalaGenerator.position, Quaternion.identity);    //Crea objeto. Orden de parentesis: qué objeto, dónde (o sobre qué objeto) y la rotación
    }

    public void JugadorEnRango()
    {
        EstadoQuieto();

        JamonAnim.Play("Jamon_Ataque");

        JamonAnim.SetBool("StartMov", false);

        CDTimer = CoolDown;

    }

    public void CoolDownTime()
    {
        CDTimer -= Time.deltaTime;
        if(CDTimer<=0)
        {
            JamonAnim.SetBool("StartMov", true);

            estado = GameState.Patrullando;
            CdOn = false;
        }
    }

    public void StartCoolDown()
    {
        CdOn = true;
    }

    #endregion







    #region Estados

    public void EstadoPatrulla()
    {
        estado = GameState.Patrullando;
    }
    public void EstadoQuieto()
    {
        estado = GameState.Quieto;
    }
    public void EstadoMuerto()
    {
        estado = GameState.Muerto;
    }

    #endregion

    #region Destruir Objeto

    public void Destruir()
    {
        Destroy(JamonAll); // metodo para destruir el objeto (llamado desde la animacion)
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
