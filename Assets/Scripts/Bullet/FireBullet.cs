using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{

    private InputController input;
    private VariableController var;
    private bool canShoot = true;
    public GameObject bullet;
    public GameObject specialBullet;
    public Transform firePosition;
    private VariableController vc;

    // Start is called before the first frame update
    void Start()
    {
        input = DoStatic.GetGameController().GetComponent<InputController>();
        vc = DoStatic.GetGameController().GetComponent<VariableController>();
    }

    // Update is called once per frame
    void Update()
    {

        //Probably could put all this in its own fire fucntion... will see how Ryan has handled fire rate
        if (input.shoot && canShoot)
        {
            StartCoroutine(FireRate());
            
        }
    }

    IEnumerator FireRate()
    {
        canShoot = false;
        if (var.blasts > 0) //If player has an upgraded bullet
        {
            GameObject new_bullet = Instantiate(bullet, firePosition.position, Quaternion.identity); //Make a new bullet
            new_bullet.transform.up = transform.up.normalized; //match y-axis of bullet to that of the player
        }

        //Press E to shoot a special Bullet
        if (input.specialShoot == true)
        {
            if (vc.blasts > 0)
            {
                GameObject new_SpecialBullet = Instantiate(specialBullet, firePosition.position, Quaternion.identity);
                new_SpecialBullet.transform.up = transform.up.normalized;
                vc.ChangeBlast(-1);
            }
        }
    }
}



