using UnityEngine;

public class EnemyBoss : EnemyShooter
{
    public GameObject planet;

    protected override void Start()
    {
        base.Start();
    }

    protected override void DoUpdate() {
        transform.localScale = originalScale;
        transform.eulerAngles = Vector3.zero;
    }

    protected override void Shoot(bool randomDirection = false)
    {
        base.Shoot(true);
    }

    protected override void ChangeHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth <= 0)
        {
            variableController.ChangeScore(scoreWorth);
            InputController input = DoStatic.GetGameController().GetComponent<InputController>();
            input.ToggleInputLock();
            Instantiate(planet);
            gameObject.SetActive(false);
        }

    }
}
