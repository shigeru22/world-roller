using UnityEngine;

public class Lift : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lift")
        {
            other.GetComponent<Animator>().SetBool("Up", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Lift")
        {
            other.GetComponent<Animator>().SetBool("Up", false);
        }
    }
}
