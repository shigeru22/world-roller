using UnityEngine;

public class Player : MonoBehaviour
{
    void Update()
    {
        // rotate world instead, use InputManager.Instance.horizontal and vertical later
        /*
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        this.transform.Translate(new Vector3(h, 0, v) * Time.deltaTime * 10f);
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Gate")
        {
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
