using UnityEngine;

public class Unblocker : MonoBehaviour
{
    public void Unblock()
    {
        OverlayManager.Instance.blocked = false;
    }
}