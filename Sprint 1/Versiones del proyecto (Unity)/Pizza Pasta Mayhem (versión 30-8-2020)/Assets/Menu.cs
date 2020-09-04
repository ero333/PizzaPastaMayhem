using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameObject selectedPrincipal;
    public GameObject selectedOpciones;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EmpezarJuego()
    {
        SceneManager.LoadScene(1);
    }

    public void SetSelectedPrincipal()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(selectedPrincipal);
    }

    public void SetSelectedOpciones()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(selectedOpciones);
    }


}
