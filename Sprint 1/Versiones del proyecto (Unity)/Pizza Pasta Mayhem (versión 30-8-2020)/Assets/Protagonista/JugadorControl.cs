using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorControl : MonoBehaviour
{

    public enum GameState { vivo, muerto} // estados que puede tener el jugador

    public GameState estado = GameState.vivo; // el jugador empieza vivo

    private Rigidbody2D RBPlayer;

    public GameObject game;

    public GameObject spritePlayer; // traer gameobject del jugador con los sprites (body)

    public float speed = 4f; // Velocidad de movimiento

    public float speedjump = 5f; // Fuerza de salto

    public GameObject bala; // traer prefab de la bala

    public Transform balaGen; // traer generador de balas

    public GameObject player; // traer gameobject del body del jugador

    public Animator anim;






    // Start is called before the first frame update
    void Start()
    {
        RBPlayer = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (estado == GameState.vivo)
        {
            Movimiento();
            Salto();
        }
    }







    void Movimiento() // movimiento del jugador
    {
        if (Input.GetKey(KeyCode.RightArrow)) // al presionar la tecla mencionada
        {
            RBPlayer.velocity = new Vector2(speed, RBPlayer.velocity.y); // el jugador se mueve hacia la derecha
            spritePlayer.GetComponent<SpriteRenderer>().flipX = false; // flipear o no el sprite
        }

        else if (Input.GetKey(KeyCode.LeftArrow)) // al presionar la tecla mencionada
        {
            RBPlayer.velocity = new Vector2(-speed, RBPlayer.velocity.y); // el jugador se mueve hacia la izquierda
            spritePlayer.GetComponent<SpriteRenderer>().flipX = true; // flipear o no el sprite
        }

    }

    void Salto()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            RBPlayer.velocity = new Vector2(RBPlayer.velocity.x, speedjump);
        }
    }






}
