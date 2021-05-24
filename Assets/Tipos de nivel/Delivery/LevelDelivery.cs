using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelDelivery : MonoBehaviour
{
    [Header("Level")]

    public GameObject UI_Pasaste;                                           // traer gameobject con el mensaje de que pasaste el nivel

    public GameObject LvlManager;                                           // traer gameobject del lvl manager o llamarmo desde el start (busqueda por tag)

    public bool completado;                                                 // bool para detectar si el nivel está completado

    [Header("Jugador")]

    public GameObject PlayerAll;                                            // abajo, en el start, está el código que busca el objeto que contiene a todo el Player (busqueda por tag)

    public GameObject PlayerBody;                                           // abajo, en el start, está el código que busca el objeto que contiene el body del player (busqueda por tag)

    [Header("Contador")]

    public Text ContadorJugador;                                            // traer texto que va a ir cambiando

    public Text ContadorTotal;                                              // traer objeto de texto con numero total de gelatinas
    
    public float TotalContador;                                             // numero total de las gelatinas

    public float JugadorContador;                                           // Numero de las gelatinas que va agarrando el jugador

    public bool MsgEnviado;

    // Start is called before the first frame update
    void Start()
    {
        PlayerAll = GameObject.FindGameObjectWithTag("PlayerAll");          // (busqueda por tag)

        PlayerBody = GameObject.FindGameObjectWithTag("Player");            // (busqueda por tag)

        LvlManager = GameObject.FindGameObjectWithTag("LVLMANAGER");        // (busqueda por tag)

        completado = false;

        ObjetosARecolectar();

        JugadorContador = 0;

        MsgEnviado = false;

    }

    // Update is called once per frame
    void Update()
    {
        ContadorTotal.text = TotalContador.ToString("0");

        ContadorJugador.text = JugadorContador.ToString("0");


        if (JugadorContador == TotalContador) 
        {
            UI_Pasaste.SetActive(true);                                     // activa Interfaz de que ganaste

            completado = true;                                              // activa bool

            //PlayerAll.SendMessage("NivelCompleto");                         // envia mensaje al jugador


        }

        if (completado && !MsgEnviado)
        {
            //PlayerAll.SendMessage("NivelCompleto");                         // envia mensaje al jugador
            MsgEnviado = true;
        }


        if (Input.GetKeyDown("g"))
        {
            GelatinaMenos();
        }
    }










    public void ObjetosARecolectar()                                        // busca todos los objetos que se tendrán que recolectar en el nivel
    {
        Object[] Gelatinas = GameObject.FindGameObjectsWithTag("Gelatina"); // llamar a todos los objetos con esta TAG

        foreach (GameObject Gelatina in Gelatinas)                          // Por cada objeto que haya, suma 1 a la variable
        {
            TotalContador++;
        }

    }

    public void GelatinaMenos()
    {
        if (JugadorContador < TotalContador)
        {
            JugadorContador++;
        }
    }


}
