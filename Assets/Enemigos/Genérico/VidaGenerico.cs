using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaGenerico : MonoBehaviour
{
    public float vidaEnemiga = 5f; // vida que quiero que tenga el enemigo

    private float vidaActual; // vida actual del enemigo

    public GameObject barraEnemiga; // traer la barra de vida del enemigo (vida visible)







    // Start is called before the first frame update
    void Start()
    {
        vidaActual = vidaEnemiga;
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bala") // si colisiona con un objeto con el tag mensionado
        {
            vidaActual--;

            float LargoBarraHP = vidaActual / vidaEnemiga; // calcula el largo de la barra de vida del enemigo

            PerderHP(LargoBarraHP);


            Destroy(collision.gameObject); // Al colisionar con objeto, este mismo se destruye

            if (vidaActual > 0)
            {
                SendMessage(""); // envia mensaje al método que triggea animacion de que recibe daño
            }

            if (vidaActual <= 0)
            {
                SendMessage(""); // Le envía al gameobject un mensaje para que "reproduzca" este método con la animacion de muerte

                Destroy(barraEnemiga); // destruye la barra de vida
            }
        }

        if (collision.tag == "Sartén") // si colisiona con un objeto con el tag mensionado
        {
            vidaActual--;

            float LargoBarraHP = vidaActual / vidaEnemiga; // calcula el largo de la barra de vida del enemigo

            PerderHP(LargoBarraHP);



            if (vidaActual > 0)
            {
                SendMessage(""); // envia mensaje al método que triggea animacion de que recibe daño
            }



            if (vidaActual <= 0)
            {
                SendMessage(""); // Le envía al gameobject un mensaje para que "reproduzca" este método con la animacion de muerte

                Destroy(barraEnemiga); // destruye la barra de vida
            }
        }
    }

    public void PerderHP(float LargoBarraHP) // metodo para hacer que la barra enemiga "baje" (visualmente hablando) de cierta manera. EJ: De derecha a izquierda, izquierda es 0 y derecha es su vida
    {
        barraEnemiga.transform.localScale = new Vector3(LargoBarraHP, barraEnemiga.transform.localScale.y, barraEnemiga.transform.localScale.z); // Para que al barra enemiga vaya bajando

    }


}
