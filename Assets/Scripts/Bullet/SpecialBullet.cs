using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBullet : MonoBehaviour
{
    public float speed = 4; //bullet speed
    public float destroyTime; //Time takes for the bullet to destroy itself
    private Rigidbody2D rb;
    private VariableController vc;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        vc = DoStatic.GetGameController().GetComponent<VariableController>();
        destroyTime = 4;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up * speed; //bullet being fired along y-axis of player
        destroyTime -= Time.deltaTime;
        if (destroyTime <= 0)
        {
            DestroySelf();
        }

    }

    //Bullet Collision with Enemy
    //Destory itself and increase score
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
           collision.GetComponent<EnemyBehaviour>().health -= vc.specialBulletDamage;
        }
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
