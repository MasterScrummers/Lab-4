using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{

    private InputController input;
    private VariableController vc;
    private bool canShoot = true;
    public GameObject bullet;
    public GameObject specialBullet;
    public Transform firePosition;

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

        if (input.specialShoot && canShoot && vc.blasts>0)
        {
            StartCoroutine(SpecialFireRate());
        }


    }

    IEnumerator FireRate()
    {
        canShoot = false;
        GameObject new_bullet = Instantiate(bullet, firePosition.position, Quaternion.identity); //Make a new bullet
        new_bullet.transform.up = transform.up.normalized; //match y-axis of bullet to that of the player

        yield return new WaitForSeconds(0.5f); //wait 2.5 seconds between shots
        canShoot = true;
    }


    IEnumerator SpecialFireRate()
    {
        canShoot = false;
        GameObject new_SpecialBullet = Instantiate(specialBullet, firePosition.position, Quaternion.identity);
        new_SpecialBullet.transform.up = transform.up.normalized;
        vc.ChangeBlast(-1);
           
        yield return new WaitForSeconds(0.5f); //wait 2.5 seconds between shots
        canShoot = true;
        Debug.Log(canShoot);
    }
}



