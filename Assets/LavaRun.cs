using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaRun : MonoBehaviour
{
    public bool start;

    public float speed = 20f;

    public Transform APoint; // Traer gameobject del punto A

    public Transform BPoint; // Traer gameobject del punto B

    private Animator Anim;


    public Transform Player;

    public Transform Checkpoint;



        // Start is called before the first frame update
    void Start()
    {
        transform.position = APoint.position;



        Player = GameObject.FindGameObjectWithTag("Player").transform;

        Checkpoint = GameObject.FindGameObjectWithTag("Checkpoint").transform;

        start = false;

        Anim = gameObject.GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {

        if(start == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, BPoint.position, speed * Time.deltaTime);
        }


    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            start = false;

            transform.position = APoint.position;
        }
    }

    public void StarClimb()
    {
        start = true;
    }


}
