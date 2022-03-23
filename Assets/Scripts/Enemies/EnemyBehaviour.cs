using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private float timeBTW; //the time between each shot
    public GameObject bullet; //bullet object
    public Transform firePosition; //Where the bullet will spawn
    private bool canShoot;  //detemine if the enemy can fire or not, based on the timeBTW variable
    public int health;
    //private bool playerSpotted; //If the raycast hit the player
    //private RaycastHit2D hit;
    private VariableController vc;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
        vc = DoStatic.GetGameController().GetComponent<VariableController>();
        //playerSpotted = false;
    }

    // Update is called once per frame
    void Update()
    {
        //If canShoot = true
        if(canShoot)
        {
            Shoot();
            //Assign a random time for enemy fire rate
            timeBTW = Random.Range(0.5f, 2.0f);
        }
        
        //Set can Shoot to true again, if the timeBTW variable = 0
        timeBTW -= Time.deltaTime;
        if (timeBTW <= 0)
        {
            canShoot = true;
        }

        //Destroy itself if health is below 0
        if (health <= 0)
        {
            Die();
        }
    }

    //Shoot A bullet
    private void Shoot()
    {
        canShoot = false;
        GameObject new_bullet = Instantiate(bullet, firePosition.position, Quaternion.identity);
        new_bullet.transform.up = transform.up.normalized; 
    }

    //Destroy itself
    private void Die()
    {
        vc.ChangeScore(score);
        Destroy(gameObject);
    }

    //IEnumerator can be expansive, so I decided to not use it anymore. Can be re-used if needed.
    /*
    private IEnumerator Shoot()
    {
        canShoot = false;
        GameObject new_bullet = Instantiate(bullet, firePosition.position, Quaternion.identity);
        new_bullet.transform.up = transform.up.normalized;
        yield return new WaitForSeconds(timeBTW);
        canShoot = true;
    }
    */

    //Raycast Disabled 
    /*
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
    */
}
