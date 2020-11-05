using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public GameObject PlayerAll; //objeto que contiene a todo el jugador

    // Start is called before the first frame update
    void Start()
    {
        PlayerAll = GameObject.FindGameObjectWithTag("PlayerAll"); // busqueda del objeto por Tag
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Limbo()
    {
        PlayerAll.SendMessage("Limbo");
    }

    public void ReviveIdle()
    {
        PlayerAll.SendMessage("AnimacionIdle");

        PlayerAll.SendMessage("ItsAlive");
    }

    public void NOAtaca()
    {
        PlayerAll.SendMessage("JugadorNoAtaca");
    }

    public void PowerShot()
    {
        PlayerAll.SendMessage("PowerProyectil");
    }

    public void Melee()
    {
        PlayerAll.SendMessage("CrearGolpe");
    }

    public void GenerarAmenaza()
    {
        PlayerAll.SendMessage("ThreatGenerator");
    }

    public void DestruirAmenaza()
    {
        PlayerAll.SendMessage("DestroyThreat");
    }

    public void ResetLevel()
    {
        PlayerAll.SendMessage("ReiniciarScene");
    }

    public void NivelCompleto()
    {
        PlayerAll.SendMessage("NivelCompleto");
    }

    public void ObtenerCoordenadas()
    {
        PlayerAll.SendMessage("Coordenadas");
    }

}
