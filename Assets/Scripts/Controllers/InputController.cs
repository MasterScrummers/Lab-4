using UnityEngine;

public class InputController : MonoBehaviour
{
    public float horizontal { get; private set; } = 0; //[a, d, left, right]
    public float vertical { get; private set; } = 0; //[w, s, up, down]
    public bool shoot { get; private set; } = false; //[space]
    public bool specialShoot { get; private set; } = false; //[E]

    public bool inputLock = false;

    void Update()
    {
        if (inputLock)
        {
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        shoot = Input.GetButtonDown("Jump");
        specialShoot = Input.GetButtonDown("Special");
    }

    public void ToggleInputLock()
    {
        inputLock = !inputLock;
        if (inputLock)
        {
            horizontal = 0;
            vertical = 0;
            shoot = false;
            specialShoot = false;
        }
    }
}
