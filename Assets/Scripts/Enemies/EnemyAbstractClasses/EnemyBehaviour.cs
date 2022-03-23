using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PivotCreator))]
public abstract class EnemyBehaviour : EnemyBase
{
    public int maxHealth = 1; //The starting number of hits before it dies.
    public int scoreWorth = 100; //The enemy's given score when destroyed.
    public float pivotRotationSpeed = 0.03f; //The rotation speed range between 0 and value. Cannot be negative.

    protected int currentHealth; //The current health of the enemy

    protected PivotCreator pivotCreator; //Adds a pivot to the origin.
    protected Rotate rot; //The natural rotation of the enemy.

    protected override void Start()
    {
        pivotCreator = GetComponent<PivotCreator>();
        rot = pivotCreator.pivot.gameObject.AddComponent<Rotate>();
        base.Start();
    }

    /// <summary>
    /// Should be called once when respawning.
    /// </summary>
    public override void ResetValues()
    {
        base.ResetValues();
        transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360f));
        currentHealth = maxHealth;
        float rotSpeed = Random.Range(-pivotRotationSpeed, pivotRotationSpeed);
        rot.rotationSpeed = new Vector3(0, 0, rotSpeed);
    }

    /// <summary>
    /// Change the health by amount.
    /// </summary>
    /// <param name="amount">Can be positive or negative.</param>
    protected virtual void ChangeHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth <= 0)
        {
            variableController.ChangeScore(scoreWorth);
            gameObject.SetActive(false);
        }
    }

    protected override void DoCollision(Collider2D collision)
    {
        base.DoCollision(collision);
        if (collision.CompareTag("PlayerBullet") || collision.CompareTag("SpecialBullet"))
        {
            Bullet bullet = collision.GetComponent<Bullet>();
            ChangeHealth(-bullet.strength);
            bullet.gameObject.SetActive(false);
        }
    }
}
