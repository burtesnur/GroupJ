using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoorReenter : MonoBehaviour
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
        if (DoorOpening.BossFight)
        {
            Debug.Log("Backtrack");
            DoorOpening.BossFight = false;
        }
    }
}
