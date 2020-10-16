using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBombManager : MonoBehaviour
{
    public GameObject playerBody;                                               // Traer el objeto del jugador con Sprite. Busqueda por TAG en el start

    private float BombSpeed;                                                   // Velocidad de la bala

    public float manualSpeed = 4;                                               // Velocidad de la bala. Modificable

    private SpriteRenderer BombDirection;

    private Rigidbody2D RBBread;






    // Start is called before the first frame update
    void Start()
    {
        RBBread = GetComponent<Rigidbody2D>();

        BombDirection = GetComponent<SpriteRenderer>();

        playerBody = GameObject.FindGameObjectWithTag("Player");                // detecta al jugador

        if (playerBody.transform.position.x > transform.position.x)             //checkea si el robot está de un lado o no
        {
            BombSpeed = (manualSpeed * 1);                                     // velocidad de la bala

            BombDirection.flipX = false;                                       //Flipear (o no) sprite
        }

        else if (playerBody.transform.position.x < transform.position.x)        //checkea si el robot está de un lado o no
        {
            BombSpeed = (manualSpeed * -1);                                    // velocidad de la bala

            BombDirection.flipX = true;                                        //Flipear (o no) sprite
        }



        RBBread.velocity = new Vector2(BombSpeed, RBBread.velocity.y);         //movimiento de la bala en una direccion

    }
    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PanMonstruoFall")                                 // si colisiona con un objeto con el tag mensionado
        {
            Destroy(gameObject);                      // cambia tipo de rigidbody
        }
    }
}
