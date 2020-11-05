using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueoNiveles : MonoBehaviour
{
    public GameObject Boton1;
    public GameObject Boton2;
    public GameObject Boton3;
    public GameObject Boton4;
    public GameObject Boton5;
    public GameObject Boton6;
    public GameObject Boton7;
    public GameObject Boton8;
    public GameObject Boton9;
    public GameObject Boton10;
    public GameObject Boton11;
    public GameObject Boton12;
    public GameObject Boton13;

    public int NivelAlcanzado_1;
    public int NivelAlcanzado_2;
    public int NivelAlcanzado_3;
    public int NivelAlcanzado_4;
    public int NivelAlcanzado_5;
    public int NivelAlcanzado_6;
    public int NivelAlcanzado_7;
    public int NivelAlcanzado_8;
    public int NivelAlcanzado_9;
    public int NivelAlcanzado_10;
    public int NivelAlcanzado_11;
    public int NivelAlcanzado_12;
    public int NivelAlcanzado_13;

    // Start is called before the first frame update
    void Start()
    {
        Object[] Botones = GameObject.FindGameObjectsWithTag("Botón");

        foreach (GameObject Boton in Botones) 
        {

            Boton.SetActive(false);
        }

        Boton1.SetActive(true);





        NivelAlcanzado_1 = PlayerPrefs.GetInt("DesbloqueasteNivel_1");
        NivelAlcanzado_2 = PlayerPrefs.GetInt("DesbloqueasteNivel_2");
        NivelAlcanzado_3 = PlayerPrefs.GetInt("DesbloqueasteNivel_3");
        NivelAlcanzado_4 = PlayerPrefs.GetInt("DesbloqueasteNivel_4");
        NivelAlcanzado_5 = PlayerPrefs.GetInt("DesbloqueasteNivel_5");
        NivelAlcanzado_6 = PlayerPrefs.GetInt("DesbloqueasteNivel_6");
        NivelAlcanzado_7 = PlayerPrefs.GetInt("DesbloqueasteNivel_7");
        NivelAlcanzado_8 = PlayerPrefs.GetInt("DesbloqueasteNivel_8");
        NivelAlcanzado_9 = PlayerPrefs.GetInt("DesbloqueasteNivel_9");
        NivelAlcanzado_10 = PlayerPrefs.GetInt("DesbloqueasteNivel_10");
        NivelAlcanzado_11 = PlayerPrefs.GetInt("DesbloqueasteNivel_11");
        NivelAlcanzado_12 = PlayerPrefs.GetInt("DesbloqueasteNivel_12");
        NivelAlcanzado_13 = PlayerPrefs.GetInt("DesbloqueasteNivel_13");
    }

    // Update is called once per frame
    void Update()
    {
        NivelesDesbloqueados();


        if (Input.GetKeyDown("c"))
        {
            //print("bonk");

            CheatDesbloquear();


        }



    }

    void NivelesDesbloqueados()
    {
        if (NivelAlcanzado_1 == 1)
        {
            Boton1.SetActive(true);
        }

        if (NivelAlcanzado_2 == 1)
        {
            Boton2.SetActive(true);
        }

        if (NivelAlcanzado_3 == 1)
        {
            Boton3.SetActive(true);
        }

        if (NivelAlcanzado_4 == 1)
        {
            Boton4.SetActive(true);
        }

        if (NivelAlcanzado_5 == 1)
        {
            Boton5.SetActive(true);
        }

        if (NivelAlcanzado_6 == 1)
        {
            Boton6.SetActive(true);
        }

        if (NivelAlcanzado_7 == 1)
        {
            Boton7.SetActive(true);
        }

        if (NivelAlcanzado_8 == 1)
        {
            Boton8.SetActive(true);
        }

        if (NivelAlcanzado_9 == 1)
        {
            Boton9.SetActive(true);
        }

        if (NivelAlcanzado_10 == 1)
        {
            Boton10.SetActive(true);
        }

        if (NivelAlcanzado_11 == 1)
        {
            Boton11.SetActive(true);
        }

        if (NivelAlcanzado_12 == 1)
        {
            Boton12.SetActive(true);
        }

        if (NivelAlcanzado_13 == 1)
        {
            Boton13.SetActive(true);
        }
    }

    void CheatDesbloquear()
    {
        Boton1.SetActive(true);
        Boton2.SetActive(true);
        Boton3.SetActive(true);
        Boton4.SetActive(true);
        Boton5.SetActive(true);
        Boton6.SetActive(true);
        Boton7.SetActive(true);
        Boton8.SetActive(true);
        Boton9.SetActive(true);
        Boton10.SetActive(true);
        Boton11.SetActive(true);
        Boton12.SetActive(true);
        Boton13.SetActive(true);

    }



}
