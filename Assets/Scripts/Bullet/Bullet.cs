using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1.5f; //bullet speed
    private Rigidbody2D rb;
    private Vector3 targetScale;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetScale = new Vector3(0.01f, 0.02f, 0.01f); //y-axis slightly bigger to mimic depth distoriton
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up * speed; //bullet being fired along y-axis of player
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * speed); //Bullet getting smaller as it gets further away

        if (transform.localScale.x <= (targetScale.x+0.005))
        {
            //Destory the upgraded bullet parent object
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(gameObject); //Destroy bullet itself
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
