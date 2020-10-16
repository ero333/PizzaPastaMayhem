using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeHit : MonoBehaviour
{

    public float MeleeTime = 0.30f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, MeleeTime); //Destruye gameobject y en cuanto tiempo
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BalaMorron")              // si colisiona con un objeto con el tag mensionado
        {
            Destroy(collision.gameObject);
        }

        if (collision.tag == "BalaAlbondiga")           // si colisiona con un objeto con el tag mensionado
        {
            Destroy(collision.gameObject);
        }
    }
}