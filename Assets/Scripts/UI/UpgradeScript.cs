using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeScript : MonoBehaviour
{
    [SerializeField] Text unlockPriceText;
    [SerializeField] Text currentCoinsText;
    [SerializeField] Button yesButton;
    [SerializeField] Button noButton;

    Powerup type;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

        yesButton.onClick.AddListener(YesAction);
        noButton.onClick.AddListener(NoAction);
    }

    void YesAction()
    {
        if (type == Powerup.Button) throw new InvalidObjectException("Object must be powerup buttons, not window toggle button");

        // reduce coin, unlock powerup
        int coins = UserDataManager.Instance.data.coins;
        if (type == Powerup.Hyperspeed)
        {
            coins -= UnlockPrices.HyperspeedMode;
            UserDataManager.Instance.data.powerups.hyperspeedMode = true;
            MainMenuManager.Instance.UnlockHyperspeedMode();
        }
        else if (type == Powerup.Magnet)
        {
            coins -= UnlockPrices.MagnetMode;
            UserDataManager.Instance.data.powerups.magnetMode = true;
            MainMenuManager.Instance.UnlockMagnetMode();
        }
        else if (type == Powerup.Zen)
        {
            coins -= UnlockPrices.ZenMode;
            UserDataManager.Instance.data.powerups.zenMode = true;
            MainMenuManager.Instance.UnlockZenMode();
        }
        UserDataManager.Instance.data.coins = coins;
        UserDataManager.Instance.SaveData();

        NoAction();
    }

    void NoAction()
    {
        SetInteractable(false);
        anim.SetTrigger("Toggle");
    }

    void SetInteractable(bool target)
    {
        yesButton.interactable = target;
        noButton.interactable = target;
    }

    public void ToggleWindow(Powerup type)
    {
        if (type == Powerup.Button) throw new InvalidObjectException("Must not the toggle button");

        this.type = type;

        int price = 0;
        if (type == Powerup.Hyperspeed) price = UnlockPrices.HyperspeedMode;
        else if (type == Powerup.Magnet) price = UnlockPrices.MagnetMode;
        else if (type == Powerup.Zen) price = UnlockPrices.ZenMode;

        unlockPriceText.text = price.ToString();
        currentCoinsText.text = UserDataManager.Instance.data.coins.ToString();
        SetInteractable(true);
        if (UserDataManager.Instance.data.coins < price)
        {
            currentCoinsText.color = Color.red;
            yesButton.interactable = false;
        }
        else
        {
            currentCoinsText.color = Color.black;
            yesButton.interactable = true;
        }

        anim.SetTrigger("Toggle");
    }
}