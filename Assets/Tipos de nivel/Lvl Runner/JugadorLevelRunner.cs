using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorLevelRunner : MonoBehaviour
{

    public Transform ThreatGen;                                                 // traer gameobject correspondiente

    public GameObject ThreatPan;                                                // traer gameobject correspondiente

    public GameObject ThreatLava;                                               // traer gameobject correspondiente

    public GameObject ParedesWin;                                               // traer gameobject correspondiente

    public GameObject Felicitaciones;                                           // traer gameobject correspondiente

    public bool RunnerHorizontal = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AmenazaGen()
    {
        Debug.Log("GenFunciona");

        if(RunnerHorizontal==true)
        {
            Instantiate(ThreatPan, ThreatGen.position, Quaternion.identity);    //Crea objeto. Orden de parentesis: qué objeto, dónde (o sobre qué objeto) y la rotación
        }

        if (RunnerHorizontal==false)
        {
            Instantiate(ThreatLava, ThreatGen.position, Quaternion.identity);   //Crea objeto. Orden de parentesis: qué objeto, dónde (o sobre qué objeto) y la rotación
        }
    }



    #region Colliders

    private void OnTriggerEnter2D(Collider2D collision)                         //si colisiona con el objecto
    {
        if ((collision.gameObject.tag == "PlataformaWin"))                      // Al colisionar con objeto y "TengoGelatina" es falso
        {
            SendMessage("NivelCompleto");                                       // Al colisionar con objeto, envia mensaje al jugador

            ParedesWin.SetActive(true);

            Felicitaciones.SetActive(true);
        }

    }

    #endregion
}
