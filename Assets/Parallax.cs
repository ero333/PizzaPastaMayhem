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
    public bool HayMovimientoHorizontal = true;





    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("PlayerAll").transform;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;



        if(Input.GetAxis("Horizontal") < 0)
        {
            parallaxActual = parallaxSpeed * -1;

        }

        if (Input.GetAxis("Horizontal") > 0)
        {

            parallaxActual = parallaxSpeed * 1;
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            Paralax();
        }



        if (HayMovimientoHorizontal)
        {
            temp.x = Player.transform.position.x;

        }

        transform.position = temp;


    }


    void Paralax()
    {
        float finalspeed = parallaxActual * Time.deltaTime;
        Cielo.uvRect = new Rect(Cielo.uvRect.x + finalspeed, 0f, 1f, 1f);
        Horizonte.uvRect = new Rect(Horizonte.uvRect.x + finalspeed * 1.3f, 0f, 1f, 1f);
    }
}
