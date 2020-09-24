using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaRun : MonoBehaviour
{

    public float Velocidad = 20f;         // Velocidad Máxima a la que va a llegar



    public Transform APoint;                    // Traer gameobject del punto A

    public Transform BPoint;                    // Traer gameobject del punto B

    private Animator Anim;






        // Start is called before the first frame update
    void Start()
    {
        transform.position = APoint.position;

        Anim = gameObject.GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {

            transform.position = Vector3.MoveTowards(transform.position, BPoint.position, Velocidad * Time.deltaTime);



    }


}
