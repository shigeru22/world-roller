using UnityEngine;

public class StarsHover : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Expand()
    {
        anim.SetBool("Hover", true);
    }

    public void Shrink()
    {
        anim.SetBool("Hover", false);
    }
}