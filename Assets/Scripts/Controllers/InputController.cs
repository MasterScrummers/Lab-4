using UnityEngine;

public class InputController : MonoBehaviour
{
    public float horizontal { get; private set; } = 0; //[a, d, left, right]
    public float vertical { get; private set; } = 0; //[w, s, up, down]
    public bool shoot { get; private set; } = false; //[space]

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        shoot = Input.GetButtonDown("Jump");
    }
}
