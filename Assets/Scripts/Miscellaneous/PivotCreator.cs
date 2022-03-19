using UnityEngine;

public class PivotCreator : MonoBehaviour
{
    public string pivotName = "Pivot"; //The name of the gameobject to spawn as parent.
    public Vector3 pivotPosition; //The position of the pivot gameobject
    public bool addRotationMovement = false; //Adds a component to allow the input rotation movement.

    void Start()
    {
        GameObject pivot = new GameObject(pivotName);
        pivot.transform.position = pivotPosition;
        if (addRotationMovement)
        {
            pivot.AddComponent<ShipRotationMovement>();
        }
        transform.parent = pivot.transform;
    }
}
