using UnityEngine;

public class VariableController : MonoBehaviour
{
    public int highScore { get; private set; } = 0; //The high score
    public int score { get; private set; } = 0; //The game score
    public int lives { get; private set; } = 4; //The life number.
    public int blasts { get; private set; } = 0; //The number of blasts remaining?

    private SaveController save; //A reference of the save file. Used for the high score.

    public int bulletDamage { get; private set; } = 1; //The damage of regular bullet from player

    public int specialBulletDamage { get; private set; } = 5; //The damage of special bullet

    public void Start()
    {
        save = GetComponent<SaveController>();
        save.Load();
        highScore = (int)save.LoadNumberVariable("High Score");
    }

    /// <summary>
    /// Should be called once at the end of a game.
    /// Checks if score is higher than highscore.
    /// If so, update save file.
    /// </summary>
    public void scoreCheck()
    {
        if (score > highScore)
        {
            save.SaveVariable("High Score", highScore);
            save.Save();
        }
    }

    /// <summary>
    /// Change the score value.
    /// </summary>
    /// <param name="amount">Can be positive or negative.</param>
    public void ChangeScore(int amount)
    {
        score += amount;
    }

    /// <summary>
    /// Change the blasts value.
    /// </summary>
    /// <param name="amount">Can be positive or negative.</param>
    public void ChangeBlast(int amount)
    {
        blasts += amount;
    }

    /// <summary>
    /// Resets the score value to 0.
    /// </summary>
    public void ResetScore()
    {
        score = 0;
    }

    /// <summary>
    /// Decreases the life value by one.
    /// </summary>
    /// <returns>Life value after being decremented.</returns>
    public int DecrementLife()
    {
        return --lives;
    }

    public void ResetLife()
    {
        lives = 4;
    }

    /// <summary>
    /// Set the damage for regular bullet from player
    /// </summary>
    public void SetBulletDamage(int damage)
    {
        bulletDamage = damage;
    }
}
