using UnityEngine;

public class InputController : MonoBehaviour
{
    public float horizontal { get; private set; } = 0; //[a, d, left, right]
    public float vertical { get; private set; } = 0; //[w, s, up, down]
    public bool shoot { get; private set; } = false; //[space]
    public bool specialShoot { get; private set; } = false; //[E]

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        shoot = Input.GetButtonDown("Jump");
        specialShoot = Input.GetButtonDown("Special");
    }
}
