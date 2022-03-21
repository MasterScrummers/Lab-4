using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{

    private InputController input;
    private VariableController var;
    private bool canShoot = true;
    public GameObject bullet;
    public GameObject upgradedBullet;


    // Start is called before the first frame update
    void Start()
    {
        input = DoStatic.GetGameController().GetComponent<InputController>();
        var = DoStatic.GetGameController().GetComponent<VariableController>();
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
            GameObject newUpgradedBullet = Instantiate(upgradedBullet, transform.position, transform.rotation); //Make a new upgraded bullet
            var.blasts--;
        }
        else //Regular shot
        {
            GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation); //Make a new bullet

        }
        yield return new WaitForSeconds(2.5f); //wait 2.5 seconds between shots
        canShoot = true;
    }
}



