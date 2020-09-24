using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorDelivery : MonoBehaviour
{

    public GameObject Gelatina;                                                 // traer gameobject correspondiente

    public GameObject LVLDelivery;                                              // traer gameobject correspondiente

    public bool TengoGelatina = false;


    // Start is called before the first frame update
    void Start()
    {
        TengoGelatina = false;

        LVLDelivery = GameObject.FindGameObjectWithTag("LVLDelivery");
    }

    // Update is called once per frame
    void Update()
    {
        if(TengoGelatina)
        {
            Gelatina.SetActive(true);                                           // Activa objeto de la UI
        }

        if (!TengoGelatina)
        {
            Gelatina.SetActive(false);                                          // Desactiva objeto de la UI
        }
    }






    #region Colliders

    private void OnTriggerEnter2D(Collider2D collision)                         //si colisiona con el objecto
    {
        if ((collision.gameObject.tag == "Gelatina")&&(!TengoGelatina))         // Al colisionar con objeto y "TengoGelatina" es falso
        {
            TengoGelatina = true;

            Debug.Log("AgarreGelatina");

            Destroy(collision.gameObject);                                      // Al colisionar con objeto, este mismo se destruye

        }

        if ((collision.gameObject.tag == "GelatinaDestino")&&(TengoGelatina))   // Al colisionar con objeto y "TengoGelatina" es verdadero
        {
            TengoGelatina = false;

            Debug.Log("DejeGelatina");

            LVLDelivery.SendMessage("GelatinaMenos");
        }

    }

    #endregion



    #region Gelatina Bool

    public void AgarreGelatina()
    {
        TengoGelatina = true;
    }

    public void PerdiGelatina()
    {
        TengoGelatina = false;
    }

    #endregion




}
