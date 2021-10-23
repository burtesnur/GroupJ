using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoor : MonoBehaviour
{
    AutomaticOpening DoorOpening;
    public Transform Doors;
    public Collider TriggerZone;
    public Transform Boss;
    
    // Start is called before the first frame update
    void Start()
    {
        DoorOpening = Doors.GetComponent<AutomaticOpening>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Boss.childCount == 0)
        {
            DoorOpening.BossFight = false;
        }
    }

    void OnTriggerEnter (Collider other)
    {
        if (!DoorOpening.BossFight)
        {
            
            Debug.Log("Baby let the games begin");
            DoorOpening.BossFight = true;
        }
    }
}