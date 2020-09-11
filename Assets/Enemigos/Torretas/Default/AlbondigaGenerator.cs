using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlbondigaGenerator : MonoBehaviour
{
    public GameObject enemyBulletPrefab;  //arrastrar el prefab del enemigo aca

    public float timer = 4f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    void CreateEnemy()
    {
        Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity); // crea pre-fab del enemigo en el lugar de este mismo objeto
    }

    void startGen()
    {
        InvokeRepeating("CreateEnemy", 0f, timer); // llama al método de arriba, empieza a dispararse de una y en cuanto tiempo se repite
    }

    void stopGen()
    {
        CancelInvoke("CreateEnemy"); // cancela los spawns del método
    }
}
