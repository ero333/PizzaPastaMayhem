using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPanRunner : MonoBehaviour
{

    public GameObject PlataformasDestructibles;

    public GameObject Felicitaciones;

    public Transform PlayerPosition;

    public GameObject PanGigante;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DestruirPlataformas()
    {
        PlataformasDestructibles.SetActive(false);
    }

    public void AparecerPlataformas()
    {
        PlataformasDestructibles.SetActive(true);
    }

    public void LevelCompletado()
    {
        Felicitaciones.SetActive(true);
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PanGigante.SendMessage("ResetPosition");

            AparecerPlataformas();

        }
    }
}
