using System;

[Serializable]
public struct StageData
{
    /// <summary>
    /// Whether the stage has been cleared.
    /// </summary>
    public bool cleared;

    /// <summary>
    /// Stage's high score.
    /// </summary>
    public int score;

    /// <summary>
    /// Stage's collected stars count.
    /// </summary>
    public int stars;

    /// <summary>
    /// Stage's collected coins count.
    /// </summary>
    public int coins;
}