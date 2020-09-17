using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    public GameObject[] audios; // array de gameobjects

    public GameObject PlayerAll; // objeto del jugador con audios

    bool isMuted;

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



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            Mute();
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
