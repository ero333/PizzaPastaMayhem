using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPepinoManager : MonoBehaviour
{
    public enum GameState { Idle, Ataque, Muerto}

    public GameState estado = GameState.Idle;









    public float IdleTimeCD;                              // valor modificable                   
    public float IdleTimer;                             

    private float NumeroAzar;                           // variable para el numero al azar

    private bool muerto;


    [Header("Body y All")]
    public GameObject ObjectAll;                        // traer GameObject que contiene al body
    public GameObject ObjectBody;                       // traer GameObject donde está el sprite
    public GameObject PepinoVerticalPrefab;             // traer Pre-fab
    public GameObject PepinoHorizontalPrefab;           // traer pre-fab


    private Animator ObjectAnim;


    // Start is called before the first frame update
    void Start()
    {
        IdleTimer = IdleTimeCD;


        ObjectAnim = ObjectBody.GetComponent<Animator>();


        ObjectAnim.SetBool("PepinoMuere", false);

        muerto = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(estado == GameState.Idle)
        {
            CoolDownIdle();
        }


        if(estado == GameState.Muerto)
        {
            ObjectAnim.SetBool("PepinoMuere", true);
        }

        if(muerto == true)
        {
            estado = GameState.Muerto;
        }

    }





    #region Estados Especificos

    public void EstadoIdle()                              
    {
        estado = GameState.Idle;
    }

    public void EstadoAtaque()
    {
        estado = GameState.Ataque;
    }

    public void EstadoMuerto()
    {
        estado = GameState.Muerto;
    }

    #endregion

    public void Death()
    {
        muerto = true;
    }




    public void CoolDownIdle()
    {
        IdleTimer -= Time.deltaTime;

        if(IdleTimer<=0)
        {
            AtaqueAzar();

            estado = GameState.Ataque;
        }
    }



    public void AtaqueAzar()                                                       // metodo para que dropee items
    {
        NumeroAzar = Random.Range(0, 15);                                           // numero al azar

        if (NumeroAzar >=10)
        {

            IdleTimer = IdleTimeCD;

            ObjectAnim.Play("Pepino_Tornado");

            Debug.Log("nro " + NumeroAzar);
        }

        if (NumeroAzar < 10 && NumeroAzar >4) 
        {

            IdleTimer = IdleTimeCD;

            ObjectAnim.Play("Pepino_Lluvia");

            Debug.Log("nro " + NumeroAzar);
        }

        if (NumeroAzar <= 4)
        {
            IdleTimer = IdleTimeCD;

            ObjectAnim.Play("Pepino_Enjambre");

            Debug.Log("nro " + NumeroAzar);
        }

    }






    public void GenerarPepinosVerticales()
    {
        Object[] GeneradoresVerticales = GameObject.FindGameObjectsWithTag("PepinoVGen");     // llamar a todos los objetos con esta TAG

        foreach (GameObject Generador in GeneradoresVerticales)                                     // todos los generadores que haya en la escena
        {
            Instantiate(PepinoVerticalPrefab, Generador.transform.position, Quaternion.identity);    //Crea objeto. Orden de parentesis: qué objeto, dónde (o sobre qué objeto) y la rotación
        }
    }

    public void GenerarPepinosHorizontales()
    {
        Object[] GeneradoresVerticales = GameObject.FindGameObjectsWithTag("PepinoHGen");     // llamar a todos los objetos con esta TAG

        foreach (GameObject Generador in GeneradoresVerticales)                                     // todos los generadores que haya en la escena
        {
            Instantiate(PepinoHorizontalPrefab, Generador.transform.position, Quaternion.identity);    //Crea objeto. Orden de parentesis: qué objeto, dónde (o sobre qué objeto) y la rotación
        }
    }

}
