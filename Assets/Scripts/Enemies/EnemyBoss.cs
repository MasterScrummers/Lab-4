using UnityEngine;

public class EnemyBoss : EnemyBehaviour
{
    public float timeBTW; //the time between each shot
    public GameObject bullet; //bullet object
    public Transform firePosition; //Where the bullet will spawn
    //private bool canShoot = true;  //detemine if the enemy can fire or not, based on the timeBTW variable
    //private bool playerSpotted = false; //If the raycast hit the player
    private RaycastHit2D hit;

    void FixedUpdate()
    {
        //A raycast to check if the enemy spotted the player or not
        hit = Physics2D.Raycast(firePosition.position, Vector2.up);
        
        if (hit.collider != null)
        {
            //if it hits the player
            if (hit.collider.tag == "Player")
            {
                //playerSpotted = true;
            }
            else
            {
                //playerSpotted = false;
            }
        }
    }
}
