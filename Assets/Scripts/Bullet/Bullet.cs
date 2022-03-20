using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1.5f; //bullet speed
    private Rigidbody2D rb;
    private Vector3 originalScale;
    private Vector3 targetScale;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
        targetScale = new Vector3(0.01f, 0.02f, 0.01f); //y-axis slightly bigger to mimic depth distoriton
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up * speed; //bullet being fired along y-axis of player
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * speed); //Bullet getting smaller as it gets further away

        //This is just a dummy for now, will be removed once we figure out perspective
        if (transform.position.y >= -0.2 && transform.position.y <= 0.2 && transform.position.x >= -0.2 && transform.position.x <= 0.2)
        {
            Destroy(gameObject); //Destroy bullet at center of screen
        }
    }
}
