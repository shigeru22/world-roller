using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unblocker : MonoBehaviour
{
    public void Unblock()
    {
        OverlayManager.Instance.blocked = false;
    }
}