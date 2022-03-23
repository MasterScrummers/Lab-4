using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public abstract class EnemyBase : MonoBehaviour
{
    public float speed = 1; //The speed of the enemy
    protected float currentSpeed; //The current speed of the enemy
    protected VariableController variableController; //To add to the score.
    protected Vector3 originalScale; //The original scale.
    protected float lifetime; //The age of the gameobject. The older, the larger.
    protected Collider2D col; //The collider of the enemy
    protected SpriteRenderer sprite; //The sprite of the enemy
    
    protected float delta; //DeltaTime

    protected virtual void Start()
    {
        col = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
        originalScale = transform.localScale;
        variableController = DoStatic.GetGameController().GetComponent<VariableController>();
        ResetValues();
    }

    public virtual void ResetValues()
    {
        transform.position = Vector3.zero;
        transform.localScale = Vector3.zero;
        lifetime = 0;
        currentSpeed = speed;
    }

    protected virtual void Update()
    {
        delta = currentSpeed * Time.deltaTime;
        DoUpdate();
        ColliderCheck();
    }

    protected virtual void DoUpdate()
    {
        transform.Translate(new Vector3(0, delta, 0));
        transform.localScale = originalScale * (lifetime += delta * 0.6f);
        currentSpeed += delta;
    }

    protected virtual void ColliderCheck()
    {
        bool hasPassed = transform.localScale.x < 2.5;
        col.enabled = hasPassed;
        sprite.sortingOrder = hasPassed ? 0 : 2;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DoCollision(collision);
    }

    protected virtual void DoCollision(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            variableController.DecrementLife();
            gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// When all cameras cannot see this gameobject, this procedure is called.
    /// All cameras INCLUDING SCENE VIEW CAMERA. It's a pain, I know.
    /// </summary>
    private void OnBecameInvisible()
    {
        transform.localScale = Vector3.zero;
        gameObject.SetActive(false);
    }
}
