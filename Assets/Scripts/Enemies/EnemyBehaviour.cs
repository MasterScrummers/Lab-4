using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyBehaviour : MonoBehaviour
{
    public int maxHealth { get; private set; } = 1; //The starting number of hits before it dies.
    public int scoreWorth = 100; //The enemy's given score when destroyed.
    public float speed = 20; //The speed of the enemy
    
    private int currentHealth; //The current health of the enemy
    private VariableController variableController; //To add to the score.
    private Vector3 originalScale; //The original scale.
    private float lifetime;

    protected virtual void Start()
    {
        originalScale = transform.localScale;
        variableController = DoStatic.GetGameController().GetComponent<VariableController>();
        Reset();
    }

    protected virtual void Update()
    {
        float delta = Time.deltaTime;
        transform.Translate(new Vector3(0, speed * delta, 0));
        transform.localScale = originalScale * (lifetime += delta / 2);
    }

    /// <summary>
    /// Should be called once when respawning.
    /// </summary>
    public virtual void Reset()
    {
        transform.position = Vector3.zero;
        transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360f));
        transform.localScale = Vector3.zero;
        lifetime = 0;
        currentHealth = maxHealth;
    }

    /// <summary>
    /// When all cameras cannot see this gameobject, this procedure is called.
    /// All cameras INCLUDING SCENE VIEW CAMERA. It's a pain, I know.
    /// </summary>
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    private void ChangeHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth <= 0)
        {
            variableController.ChangeScore(scoreWorth);
            gameObject.SetActive(false);
        }
    }
}
