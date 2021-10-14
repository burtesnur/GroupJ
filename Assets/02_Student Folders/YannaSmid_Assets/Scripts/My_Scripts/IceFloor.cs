using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceFloor : MonoBehaviour
{
    public SlippingPlayer sPlayer;
    PlayerCharacterController playerDetected;
    public Collider TriggerZone;
    
    // Start is called before the first frame update
    void Start()
    {
       TriggerZone = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider other)
    {
        playerDetected = other.GetComponent<PlayerCharacterController>();

        if (!sPlayer.slippery)
        {
            if (playerDetected == null) return;
            //Debug.Log("It's slippery!");
            sPlayer.slippery = true;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (sPlayer.slippery)
        {
            if (playerDetected == null) return;

            //Debug.Log("Normal again");
            sPlayer.slippery = false;
        }
    }
}
