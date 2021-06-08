using UnityEngine;
using UnityEngine.UI;

public class GameOverlay : MonoBehaviour
{
    [SerializeField] Text timeSeconds;
    [SerializeField] Text miliSeconds;
    [SerializeField] Text coinCounter;
    [SerializeField] Text starCounter;
    [SerializeField] GameObject hyperspeedMode;

    // [SerializeField] Transform coinUIObject;
    // [SerializeField] Transform starUIObject;

    [SerializeField] Vector3 coinRelativeToCamera;
    [SerializeField] Vector3 starRelativeToCamera;

    void Start()
    {
        // if (!GameManager.Instance.hyperspeedMode) hyperspeedMode.SetActive(false);
        GetComponent<Canvas>().worldCamera = Camera.main;

        // set as its parent
        // coinUIObject.parent = Camera.main.transform;
        // starUIObject.parent = Camera.main.transform;

        // set position relative to its parent
        // coinUIObject.localPosition = coinRelativeToCamera;
        // starUIObject.localPosition = starRelativeToCamera;
    }

    void Update()
    {
        int seconds = (int)Mathf.Floor(GameManager.Instance.timer);
        int miliseconds = (int)Mathf.Floor((GameManager.Instance.timer * 10f) % 10f);

        timeSeconds.text = seconds.ToString();
        miliSeconds.text = miliseconds.ToString();
        coinCounter.text = GameManager.Instance.coins.ToString();
        starCounter.text = GameManager.Instance.stars.ToString();
    }
}
