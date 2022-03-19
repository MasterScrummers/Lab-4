using UnityEngine;

public class ShipRotationMovement : MonoBehaviour
{
    private InputController input;
    public float rotationSpeed = 1;

    void Start()
    {
        input = DoStatic.GetGameController().GetComponent<InputController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed * input.horizontal) * 360 * Time.deltaTime);
    }
}
