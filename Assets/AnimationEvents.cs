using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public GameObject PlayerAll;

    // Start is called before the first frame update
    void Start()
    {
        
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
}
