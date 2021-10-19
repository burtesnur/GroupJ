using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class birbController : MonoBehaviour { 

    Animator idle;

    // Start is called before the first frame update
    void Start()
    {
        idle = GetComponent<Animator>();
    }

}
