using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorLevelLineal : MonoBehaviour
{

    public GameObject ParedesWin;                                               // traer gameobject correspondiente

    public GameObject Felicitaciones;                                           // traer gameobject correspondiente

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)                         //si colisiona con el objecto
    {
        if ((collision.gameObject.tag == "PlataformaWin"))                      // Al colisionar con objeto y "TengoGelatina" es falso
        {
            SendMessage("NivelCompleto");                                       // Al colisionar con objeto, envia mensaje al jugador

            ParedesWin.SetActive(true);

            Felicitaciones.SetActive(true);
        }

    }
}
