using UnityEngine;

public class FinalGate : MonoBehaviour
{
    [SerializeField] int gatesCount;
    [SerializeField] GameObject[] childItems;
    [SerializeField] ParticleSystem[] sparklers;
    MeshRenderer meshRenderer;
    MeshCollider meshCollider;

    bool shown = false;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshCollider = GetComponent<MeshCollider>();
        meshRenderer.enabled = false;
        meshCollider.enabled = false;
        foreach (GameObject child in childItems) child.SetActive(false);
    }

    void Update()
    {
        if (!shown && GameManager.Instance.gates == gatesCount)
        {
            meshRenderer.enabled = true;
            meshCollider.enabled = true;
            foreach (GameObject child in childItems) child.SetActive(true);
            foreach (ParticleSystem particle in sparklers) particle.Play();
            shown = true;
        }
    }
}