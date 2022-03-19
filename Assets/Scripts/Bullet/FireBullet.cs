using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{

    private InputController input;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        input = DoStatic.GetGameController().GetComponent<InputController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //Probably could put all this in its own fire fucntion... will see how Ryan has handled fire rate
        if (input.shoot == true)
        {
            GameObject new_bullet = Instantiate(bullet, transform.position, Quaternion.identity); //Make a new bullet
            new_bullet.transform.up = transform.up.normalized; //match y-axis of bullet to that of the player
        }
    }
}
