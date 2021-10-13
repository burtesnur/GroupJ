using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class doorController : MonoBehaviour
{
    Animator anim;

    [Header("Settings")]
    [Tooltip("Color of door, Represents group that will trigger with same trigger?")]
    public Color doorColor;
    [Tooltip("If door starts in open position or not")]
    public bool isOpen = false;

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        if (isOpen)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
