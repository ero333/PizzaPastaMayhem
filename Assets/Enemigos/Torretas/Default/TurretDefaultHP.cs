using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDefaultHP : MonoBehaviour
{
    public float vida = 10f;     //vida que quiero que tenga el enemigo

    private float VidaActual;   //vida actual del enemigo

    public GameObject BarraHP; // traer gameobject de la vida

    public GameObject ItemDrop; // traer objeto que dropea la salchicha

    public Transform DropPosition; // traer gameobject donde se dropea el objeto


    // Start is called before the first frame update
    void Start()
    {
        VidaActual = vida;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Bala") || (collision.tag == "Sartén"))
        {
            VidaActual--;  //reduce la vida actual del enemigo si es golpeado por una bala


            float LargoBarraHp = VidaActual / vida;  //calcula el largo de la barra de vida del enemigo

            PerderHP(LargoBarraHp);

            Destroy(collision.gameObject);  //La laba se destruye al colisionar con el enemigo

            if (VidaActual <= 0)
            {
                Destroy(BarraHP);
                
                SendMessage("AnimacionMuerte");
            }
        }
    }

    public void PerderHP(float LargoBarraHp)
    {
        BarraHP.transform.localScale = new Vector3(LargoBarraHp, BarraHP.transform.localScale.y, BarraHP.transform.localScale.z);
    }

    public void DropearItem() //metodo para que dropee items
    {
        Instantiate(ItemDrop, DropPosition.position, Quaternion.identity);    //Crea objeto. Orden de parentesis: qué objeto, dónde (o sobre qué objeto) y la rotación
    }
}
