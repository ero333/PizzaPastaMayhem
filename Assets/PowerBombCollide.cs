using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBombCollide : MonoBehaviour
{
    public GameObject Ingrediente;

    private Transform Posicion;

    // Start is called before the first frame update
    void Start()
    {
        Posicion = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PowerBomb")                                 // si colisiona con un objeto con el tag mensionado
        {
            DropearItem();

            Destroy(gameObject);                      // cambia tipo de rigidbody

        }
    }

    public void DropearItem()                                                       // metodo para que dropee items
    {

            Instantiate(Ingrediente, Posicion.position, Quaternion.identity);

    }
}
