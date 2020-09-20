using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordaEnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;  //arrastrar el prefab del enemigo aca

    public float timer = 4f; // cada cuanto tiempo van a aparecer




    public bool Muchos = false;
    public float VelocidadDeAparicionHorda = 1; // velocidad en la que aparecen los enemigos





    public float DuracionDeHorda = 3f;
    public float TiempoDeHorda;
    public float DuracionPausa = 6f;

    public bool HordaOn = false;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TimerDeHorda();

    }

    public void CreateEnemy()
    {

        Instantiate(enemyPrefab, transform.position, Quaternion.identity); // genera al enemigo

    }

    public void startGen()
    {

        if (Muchos == true)
        {
            HordaOn = true;

            TiempoDeHorda = DuracionDeHorda;
        }

        if (HordaOn == true)
        {
            InvokeRepeating("CreateEnemy", 0f, VelocidadDeAparicionHorda); // utiliza el metodo de generar enemigos a partir de que tiempo, y cada cuanto tiempo
        }


        if (Muchos == false)
        {
            InvokeRepeating("CreateEnemy", 0f, timer); // utiliza el metodo de generar enemigos a partir de que tiempo, y cada cuanto tiempo
        }
    }

    public void stopGen()
    {
        CancelInvoke("CreateEnemy"); // cancela el generar enemigos

    }


    private void TimerDeHorda()
    {
        if (HordaOn == true) // tiempo de spawning
        {

            if (TiempoDeHorda > 0)
            {
                TiempoDeHorda -= Time.deltaTime;
            }
            else if (TiempoDeHorda <= 0)
            {
                HordaOn = false;

                CancelInvoke("CreateEnemy");
            }

        }

        if (HordaOn == false) // Tiempo de pausa
        {

            TiempoDeHorda += Time.deltaTime;


            if (TiempoDeHorda > DuracionPausa)
            {
                TiempoDeHorda = DuracionDeHorda;

                HordaOn = true;

                InvokeRepeating("CreateEnemy", 0f, VelocidadDeAparicionHorda); // utiliza el metodo de generar enemigos a partir de que tiempo, y cada cuanto tiempo
            }

        }
    }


}
