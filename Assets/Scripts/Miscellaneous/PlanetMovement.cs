using UnityEngine;

public class PlanetMovement : MonoBehaviour
{
    public Vector3 start; //Start position
    public Vector3 dest; //Destination
    public float lerpSpeed = 3;
    public Lerper lerp;

    private void Start()
    {
        lerp = new Lerper();
        lerp.SetValues(0, 1, lerpSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        lerp.Update(Time.deltaTime);
        transform.position = Vector3.Lerp(start, dest, lerp.currentValue);

        if (!lerp.isLerping)
        {
            DoStatic.GetGameController().GetComponent<SceneController>().ChangeScene("MainMenu", "FadeLoss");
            Destroy(this);
        }
    }
}
