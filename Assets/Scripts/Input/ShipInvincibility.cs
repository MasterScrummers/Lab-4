using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class ShipInvincibility : MonoBehaviour
{
    private VariableController variableController; //To have access to lives.
    private SpriteRenderer sprite; //The sprite.
    private Collider2D col; //The collider of the ship.
    public float iFrames = 2; //The length of time of invincibility
    private float itimer; //The timer for the invincibiliy
    private int prevLives; //The previous amount of lives.

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        variableController = DoStatic.GetGameController().GetComponent<VariableController>();
        prevLives = variableController.lives;
    }

    void Update()
    {
        if (prevLives != variableController.lives)
        {
            prevLives = variableController.lives;
            itimer = iFrames;
        }

        col.enabled = itimer <= 0;
        if (col.enabled)
        {
            sprite.enabled = true;
            return;
        }

        col.enabled = false;
        sprite.enabled = !sprite.enabled;
        itimer -= Time.deltaTime;
    }
}
