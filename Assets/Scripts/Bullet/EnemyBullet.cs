using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 2; //bullet speed
    private Rigidbody2D rb;
    public float destroyTime; //Time takes for the bullet to destroy itself
    private VariableController vc;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        vc = DoStatic.GetGameController().GetComponent<VariableController>();
        destroyTime = 3;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up * speed; //bullet being fired along y-axis of enemy
        destroyTime -= Time.deltaTime;
        if (destroyTime <= 0)
        {
            DestroySelf();
        }
    }

    //Bullet Collision with the player (decrease life)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            vc.DecrementLife();
            Destroy(gameObject);

            if (vc.lives <= 0)
            {
                Destroy(collision.gameObject);
            }
        }
    }

    //Bullet Destroy itsel
    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
