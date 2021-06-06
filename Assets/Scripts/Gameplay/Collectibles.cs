using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    [SerializeField] CollectibleTypes collectibleType;
    [SerializeField] AudioSource sfx;
    private bool _catched;
    Animator anim;

    /// <summary>
    /// Returns collectible type.
    /// </summary>
    public CollectibleTypes type {  get { return collectibleType; } }

    /// <summary>
    /// Returns catched status.
    /// </summary>
    public bool catched { get { return _catched; } }

    void Start()
    {
        anim = GetComponent<Animator>();
        _catched = false;
    }

    void Update()
    {
        if (catched)
        {
            if (type == CollectibleTypes.Coin) transform.Translate(Vector3.up * Time.deltaTime * 15f);
            else if (type == CollectibleTypes.Star) transform.Translate(Vector3.back * Time.deltaTime * 15f);
        }
    }

    /// <summary>
    /// Marks the collectible as catched.
    /// </summary>
    public void CatchObject()
    {
        _catched = true;
        anim.SetBool("Catched", true);
        sfx.Play();
    }

    void Disappear()
    {
        Destroy(gameObject);
    }
}
