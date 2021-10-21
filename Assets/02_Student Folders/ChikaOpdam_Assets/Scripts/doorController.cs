using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class doorController : MonoBehaviour
{

    Animator anim;

    [Header("Settings")]
    [Tooltip("If door starts in open position or not")]
    public bool isOpen = false;

    [Header("Sounds")]
    [Tooltip("Sound played when opening and closing door")]
    public AudioClip openSFX;

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();

        if (isOpen)
        {
            anim.SetTrigger("ToggleHit");
        }
    }


    public void activate()
    {
        anim.SetTrigger("ToggleHit");
    }
}
