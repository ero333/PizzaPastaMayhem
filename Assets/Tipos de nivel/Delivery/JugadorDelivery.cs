using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorDelivery : MonoBehaviour
{

    public GameObject LVLDelivery;                                              // traer gameobject correspondiente



    // Start is called before the first frame update
    void Start()
    {
        LVLDelivery = GameObject.FindGameObjectWithTag("LVLDelivery");
    }

    // Update is called once per frame
    void Update()
    {

    }






    #region Colliders

    private void OnTriggerEnter2D(Collider2D collision)                         //si colisiona con el objecto
    {
        if (collision.gameObject.tag == "Gelatina")         // Al colisionar con objeto y "TengoGelatina" es falso
        {

            Debug.Log("AgarreGelatina");

            Destroy(collision.gameObject);                                      // Al colisionar con objeto, este mismo se destruye

            LVLDelivery.SendMessage("GelatinaMenos");

        }

    }

    #endregion





}
