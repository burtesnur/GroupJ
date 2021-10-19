using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class basketController : MonoBehaviour
{
    [Header("Switches")]
    [Tooltip("Doors that will open/close when this is hit")]
    public List<doorController> triggerDoors = new List<doorController>();

    public UnityAction onHit;
    void Start()
    {
        onHit += OnHit;
    }

    //When hit by egg
    private void OnTriggerEnter(Collider other)
    {
        onHit.Invoke();
    }

    private void OnHit()
    {
        Debug.Log("Attempt to open doors from basket");
        foreach(var door in triggerDoors)
        {
            door.activate();
        }
    }
}
