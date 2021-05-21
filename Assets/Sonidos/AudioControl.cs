using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class AudioControl : MonoBehaviour
{
    Scene NivelActual;

    public GameObject[] audios; // array de gameobjects

    public GameObject PlayerAll; // objeto del jugador con audios

    bool isMuted;

    int AudioMuteado;


    // Start is called before the first frame update
    void Start()
    {
        isMuted = PlayerPrefs.GetInt("MUTED") == 1;

        audios = GameObject.FindGameObjectsWithTag("AudioSource"); // busca objetos con audio por tags

        PlayerAll = GameObject.FindGameObjectWithTag("PlayerAll"); // busca al jugador por su tag

        for (int i = 0; i < audios.Length; i++)
        {
            audios[i].GetComponent<AudioSource>().mute = isMuted;
        }

        AudioMuteado = PlayerPrefs.GetInt("MUTED");

        NivelActual = SceneManager.GetActiveScene();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            Mute();




            if(isMuted)
            {


                print("Evento desactivar_musica: Nivel " + NivelActual.buildIndex);


                Analytics.CustomEvent("desactivar_musica", new Dictionary<string, object>
            {
                {"level_index", NivelActual.buildIndex },


            });


            }

            if (!isMuted)
            {




                print("Evento activar_musica: Nivel " + NivelActual.buildIndex);


                Analytics.CustomEvent("activar_musica", new Dictionary<string, object>
            {
                {"level_index", NivelActual.buildIndex },


            });


            }

        }
    }



    public void Mute()
    {


        isMuted = !isMuted;


        for (int i = 0; i < audios.Length; i++)
        {
            audios[i].GetComponent<AudioSource>().mute = isMuted;

        }


        PlayerPrefs.SetInt("MUTED", isMuted ? 1 : 0);

    }
}
