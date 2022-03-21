using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{

    private InputController input;
    private bool canShoot = true;
    private Vector3 bulletVariance = new Vector3(0.2f, 0f, 0f);
    public bool upgradeShot = true;
    public GameObject bullet;
    public GameObject upgradedBullet;


    // Start is called before the first frame update
    void Start()
    {
        input = DoStatic.GetGameController().GetComponent<InputController>();
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
        /*if (upgradeShot)
        {
            GameObject newUpgradedBullet = Instantiate(upgradedBullet, transform.position, transform.rotation); //Make a new upgraded bullet
           
            upgradeShot = false;
        }
        else*/
        {
            GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation); //Make a new bullet

        }
        yield return new WaitForSeconds(2.5f); //wait 2.5 seconds between shots
        canShoot = true;
    }
}



