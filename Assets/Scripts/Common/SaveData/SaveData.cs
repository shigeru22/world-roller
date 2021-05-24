using System;

[Serializable]
public class SaveData
{
    /// <summary>
    /// Coins possessed.
    /// </summary>
    public int coins = 0;

    /// <summary>
    /// Powerup unlock data.
    /// </summary>
    public Powerups powerups;

    /// <summary>
    /// Stages' data.
    /// </summary>
    public StageData[] stages = new StageData[4];

    /// <summary>
    /// Options data.
    /// </summary>
    public Options options;
}