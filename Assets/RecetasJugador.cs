using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecetasJugador : MonoBehaviour
{


    #region Ingredientes_Receta_1

    public GameObject Pan;

    public bool TengoPan = false;

    public GameObject Paty;

    public bool TengoPaty = false;

    public GameObject Queso;

    public bool TengoQueso = false;

    #endregion

    #region Ingredientes_Receta_2

    public GameObject Jamon;

    public bool TengoJamon = false;

    public GameObject Salchichas;

    public bool TengoSalchicha = false;

    public GameObject Albondigas;

    public bool TengoAlbondigas = false;

    #endregion

    #region Ingredientes_Receta_2

    public GameObject Pollo;

    public bool TengoPollo = false;

    public GameObject Lechuga;

    public bool TengoLechuga = false;

    public GameObject Tomates;

    public bool TengoTomate = false;

    #endregion

    public bool Receta1 = false;

    public bool Receta2 = false;

    public bool Receta3 = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Receta1Lista();

        Receta2Lista();

        Receta3Lista();
    }

    #region RecetasListas
    public void Receta1Lista()
    {
        if ((TengoPan == true) && (TengoPaty == true) && (TengoQueso == true))
        {
            Receta1 = true;
            
            SendMessage("TengoReceta1");

        }
    }

    public void Receta2Lista()
    {
        if ((TengoJamon == true) && (TengoSalchicha == true) && (TengoAlbondigas == true))
        {
            Receta2 = true;

            SendMessage("TengoReceta2");

        }
    }

    public void Receta3Lista()
    {
        if ((TengoPollo == true) && (TengoLechuga == true) && (TengoTomate == true))
        {
            Receta3 = true;

            SendMessage("TengoReceta3");

        }
    }
    #endregion


    #region colisiones
    private void OnCollisionEnter2D(Collision2D collision)  //si colisiona con plataforma
    {
        #region receta1

        if ((collision.gameObject.tag == "DropPan"))
        {
            TengoPan = true;

            Destroy(collision.gameObject); // Al colisionar con objeto, este mismo se destruye

            Pan.SetActive(true);
        }

        if ((collision.gameObject.tag == "DropPaty"))
        {
            TengoPaty = true;

            Destroy(collision.gameObject); // Al colisionar con objeto, este mismo se destruye

            Paty.SetActive(true);
        }

        if ((collision.gameObject.tag == "DropQueso"))
        {
            TengoQueso = true;

            Destroy(collision.gameObject); // Al colisionar con objeto, este mismo se destruye

            Queso.SetActive(true);
        }

        #endregion

        #region receta2
        if ((collision.gameObject.tag == "DropJamon"))
        {
            TengoJamon = true;

            Destroy(collision.gameObject); // Al colisionar con objeto, este mismo se destruye

            Jamon.SetActive(true);
        }

        if ((collision.gameObject.tag == "DropSalchicha"))
        {
            TengoSalchicha = true;

            Destroy(collision.gameObject); // Al colisionar con objeto, este mismo se destruye

            Salchichas.SetActive(true);
        }

        if ((collision.gameObject.tag == "DropAlbondigas"))
        {
            TengoAlbondigas = true;

            Destroy(collision.gameObject); // Al colisionar con objeto, este mismo se destruye

            Albondigas.SetActive(true);
        }

        #endregion

        #region receta3
        if ((collision.gameObject.tag == "DropPollo"))
        {
            TengoPollo = true;

            Destroy(collision.gameObject); // Al colisionar con objeto, este mismo se destruye

            Pollo.SetActive(true);
        }

        if ((collision.gameObject.tag == "DropTomate"))
        {
            TengoTomate = true;

            Destroy(collision.gameObject); // Al colisionar con objeto, este mismo se destruye

            Tomates.SetActive(true);
        }

        if ((collision.gameObject.tag == "DropLechuga"))
        {
            TengoLechuga = true;

            Destroy(collision.gameObject); // Al colisionar con objeto, este mismo se destruye

            Lechuga.SetActive(true);
        }
        #endregion
    }
    #endregion

    #region RecetasUsadas

    #region receta1
    public void Receta1Usada()
    {
        Receta1 = false;

        TengoPan = false;

        TengoPaty = false;

        TengoQueso = false;

        Pan.SetActive(false);

        Paty.SetActive(false);

        Queso.SetActive(false);
    }

    #endregion

    #region receta2

    public void Receta2Usada()
    {
        Receta2 = false;

        TengoAlbondigas = false;

        TengoSalchicha = false;

        TengoJamon = false;

        Salchichas.SetActive(false);

        Albondigas.SetActive(false);

        Jamon.SetActive(false);
    }

    #endregion

    #region receta3

    public void Receta3Usada()
    {
        Receta3 = false;

        TengoLechuga = false;

        TengoTomate = false;

        TengoJamon = false;

        Tomates.SetActive(false);

        Lechuga.SetActive(false);

        Pollo.SetActive(false);
    }
    #endregion


    #endregion
}

