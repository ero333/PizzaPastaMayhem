using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPepinoVida : MonoBehaviour
{
    public float vidaEnemiga = 5f;          // vida que quiero que tenga el enemigo

    public float vidaActual;               // vida actual del enemigo

    public GameObject ContenedorVida;       // Traer Gameobject que contiene toda la vida

    public GameObject barraEnemiga;         // traer la barra de vida del enemigo (vida visible)

    public GameObject EnemyTag;

    public float DañoBala = 1f;             // daño que recibe por colisionar con la bala del jugador

    public float DañoPowerBala = 1f;        // daño que recibe por colisionar con los Power Attack del jugador

    public float DañoSarten = 1f;           // daño que recibe por colisionar con el ataque melee del jugador

    public float DañoShield = 1f;           // daño que recibe por colisionar con el escudo del jugador

    // Start is called before the first frame update
    void Start()
    {
        vidaActual = vidaEnemiga;
    }

    // Update is called once per frame
    void Update()
    {
        if (vidaActual <= 0)
        {
            SendMessage("Death");    // Le envía al gameobject un mensaje para que "reproduzca" este método

            Destroy(EnemyTag);

        }
    }







    void OnTriggerEnter2D(Collider2D collision)
    {

        #region Bala collision

        if (collision.tag == "Bala")                        // si colisiona con un objeto con el tag mensionado
        {
            vidaActual -= DañoBala;

            float LargoBarraHP = vidaActual / vidaEnemiga;  // calcula el largo de la barra de vida del enemigo

            PerderHP(LargoBarraHP);


            Destroy(collision.gameObject);                  // Al colisionar con objeto, este mismo se destruye

        }

        #endregion

        #region BalaPower collision

        if (collision.tag == "BalaPower")                   // si colisiona con un objeto con el tag mensionado
        {
            vidaActual -= DañoPowerBala;

            float LargoBarraHP = vidaActual / vidaEnemiga;  // calcula el largo de la barra de vida del enemigo

            PerderHP(LargoBarraHP);



        }

        #endregion

        #region Sartén collision

        if (collision.tag == "Sartén")                      // si colisiona con un objeto con el tag mensionado
        {
            vidaActual -= DañoSarten;

            float LargoBarraHP = vidaActual / vidaEnemiga;  // calcula el largo de la barra de vida del enemigo

            PerderHP(LargoBarraHP);


        }

        #endregion

        #region Shield Collision

        if (collision.tag == "Shield")                      // si colisiona con un objeto con el tag mensionado
        {
            vidaActual -= DañoShield;

            float LargoBarraHP = vidaActual / vidaEnemiga;  // calcula el largo de la barra de vida del enemigo

            PerderHP(LargoBarraHP);

        }

        #endregion
    }

    public void PerderHP(float LargoBarraHP)                // metodo para hacer que la barra enemiga "baje" (visualmente hablando) de cierta manera. EJ: De derecha a izquierda, izquierda es 0 y derecha es su vida
    {
        barraEnemiga.transform.localScale = new Vector3(LargoBarraHP, barraEnemiga.transform.localScale.y, barraEnemiga.transform.localScale.z); // Para que al barra enemiga vaya bajando

    }
}
