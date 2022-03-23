using UnityEngine;

public class EnemyBullet : EnemyBase
{
    public float extraSpeed = 1;

    /// <summary>
    /// Sets the bullet to a particular position in a particular size
    /// </summary>
    /// <param name="pos">Controls the position of the bullet</param>
    /// <param name="currentLifetime">Controls the size of the bullet</param>
    public void SetPos(Transform form, float currentLifetime, float startSpeed, bool randomDirection)
    {
        lifetime = currentLifetime;
        transform.position = form.position;
        transform.eulerAngles = randomDirection ? new Vector3(0, 0, Random.Range(0f, 360f)) : form.eulerAngles;
        currentSpeed = startSpeed + extraSpeed;
    }

    public override void ResetValues() {
        transform.localScale = Vector3.zero;
    }
}
