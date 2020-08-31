using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaMov : MonoBehaviour
{
    public float balaSpeed;		//velocidad de la bala

    private Rigidbody2D RBBala;

    public SpriteRenderer spritePlayer;     //traer "Body" del jugador

    private SpriteRenderer spriteBala;


    // Start is called before the first frame update
    void Start()
    {
        RBBala = GetComponent<Rigidbody2D>();

        spriteBala = GetComponent<SpriteRenderer>();

        spritePlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>(); //Añadir la etiqueta del jugador

        if (spritePlayer.GetComponent<SpriteRenderer>().flipX == false)      //checkea si el jugador está mirando para un lado o no
        {
            balaSpeed = 10;

            spriteBala.flipX = false;  //Flipear (o no) sprite
        }

        else if (spritePlayer.GetComponent<SpriteRenderer>().flipX == true)     //checkea si el jugador está mirando para un lado o no
        {
            balaSpeed = -10;

            spriteBala.flipX = true;  //Flipear (o no) sprite
        }

        RBBala.velocity = new Vector2(balaSpeed, RBBala.velocity.y);  //movimiento de la bala en una direccion

        Destroy(gameObject, 2.5f); //Destruye gameobject y en cuanto tiempo
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
