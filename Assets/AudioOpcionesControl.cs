using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOpcionesControl : MonoBehaviour
{
    public GameObject BotonMuteOn;

    public GameObject BotonMuteOff;

    public bool isMuted;

    public bool isNotMuted;


    // Start is called before the first frame update
    void Start()
    {
        isMuted = PlayerPrefs.GetInt("MUTED") == 1;

        isNotMuted = PlayerPrefs.GetInt("MUTED") == 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMuted)
        {
            BotonMuteOff.SetActive(true);
            BotonMuteOn.SetActive(false);
        }
        if(isNotMuted)
        {
            BotonMuteOn.SetActive(true);
            BotonMuteOff.SetActive(false);
        }
    }
}
