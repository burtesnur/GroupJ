using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoor : MonoBehaviour
{
    AutomaticOpening DoorOpening;
    public Transform Doors;
    public Collider TriggerZone;
    
    // Start is called before the first frame update
    void Start()
    {
        DoorOpening = Doors.GetComponent<AutomaticOpening>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter (Collider other)
    {
        if (!DoorOpening.BossFight && DoorOpening.isClosed)
        {
            DoorOpening.BossFight = true;
        }
    }
}