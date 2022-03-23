using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 2; //bullet speed
    private Rigidbody2D rb;
    private VariableController vc;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        vc = DoStatic.GetGameController().GetComponent<VariableController>();
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
            collision.GetComponent<EnemyBehaviour>().health -= vc.bulletDamage;
            Debug.Log(collision.GetComponent<EnemyBehaviour>().health);
            Destroy(gameObject);
        }
    }
}
