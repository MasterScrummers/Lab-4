using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 2;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up * speed;

        //This is just a dummy for now, will be removed once we figure out perspective
        if (transform.position.y >= -0.2 && transform.position.y <= 0.2 && transform.position.x >= -0.2 && transform.position.x <= 0.2)
        {
            Destroy(gameObject); //Destroy bullet at center of screen
        }
    }
}
