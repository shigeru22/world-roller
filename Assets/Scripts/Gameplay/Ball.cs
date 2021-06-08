using UnityEngine;

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
        if (!GameManager.Instance.isPlaying)
        {
            GameManager.Instance.ResetScore();
            GameManager.Instance.ResetHealth();
            GameManager.Instance.ResetStock();
        }
        GameManager.Instance.ResetTimer();

        //set coin magnet
        rigid = this.GetComponent<Rigidbody>();
        coincollector = this.GetComponent<CapsuleCollider>();
        if (GameManager.Instance.getMagnetLevel() == 0)
        {
            coincollector.radius = 1f;
        }
        else if (GameManager.Instance.getMagnetLevel() == 1)
        {
            coincollector.radius = 2.5f;
        }
        else if (GameManager.Instance.getMagnetLevel() == 2)
        {
            coincollector.radius = 4.5f;
        }
        else if (GameManager.Instance.getMagnetLevel() == 3)
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

        Debug.DrawRay(transform.position, -Vector3.up * 100f, Color.red);
        if (Physics.Raycast(transform.position + new Vector3(0, 10f, 0), -Vector3.up, 1000f, layerMask))
        {
            delay = 0;
        }
        else
        {
            delay += Time.deltaTime;
            if (delay > 2f)
            {
                this.transform.position = spawnPoint.transform.position;
                rigid.velocity = new Vector3(0, 0, 0);
                rigid.angularVelocity = new Vector3(0, 0, 0);
                Debug.Log(rigid.velocity);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        AudioManager.Instance.PlaySound(AudioStore.Collide);

        if (collision.gameObject.name.Contains("SteppingStone"))
        {
            Physics.gravity = new Vector3(0, -40.0F, 0);
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
            else if (other.gameObject.CompareTag("Gate"))
            {
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
                AudioManager.Instance.PlaySound(AudioStore.Complete);
                StartCoroutine(GameManager.Instance.FinishLevel());
            }
        }
    }
}
