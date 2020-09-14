using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordaEnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;  //arrastrar el prefab del enemigo aca

    public float timer = 4f; // cada cuanto tiempo van a aparecer
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void CreateEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity); // genera al enemigo
    }

    public void startGen()
    {
        InvokeRepeating("CreateEnemy", 0f, timer); // utiliza el metodo de generar enemigos a partir de que tiempo, y cada cuanto tiempo
    }

    public void stopGen()
    {
        CancelInvoke("CreateEnemy"); // cancela el generar enemigos

    }
}
