using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float timeBTW; //the time between each shot
    public GameObject bullet; //bullet object
    public Transform firePosition; //Where the bullet will spawn
    private bool canShoot;  //detemine if the enemy can fire or not, based on the timeBTW variable
    private bool playerSpotted; //If the raycast hit the player
    private RaycastHit2D hit;

    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
        playerSpotted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerSpotted)
        {
            if (canShoot)
            {
                StartCoroutine(Shoot());
            }
        }
    }

    private IEnumerator Shoot()
    {
        canShoot = false;
        GameObject new_bullet = Instantiate(bullet, firePosition.position, Quaternion.identity);
        new_bullet.transform.up = transform.up.normalized;
        yield return new WaitForSeconds(timeBTW);
        canShoot = true;
    }


    void FixedUpdate()
    {
        //A raycast to check if the enemy spotted the player or not
        hit = Physics2D.Raycast(firePosition.position, Vector2.up);

        if (hit.collider != null)
        {
            //if it hits the player
            if (hit.collider.tag == "Player")
            {
                playerSpotted = true;
            }
            else
            {
                playerSpotted = false;
            }
        }
    }
}
