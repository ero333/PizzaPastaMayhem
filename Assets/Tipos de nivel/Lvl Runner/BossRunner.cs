using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRunner : MonoBehaviour
{
    public bool reinicio;

    public float speed = 20f;

    private Rigidbody2D rbd2; 

    public Transform APoint; // Traer gameobject del punto A

    public Transform BPoint; // Traer gameobject del punto B

    public GameObject PanRunnerlvl; // traer gameobject que contiene todo el objeto

    // Start is called before the first frame update
    void Start()
    {
        transform.position = APoint.position;

        rbd2 = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, BPoint.position, speed * Time.deltaTime);

        if (transform.position==BPoint.position) // cuando la posicion del enemigo es igual a la del punto B
        {
            rbd2.bodyType = RigidbodyType2D.Dynamic; // cambia tipo de rigidbody

            rbd2.constraints = RigidbodyConstraints2D.None;

            PanRunnerlvl.SendMessage("DestruirPlataformas");
        }

        if (transform.position == APoint.position) // cuando la posicion del enemigo es igual a la del punto B
        {
            PanRunnerlvl.SendMessage("AparecerPlataformas");
        }
    }


    public void ResetPosition()
    {
        transform.position = APoint.position;

        rbd2.constraints = RigidbodyConstraints2D.FreezePositionY; // evita que el enemigo se caiga cuando vuelve a aparecer en el punto A

        rbd2.bodyType = RigidbodyType2D.Kinematic; // cambia tipo de rigidbody

    }


}
