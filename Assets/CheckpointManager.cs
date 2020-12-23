using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class CheckpointManager : MonoBehaviour
{
    //public GameObject Checkpoint;

    Object[] CheckpointOff;

    Scene NivelActual;

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        NivelActual = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        CheckpointOff = GameObject.FindGameObjectsWithTag("Checkpoint");

        if (GameObject.FindGameObjectsWithTag("Checkpoint").Length == 0) // detecta si hay enemigos en la escena actual
        {
            //Checkpoint.SetActive(true);

            //Instantiate(Checkpoint, transform.position, Quaternion.identity);

            //Destroy(gameObject);

            //this.transform.gameObject.tag = "Checkpoint";

            //this.GetComponent<BoxCollider2D>().enabled = false;
        }

        Player = GameObject.FindGameObjectWithTag("PlayerAll");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "PlayerAll")                             // si colisiona con un objeto con el tag mensionado
        {


            foreach (GameObject Checkpoints in CheckpointOff) //todos los generadores que haya en la escena
            {
                Destroy(Checkpoints.gameObject);
            }

            this.transform.gameObject.tag = "Checkpoint";

            this.GetComponent<BoxCollider2D>().enabled = false;

            CheckpointAnalytics();

        }
    }

    void CheckpointAnalytics()
    {
        Player.SendMessage("AnalyticsCheckpoint");
    }
}