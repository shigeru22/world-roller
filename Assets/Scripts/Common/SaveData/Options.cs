using System;
using UnityEngine;

[Serializable]
public struct Options
{
    public float masterVolume;
    public float bgmVolume;
    public float sfxVolume;

    public KeyCode leftRotateButton;
    public KeyCode rightRotateButton;
}