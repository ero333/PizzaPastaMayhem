using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDefaultHP : MonoBehaviour
{

    [Header("Vida y Barra")]

    public GameObject barraEnemiga;             // traer la barra de vida del enemigo (vida visible)

    public float vidaEnemiga = 5f;              // vida que quiero que tenga el enemigo

    private float VidaActual;                   // vida actual del enemigo



    [Header("Daño Recibido")]

    public float DañoBala = 1f;                 // daño que recibe por colisionar con la bala del jugador

    public float DañoPowerBala = 1f;            // daño que recibe por colisionar con los Power Attack del jugador

    public float DañoSarten = 1f;               // daño que recibe por colisionar con el ataque melee del jugador

    public float DañoShield = 1f;               // daño que recibe por colisionar con el escudo del jugador


    [Header("Drops")]

    public GameObject HPDrop;                   //  traer Gameobject del paquete de vida

    public GameObject AmmoDrop;                 // traer Gameobject del paquete de municion

    public GameObject ItemDrop;                 // traer objeto que dropea la salchicha

    public Transform DropPosition;              // traer gameobject donde va a dropearse el objeto

    private float AzarDrop;




    // Start is called before the first frame update
    void Start()
    {
        VidaActual = vidaEnemiga;
    }

    // Update is called once per frame
    void Update()
    {
        if (VidaActual <= 0)
        {
            SendMessage("AnimacionMuerte");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        #region Bala collision

        if (collision.tag == "Bala")
        {
            VidaActual -= DañoBala;                         // reduce la vida actual del enemigo si es golpeado por una bala


            float LargoBarraHp = VidaActual / vidaEnemiga;  // calcula el largo de la barra de vida del enemigo

            PerderHP(LargoBarraHp);

            Destroy(collision.gameObject);                  // La lava se destruye al colisionar con el enemigo

            if (VidaActual <= 0)
            {
                
                SendMessage("AnimacionMuerte");
            }
        }

        #endregion

        #region BalaPower collision

        if (collision.tag == "BalaPower")                   // si colisiona con un objeto con el tag mensionado
        {
            VidaActual -= DañoPowerBala;

            float LargoBarraHP = VidaActual / vidaEnemiga;  // calcula el largo de la barra de vida del enemigo

            PerderHP(LargoBarraHP);

            if (VidaActual <= 0)
            {
                SendMessage("AnimacionMuerte");             // Le envía al gameobject un mensaje para que "reproduzca" este método

            }
        }

        #endregion

        #region Sartén collision

        if (collision.tag == "Sartén")                      // si colisiona con un objeto con el tag mensionado
        {
            VidaActual -= DañoSarten;

            float LargoBarraHP = VidaActual / vidaEnemiga;  // calcula el largo de la barra de vida del enemigo

            PerderHP(LargoBarraHP);

            if (VidaActual <= 0)
            {
                SendMessage("AnimacionMuerte");             // Le envía al gameobject un mensaje para que "reproduzca" este método

            }
        }

        #endregion

        #region Shield Collision

        if (collision.tag == "Shield")                      // si colisiona con un objeto con el tag mensionado
        {
            VidaActual -= DañoShield;

            float LargoBarraHP = VidaActual / vidaEnemiga;  // calcula el largo de la barra de vida del enemigo

            PerderHP(LargoBarraHP);

            if (VidaActual <= 0)
            {
                SendMessage("AnimacionMuerte");             // Le envía al gameobject un mensaje para que "reproduzca" este método

            }
        }

        #endregion
    }

    public void PerderHP(float LargoBarraHp)
    {
        barraEnemiga.transform.localScale = new Vector3(LargoBarraHp, barraEnemiga.transform.localScale.y, barraEnemiga.transform.localScale.z);
    }

    #region drops

    public void DropearItem()                                                       // metodo para que dropee items
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
            Instantiate(ItemDrop, DropPosition.position, Quaternion.identity);
        }

    }

    #endregion
}
