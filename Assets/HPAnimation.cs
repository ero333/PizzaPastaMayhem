using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPAnimation : MonoBehaviour
{

    public GameObject MarcoHP; // traer gameobject con los sprites

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = MarcoHP.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HPHit()
    {
        anim.Play("HP_Hit");
    }

    public void HPHeal()
    {
        anim.Play("HP_Heal");
    }
}
