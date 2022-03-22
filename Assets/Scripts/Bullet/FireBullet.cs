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
    public GameObject dualBullet;
    public Transform firePosition;
    public bool satBuff = false; //Dual bullet buff activated upon destroying satellite


    // Start is called before the first frame update
    void Start()
    {
        input = DoStatic.GetGameController().GetComponent<InputController>();
        vc = DoStatic.GetGameController().GetComponent<VariableController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Firing regular bullet and dual bullet
        if (input.shoot && canShoot)
        {
            StartCoroutine(FireRate());    
        }

        //Speical Bullet
        if (input.specialShoot && canShoot && vc.blasts>0)
        {
            StartCoroutine(SpecialFireRate());
        }

        //Start buff timer
        if (satBuff)
        {
            StartCoroutine(SatelliteBuff());
        }


    }

    IEnumerator FireRate()
    {
        canShoot = false;
        //If not buffed to dual
        if (!satBuff)
        {
            GameObject new_bullet = Instantiate(bullet, firePosition.position, Quaternion.identity); //Make a new bullet
            new_bullet.transform.up = transform.up.normalized; //match y-axis of bullet to that of the player
        }
        //if buffed
        else
        {
            GameObject new_bullet = Instantiate(dualBullet, firePosition.position, Quaternion.identity); //Make a new dual bullet
            new_bullet.transform.up = transform.up.normalized; //match y-axis of bullet to that of the player
        }


        yield return new WaitForSecondsRealtime(0.5f); //wait 0.5 seconds between shots
        canShoot = true;
    }

    //Special bullet with "E" key
    IEnumerator SpecialFireRate()
    {
        canShoot = false;
        GameObject new_SpecialBullet = Instantiate(specialBullet, firePosition.position, Quaternion.identity);
        new_SpecialBullet.transform.up = transform.up.normalized;
        vc.ChangeBlast(-1);
           
        yield return new WaitForSecondsRealtime(0.5f); //wait 0.5 seconds between shots
        canShoot = true;
        Debug.Log(canShoot);
    }

    //Buff timer
    IEnumerator SatelliteBuff()
    {

        yield return new WaitForSecondsRealtime(10.0f); //wait 10 seconds then debuff
        satBuff = false;
    }


}



