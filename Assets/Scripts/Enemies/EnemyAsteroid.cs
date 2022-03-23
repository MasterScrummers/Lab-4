using UnityEngine;

[RequireComponent(typeof(Rotate))]
public class EnemyAsteroid : EnemyBehaviour
{
    private Rotate spriteRot; //The Rotate component for the sprite.
    public float spriteRotationSpeed = 1; //The rotation speed of the sprite.

    protected override void Start()
    {
        spriteRot = GetComponent<Rotate>();
        base.Start();
    }

    protected override void DoUpdate()
    {
        GetPivot().Translate(new Vector3(0, delta, 0));
        transform.localScale = originalScale * (lifetime += delta * 0.6f);
        currentSpeed += delta;
    }

    public override void ResetValues()
    {
        base.ResetValues();
        GetPivot().position = Vector3.zero;
        transform.localPosition = Vector3.zero;
        GetPivot().eulerAngles = new Vector3(0, 0, Random.Range(0, 360f));

        float spriteRotSpeed = Random.Range(-spriteRotationSpeed, spriteRotationSpeed);
        spriteRot.rotationSpeed = new Vector3(0, 0, spriteRotSpeed);
    }

    private Transform GetPivot()
    {
        return pivotCreator.pivot.transform;
    }
}
