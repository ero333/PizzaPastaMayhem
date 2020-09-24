using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanMonstruoBulletBehavior : MonoBehaviour
{

    public GameObject playerBody;                                               // Traer el objeto del jugador con Sprite. Busqueda por TAG en el start

    private float BreadSpeed;                                                   // Velocidad de la bala

    public float manualSpeed = 4;                                               // Velocidad de la bala. Modificable

    private SpriteRenderer BreadDirection;

    private Rigidbody2D RBBread;






    // Start is called before the first frame update
    void Start()
    {
        RBBread = GetComponent<Rigidbody2D>();

        BreadDirection = GetComponent<SpriteRenderer>();

        playerBody = GameObject.FindGameObjectWithTag("Player");                // detecta al jugador

        if (playerBody.transform.position.x > transform.position.x)             //checkea si el robot está de un lado o no
        {
            BreadSpeed = (manualSpeed * 1);                                     // velocidad de la bala

            BreadDirection.flipX = false;                                       //Flipear (o no) sprite
        }

        else if (playerBody.transform.position.x < transform.position.x)        //checkea si el robot está de un lado o no
        {
            BreadSpeed = (manualSpeed * -1);                                    // velocidad de la bala

            BreadDirection.flipX = true;                                        //Flipear (o no) sprite
        }



        RBBread.velocity = new Vector2(BreadSpeed, RBBread.velocity.y);         //movimiento de la bala en una direccion

    }
    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PanMonstruoFall")                                 // si colisiona con un objeto con el tag mensionado
        {
            RBBread.bodyType = RigidbodyType2D.Dynamic;                         // cambia tipo de rigidbody
        }
    }
}

