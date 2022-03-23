using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PivotCreator))]
public class EnemyBehaviour : MonoBehaviour
{
    public int maxHealth { get; private set; } = 1; //The starting number of hits before it dies.
    public int scoreWorth = 100; //The enemy's given score when destroyed.
    public float speed = 1; //The speed of the enemy
    public float rotationSpeed = 1; //The rotation speed range between 0 and value. Cannot be negative.

    protected int currentHealth; //The current health of the enemy
    protected float currentSpeed; //The current speed of the enemy
    protected VariableController variableController; //To add to the score.
    protected Vector3 originalScale; //The original scale.
    protected float lifetime; //The age of the gameobject. The older, the larger.
    protected PivotCreator pivotCreator; //Adds a pivot to the origin.
    protected Rotate rot; //The natural rotation of the enemy.
    private Collider2D collider;
    private SpriteRenderer sprite;

    protected virtual void Start()
    {
        originalScale = transform.localScale;
        variableController = DoStatic.GetGameController().GetComponent<VariableController>();
        pivotCreator = GetComponent<PivotCreator>();
        GetRot();
        Reset();
        collider = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    protected virtual void GetRot()
    {
        rot = pivotCreator.pivot.gameObject.AddComponent<Rotate>();
    }

    void Update()
    {
        float delta = currentSpeed * Time.deltaTime;
        Movement(delta);
        transform.localScale = originalScale * (lifetime += delta * 0.6f);
        currentSpeed += delta;

        bool hasPassed = transform.localScale.x < 2.5;
        collider.enabled = hasPassed;
        sprite.sortingOrder = hasPassed ? 0 : 2;
    }

    protected virtual void Movement(float delta)
    {
        transform.Translate(new Vector3(0, delta, 0));
    }

    /// <summary>
    /// Should be called once when respawning.
    /// </summary>
    public virtual void Reset()
    {
        ResetPos();
        transform.localScale = Vector3.zero;
        lifetime = 0;
        currentHealth = maxHealth;
        currentSpeed = speed;
        float rotSpeed = Random.Range(0, rotationSpeed);
        rot.rotationSpeed = new Vector3(0, 0, DoStatic.RandomBool() ? rotSpeed : -rotSpeed);
    }

    protected virtual void ResetPos()
    {
        transform.position = Vector3.zero;
        transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360f));
    }

    /// <summary>
    /// When all cameras cannot see this gameobject, this procedure is called.
    /// All cameras INCLUDING SCENE VIEW CAMERA. It's a pain, I know.
    /// </summary>
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Change the health by amount.
    /// </summary>
    /// <param name="amount">Can be positive or negative.</param>
    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth <= 0)
        {
            variableController.ChangeScore(scoreWorth);
            gameObject.SetActive(false);
        }
    }
}
