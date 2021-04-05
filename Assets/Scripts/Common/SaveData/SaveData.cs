using System;

[Serializable]
public class SaveData
{
    /// <summary>
    /// Stages' data.
    /// </summary>
    public StageData[] stages = new StageData[4];

    /// <summary>
    /// Options data.
    /// </summary>
    public Options options;
}