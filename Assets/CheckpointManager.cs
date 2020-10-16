using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public GameObject Checkpoint;

    Object[] CheckpointOff;


    // Start is called before the first frame update
    void Start()
    {
        CheckpointOff = GameObject.FindGameObjectsWithTag("Checkpoint");
    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.FindGameObjectsWithTag("Checkpoint").Length == 0) // detecta si hay enemigos en la escena actual
        {
            Checkpoint.SetActive(true);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "PlayerAll")                             // si colisiona con un objeto con el tag mensionado
        {


            foreach (GameObject Checkpoints in CheckpointOff) //todos los generadores que haya en la escena
            {
                Destroy(Checkpoints.gameObject);
            }
        }
    }
}