using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;          //arrastrar el prefab del enemigo aca



    public bool HordaStart;                 // bool que permite prender o apagar la Horda



    public int EnemigosAGenerar;            // Cantidad de enemigos que van a generarse
    public int EnemigosGenerandose;         // Cantidad de enemigos que se han generado en la wave
    public int TotalEnemigosGenerados;      // Cantidad total de enemigos generados por el objecto con este script



    public float Contador;                  // Timer
    public float EntreSpawn;                // Tiempo de espera de un Spawn a otro
    public float TiempoPausa;               // Tiempo de pausa de Wave a Wave

    public bool DestroyAfterWave = true;

    // Start is called before the first frame update 
    void Start()
    {
        Contador = TiempoPausa - 1 ;                       // Timer empieza en 0
        HordaStart = false;                 // La Horda empieza apagada
        EnemigosGenerandose = 0;
        TotalEnemigosGenerados = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Horda();                            // Llama al método de la Horda
    }

    public void CreateEnemy()
    {

        Instantiate(enemyPrefab, transform.position, Quaternion.identity); // genera al enemigo

    }

    public void startGen()
    {

        HordaStart = true;                  // La Horda empieza a funcionar


    }

    public void Horda()
    {
        if (HordaStart)
        {

            if (EnemigosGenerandose < EnemigosAGenerar) // Si la cantidad de enemigos generados es menor a la cantidad que se tiene que generar
            {
                Contador += Time.deltaTime; // Empieza Timer
            }

            if(Contador>=EntreSpawn)        // Si el Timer supera el tiempo de generacion de los enemigos
            {
                Contador = 0;               // Reinicia Timer

                EnemigosGenerandose++;      // La cuenta de enemigos generandose aumenta

                TotalEnemigosGenerados++;   // La cuenta de enemigos generados (total) aumenta


                CreateEnemy();              // Llama al método para generar enemigos


            }

            if(EnemigosGenerandose == EnemigosAGenerar) // Si la cantidad de enemigos generados es igual a la cantidad que se tiene que generar
            {
                HordaStart = false;         // La Horda deja de funcionar

                Contador = 0;               // Reinicia Timer

                if(DestroyAfterWave==true)
                {
                    Destroy(gameObject);
                }
            }



        }

        if (HordaStart == false)            // Si la Horda deja de funcionar, empieza proceso de pausa
        {
            Contador += Time.deltaTime;     // Empieza timer


            if (Contador >= TiempoPausa)    // Si el Timer alcanza/supera el valor del tiempo de pausa
            {
                HordaStart = true;          // La Horda empieza a funcionar

                Contador = 0;               // Reinicia timer

                EnemigosGenerandose = 0;    // Reinicio del contador de enemigos que se está generando
            }
        }
    }




}
