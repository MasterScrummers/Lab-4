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
        
        if (input.shoot == true)
        {
            //Debug.Log("bullet");
            //Instantiate(bullet, transform.position, transform.rotation, transform);
            GameObject new_bullet = Instantiate(bullet, transform.position, Quaternion.identity);
            //rotate the bullet as the gameobject
            new_bullet.transform.up = transform.up.normalized;
        }
    }
}
