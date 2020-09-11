using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretVarianteManager : MonoBehaviour
{
    public bool PlayerInRange = false; // bool que cambia si el jugador entra en el campo de vision

    public GameObject player; //En el start puse que busque al jugador, sino traer objeto del jugador	

    public GameObject TurretBody;   //traer objeto con sprite del enemigo

    public GameObject TurretAll; // traer objeto que contiene a toda la torreta

    public Transform Aceituna1; // traer objeto de la aceituna donde se genera la bala

    public Transform Aceituna2; // traer objeto de la aceituna donde se genera la bala

    public Transform Aceituna3; // traer objeto de la aceituna donde se genera la bala

    public GameObject MorronPrefab; // traer el prefab de la bala

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
        Mirada();
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




    public void Mirada()
    {
        if (player.transform.position.x < transform.position.x)
        {
            TurretBody.GetComponent<SpriteRenderer>().flipX = false;
            Aceituna1.transform.rotation = Quaternion.Euler(0, 0, 0); // el enemigo se queda en su forma inicial
            Aceituna2.transform.rotation = Quaternion.Euler(0, 0, 0); // el enemigo se queda en su forma inicial
            Aceituna3.transform.rotation = Quaternion.Euler(0, 0, 0); // el enemigo se queda en su forma inicial
        }

        else
        {
            TurretBody.GetComponent<SpriteRenderer>().flipX = true;
            Aceituna1.transform.rotation = Quaternion.Euler(0, 180, 0); // el enemigo se queda en su forma inicial
            Aceituna2.transform.rotation = Quaternion.Euler(0, 180, 0); // el enemigo se queda en su forma inicial
            Aceituna3.transform.rotation = Quaternion.Euler(0, 180, 0); // el enemigo se queda en su forma inicial
        }
    }

    #region Disparos
    public void EstaDisparando()
    {
        TurretAnim.SetBool("EnRango", true);

    }

    public void NoEstaDisparando()
    {
        TurretAnim.SetBool("EnRango", false);
    }
    public void DisparoDeMorron()
    {
        Instantiate(MorronPrefab, Aceituna1.position, Quaternion.identity);    //Crea objeto. Orden de parentesis: qué objeto, dónde (o sobre qué objeto) y la rotación

        Instantiate(MorronPrefab, Aceituna2.position, Quaternion.identity);    //Crea objeto. Orden de parentesis: qué objeto, dónde (o sobre qué objeto) y la rotación

        Instantiate(MorronPrefab, Aceituna3.position, Quaternion.identity);    //Crea objeto. Orden de parentesis: qué objeto, dónde (o sobre qué objeto) y la rotación
    }
    #endregion

    #region Animaciones
    public void AnimacionIdle()
    {
        TurretAnim.Play("Aceituna_Idle");
    }

    public void AnimacionMuerte()
    {
        TurretAnim.Play("Aceituna_Muere");
    }

    public void AnimacionDisparo()
    {
        TurretAnim.Play("Aceituna_Dispara");
    }

    #endregion

    public void Desaparece()
    {
        Destroy(gameObject);
    }
}