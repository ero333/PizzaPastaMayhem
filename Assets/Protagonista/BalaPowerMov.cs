using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaPowerMov : MonoBehaviour
{
    private float balaPowerSpeed;		//velocidad de la bala

    public float speed = 10; // velocidad de la bala, modificable

    private Rigidbody2D RBBala;

    public SpriteRenderer spritePlayer;     //traer "Body" del jugador

    private SpriteRenderer spritePowerBala;

    public float BalaDestroy = 2.5f;


    // Start is called before the first frame update
    void Start()
    {
        RBBala = GetComponent<Rigidbody2D>();

        spritePowerBala = GetComponent<SpriteRenderer>();

        spritePlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>(); // Añadir la etiqueta del jugador

        if (spritePlayer.GetComponent<SpriteRenderer>().flipX == false)      // checkea si el jugador está mirando para un lado o no
        {
            balaPowerSpeed = speed;

            spritePowerBala.flipX = false;  //Flipear (o no) sprite
        }

        else if (spritePlayer.GetComponent<SpriteRenderer>().flipX == true)     // checkea si el jugador está mirando para un lado o no
        {
            balaPowerSpeed = -speed;

            spritePowerBala.flipX = true;  //Flipear (o no) sprite
        }

        RBBala.velocity = new Vector2(balaPowerSpeed, RBBala.velocity.y);  //movimiento de la bala en una direccion

        Destroy(gameObject, BalaDestroy); //Destruye gameobject y en cuanto tiempo
    }
    // Update is called once per frame
    void Update()
    {

    }
}
