using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDefaultManager : MonoBehaviour
{
    public bool PlayerInRange = false; // bool que cambia si el jugador entra en el campo de vision

    public GameObject player; //En el start puse que busque al jugador, sino traer objeto del jugador	

    public GameObject TurretBody;   //traer objeto con sprite del enemigo

    public GameObject TurretAll; // traer objeto que contiene a toda la torreta

    public GameObject BalaAlbondiga; // traer pre-fab de la albondiga

    public Transform AlbondigaGen; // traer objeto donde apareceran las albondigas

    private Animator TurretAnim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerAll");

        TurretAnim = TurretBody.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Vision()
    {
        if (!PlayerInRange)
        {
            PlayerInRange = true;
        }


        else
        {
            PlayerInRange = false;
        }
    }


    public void EstaDisparando()
    {
        TurretAnim.SetBool("EnRango", true);
    }

    public void NoEstaDisparando()
    {
        TurretAnim.SetBool("EnRango", false);
    }

    public void DisparoDeAlbondiga()
    {
        Instantiate(BalaAlbondiga, AlbondigaGen.position, Quaternion.identity);    //Crea objeto. Orden de parentesis: qué objeto, dónde (o sobre qué objeto) y la rotación
    }


    #region Animaciones
        public void AnimacionIdle()
    {
        TurretAnim.Play("Fideo_Idle");
    }

    public void AnimacionMuerte()
    {
        TurretAnim.Play("Fideo_Muere");
        //print("death");
    }

    public void AnimacionDisparo()
    {
        TurretAnim.Play("Fideo_Dispara");
    }

    #endregion

    public void Desaparece()
    {
        Destroy(gameObject);
        Destroy(TurretAll);
    }
}
