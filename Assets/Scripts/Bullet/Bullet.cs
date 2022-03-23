using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public float lifetime = 3f;
    private Lerper lerp;

    [HideInInspector] public int strength; //The damage the bullet deals.

    protected Vector3 originalScale; //The original scale.
    protected Vector3 startRot; //The starting rotation.
    protected Vector3 startPos; //The starting position of the bullet.

    private float delta; //DeltaTime

    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale;
        lerp = new Lerper();
        ResetValues();
    }

    // Update is called once per frame
    void Update()
    {
        delta = Time.deltaTime;
        lerp.Update(delta);
        transform.position = Vector3.Lerp(startPos, Vector3.zero, lerp.currentValue);
        transform.eulerAngles = startRot;
        transform.localScale = Vector3.Lerp(originalScale, Vector3.zero, lerp.currentValue);
        if (transform.localScale == Vector3.zero)
        {
            transform.localScale = Vector3.zero;
            gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Resets all the appropriate values.
    /// </summary>
    public void ResetValues()
    {
        transform.localPosition = Vector3.zero;
        startRot = transform.parent.eulerAngles;
        startPos = transform.position;
        transform.localScale = originalScale;
        lerp.SetValues(0, 1, lifetime);
    }

    /// <summary>
    /// Updates certain values according to the parameter.
    /// </summary>
    /// <param name="strength">The power of the bullet.</param>
    public void SetValues(int newStrength)
    {
        strength = newStrength;
    }

    public Transform GetShip()
    {
        return transform.parent;
    }
}
