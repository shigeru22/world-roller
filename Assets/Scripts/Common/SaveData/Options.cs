using System;
using UnityEngine;

[Serializable]
public struct Options
{
    /// <summary>
    /// Master volume.
    /// </summary>
    public float masterVolume;

    /// <summary>
    /// BGM volume.
    /// </summary>
    public float bgmVolume;

    /// <summary>
    /// SFX volume.
    /// </summary>
    public float sfxVolume;

    /// <summary>
    /// Rotate left button.
    /// </summary>
    public KeyCode leftRotateButton;

    /// <summary>
    /// Rotate Right button.
    /// </summary>
    public KeyCode rightRotateButton;

    /// <summary>
    /// Pause button.
    /// </summary>
    public KeyCode pauseButton;
}