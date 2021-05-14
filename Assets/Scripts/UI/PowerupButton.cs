using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupButton : MonoBehaviour
{
    [SerializeField] Powerup type;
    Image background;

    void Start()
    {
        background = GetComponent<Image>();
        GetComponent<Button>().onClick.AddListener(PowerupAction);
    }

    void PowerupAction()
    {
        bool status = false;
        bool powerup = false;

        switch(type)
        {
            case Powerup.Button:
                MainMenuManager.Instance.TogglePowerup();
                return;
            case Powerup.Hyperspeed:
                powerup = true;
                status = GameManager.Instance.hyperspeedMode;
                if (!status) GameManager.Instance.SetHyperspeedMode(true);
                else GameManager.Instance.SetHyperspeedMode(false);
                break;
            case Powerup.Magnet:
                powerup = true;
                status = GameManager.Instance.isMagnet;
                if (!status) GameManager.Instance.magnetManaget(true);
                else GameManager.Instance.magnetManaget(false);
                break;
            case Powerup.Zen:
                powerup = true;
                status = GameManager.Instance.isInvuln;
                if (!status) GameManager.Instance.invulnManager(true);
                else GameManager.Instance.invulnManager(false);
                break;
        }

        if(powerup)
        {
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
    }
}