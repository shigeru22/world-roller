using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupButton : MonoBehaviour
{
    [SerializeField] Powerup type;
    [SerializeField] Image lockedPowerup;
    Image background;

    public Powerup powerupType { get { return type; } }
    bool locked = true;

    void Start()
    {
        background = GetComponent<Image>();
        GetComponent<Button>().onClick.AddListener(PowerupAction);
    }

    void PowerupAction()
    {
        if(type == Powerup.Button)
        {
            MainMenuManager.Instance.TogglePowerup();
            return;
        }

        if(!locked)
        {
            bool status = false;

            switch (type)
            {
                case Powerup.Hyperspeed:
                    status = GameManager.Instance.hyperspeedMode;
                    if (!status) GameManager.Instance.SetHyperspeedMode(true);
                    else GameManager.Instance.SetHyperspeedMode(false);
                    break;
                case Powerup.Magnet:
                    status = GameManager.Instance.isMagnet;
                    if (!status) GameManager.Instance.magnetManaget(true);
                    else GameManager.Instance.magnetManaget(false);
                    break;
                case Powerup.Zen:
                    status = GameManager.Instance.isZen;
                    if (!status) GameManager.Instance.invulnManager(true);
                    else GameManager.Instance.invulnManager(false);
                    break;
            }

            Color color = background.color;
            if (!status)
            {
                color.r = Color.yellow.r;
                color.g = Color.yellow.g;
                color.b = Color.yellow.b;
            }
            else
            {
                color.r = Color.white.r;
                color.g = Color.white.g;
                color.b = Color.white.b;
            }
            background.color = color;
        }
        else MainMenuManager.Instance.UnlockPowerupWindow(type);
    }

    public void UnlockPowerup()
    {
        if (type == Powerup.Button) throw new InvalidObjectException("Object must be powerup buttons, not window toggle button");

        locked = false;
        lockedPowerup.GetComponent<Image>().enabled = false;
    }
}