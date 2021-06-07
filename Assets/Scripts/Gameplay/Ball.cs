using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ball : MonoBehaviour
{
    public int checkpointGates;
    public GameObject finalGate;
    public GameObject spawnPoint;

    CapsuleCollider coincollector;
    Rigidbody rigid;
    float delay = 0.0f;

    void Start()
    {
        if(!GameManager.Instance.isPlaying)
        {
            GameManager.Instance.ResetScore();
            GameManager.Instance.ResetHealth();
            GameManager.Instance.ResetStock();
        }
        GameManager.Instance.ResetTimer();
        Debug.Log($"Health: {GameManager.Instance.health}, Lives: {GameManager.Instance.lives}");

        //set coin magnet
        rigid = this.GetComponent<Rigidbody>();
        coincollector = this.GetComponent<CapsuleCollider>();
        if (GameManager.Instance.getMagnetLevel() == 0)
        {
            coincollector.radius = 1f;
        }else if (GameManager.Instance.getMagnetLevel() == 1)
        {
            coincollector.radius = 2.5f;
        }else if (GameManager.Instance.getMagnetLevel() == 2)
        {
            coincollector.radius = 4.5f;
        }else if (GameManager.Instance.getMagnetLevel() == 3)
        {
            coincollector.radius = 7f;
        }

        //set zenmode
        if (GameManager.Instance.isZen)
        {
            GameManager.Instance.StopTimer();
        }

        //Set hyperspeedmode
        if (GameManager.Instance.hyperspeedMode)
        {
            Time.timeScale = 2f;
        }
    }

    private void Update()
    {
        int layerMask = 1 << 6;

        layerMask = ~layerMask;

        Debug.DrawRay(transform.position, -Vector3.up* 100f, Color.red);
        if (Physics.Raycast(transform.position + new Vector3(0,10f,0), -Vector3.up, 1000f, layerMask))
        {
            delay = 0;
            //Debug.Log("Did Hit");
        }
        else
        {
            delay += Time.deltaTime;
            if(delay > 2f)
            {
                this.transform.position = spawnPoint.transform.position;
                rigid.velocity = new Vector3(0, 0, 0);
                rigid.angularVelocity = new Vector3(0, 0, 0);
                Debug.Log(rigid.velocity);
            }
            // Debug.LogError("Did not Hit");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // TODO: add collision object check
        AudioManager.Instance.PlaySound(AudioStore.Collide);
        // if fallTime is more than 0.6 seconds, damage = fallTime^1.85
        /*
        count = false;
        float damage = Mathf.Pow(fallTime, 1.85f);
        if (fallTime > 0.6f) GameManager.Instance.DecreaseHealth(damage);
        */

        // Debug.Log($"Damage: {damage}, Remaining: {GameManager.Instance.health}");
        if(collision.gameObject.name.Contains("SteppingStone")){
            Physics.gravity = new Vector3(0, -40.0F, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(GameManager.Instance.isPlaying)
        {
            // Debug.Log(other.gameObject.name);
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
            else if (other.gameObject.CompareTag("Gate"))
            {
                // Debug.Log("Gate hit");
                Gate temp = other.GetComponent<Gate>();

                if (!temp.entered)
                {
                    temp.EnterGate();
                    GameManager.Instance.AddGate();
                    GameManager.Instance.IncreaseScore(2000);
                }
            }
            else if (other.gameObject.CompareTag("FinalGate"))
            {
                // show results
                AudioManager.Instance.PlaySound(AudioStore.Complete);
                StartCoroutine(GameManager.Instance.FinishLevel());
            }
        }
    }
}
