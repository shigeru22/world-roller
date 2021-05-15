using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unblocker : MonoBehaviour
{
    public void Unblock()
    {
        PauseManager.Instance.blocked = false;
    }
}