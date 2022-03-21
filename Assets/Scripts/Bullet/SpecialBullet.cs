using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBullet : MonoBehaviour
{
    public float speed = 4; //bullet speed
    public float destroyTime; //Time take for the bullet to destroy itself
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
        StartCoroutine(DestroySelf());
        
    }

    //Bullet Collision with Enemy
    //Destory itself and increase score
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            DoStatic.GetGameController().GetComponent<VariableController>().ChangeScore(100);
            Destroy(collision.gameObject); //Might need to change it if we want a explode animation when enemy get destroyed.
        }
    }

    private IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }
}
