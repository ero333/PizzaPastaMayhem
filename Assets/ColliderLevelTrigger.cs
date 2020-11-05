using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderLevelTrigger : MonoBehaviour
{
    Scene NivelActual;

    // Start is called before the first frame update
    void Start()
    {
        NivelActual = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")                             // si colisiona con un objeto con el tag mensionado
        {
            collision.SendMessage("NivelCompleto");
            //print("nivel completado");
            SceneManager.LoadScene(NivelActual.buildIndex + 1);
        }
    }
}
