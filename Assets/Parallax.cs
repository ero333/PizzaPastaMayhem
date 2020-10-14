using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{
    public RawImage Cielo;
    public RawImage Horizonte;
    public float parallaxSpeed = 0.2f;
    private float parallaxActual;



    public Transform Player; // traer posicion del gameobject


    private float lastX;





    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("PlayerAll").transform;

        lastX = Player.transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetAxis("Horizontal") < 0)
        {
            parallaxActual = parallaxSpeed * -1;

        }

        if (Input.GetAxis("Horizontal") > 0)
        {

            parallaxActual = parallaxSpeed * 1;
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            if (lastX != Player.transform.position.x)       // Si la posicion actual de X es distinta a la anterior (personaje avanza), genera el efecto parallax. Si el jugador deja de avanzar en X, el efecto Parallax deja de funcionar
            {
                Paralax();
            }
        }

        lastX = gameObject.transform.position.x;            // Toma la última posicion del jugador





    }


    void Paralax()
    {
        float finalspeed = parallaxActual * Time.deltaTime;
        Cielo.uvRect = new Rect(Cielo.uvRect.x + finalspeed, 0f, 1f, 1f);
        Horizonte.uvRect = new Rect(Horizonte.uvRect.x + finalspeed * 1.3f, 0f, 1f, 1f);
    }
}
