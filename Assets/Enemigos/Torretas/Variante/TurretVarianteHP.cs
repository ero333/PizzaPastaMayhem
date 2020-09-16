using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretVarianteHP : MonoBehaviour
{
    public float vidaEnemiga = 10f;     //vida que quiero que tenga el enemigo

    private float VidaActual;   //vida actual del enemigo

    public GameObject barraEnemiga; // traer gameobject de la vida




    public float DañoBala = 1f; // daño que recibe por colisionar con la bala del jugador

    public float DañoPowerBala = 1f; // daño que recibe por colisionar con los Power Attack del jugador

    public float DañoSarten = 1f; // daño que recibe por colisionar con el ataque melee del jugador

    public float DañoShield = 1f; // daño que recibe por colisionar con el escudo del jugador






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

            Destroy(barraEnemiga);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bala")
        {
            VidaActual--;  //reduce la vida actual del enemigo si es golpeado por una bala


            float LargoBarraHp = VidaActual / vidaEnemiga;  //calcula el largo de la barra de vida del enemigo

            PerderHP(LargoBarraHp);

            Destroy(collision.gameObject);  //La laba se destruye al colisionar con el enemigo

            if (VidaActual <= 0)
            {
                SendMessage("AnimacionMuerte");

                Destroy(barraEnemiga);
            }
        }



        #region BalaPower collision

        if (collision.tag == "BalaPower") // si colisiona con un objeto con el tag mensionado
        {
            VidaActual -= DañoPowerBala;

            float LargoBarraHP = VidaActual / vidaEnemiga; // calcula el largo de la barra de vida del enemigo

            PerderHP(LargoBarraHP);

            if (VidaActual <= 0)
            {
                SendMessage("AnimacionMuerte"); // Le envía al gameobject un mensaje para que "reproduzca" este método

                Destroy(barraEnemiga);
            }
        }

        #endregion

        #region Sartén collision

        if (collision.tag == "Sartén") // si colisiona con un objeto con el tag mensionado
        {
            VidaActual -= DañoPowerBala;

            float LargoBarraHP = VidaActual / vidaEnemiga; // calcula el largo de la barra de vida del enemigo

            PerderHP(LargoBarraHP);

            if (VidaActual <= 0)
            {
                SendMessage("AnimacionMuerte"); // Le envía al gameobject un mensaje para que "reproduzca" este método

                Destroy(barraEnemiga);
            }
        }

        #endregion

        #region Shield Collision

        if (collision.tag == "Shield") // si colisiona con un objeto con el tag mensionado
        {
            VidaActual -= DañoShield;

            float LargoBarraHP = VidaActual / vidaEnemiga; // calcula el largo de la barra de vida del enemigo

            PerderHP(LargoBarraHP);

            if (VidaActual <= 0)
            {
                SendMessage("AnimacionMuerte"); // Le envía al gameobject un mensaje para que "reproduzca" este método

                Destroy(barraEnemiga);
            }
        }

        #endregion
    }

    public void PerderHP(float LargoBarraHp)
    {
        barraEnemiga.transform.localScale = new Vector3(LargoBarraHp, barraEnemiga.transform.localScale.y, barraEnemiga.transform.localScale.z);
    }
}
