using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelHorda : MonoBehaviour
{
    public GameObject UI_Pasaste; // traer gameobject con el mensaje de que pasaste el nivel

    public bool completado; // bool para detectar si el nivel está completado

    public GameObject LvlManager; // traer gameobject del lvl manager o llamarmo desde el start (busqueda por tag)

    public GameObject PlayerAll; // abajo, en el start, está el código que busca el objeto que contiene a todo el Player (busqueda por tag)

    public GameObject PlayerBody; // abajo, en el start, está el código que busca el objeto que contiene el body del player (busqueda por tag)

    public float Timer = 0; // numero manual

    public Text Cronometro; // traer objeto de texto con cronometro

    public Text Sobrevive;

    public bool MsgEnviado;


    // Start is called before the first frame update
    void Start()
    {
        PlayerAll = GameObject.FindGameObjectWithTag("PlayerAll"); // (busqueda por tag)

        PlayerBody = GameObject.FindGameObjectWithTag("Player"); // (busqueda por tag)

        LvlManager = GameObject.FindGameObjectWithTag("LVLMANAGER"); // (busqueda por tag)

        completado = false;

        MsgEnviado = false;

        HordaGeneratorStart();
    }

    // Update is called once per frame
    void Update()
    {
        CountDown();

        Cronometro.text = Timer.ToString("0"); // muestra el número del cronometro como texto con numeros enteros

        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            Sobrevive.gameObject.SetActive(false);
        }

        if (completado && !MsgEnviado)
        {
            PlayerAll.SendMessage("NivelCompleto"); // envia mensaje al jugador

            MsgEnviado = true;
        }

    }

    public void CountDown() // metodo con el timer
    {
        if (Timer > 0) // si el tiempo es mayor a 0
        {
            Timer -= Time.deltaTime; // el tiempo del timer se resta por segundo
        }

        if ((Timer <= 0) && (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)) // si el timer llega a 0
        {
            UI_Pasaste.SetActive(true); // activa Interfaz de que ganaste

            completado = true; // activa bool

            //PlayerAll.SendMessage("NivelCompleto"); // envia mensaje al jugador

            Cronometro.gameObject.SetActive(false); // destruye el cronometro
        }

        if(Timer <= 0)
        {
            HordaGeneratorStop();
        }

    }

    public void HordaGeneratorStart()
    {
        Object[] Generadores = GameObject.FindGameObjectsWithTag("GeneradorDeHorda");  //llamar a todos los objetos con esta TAG

        foreach(GameObject Generador in Generadores) //todos los generadores que haya en la escena
        {
            Generador.SendMessage("startGen");
        }
    }

    public void HordaGeneratorStop()
    {
        Object[] Generadores = GameObject.FindGameObjectsWithTag("GeneradorDeHorda");  //llamar a todos los objetos con esta TAG

        foreach (GameObject Generador in Generadores) //todos los generadores que haya en la escena
        {
            //Generador.SendMessage("stopGen");

            Destroy(Generador);
        }
    }

}
