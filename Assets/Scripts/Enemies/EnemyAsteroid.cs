using UnityEngine;

[RequireComponent(typeof(Rotate))]
public class EnemyAsteroid : EnemyBehaviour
{
    protected override void GetRot()
    {
        rot = GetComponent<Rotate>();
    }

    protected override void Movement(float delta)
    {
        GetPivot().Translate(new Vector3(0, delta, 0));
    }

    protected override void ResetPos()
    {
        GetPivot().position = Vector3.zero;
        GetPivot().eulerAngles = new Vector3(0, 0, Random.Range(0, 360f));
    }

    private Transform GetPivot()
    {
        return pivotCreator.pivot.transform;
    }
}
