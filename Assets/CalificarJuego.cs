using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class CalificarJuego : MonoBehaviour
{
    public int Puntaje;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Puntaje = PlayerPrefs.GetInt("calificacion");


        if (Puntaje > 0)
        {
            gameObject.SetActive(false);
        }


        /*if(Input.GetKeyDown("c"))
        {
            PlayerPrefs.SetInt("calificacion", 0);

            Puntaje = 0;

            

            gameObject.SetActive(true);
        }*/
    }

    public void puntaje1()
    {
        PlayerPrefs.SetInt("calificacion", 1);

       

        Puntaje = 1;
        Mensaje();
        CalificacionAnalytics();
    }

    public void puntaje2()
    {
        PlayerPrefs.SetInt("calificacion", 2);



        Puntaje = 2;
        Mensaje();
        CalificacionAnalytics();
    }

    public void puntaje3()
    {
        PlayerPrefs.SetInt("calificacion", 3);

        Puntaje = 3;
        Mensaje();
        CalificacionAnalytics();
    }

    public void puntaje4()
    {
        PlayerPrefs.SetInt("calificacion", 4);

        Puntaje = 4;
        Mensaje();
        CalificacionAnalytics();
    }

    public void puntaje5()
    {
        PlayerPrefs.SetInt("calificacion", 5);


        Puntaje = 5;
        Mensaje();
        CalificacionAnalytics();
    }

    public void Mensaje()
    {


        print("puntuacion: " + Puntaje);
    }


    public void CalificacionAnalytics()
    {

        print("Evento calificacion: nota " + Puntaje);

        Analytics.CustomEvent("calificacion", new Dictionary<string, object>
            {
                {"nota", Puntaje },


            });
    }


}
