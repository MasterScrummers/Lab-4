using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 2; //bullet speed
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up * speed; //bullet being fired along y-axis of player

        //This is just a dummy for now, will be removed once we figure out perspective
        if (transform.position.y >= -0.2 && transform.position.y <= 0.2 && transform.position.x >= -0.2 && transform.position.x <= 0.2)
        {
            Destroy(gameObject); //Destroy bullet at center of screen
        }
    }

    //Bullet Collision with Enemy
    //Destory itself and increase score
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            DoStatic.GetGameController().GetComponent<VariableController>().ChangeScore(100);
            Destroy(collision.gameObject); //Might need to change it if we want a explode animation when enemy get destroyed.
            Destroy(gameObject);
        }
    }
}
