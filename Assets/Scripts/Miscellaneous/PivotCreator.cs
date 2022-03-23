using UnityEngine;

public class PivotCreator : MonoBehaviour
{
    public string pivotName = "Pivot"; //The name of the gameobject to spawn as parent.
    public string pivotParentTagName = "StartUp";
    public Vector3 pivotPosition; //The position of the pivot gameobject
    public bool addRotationMovement = false; //Adds a component to allow the input rotation movement.
    public GameObject pivot { get; private set; }

    void Awake()
    {
        pivot = new GameObject(pivotName);
        DoStatic.MoveGameObjectToScene(pivot, gameObject.scene);
        pivot.transform.position = pivotPosition;
        if (addRotationMovement)
        {
            pivot.AddComponent<ShipRotationMovement>();
        }
        transform.parent = pivot.transform;
        pivot.transform.parent = GameObject.FindGameObjectWithTag(pivotParentTagName).transform;
    }
}
