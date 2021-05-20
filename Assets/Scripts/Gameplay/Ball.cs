using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ball : MonoBehaviour
{
    float fallTime;
    bool count;
    public int checkpointGates;
    int gateCrossed = 0;
    public GameObject finalGate;
    public GameObject spawnPoint;

    CapsuleCollider coincollector;
    Rigidbody rigid;
    float delay = 0.0f;

    void Start()
    {
        fallTime = 0f;
        count = false;

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

    void FixedUpdate()
    {
        if (count) fallTime += Time.fixedDeltaTime;
    }

    private void Update()
    {
        /*if (gateCrossed == checkpointGates)
        {
            Instantiate(finalGate, new Vector3 (1,1.8f,14), Quaternion.Euler(-90,0,0));
            gateCrossed = 0;
        }*/

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
            }
            Debug.LogError("Did not Hit");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // TODO: add collision object check

        // if fallTime is more than 0.6 seconds, damage = fallTime^1.85
        count = false;
        float damage = Mathf.Pow(fallTime, 1.85f);
        if (fallTime > 0.6f) GameManager.Instance.DecreaseHealth(damage);

        // Debug.Log($"Damage: {damage}, Remaining: {GameManager.Instance.health}");
    }

    void OnCollisionExit(Collision collision)
    {
        fallTime = 0;
        count = true;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if(other.gameObject.tag.Equals("Collectible"))
        {
            Collectibles temp = other.GetComponent<Collectibles>();
            CollectibleTypes type = temp.type;

            if(!temp.catched)
            {
                if (type == CollectibleTypes.Coin) GameManager.Instance.AddCoin();
                else if (type == CollectibleTypes.Star) GameManager.Instance.AddStar();
                else throw new InvalidObjectException($"{gameObject.name} triggered {other.gameObject.name} collectible");

                temp.CatchObject();
            }
        }
        else if (other.gameObject.tag.Equals("Gate"))
        {
            Debug.Log("Gate hit");
            other.GetComponent<BoxCollider>().enabled = false;
            GameManager.Instance.AddGate();
            gateCrossed++;
        }
        else if(other.gameObject.tag.Equals("FinalGate"))
        {
            // show results
            StartCoroutine(GameManager.Instance.FinishLevel());
        }
    }
}
