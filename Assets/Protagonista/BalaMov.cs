using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaMov : MonoBehaviour
{
    private float balaSpeed;		//velocidad de la bala

    public float speed = 10; // velocidad de la bala, modificable

    private Rigidbody2D RBBala;

    public SpriteRenderer spritePlayer;     //traer "Body" del jugador

    private SpriteRenderer spriteBala;

    public float BalaDestroy = 2.5f;


    // Start is called before the first frame update
    void Start()
    {
        RBBala = GetComponent<Rigidbody2D>();

        spriteBala = GetComponent<SpriteRenderer>();

        spritePlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>(); // Añadir la etiqueta del jugador

        if (spritePlayer.GetComponent<SpriteRenderer>().flipX == false)      // checkea si el jugador está mirando para un lado o no
        {
            balaSpeed = speed;

            spriteBala.flipX = false;  //Flipear (o no) sprite
        }

        else if (spritePlayer.GetComponent<SpriteRenderer>().flipX == true)     // checkea si el jugador está mirando para un lado o no
        {
            balaSpeed = -speed;

            spriteBala.flipX = true;  //Flipear (o no) sprite
        }

        RBBala.velocity = new Vector2(balaSpeed, RBBala.velocity.y);  //movimiento de la bala en una direccion

        Destroy(gameObject, BalaDestroy); //Destruye gameobject y en cuanto tiempo
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)                              // si colisiona con plataforma
    {
        if ((collision.gameObject.tag == "CarniceroTornado"))
        {
            Destroy(gameObject);
        }



    }
}
