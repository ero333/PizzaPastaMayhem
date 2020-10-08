using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PepinoVertical : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rbd2;

    public float BalaDestroy = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        rbd2 = GetComponent<Rigidbody2D>();

        rbd2.velocity = Vector2.down * speed;

        Destroy(gameObject, BalaDestroy);

        transform.rotation = Quaternion.Euler(0, 0, 90);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
