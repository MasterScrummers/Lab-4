using UnityEngine;

public class EnemyShooter : EnemyBehaviour
{
    public GameObject EnemyBullet;
    private Transform AllEnemyBullets;
    public float shootingInterval = 2f; //How often does the enemy shoot.
    protected float shootTimer;

    protected override void Start()
    {
        shootingInterval = shootingInterval < 0.5f ? 0.5f : shootingInterval;
        shootTimer = Random.Range(0.5f, shootingInterval);
        base.Start();
        AllEnemyBullets = GameObject.FindGameObjectWithTag("EnemyBullets").transform;
    }

    protected override void Update()
    {
        float delta = currentSpeed * Time.deltaTime;
        base.Update();
        if (col.enabled && (shootTimer -= delta) <= 0) {
            Shoot();
            shootTimer = Random.Range(0.5f, shootingInterval);
        }
    }

    protected virtual void Shoot(bool randomDirection = false)
    {
        if (!EnemyBullet)
        {
            return;
        }

        GameObject bull;
        foreach (Transform bullet in DoStatic.GetChildren(AllEnemyBullets))
        {
            bull = bullet.gameObject;
            if (!bull.activeInHierarchy)
            {
                bull.GetComponent<EnemyBullet>().SetPos(transform, lifetime, currentSpeed, randomDirection);
                bull.SetActive(true);
                return;
            }
        }

        bull = Instantiate(EnemyBullet, AllEnemyBullets);
        EnemyBullet let = bull.GetComponent<EnemyBullet>();
        let.SetPos(transform, lifetime, currentSpeed, randomDirection);
    }
}
