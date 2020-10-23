using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogosTest : MonoBehaviour
{
    public GameObject LvlManager;

    public int Numero;

    string[] Dialogo = new string[10];

    public Text Texto; 


    public GameObject NombrePj;

    public GameObject NombreViejo;




    [Header("Sprites Viejo")]

    public GameObject SpriteViejo1;
    public GameObject SpriteViejo2;
    public GameObject SpriteViejo3;
    public GameObject SpriteViejo4;
    public GameObject SpriteViejo5;

    [Header("Sprites Protagonista")]

    public GameObject SpritePj1;
    public GameObject SpritePj2;
    public GameObject SpritePj3;
    public GameObject SpritePj4;
    public GameObject SpritePj5;
    public GameObject SpritePj6;


    // Start is called before the first frame update
    void Start()
    {
        Numero = 0;

        LvlManager = GameObject.FindGameObjectWithTag("LVLMANAGER");
    }

    // Update is called once per frame
    void Update()
    {
        CadaDialogo();

        SpritePjManager();

        SpriteViejoManager();


        

        Texto.color = Color.black;

        if(Input.GetKeyDown("j"))
        {
            Numero++;
        }

        if(Numero==10)
        {
            LvlManager.SendMessage("Lvl5");
        }


    }

    public void CadaDialogo()
    {
        if(Numero <10 )
        {
            Texto.text = Dialogo[Numero];

            Dialogo[0] = "...";
            Dialogo[1] = "¡Uy!¡Creo que me perdí!";
            Dialogo[2] = "Mmmmh, tal vez en esta casa haya alguien.";
            Dialogo[3] = "¡¿Hola?!¡¿Hay alguien ahí?!";
            Dialogo[4] = "¿...?";
            Dialogo[5] = "¡¿Quién interrumpe mi siestaaaa?!";
            Dialogo[6] = "¡Yo te maldigooooo!";
            Dialogo[7] = "Hola señor, ¿podría decirme qué dirección debo tomar para salir de aqui?";
            Dialogo[8] = "¿¡Un HUMANO!?¡hace decenas de meses que no veía a otro humano!";
            Dialogo[9] = "Si logras conseguirme un poco de la gelatina que producen las criaturas, te dire por donde debes ir.";
        }

    }

    public void Siguiente()
    {
        Numero++;
    }


    public void SpritePjManager()
    {
        if(Numero == 0)
        {
            SpritePj1.SetActive(true);
        }

        if (Numero == 1)
        {
            SpritePj1.SetActive(false);
            SpritePj2.SetActive(true);
        }


        if (Numero == 2)
        {
            SpritePj2.SetActive(false);
            SpritePj3.SetActive(true);
        }

        if (Numero == 5)
        {
            SpritePj3.SetActive(false);
            SpritePj2.SetActive(true);
        }

        if (Numero == 7)
        {
            NombrePj.SetActive(true);
            NombreViejo.SetActive(false);

            SpritePj2.SetActive(false);
            SpritePj6.SetActive(true);
        }

        if (Numero == 8)
        {
            SpritePj6.SetActive(false);
            SpritePj3.SetActive(true);
        }

        if (Numero == 9)
        {
            SpritePj3.SetActive(false);
            SpritePj5.SetActive(true);
        }
    }


    public void SpriteViejoManager()
    {
        if(Numero==4)
        {
            SpriteViejo1.SetActive(false);
            SpriteViejo2.SetActive(true);
        }
        if (Numero == 5)
        {
            NombrePj.SetActive(false);
            NombreViejo.SetActive(true);

            SpriteViejo2.SetActive(false);
            SpriteViejo3.SetActive(true);
        }
        if (Numero == 6)
        {
            SpriteViejo3.SetActive(false);
            SpriteViejo4.SetActive(true);
        }
        if (Numero == 8)
        {
            NombrePj.SetActive(false);
            NombreViejo.SetActive(true);

            SpriteViejo4.SetActive(false);
            SpriteViejo5.SetActive(true);
        }
    }

}
