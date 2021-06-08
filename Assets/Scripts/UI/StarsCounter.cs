using UnityEngine;
using UnityEngine.UI;

public class StarsCounter : MonoBehaviour
{
    [SerializeField] Image[] stars;
    Color32 green = new Color32(26, 180, 0, 255);

    void Start()
    {
        SetEmptyColors();
    }

    void SetEmptyColors()
    {
        foreach (Image star in stars) star.color = Color.gray;
    }

    public void SetStars(int stars)
    {
        int len = this.stars.Length;
        if (stars > len) stars = len;

        for (int i = 0; i < stars; i++) this.stars[i].color = green;
    }
}