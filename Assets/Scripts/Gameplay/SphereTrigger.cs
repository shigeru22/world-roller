using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereTrigger : MonoBehaviour
{
    SphereCollider sc;

    void Start()
    {
        sc = GetComponent<SphereCollider>();
        if (GameManager.Instance.getMagnetLevel() == 0)
        {
            sc.radius = 1f;
        }
        else if (GameManager.Instance.getMagnetLevel() == 1)
        {
            sc.radius = 2.5f;
        }
        else if (GameManager.Instance.getMagnetLevel() == 2)
        {
            sc.radius = 4.5f;
        }
        else if (GameManager.Instance.getMagnetLevel() == 3)
        {
            sc.radius = 7f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (GameManager.Instance.isPlaying)
        {
            if (other.gameObject.CompareTag("Collectible"))
            {
                Collectibles temp = other.GetComponent<Collectibles>();
                CollectibleTypes type = temp.type;

                if (!temp.catched)
                {
                    if (type == CollectibleTypes.Coin)
                    {
                        GameManager.Instance.AddCoin();
                        GameManager.Instance.IncreaseScore(100);
                    }
                    else if (type == CollectibleTypes.Star)
                    {
                        GameManager.Instance.AddStar();
                        GameManager.Instance.IncreaseScore(1000);
                    }
                    else throw new InvalidObjectException($"{gameObject.name} triggered {other.gameObject.name} collectible");

                    temp.CatchObject();
                }
            }
        }
    }
}