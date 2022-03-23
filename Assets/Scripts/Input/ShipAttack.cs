using UnityEngine;

public class ShipAttack : MonoBehaviour
{
    private InputController input; //The input controller
    private VariableController vc; //The input controller

    public float fireRate = 0.5f; //The fire rate
    private float fireTimer; //The timer for the fire rate

    private int strength = 1; //The strength of the bullet

    public GameObject[] bullets;

    // Start is called before the first frame update
    void Start()
    {
        input = DoStatic.GetGameController().GetComponent<InputController>();
        vc = input.GetComponent<VariableController>();
        fireTimer = fireRate;
    }

    void Update()
    {
        fireTimer = fireTimer - Time.deltaTime;
        if (input.shoot && fireTimer <= 0)
        {
            fireTimer = fireRate;
            Shoot();
        }

        if (input.specialShoot && vc.blasts > 0)
        {
            SpecialAttack();
            vc.ChangeBlast(-1);
        }
    }

    private void Attack(string tag, int index)
    {
        foreach (Transform child in DoStatic.GetChildren(transform))
        {
            GameObject kid = child.gameObject;
            if (!kid.activeInHierarchy && kid.CompareTag(tag))
            {
                Bullet bullet = kid.GetComponent<Bullet>();
                bullet.SetValues(strength);
                bullet.ResetValues();
                kid.SetActive(true);
                return;
            }
        }

        Instantiate(bullets[index], transform).GetComponent<Bullet>().SetValues(strength + (index == 1 ? 10 : 0));
    }

    private void Shoot()
    {
        Attack("PlayerBullet", 0);
    }

    private void SpecialAttack()
    {
        Attack("SpecialBullet", 1);
    }
}
