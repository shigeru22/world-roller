using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusScript : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ToggleFailed()
    {
        anim.SetTrigger("Failed");
    }

    public void ToggleFinish()
    {
        anim.SetTrigger("Finish");
    }
}