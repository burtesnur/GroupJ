using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class basketController : MonoBehaviour
{

    void Start()
    {
    
    }
    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided");
    }
}
