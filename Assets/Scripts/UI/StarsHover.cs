using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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