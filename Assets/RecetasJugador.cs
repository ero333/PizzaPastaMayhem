using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class RecetasJugador : MonoBehaviour
{
    Scene NivelActual;

    #region Ingredientes_Receta_1

    [Header("Variables Receta 1")]

    public bool Receta1 = false;

    public GameObject Pan;

    public GameObject Queso;

    public GameObject Paty;

    public GameObject TextoListo1;

    public int TengoPan;

    public int TengoQueso;

    public int TengoPaty;

    #endregion

    #region Ingredientes_Receta_2

    [Header("Variables Receta 2")]

    public bool Receta2 = false;

    public GameObject Jamon;

    public GameObject Salchichas;

    public GameObject Albondigas;

    public GameObject TextoListo2;

    public int TengoJamon;

    public int TengoSalchicha;

    public int TengoAlbondigas;

    #endregion

    #region Ingredientes_Receta_3

    [Header("Variables Receta 3")]

    public bool Receta3 = false;

    public GameObject Pollo;

    public GameObject Lechuga;

    public GameObject Tomates;

    public GameObject TextoListo3;

    public int TengoPollo;

    public int TengoLechuga;

    public int TengoTomate;

    #endregion

    string IngredienteObtenido;





    // Start is called before the first frame update
    void Start()
    {
        TengoPan = PlayerPrefs.GetInt("DropPan");
        TengoQueso = PlayerPrefs.GetInt("DropQueso");
        TengoPaty = PlayerPrefs.GetInt("DropPaty");

        TengoJamon = PlayerPrefs.GetInt("DropJamon");
        TengoSalchicha = PlayerPrefs.GetInt("DropSalchicha");
        TengoAlbondigas = PlayerPrefs.GetInt("DropAlbondiga");

        TengoTomate = PlayerPrefs.GetInt("DropTomate");
        TengoLechuga = PlayerPrefs.GetInt("DropLechuga");
        TengoPollo = PlayerPrefs.GetInt("DropPollo");


        NivelActual = SceneManager.GetActiveScene();

    }

    // Update is called once per frame
    void Update()
    {
        Receta1Lista();

        Receta2Lista();

        Receta3Lista();

        RecetasPrefUpdate();

        UIFunction();

    }

    #region RecetasListas
    public void Receta1Lista()
    {
        if ((TengoPan == 1) && (TengoPaty == 1) && (TengoQueso == 1))
        {
            Receta1 = true;
            
            SendMessage("TengoReceta1");

            TextoListo1.SetActive(true);

        }
    }

    public void Receta2Lista()
    {
        if ((TengoJamon == 1) && (TengoSalchicha == 1) && (TengoAlbondigas == 1))
        {
            Receta2 = true;

            SendMessage("TengoReceta2");

            TextoListo2.SetActive(true);

        }
    }

    public void Receta3Lista()
    {
        if ((TengoPollo == 1) && (TengoLechuga == 1) && (TengoTomate == 1))
        {
            Receta3 = true;

            SendMessage("TengoReceta3");

            TextoListo3.SetActive(true);

        }
    }
    #endregion


    #region colisiones
    private void OnCollisionEnter2D(Collision2D collision)  // si colisiona con objetos
    {
        #region receta1

        if ((collision.gameObject.tag == "DropPan"))
        {
            TengoPan = 1;

            Destroy(collision.gameObject); // Al colisionar con objeto, este mismo se destruye

            Pan.SetActive(true);

            IngredienteObtenido = collision.gameObject.tag;

            IngredientesAnalytics();
        }

        if ((collision.gameObject.tag == "DropPaty"))
        {
            TengoPaty = 1;

            Destroy(collision.gameObject); // Al colisionar con objeto, este mismo se destruye

            Paty.SetActive(true);

            IngredienteObtenido = collision.gameObject.tag;

            IngredientesAnalytics();
        }

        if ((collision.gameObject.tag == "DropQueso"))
        {
            TengoQueso = 1;

            Destroy(collision.gameObject); // Al colisionar con objeto, este mismo se destruye

            Queso.SetActive(true);

            IngredienteObtenido = collision.gameObject.tag;

            IngredientesAnalytics();
        }

        #endregion

        #region receta2
        if ((collision.gameObject.tag == "DropJamon"))
        {
            TengoJamon = 1;

            Destroy(collision.gameObject); // Al colisionar con objeto, este mismo se destruye

            Jamon.SetActive(true);

            IngredienteObtenido = collision.gameObject.tag;

            IngredientesAnalytics();
        }

        if ((collision.gameObject.tag == "DropSalchicha"))
        {
            TengoSalchicha = 1;

            Destroy(collision.gameObject); // Al colisionar con objeto, este mismo se destruye

            Salchichas.SetActive(true);

            IngredienteObtenido = collision.gameObject.tag;

            IngredientesAnalytics();
        }

        if ((collision.gameObject.tag == "DropAlbondigas"))
        {
            TengoAlbondigas = 1;

            Destroy(collision.gameObject); // Al colisionar con objeto, este mismo se destruye

            Albondigas.SetActive(true);

            IngredienteObtenido = collision.gameObject.tag;

            IngredientesAnalytics();
        }

        #endregion

        #region receta3
        if ((collision.gameObject.tag == "DropPollo"))
        {
            TengoPollo = 1;

            Destroy(collision.gameObject); // Al colisionar con objeto, este mismo se destruye

            Pollo.SetActive(true);

            IngredienteObtenido = collision.gameObject.tag;

            IngredientesAnalytics();
        }

        if ((collision.gameObject.tag == "DropTomate"))
        {
            TengoTomate = 1;

            Destroy(collision.gameObject); // Al colisionar con objeto, este mismo se destruye

            Tomates.SetActive(true);

            IngredienteObtenido = collision.gameObject.tag;

            IngredientesAnalytics();
        }

        if ((collision.gameObject.tag == "DropLechuga"))
        {
            TengoLechuga = 1;

            Destroy(collision.gameObject); // Al colisionar con objeto, este mismo se destruye

            Lechuga.SetActive(true);

            IngredienteObtenido = collision.gameObject.tag;

            IngredientesAnalytics();
        }
        #endregion

        #region items drop

        if ((collision.gameObject.tag == "DropHP"))
        {
            SendMessage("MasVida");

            Destroy(collision.gameObject);                  // Al colisionar con objeto, este mismo se destruye
        }

        if ((collision.gameObject.tag == "DropAmmo"))
        {
            SendMessage("MasMunicion");

            Destroy(collision.gameObject);                  // Al colisionar con objeto, este mismo se destruye
        }

        #endregion
    }
    #endregion

    #region Recetas Usadas

    #region receta1
    public void Receta1Usada()
    {
        Receta1 = false;

        TengoPan = 0;

        TengoPaty = 0;

        TengoQueso = 0;

        Pan.SetActive(false);

        Paty.SetActive(false);

        Queso.SetActive(false);

        TextoListo1.SetActive(false);
    }

    #endregion

    #region receta2

    public void Receta2Usada()
    {
        Receta2 = false;

        TengoAlbondigas = 0;

        TengoSalchicha = 0;

        TengoJamon = 0;

        Salchichas.SetActive(false);

        Albondigas.SetActive(false);

        Jamon.SetActive(false);

        TextoListo2.SetActive(false);
    }

    #endregion

    #region receta3

    public void Receta3Usada()
    {
        Receta3 = false;

        TengoLechuga = 0;

        TengoTomate = 0;

        TengoJamon = 0;

        Tomates.SetActive(false);

        Lechuga.SetActive(false);

        Pollo.SetActive(false);

        TextoListo3.SetActive(false);
    }
    #endregion


    #endregion

    #region Activacion de UI

    public void UIFunction()
    {
        #region Receta 1

        if (TengoPan==1)
        {
            Pan.SetActive(true);
        }

        if (TengoQueso == 1)
        {
            Queso.SetActive(true);
        }

        if (TengoPaty == 1)
        {
            Paty.SetActive(true);
        }

        if (TengoPan == 0)
        {
            Pan.SetActive(false);
        }

        if (TengoQueso == 0)
        {
            Queso.SetActive(false);
        }

        if (TengoPaty == 0)
        {
            Paty.SetActive(false);
        }

        #endregion

        #region Receta 2

        if (TengoSalchicha == 1)
        {
            Salchichas.SetActive(true);
        }

        if (TengoAlbondigas == 1)
        {
            Albondigas.SetActive(true);
        }

        if (TengoJamon == 1)
        {
            Jamon.SetActive(true);
        }

        if (TengoSalchicha == 0)
        {
            Salchichas.SetActive(false);
        }

        if (TengoAlbondigas == 0)
        {
            Albondigas.SetActive(false);
        }

        if (TengoJamon == 0)
        {
            Jamon.SetActive(false);
        }

        #endregion

        #region Receta 3

        if (TengoPollo == 1)
        {
            Pollo.SetActive(true);
        }

        if (TengoLechuga == 1)
        {
            Lechuga.SetActive(true);
        }

        if (TengoTomate == 1)
        {
            Tomates.SetActive(true);
        }

        if (TengoPollo == 0)
        {
            Pollo.SetActive(false);
        }

        if (TengoLechuga == 0)
        {
            Lechuga.SetActive(false);
        }

        if (TengoTomate == 0)
        {
            Tomates.SetActive(false);
        }

        #endregion



    }

    #endregion

    public void RecetasPrefUpdate()
    {
        PlayerPrefs.SetInt("DropPan", TengoPan);
        PlayerPrefs.SetInt("DropQueso", TengoQueso);
        PlayerPrefs.SetInt("DropPaty", TengoPaty);

        PlayerPrefs.SetInt("DropJamon", TengoJamon);
        PlayerPrefs.SetInt("DropSalchicha", TengoSalchicha);
        PlayerPrefs.SetInt("DropAlbondiga", TengoAlbondigas);

        PlayerPrefs.SetInt("DropTomate", TengoTomate);
        PlayerPrefs.SetInt("DropLechuga", TengoLechuga);
        PlayerPrefs.SetInt("DropPollo", TengoPollo);
    }




    public void IngredientesAnalytics()
    {
        //print(IngredienteObtenido.Remove(0,4));
        //print(NivelActual.buildIndex);


        Analytics.CustomEvent("usar_powerup", new Dictionary<string, object>
            {
                {"level_index", NivelActual.buildIndex },
                {"ingrediente", IngredienteObtenido.Remove(0,4) },


            });
    }
}

