using System;

[Serializable]
public struct StageData
{
    public int score;
    public int stars
    {
        get { return stars; }
        set
        {
            stars = value;
            if (stars > 3) stars = 3;
        }
    }
    public int coins;
}