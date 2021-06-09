using UnityEngine;

public class Ball : MonoBehaviour
{
    public int checkpointGates;
    public GameObject finalGate;
    public GameObject spawnPoint;

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
        if (other.gameObject.CompareTag("Gate"))
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
